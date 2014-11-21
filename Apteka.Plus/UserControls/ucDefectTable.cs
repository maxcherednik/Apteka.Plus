﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Common.Controls;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.UserControls
{
    public partial class ucDefectTable : UserControl
    {

        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ucDefectTable()
        {
            InitializeComponent();
            dgvDefecturaList.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            dgvDefecturaList.CurrentRowChanged += new EventHandler<MyDataGridView.CurrentRowChangedEventArgs>(dgvDefecturaList_CurrentRowChanged);
        }

        void dgvDefecturaList_CurrentRowChanged(object sender, MyDataGridView.CurrentRowChangedEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            SmartDefectRow smartDefectRow = dgv.Rows[e.RowIndex].DataBoundItem as SmartDefectRow;
            OnCurrentRowChange(smartDefectRow);
        }

        public void SetFocus()
        {
            dgvDefecturaList.Select();
        }

        List<SmartDefectRow> _liSmartDefectRows;
        string _defectListName;
        DefectList _DefectList;

        int _unprocessedRows = 0;

        MyStore _selectedStore;

        #region Public

        #region Properties
        public List<SmartDefectRow> SmartDefectRows
        {
            get { return _liSmartDefectRows; }

        }
        #endregion

        #region Methods

        public void SetDefectList(MyStore selectedStore, string DefectListName, DefectList DefectList, List<SmartDefectRow> liSmartDefectRows, List<DefectList> liExcludeLists)
        {
            List<SmartDefectRow> liUnprocessedRows = liSmartDefectRows.FindAll(delegate(SmartDefectRow p) { return p.Status == SmartDefectRowStatusEnum.NotProcessed && !p.RemindAt.HasValue; });
            _unprocessedRows = liUnprocessedRows.Count;
            _selectedStore = selectedStore;

            _DefectList = DefectList;
            _defectListName = DefectListName;
            _liSmartDefectRows = liSmartDefectRows;

            #region Fill Defect Dates ComboBox
            //List<DateTime> liDefectDates = new List<DateTime>();
            //foreach (SmartDefectRow row in liSmartDefectRows)
            //{
            //    if (!liDefectDates.Contains(row.DateAccepted.Date))
            //    {
            //        liDefectDates.Add(row.DateAccepted.Date);
            //    }
            //}
            //liDefectDates.Sort();

            List<DateTime> liDefectDates = new List<DateTime>();
            foreach (SmartDefectRow row in liSmartDefectRows)
            {
                if (!liDefectDates.Contains(row.DateLastSale.Date) && !row.RemindAt.HasValue && row.Status == SmartDefectRowStatusEnum.NotProcessed)
                {
                    liDefectDates.Add(row.DateLastSale.Date);
                }
            }
            liDefectDates.Sort();

            #endregion

            this.InvokeInGUIThread(() =>
            {
                cbDateDefect.Items.Clear();
                cbDateDefect.Items.Add("Без фильтра");

                foreach (DateTime Date in liDefectDates)
                {
                    cbDateDefect.Items.Insert(0, Date);
                }

                smartDefectRowBindingSource.DataSource = liSmartDefectRows;
                smartDefectRowBindingSource.ResetBindings(false);

                cmsDefectlistMenu.Items.Clear();

                if (_DefectList != null)
                {
                    if (!_DefectList.IsSmartList)
                    {
                        cmsDefectlistMenu.Items.Add("Удалить из списка");
                        cmsDefectlistMenu.Items[cmsDefectlistMenu.Items.Count - 1].Name = "del";
                        Font font = cmsDefectlistMenu.Items[cmsDefectlistMenu.Items.Count - 1].Font;
                        Font f = new Font(font, FontStyle.Bold);
                        cmsDefectlistMenu.Items[cmsDefectlistMenu.Items.Count - 1].Font = f;
                    }
                }

                foreach (DefectList defectList in liExcludeLists)
                {
                    if (_defectListName != defectList.ID.ToString())
                    {
                        cmsDefectlistMenu.Items.Add(defectList.Name);
                        cmsDefectlistMenu.Items[cmsDefectlistMenu.Items.Count - 1].Tag = defectList;
                    }
                }

                cbDelayedFilter.SelectedIndex = 0;

            });

            OnProcessedRowsCountChange();

        }
        #endregion

        #region Events

        #region CurrentRowChanged
        public event EventHandler<CurrentRowChangedEventArgs> CurrentRowChanged;

        private void OnCurrentRowChange(SmartDefectRow smartDefectRow)
        {
            if (CurrentRowChanged != null)
            {
                CurrentRowChangedEventArgs e = new CurrentRowChangedEventArgs(smartDefectRow);
                CurrentRowChanged.Invoke(dgvDefecturaList, e);
            }

        }
        public class CurrentRowChangedEventArgs : EventArgs
        {
            public CurrentRowChangedEventArgs(SmartDefectRow smartDefectRow)
            {
                _SmartDefectRow = smartDefectRow;
            }

            private SmartDefectRow _SmartDefectRow;

            public SmartDefectRow SmartDefectRow
            {
                get { return _SmartDefectRow; }
                set { _SmartDefectRow = value; }
            }
        }
        #endregion

        #region ProcessedRowsCountChanged

        public event EventHandler<ProcessedRowsCountChangedEventArgs> ProcessedRowsCountChanged;

        private void OnProcessedRowsCountChange()
        {

            if (ProcessedRowsCountChanged != null)
            {
                List<SmartDefectRow> liDefectRows = smartDefectRowBindingSource.List as List<SmartDefectRow>;

                ProcessedRowsCountChangedEventArgs e = new ProcessedRowsCountChangedEventArgs(liDefectRows.Count, _unprocessedRows);

                ProcessedRowsCountChanged.Invoke(this, e);
            }

        }
        public class ProcessedRowsCountChangedEventArgs : EventArgs
        {
            public ProcessedRowsCountChangedEventArgs(int RowCount, int UnprocessedRowCount)
            {
                _RowCount = RowCount;
                _UnprocessedRowCount = UnprocessedRowCount;
            }

            int _RowCount;
            int _UnprocessedRowCount;

            public int RowCount
            {
                get { return _RowCount; }
                set { _RowCount = value; }
            }

            public int UnprocessedRowCount
            {
                get { return _UnprocessedRowCount; }
                set { _UnprocessedRowCount = value; }
            }
        }
        #endregion

        #region RowAddedToExcludeList
        public event EventHandler<RowAddedToExcludeListEventArgs> RowAddedToExcludeList;

        private void OnRowAddToExcludeList(string defectListName)
        {
            if (RowAddedToExcludeList != null)
            {
                RowAddedToExcludeListEventArgs e = new RowAddedToExcludeListEventArgs(defectListName);
                RowAddedToExcludeList.Invoke(this, e);
            }

        }
        public class RowAddedToExcludeListEventArgs : EventArgs
        {
            string _defectListName;

            public string DefectListName
            {
                get { return _defectListName; }
                set { _defectListName = value; }
            }
            public RowAddedToExcludeListEventArgs(string defectListName)
            {
                _defectListName = defectListName;
            }

        }
        #endregion

        #endregion

        #endregion

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {

            if (tbSearch.Text.Length > 2)
            {
                List<SmartDefectRow> liFiltered = _liSmartDefectRows.FindAll(delegate(SmartDefectRow p) { return p.FullProductInfo.ProductName.Contains(tbSearch.Text); });

                smartDefectRowBindingSource.DataSource = liFiltered;

            }
            else
            {
                smartDefectRowBindingSource.DataSource = _liSmartDefectRows;
            }
        }

        private void dgvDefecturaList_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            // Load context menu on right mouse click
            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right)
            {

                hitTestInfo = dgv.HitTest(e.X, e.Y);
                // If column is first column
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell && hitTestInfo.RowIndex >= 0)
                {
                    dgv.ClearSelection();

                    dgv.Rows[hitTestInfo.RowIndex].Selected = true;
                    //setting active cell (black arrow)
                    dgv.CurrentCell = dgv.Rows[hitTestInfo.RowIndex].Cells[0];
                }
            }
        }

        private void dgvDefecturaList_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            // Load context menu on right mouse click
            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right)
            {

                hitTestInfo = dgv.HitTest(e.X, e.Y);
                // If column is first column
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell
                    && hitTestInfo.RowIndex >= 0)
                {
                    cmsDefectlistMenu.Show(dgv, e.Location);
                }

            }
        }

        private void dgvDefecturaList_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgvDefecturaList_KeyPress(object sender, KeyPressEventArgs e)
        {

            tbSearch.Text = tbSearch.Text + e.KeyChar;

        }

        private void dgvDefecturaList_KeyDown(object sender, KeyEventArgs e)
        {
            log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            DataGridView dgv = sender as DataGridView;

            switch (e.KeyCode)
            {

                case Keys.Back:
                    {
                        if (tbSearch.Text.Length != 0)
                        {
                            tbSearch.Text = tbSearch.Text.Substring(0, tbSearch.Text.Length - 1);
                        }

                        e.SuppressKeyPress = true;
                    }

                    break;

                case Keys.Delete:
                    {

                        dgv.CurrentRow.Cells["ManualAmountToOrder"].Value = null;
                        SmartDefectRow row = dgv.CurrentRow.DataBoundItem as SmartDefectRow;
                        row.Status = SmartDefectRowStatusEnum.NotProcessed;

                        using (DbManager dbSatelite = new DbManager(_selectedStore.Name))
                        {
                            SmartDefectRowsAccessor SmartDefectRowsAccessor = SmartDefectRowsAccessor.CreateInstance<SmartDefectRowsAccessor>(dbSatelite);

                            _unprocessedRows = _unprocessedRows - 1;
                            SmartDefectRowsAccessor.UpdateManualAmountToOrderAndStatus(row);

                        }

                        //dgv.EndEdit();

                    }
                    break;

                case Keys.Enter:
                    {

                        dgv.CurrentCell = dgv.CurrentRow.Cells["ManualAmountToOrder"];
                        dgv.BeginEdit(true);
                        e.Handled = true;
                        e.SuppressKeyPress = true;

                    }
                    break;

                case Keys.Escape:
                    {
                        tbSearch.Text = "";
                        e.SuppressKeyPress = true;
                    }
                    break;

                default:
                    break;
            }

        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                tbSearch.Text = "";
                e.SuppressKeyPress = true;

            }
        }

        private void dgvDefecturaList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            SmartDefectRow row = dgv.Rows[e.RowIndex].DataBoundItem as SmartDefectRow;

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "ManualAmountToOrder":
                    {
                        if (e.Value != null)
                        {
                            int val = (int)e.Value;

                            if (val > 0)
                            {
                                e.CellStyle.BackColor = Color.LightGreen;
                                Font f = new Font(e.CellStyle.Font, FontStyle.Bold);
                                e.CellStyle.Font = f;
                                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else
                            {
                                e.Value = "";
                                e.FormattingApplied = true;
                            }
                        }

                    }
                    break;

                case "RemindAt":
                    {
                        if (row.RemindAt.HasValue)
                        {
                            if (row.RemindAt.Value >= 0 && row.CurrentAmount > row.RemindAt.Value)
                            {
                                e.CellStyle.BackColor = Color.Orange;
                                Font f = new Font(e.CellStyle.Font, FontStyle.Bold);
                                e.CellStyle.Font = f;
                                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else if (row.CurrentAmount <= row.RemindAt.Value)
                            {
                                e.CellStyle.BackColor = Color.Red;
                                Font f = new Font(e.CellStyle.Font, FontStyle.Bold);
                                e.CellStyle.Font = f;
                                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else
                            {
                                e.Value = "";
                                e.FormattingApplied = true;
                            }
                        }

                    }
                    break;

                default:
                    break;
            }

        }

        private void cmsDefectlistMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SmartDefectRow defectRow = dgvDefecturaList.CurrentRow.DataBoundItem as SmartDefectRow;
            DialogResult res;

            cmsDefectlistMenu.Close();

            if (e.ClickedItem.Name == "del")
            {

                res = MessageBox.Show("Вы уверены, что хотите удалить " + defectRow.ProductName + " " + defectRow.PackageName + " из " + _DefectList.Name + "?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {

                    using (DbManager db = new DbManager())
                    {
                        DefectExceptionsAccessor DefectExceptionsAccessor = DefectExceptionsAccessor.CreateInstance<DefectExceptionsAccessor>(db);

                        DefectExceptionsAccessor.DeletebyProduct(defectRow.FullProductInfo.ID);
                    }

                    dgvDefecturaList.Rows.Remove(dgvDefecturaList.CurrentRow);

                    //event Subscribers notify
                    OnRowAddToExcludeList(_defectListName);
                }
            }
            else
            {

                DefectList DefectList = e.ClickedItem.Tag as DefectList;

                res = MessageBox.Show("Вы уверены, что хотите добавить " + defectRow.ProductName + " " + defectRow.PackageName + " в " + DefectList.Name + "?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {

                    DefectExceptionRow defectExceptions = new DefectExceptionRow();

                    defectExceptions.FullProductInfoID = defectRow.FullProductInfo.ID;
                    defectExceptions.DefectListID = DefectList.ID;

                    using (DbManager db = new DbManager())
                    {
                        DefectExceptionsAccessor DefectExceptionsAccessor = DefectExceptionsAccessor.CreateInstance<DefectExceptionsAccessor>(db);

                        if (_DefectList != null && !_DefectList.IsSmartList)
                        {
                            DefectExceptionsAccessor.DeletebyProduct(defectExceptions.FullProductInfoID);
                        }
                        DefectExceptionsAccessor.Query.Insert(defectExceptions);
                    }

                    dgvDefecturaList.Rows.Remove(dgvDefecturaList.CurrentRow);

                    //event Subscribers notify
                    OnRowAddToExcludeList(_defectListName);
                }
            }
        }

        private void dgvDefecturaList_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "ManualAmountToOrder":
                    {
                        SmartDefectRow row = dgv.Rows[e.RowIndex].DataBoundItem as SmartDefectRow;

                        if (cell.EditedFormattedValue.ToString().Trim() == "" || cell.EditedFormattedValue.ToString().Trim() == "0")
                        {

                            e.Value = null;
                            e.ParsingApplied = true;
                            row.Status = SmartDefectRowStatusEnum.NotProcessed;
                            _unprocessedRows++;
                        }
                        else
                        {
                            row.Status = SmartDefectRowStatusEnum.WaitingForSupply;
                            e.ParsingApplied = true;
                            _unprocessedRows--;
                        }

                        log.Debug("Оповещаем подписчиков об изменении количества обаботанных строк");
                        OnProcessedRowsCountChange();
                        log.Debug("Оповестили всех подписчиков");

                    }
                    break;

                case "RemindAt":
                    {
                        if (cell.EditedFormattedValue.ToString().Trim() == "")
                        {

                            e.ParsingApplied = true;

                            _unprocessedRows++;
                        }
                        else
                        {

                            e.ParsingApplied = true;
                            _unprocessedRows--;
                        }
                        e.ParsingApplied = false;

                        log.Debug("Оповещаем подписчиков об изменении количества обаботанных строк");
                        OnProcessedRowsCountChange();
                        log.Debug("Оповестили всех подписчиков");
                    }
                    break;

                default:
                    break;
            }

        }

        private void cbDateDefect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            DateTime? dt = cb.SelectedItem as DateTime?;
            if (dt.HasValue)
            {
                List<SmartDefectRow> liFilteredRows = _liSmartDefectRows.FindAll(delegate(SmartDefectRow p) { return p.DateLastSale.Date == (DateTime)cb.SelectedItem; });
                smartDefectRowBindingSource.DataSource = liFilteredRows;
            }
            else
            {
                smartDefectRowBindingSource.DataSource = _liSmartDefectRows;
            }

            dgvDefecturaList.Select();
        }

        private void dgvDefecturaList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.OwningColumn.Name == "RemindAt")
                {
                    dgv.CurrentCell = cell;
                    dgv.BeginEdit(true);
                }
            }

        }

        private void dgvDefecturaList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            SmartDefectRow defectRow = dgv.CurrentRow.DataBoundItem as SmartDefectRow;

            switch (cell.OwningColumn.Name)
            {
                case "ManualAmountToOrder":
                    {

                    }
                    break;

                case "RemindAt":
                    {
                        if (cell.IsInEditMode)
                        {
                            int remindAt;

                            if (cell.EditedFormattedValue.ToString().Trim() == "")
                            {

                            }
                            else if (int.TryParse(cell.EditedFormattedValue.ToString(), out remindAt))
                            {
                                if (remindAt >= defectRow.CurrentAmount)
                                {
                                    MessageBox.Show("Вы не можете ввести число большее чем текущий остаток", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    e.Cancel = true;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Вы ввели некорректное значение! Допускаются только числа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                e.Cancel = true;
                            }

                        }

                    }
                    break;

                default:
                    break;
            }

        }

        private void dgvDefecturaList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            SmartDefectRow defectRow = dgv.Rows[e.RowIndex].DataBoundItem as SmartDefectRow;

            switch (cell.OwningColumn.Name)
            {
                case "ManualAmountToOrder":
                    {

                        log.Debug("Пишем в базу");

                        using (DbManager dbSatelite = new DbManager(_selectedStore.Name))
                        {
                            SmartDefectRowsAccessor SmartDefectRowsAccessor = SmartDefectRowsAccessor.CreateInstance<SmartDefectRowsAccessor>(dbSatelite);

                            SmartDefectRowsAccessor.UpdateManualAmountToOrderAndStatus(defectRow);

                        }
                        log.Debug("Запись в базу совершена");
                    }
                    break;

                case "RemindAt":
                    {
                        using (DbManager dbSatelite = new DbManager(_selectedStore.Name))
                        {
                            SmartDefectRowsAccessor sdra = SmartDefectRowsAccessor.CreateInstance<SmartDefectRowsAccessor>(dbSatelite);

                            sdra.UpdateReminder(defectRow);
                        }

                    }
                    break;

            }

        }

        private void cbDelayedFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem.ToString() == "Без отложенных")
            {
                List<SmartDefectRow> liFilteredRows = _liSmartDefectRows.FindAll(delegate(SmartDefectRow p) { return !p.RemindAt.HasValue || p.CurrentAmount <= p.RemindAt.Value; });
                smartDefectRowBindingSource.DataSource = liFilteredRows;
            }
            else if (cb.SelectedItem.ToString() == "Все")
            {
                smartDefectRowBindingSource.DataSource = _liSmartDefectRows;
            }
            else if (cb.SelectedItem.ToString() == "Отложенные")
            {
                List<SmartDefectRow> liFilteredRows = _liSmartDefectRows.FindAll(delegate(SmartDefectRow p) { return p.RemindAt.HasValue; });
                smartDefectRowBindingSource.DataSource = liFilteredRows;
            }
            dgvDefecturaList.Select();
        }

    }
}
