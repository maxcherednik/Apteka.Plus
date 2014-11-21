using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Properties;
using Apteka.Plus.UserControls;
using BLToolkit.Data;
using Microsoft.Reporting.WinForms;

namespace Apteka.Plus.Forms
{
    public partial class frmDefectura : Form
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmDefectura()
        {
            InitializeComponent();
        }

        #region Private fields
        /// <summary>
        /// Выбранный пункт аптеки
        /// </summary>
        MyStore _selectedStore;

        /// <summary>
        /// Полный список
        /// </summary>
        List<SmartDefectRow> _liSmartDefectRowsFullList;

        /// <summary>
        /// Полный список без исключенных позиций
        /// </summary>
        List<SmartDefectRow> _liSmartDefectRowsFullListWithoutExcludeRows;

        /// <summary>
        /// Неклассифицированный список
        /// </summary>
        List<SmartDefectRow> _liSmartDefectRowsListUnclassified;

        /// <summary>
        /// Дефектурные листы и фильтры
        /// </summary>
        List<DefectList> _liDefectLists;

        /// <summary>
        /// Листы исключений
        /// </summary>
        List<DefectList> _liExcludeLists;

        /// <summary>
        /// Умные листы
        /// </summary>
        List<DefectList> _liSmartLists;
        #endregion

        #region Form

