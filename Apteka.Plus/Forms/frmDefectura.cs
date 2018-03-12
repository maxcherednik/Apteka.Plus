using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Properties;
using Apteka.Plus.UserControls;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using log4net;
using Microsoft.Reporting.WinForms;

namespace Apteka.Plus.Forms
{
    public partial class frmDefectura : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmDefectura()
        {
            InitializeComponent();
        }

        private MyStore _selectedStore;

        private List<SmartDefectRow> _liSmartDefectRowsFullList;

        private List<SmartDefectRow> _liSmartDefectRowsFullListWithoutExcludeRows;

        private List<SmartDefectRow> _liSmartDefectRowsListUnclassified;

        private List<DefectList> _liDefectLists;

        private List<DefectList> _liExcludeLists;

        private List<DefectList> _liSmartLists;

        private void frmDefectura_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        private void frmDefectura_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = Settings.Default.DefectSplitterDistance;
        }

        private List<SmartDefectRow> ApplyFilterForDefectList(List<SmartDefectRow> liSmartDefectRows, IEnumerable<DefectListCriteria> liCriteria)
        {
            var liSmartDefectRowsSorted = new List<SmartDefectRow>();

            foreach (var criteria in liCriteria)
            {
                var liSmartDefectRowsPartial = liSmartDefectRows.FindAll(row => row.Supplier.Name.ToLower().Contains(criteria.SearchValue.ToLower()));
                liSmartDefectRowsSorted.AddRange(liSmartDefectRowsPartial);
            }

            foreach (var row in liSmartDefectRowsSorted)
            {
                _liSmartDefectRowsListUnclassified.Remove(row);
            }

            return liSmartDefectRowsSorted;
        }

        private List<SmartDefectRow> ApplyExcludeFilterForDefectList(List<SmartDefectRow> liSmartDefectRowsFullList, IEnumerable<DefectExceptionRow> liDefectExceptions)
        {
            var liSmartDefectRowsSorted = new List<SmartDefectRow>();

            foreach (var defectExceptionRow in liDefectExceptions)
            {
                var liSmartDefectRowsPartial = liSmartDefectRowsFullList.FindAll(row => row.FullProductInfo.ID == defectExceptionRow.FullProductInfoID);
                liSmartDefectRowsSorted.AddRange(liSmartDefectRowsPartial);
            }

            foreach (var row in liSmartDefectRowsSorted)
            {
                _liSmartDefectRowsFullListWithoutExcludeRows.Remove(row);

            }

            _liSmartDefectRowsListUnclassified = new List<SmartDefectRow>(_liSmartDefectRowsFullListWithoutExcludeRows);

            return liSmartDefectRowsSorted;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == null) return;

            var defectList = _liDefectLists.Find(list => list.ID.ToString() == e.TabPage.Name);
            tsbDefectListOptions.Enabled = defectList != null;
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            var frmDefecturaOptions = new frmDefecturaOptions();
            frmDefecturaOptions.ShowDialog();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            var frmMyStoreSelectBox = new frmMyStoreSelectBox();

            if (frmMyStoreSelectBox.ShowDialog(this) == DialogResult.OK)
            {
                _selectedStore = frmMyStoreSelectBox.SelectedStore;
                Text = @"Дефектура - " + _selectedStore.Name;

                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                bgwDefectListsOpener.RunWorkerAsync();
            }
        }

        private void LoadDefectLists()
        {
            ReadFullDefectList();

            ReadAllDefectLists();

            SeparateLists();

            this.InvokeInGUIThread(PrepareTabs);

            ProcessExcludeDefectList("");
            ProcessDefectList("");

            SetRestLists("");
        }

        private void PrepareTabs()
        {
            tabControl1.TabPages.Clear();

            AddNewTab("FullList", "Весь список");

            AddNewTab("UnclassifiedList", "Без фильтра");

            foreach (var varDefectList in _liSmartLists)
            {
                AddNewTab(varDefectList.ID.ToString(), varDefectList.Name);
            }

            foreach (var varDefectList in _liExcludeLists)
            {
                AddNewTab(varDefectList.ID.ToString(), varDefectList.Name);
            }

            tabControl1.SelectTab(0);
        }

        private void AddNewTab(string key, string name)
        {
            tabControl1.TabPages.Add(key, name);

            var ucDefectTable = new ucDefectTable
            {
                Dock = DockStyle.Fill
            };

            ucDefectTable.CurrentRowChanged += ucDefectTable_CurrentRowChanged;
            ucDefectTable.ProcessedRowsCountChanged += ucDefectTable_ProcessedRowsCountChanged;
            ucDefectTable.RowAddedToExcludeList += ucDefectTable_RowAddedToExcludeList;

            tabControl1.TabPages[key].Controls.Add(ucDefectTable);
            tabControl1.TabPages[key].Tag = name;
            ucDefectTable.Tag = tabControl1.TabPages[key];
        }

        private void ucDefectTable_RowAddedToExcludeList(object sender, ucDefectTable.RowAddedToExcludeListEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                AddToExcludeListAndUpdateAllLists(e.DefectListName);
            });
        }

        private void ucDefectTable_ProcessedRowsCountChanged(object sender, ucDefectTable.ProcessedRowsCountChangedEventArgs e)
        {
            Log.Debug("Начало отрисовки кол-ва необработанных строк");

            var dt = (ucDefectTable)sender;
            var tab = (TabPage)dt.Tag;
            string tabtext;

            if (e.UnprocessedRowCount > 0)
            {
                tabtext = tab.Tag + e.UnprocessedRowCount.ToString(" (0)");
            }
            else
            {
                tabtext = tab.Tag.ToString();
            }

            if (InvokeRequired)
            {
                this.InvokeInGUIThread(() => tab.Text = tabtext);
            }
            else
            {
                tab.Text = tabtext;
            }

            Log.Debug("Конец отрисовки кол-ва необработанных строк");
        }

        private void ucDefectTable_CurrentRowChanged(object sender, ucDefectTable.CurrentRowChangedEventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            int daysOfStockRotation = Convert.ToInt16(Settings.Default.DaysOfStockRotation);
            int productSuppliesTopRows = Convert.ToInt16(Settings.Default.ProductSuppliesTopRows);
            ucProductSupplies1.GetInfo(e.SmartDefectRow.FullProductInfo, productSuppliesTopRows, daysOfStockRotation);

            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
        }

        private void SeparateLists()
        {
            _liExcludeLists = _liDefectLists.FindAll(list => list.IsSmartList == false);
            _liSmartLists = _liDefectLists.FindAll(list => list.IsSmartList);
        }

        private void ReadAllDefectLists()
        {
            using (var db = new DbManager())
            {
                var defectListsAccessor = DataAccessor.CreateInstance<DefectListsAccessor>(db);
                _liDefectLists = defectListsAccessor.Query.SelectAll(db);
            }
        }

        private void ReadFullDefectList()
        {
            int daysForAnalysis = Convert.ToInt16(Settings.Default.DaysForAnalysis);
            var fromDate = DateTime.Now.AddDays(-1 * daysForAnalysis);
            var toDate = DateTime.Now;

            int daysOfStockRotation = Convert.ToInt16(Settings.Default.DaysOfStockRotation);
            int daysOfMinAmount = Convert.ToInt16(Settings.Default.DaysOfMinAmount);

            using (var dbSatelite = new DbManager(_selectedStore.Name))
            {
                var defectAccessor = DataAccessor.CreateInstance<SmartDefectRowsAccessor>(dbSatelite);
                defectAccessor.CheckAndUpdateDeliveredRows();
                defectAccessor.FindNewDefectRows(fromDate, toDate, daysOfStockRotation, daysOfMinAmount);
                _liSmartDefectRowsFullList = defectAccessor.GetDefectList(fromDate, toDate, daysOfStockRotation, daysOfMinAmount);
                _liSmartDefectRowsFullListWithoutExcludeRows = new List<SmartDefectRow>(_liSmartDefectRowsFullList);
            }
        }

        private void bgwDefectListsOpener_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            LoadDefectLists();
        }

        private void bgwDefectListsOpener_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            tsbRefresh.Enabled = true;
            tsbPrint.Enabled = true;
        }

        private void frmDefectura_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.DefectSplitterDistance = splitContainer1.SplitterDistance;
            Settings.Default.Save();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            bgwDefectListsOpener.RunWorkerAsync();
        }

        private void AddToExcludeListAndUpdateAllLists(string sourceDefectListName)
        {
            ProcessExcludeDefectList(sourceDefectListName);

            ProcessDefectList(sourceDefectListName);

            SetRestLists(sourceDefectListName);
        }

        private void SetRestLists(string excludeDefectListName)
        {
            if ("FullList" != excludeDefectListName)
            {
                var tabPage = tabControl1.TabPages["FullList"];
                var arControls = tabPage.Controls.Find("ucDefectTable", false);
                var ucDefectTable = (ucDefectTable)arControls[0];

                ucDefectTable.SetDefectList(_selectedStore, "FullList", null, _liSmartDefectRowsFullListWithoutExcludeRows, _liExcludeLists);
            }

            if ("UnclassifiedList" != excludeDefectListName)
            {
                var tabPage = tabControl1.TabPages["UnclassifiedList"];
                var arControls = tabPage.Controls.Find("ucDefectTable", false);
                var ucDefectTable = (ucDefectTable)arControls[0];

                ucDefectTable.SetDefectList(_selectedStore, "UnclassifiedList", null, _liSmartDefectRowsListUnclassified, _liExcludeLists);
            }
        }

        private void ProcessDefectList(string excludeDefectListName)
        {
            foreach (var varDefectList in _liSmartLists)
            {
                var tabPage = tabControl1.TabPages[varDefectList.ID.ToString()];

                List<DefectListCriteria> liCriteria;
                using (var db = new DbManager())
                {
                    var defectListCriteriaAccessor = DataAccessor.CreateInstance<DefectListCriteriaAccessor>(db);

                    liCriteria = defectListCriteriaAccessor.SelectByKey(varDefectList.ID);
                }

                var liSortedSmartDefectRows = ApplyFilterForDefectList(_liSmartDefectRowsFullListWithoutExcludeRows, liCriteria);
                if (varDefectList.ID.ToString() != excludeDefectListName)
                {
                    var arControls = tabPage.Controls.Find("ucDefectTable", false);
                    var ucDefectTable = (ucDefectTable)arControls[0];

                    ucDefectTable.SetDefectList(_selectedStore, varDefectList.ID.ToString(), varDefectList, liSortedSmartDefectRows, _liExcludeLists);
                }
            }
        }

        private void ProcessExcludeDefectList(string excludeDefectListName)
        {
            _liSmartDefectRowsFullListWithoutExcludeRows = new List<SmartDefectRow>(_liSmartDefectRowsFullList);

            foreach (var varDefectList in _liExcludeLists)
            {
                var tabPage = tabControl1.TabPages[varDefectList.ID.ToString()];

                List<DefectExceptionRow> liDefectExceptions;
                using (var db = new DbManager())
                {
                    var defectExceptionsAccessor = DataAccessor.CreateInstance<DefectExceptionsAccessor>(db);

                    liDefectExceptions = defectExceptionsAccessor.SelectByKey(varDefectList.ID);
                }

                var liSortedSmartDefectRows = ApplyExcludeFilterForDefectList(_liSmartDefectRowsFullList, liDefectExceptions);

                if (varDefectList.ID.ToString() != excludeDefectListName)
                {
                    var arControls = tabPage.Controls.Find("ucDefectTable", false);
                    var ucDefectTable = (ucDefectTable)arControls[0];

                    ucDefectTable.SetDefectList(_selectedStore, varDefectList.ID.ToString(), varDefectList, liSortedSmartDefectRows, _liExcludeLists);
                }
            }
        }

        private void tsbDefectListOptions_Click(object sender, EventArgs e)
        {
            var defectList = _liDefectLists.Find(p => p.ID.ToString() == tabControl1.SelectedTab.Name);

            if (defectList != null)
            {
                var frmDefecturaNewList = new frmDefecturaNewList
                {
                    NewDefectList = defectList
                };

                if (frmDefecturaNewList.ShowDialog(this) == DialogResult.OK)
                {
                    toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                    bgwDefectListsOpener.RunWorkerAsync();
                }
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            var frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.DefectListBySupplier.rdlc");

            int iDaysOfStockRotation = Convert.ToInt16(Settings.Default.DaysOfStockRotation);
            int iDaysOfMinAmount = Convert.ToInt16(Settings.Default.DaysOfMinAmount);

            var date = new ReportParameter("Date", DateTime.Now.ToString());
            var myStore = new ReportParameter("MyStore", _selectedStore.Name);
            var daysOfMinAmount = new ReportParameter("DaysOfMinAmount", iDaysOfMinAmount.ToString());
            var daysOfStockRotation = new ReportParameter("DaysOfStockRotation", iDaysOfStockRotation.ToString());

            frmReportViewer.SetParameters(date, myStore, daysOfMinAmount, daysOfStockRotation);

            var arControls = tabControl1.SelectedTab.Controls.Find("ucDefectTable", false);
            var ucDefectTable = (ucDefectTable)arControls[0];
            var liUnprocessedRows = ucDefectTable.SmartDefectRows.FindAll(p => p.Status == SmartDefectRowStatusEnum.NotProcessed);
            frmReportViewer.SetDataSource("SmartDefectRow", liUnprocessedRows);
            frmReportViewer.ShowDialog();
        }

        private void tsbNewList_Click(object sender, EventArgs e)
        {
            var frmDefecturaNewList = new frmDefecturaNewList();

            if (frmDefecturaNewList.ShowDialog(this) == DialogResult.OK)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                bgwDefectListsOpener.RunWorkerAsync();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == null) return;

            var ctrls = e.TabPage.Controls.Find("ucDefectTable", false);
            var dt = (ucDefectTable)ctrls[0];
            e.TabPage.Update();

            dt.SetFocus();
        }
    }
}