        private void frmDefectura_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        private void frmDefectura_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = Properties.Settings.Default.DefectSplitterDistance;
            //DataGridViewColsSizeSettings.LoadColumnsSize(dgvDefecturaMainList, "dgvDefecturaMainList");

        }

        private List<SmartDefectRow> ApplyFilterForDefectList(List<SmartDefectRow> liSmartDefectRows, List<DefectListCriteria> liCriteria)
        {
            List<SmartDefectRow> liSmartDefectRowsSorted = new List<SmartDefectRow>();

            foreach (DefectListCriteria criteria in liCriteria)
            {
                List<SmartDefectRow> liSmartDefectRowsPartial = liSmartDefectRows.FindAll(delegate(SmartDefectRow row) { return row.Supplier.Name.ToLower().Contains(criteria.SearchValue.ToLower()); });
                liSmartDefectRowsSorted.AddRange(liSmartDefectRowsPartial);
            }

            foreach (SmartDefectRow row in liSmartDefectRowsSorted)
            {
                _liSmartDefectRowsListUnclassified.Remove(row);

            }
            return liSmartDefectRowsSorted;
        }

        private List<SmartDefectRow> ApplyExcludeFilterForDefectList(List<SmartDefectRow> _liSmartDefectRowsFullList, List<DefectExceptionRow> liDefectExceptions)
        {
            List<SmartDefectRow> liSmartDefectRowsSorted = new List<SmartDefectRow>();

            foreach (DefectExceptionRow DefectExceptionRow in liDefectExceptions)
            {
                List<SmartDefectRow> liSmartDefectRowsPartial = _liSmartDefectRowsFullList.FindAll(delegate(SmartDefectRow row) { return (row.FullProductInfo.ID == DefectExceptionRow.FullProductInfoID); });
                liSmartDefectRowsSorted.AddRange(liSmartDefectRowsPartial);
            }

            foreach (SmartDefectRow row in liSmartDefectRowsSorted)
            {
                _liSmartDefectRowsFullListWithoutExcludeRows.Remove(row);

            }
            _liSmartDefectRowsListUnclassified = new List<SmartDefectRow>(_liSmartDefectRowsFullListWithoutExcludeRows);

            return liSmartDefectRowsSorted;
        }

        #endregion

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == null) return;

            #region Disable ListOptions
            DefectList DefectList = _liDefectLists.Find(list => list.ID.ToString() == e.TabPage.Name);
            tsbDefectListOptions.Enabled = DefectList != null;

            #endregion
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            frmDefecturaOptions frmDefecturaOptions = new frmDefecturaOptions();
            frmDefecturaOptions.ShowDialog();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            frmDefecturaNewList frmDefecturaNewList = new frmDefecturaNewList();

            if (frmDefecturaNewList.ShowDialog(this) == DialogResult.OK)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                bgwDefectListsOpener.RunWorkerAsync();

            }

        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            frmMyStoreSelectBox frmMyStoreSelectBox = new frmMyStoreSelectBox();
            DialogResult res = frmMyStoreSelectBox.ShowDialog(this);

            if (res == DialogResult.OK)
            {

                _selectedStore = frmMyStoreSelectBox.SelectedStore;
                this.Text = "Дефектура - " + _selectedStore.Name;

                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                bgwDefectListsOpener.RunWorkerAsync();

            }
        }

        private void LoadDefectLists()
        {
            ReadFullDefectList();

            ReadAllDefectLists();

            SeparateLists();

            this.InvokeInGUIThread(() => PrepareTabs());

            ProcessExcludeDefectList("");
            ProcessDefectList("");

            SetRestLists("");
        }

        private void PrepareTabs()
        {
            tabControl1.TabPages.Clear();

            AddNewTab("FullList", "Весь список");

            AddNewTab("UnclassifiedList", "Без фильтра");

            foreach (DefectList varDefectList in _liSmartLists)
            {
                AddNewTab(varDefectList.ID.ToString(), varDefectList.Name);
            }

            foreach (DefectList varDefectList in _liExcludeLists)
            {
                AddNewTab(varDefectList.ID.ToString(), varDefectList.Name);
            }

            tabControl1.SelectTab(0);

        }

        private void AddNewTab(string key, string name)
        {
            tabControl1.TabPages.Add(key, name);

            ucDefectTable ucDefectTable = new ucDefectTable();
            ucDefectTable.Dock = DockStyle.Fill;
            ucDefectTable.CurrentRowChanged += new EventHandler<ucDefectTable.CurrentRowChangedEventArgs>(ucDefectTable_CurrentRowChanged);
            ucDefectTable.ProcessedRowsCountChanged += new EventHandler<ucDefectTable.ProcessedRowsCountChangedEventArgs>(ucDefectTable_ProcessedRowsCountChanged);
            ucDefectTable.RowAddedToExcludeList += new EventHandler<ucDefectTable.RowAddedToExcludeListEventArgs>(ucDefectTable_RowAddedToExcludeList);

            tabControl1.TabPages[key].Controls.Add(ucDefectTable);
            tabControl1.TabPages[key].Tag = name;
            ucDefectTable.Tag = tabControl1.TabPages[key];
        }

        void ucDefectTable_RowAddedToExcludeList(object sender, ucDefectTable.RowAddedToExcludeListEventArgs e)
        {
            Thread th = new Thread(new ParameterizedThreadStart(AddToExcludeListAndUpdateAllLists));
            th.Start(e.DefectListName);
        }

        void ucDefectTable_ProcessedRowsCountChanged(object sender, ucDefectTable.ProcessedRowsCountChangedEventArgs e)
        {
            log.Debug("Начало отрисовки кол-ва необработанных строк");

            ucDefectTable dt = sender as ucDefectTable;
            TabPage tab = dt.Tag as TabPage;
            string tabtext = "";

            if (e.UnprocessedRowCount > 0)
                tabtext = tab.Tag.ToString() + e.UnprocessedRowCount.ToString(" (0)");
            else
                tabtext = tab.Tag.ToString();

            if (InvokeRequired)
            {
                this.InvokeInGUIThread(() => tab.Text = tabtext);
            }
            else
            {
                tab.Text = tabtext;

            }

            log.Debug("Конец отрисовки кол-ва необработанных строк");

        }

        void ucDefectTable_CurrentRowChanged(object sender, ucDefectTable.CurrentRowChangedEventArgs e)
        {

            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            int DaysForAnalysis = Convert.ToInt16(Settings.Default.DaysForAnalysis);
            int DaysOfStockRotation = Convert.ToInt16(Settings.Default.DaysOfStockRotation);
            int ProductSuppliesTopRows = Convert.ToInt16(Settings.Default.ProductSuppliesTopRows);
            ucProductSupplies1.GetInfo(e.SmartDefectRow.FullProductInfo, ProductSuppliesTopRows, DaysOfStockRotation);

            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;

        }

        private void SeparateLists()
        {
            _liExcludeLists = _liDefectLists.FindAll(list => list.IsSmartList == false);
            _liSmartLists = _liDefectLists.FindAll(list => list.IsSmartList == true);
        }

        private void ReadAllDefectLists()
        {
            using (DbManager db = new DbManager())
            {
                DefectListsAccessor DefectListsAccessor = DefectListsAccessor.CreateInstance<DefectListsAccessor>(db);
                _liDefectLists = DefectListsAccessor.Query.SelectAll(db);
            }
        }

        private void ReadFullDefectList()
        {
            int DaysForAnalysis = Convert.ToInt16(Settings.Default.DaysForAnalysis);
            DateTime fromDate = DateTime.Now.AddDays(-1 * DaysForAnalysis);
            DateTime toDate = DateTime.Now;

            int DaysOfStockRotation = Convert.ToInt16(Settings.Default.DaysOfStockRotation);
            int DaysOfMinAmount = Convert.ToInt16(Settings.Default.DaysOfMinAmount);

            using (DbManager dbSatelite = new DbManager(_selectedStore.Name))
            {

                SmartDefectRowsAccessor defectAccessor = SmartDefectRowsAccessor.CreateInstance<SmartDefectRowsAccessor>(dbSatelite);
                defectAccessor.CheckAndUpdateDeliveredRows();
                defectAccessor.FindNewDefectRows(fromDate, toDate, DaysOfStockRotation, DaysOfMinAmount);
                _liSmartDefectRowsFullList = defectAccessor.GetDefectList(fromDate, toDate, DaysOfStockRotation, DaysOfMinAmount);
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

        void AddToExcludeListAndUpdateAllLists(object par)//, SmartDefectRow defectRow
        {
            string sourceDefectListName = par as string;
            ProcessExcludeDefectList(sourceDefectListName);

            ProcessDefectList(sourceDefectListName);

            SetRestLists(sourceDefectListName);

        }

        private void SetRestLists(string ExcludeDefectListName)
        {
            if ("FullList" != ExcludeDefectListName)
            {
                TabPage tabPage = tabControl1.TabPages["FullList"];
                Control[] arControls = tabPage.Controls.Find("ucDefectTable", false);
                ucDefectTable ucDefectTable = arControls[0] as ucDefectTable;

                ucDefectTable.SetDefectList(_selectedStore, "FullList", null, _liSmartDefectRowsFullListWithoutExcludeRows, _liExcludeLists);
            }

            if ("UnclassifiedList" != ExcludeDefectListName)
            {
                TabPage tabPage = tabControl1.TabPages["UnclassifiedList"];
                Control[] arControls = tabPage.Controls.Find("ucDefectTable", false);
                ucDefectTable ucDefectTable = arControls[0] as ucDefectTable;

                ucDefectTable.SetDefectList(_selectedStore, "UnclassifiedList", null, _liSmartDefectRowsListUnclassified, _liExcludeLists);
            }
        }

        private void ProcessDefectList(string ExcludeDefectListName)
        {
            foreach (DefectList varDefectList in _liSmartLists)
            {

                TabPage tabPage = tabControl1.TabPages[varDefectList.ID.ToString()];

                List<DefectListCriteria> liCriteria;
                using (DbManager db = new DbManager())
                {
                    DefectListCriteriaAccessor DefectListCriteriaAccessor = DefectListCriteriaAccessor.CreateInstance<DefectListCriteriaAccessor>(db);

                    liCriteria = DefectListCriteriaAccessor.SelectByKey(varDefectList.ID);
                }

                List<SmartDefectRow> liSortedSmartDefectRows = ApplyFilterForDefectList(_liSmartDefectRowsFullListWithoutExcludeRows, liCriteria);
                if (varDefectList.ID.ToString() != ExcludeDefectListName)
                {
                    Control[] arControls = tabPage.Controls.Find("ucDefectTable", false);
                    ucDefectTable ucDefectTable = arControls[0] as ucDefectTable;

                    ucDefectTable.SetDefectList(_selectedStore, varDefectList.ID.ToString(), varDefectList, liSortedSmartDefectRows, _liExcludeLists);

                }

            }
        }

        private void ProcessExcludeDefectList(string ExcludeDefectListName)
        {
            _liSmartDefectRowsFullListWithoutExcludeRows = new List<SmartDefectRow>(_liSmartDefectRowsFullList);

            foreach (DefectList varDefectList in _liExcludeLists)
            {

                TabPage tabPage = tabControl1.TabPages[varDefectList.ID.ToString()];

                List<DefectExceptionRow> liDefectExceptions;
                using (DbManager db = new DbManager())
                {
                    DefectExceptionsAccessor DefectExceptionsAccessor = DefectExceptionsAccessor.CreateInstance<DefectExceptionsAccessor>(db);

                    liDefectExceptions = DefectExceptionsAccessor.SelectByKey(varDefectList.ID);
                }

                List<SmartDefectRow> liSortedSmartDefectRows = ApplyExcludeFilterForDefectList(_liSmartDefectRowsFullList, liDefectExceptions);

                if (varDefectList.ID.ToString() != ExcludeDefectListName)
                {
                    Control[] arControls = tabPage.Controls.Find("ucDefectTable", false);
                    ucDefectTable ucDefectTable = arControls[0] as ucDefectTable;

                    ucDefectTable.SetDefectList(_selectedStore, varDefectList.ID.ToString(), varDefectList, liSortedSmartDefectRows, _liExcludeLists);
                }

            }
        }

        private void tsbDefectListOptions_Click(object sender, EventArgs e)
        {

            DefectList DefectList = _liDefectLists.Find(delegate(DefectList p) { return p.ID.ToString() == tabControl1.SelectedTab.Name; });

            if (DefectList != null)
            {
                frmDefecturaNewList frmDefecturaNewList = new frmDefecturaNewList();
                frmDefecturaNewList.NewDefectList = DefectList;

                if (frmDefecturaNewList.ShowDialog(this) == DialogResult.OK)
                {
                    toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                    bgwDefectListsOpener.RunWorkerAsync();

                }
            }

        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            frmReportViewer frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.DefectListBySupplier.rdlc");

            int iDaysOfStockRotation = Convert.ToInt16(Settings.Default.DaysOfStockRotation);
            int iDaysOfMinAmount = Convert.ToInt16(Settings.Default.DaysOfMinAmount);

            ReportParameter Date = new ReportParameter("Date", DateTime.Now.ToString());
            ReportParameter MyStore = new ReportParameter("MyStore", _selectedStore.Name);
            ReportParameter DaysOfMinAmount = new ReportParameter("DaysOfMinAmount", iDaysOfMinAmount.ToString());
            ReportParameter DaysOfStockRotation = new ReportParameter("DaysOfStockRotation", iDaysOfStockRotation.ToString());

            frmReportViewer.SetParameters(Date, MyStore, DaysOfMinAmount, DaysOfStockRotation);

            Control[] arControls = tabControl1.SelectedTab.Controls.Find("ucDefectTable", false);
            ucDefectTable ucDefectTable = arControls[0] as ucDefectTable;
            List<SmartDefectRow> liUnprocessedRows = ucDefectTable.SmartDefectRows.FindAll((p) => { return p.Status == SmartDefectRowStatusEnum.NotProcessed; });
            frmReportViewer.SetDataSource("SmartDefectRow", liUnprocessedRows);
            frmReportViewer.ShowDialog();
        }

        private void tsbNewList_Click(object sender, EventArgs e)
        {
            frmDefecturaNewList frmDefecturaNewList = new frmDefecturaNewList();

            if (frmDefecturaNewList.ShowDialog(this) == DialogResult.OK)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                bgwDefectListsOpener.RunWorkerAsync();

            }

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (e.TabPage == null) return;

            Control[] ctrls = e.TabPage.Controls.Find("ucDefectTable", false);
            ucDefectTable dt = ctrls[0] as ucDefectTable;
            e.TabPage.Update();

            dt.SetFocus();

        }

    }
}
