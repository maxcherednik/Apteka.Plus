using Apteka.Helpers;
using Apteka.Plus.Common.Controls;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLToolkit.DataAccess;

namespace Apteka.Plus.UserControls
{
    public partial class ucDefectTable : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string _defectListName;

        private DefectList _defectList;

        private int _unprocessedRows;

        private MyStore _selectedStore;

        public ucDefectTable()
        {
            InitializeComponent();
            dgvDefecturaList.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            dgvDefecturaList.CurrentRowChanged += dgvDefecturaList_CurrentRowChanged;
        }

        private void dgvDefecturaList_CurrentRowChanged(object sender, MyDataGridView.CurrentRowChangedEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var smartDefectRow = (SmartDefectRow)dgv.Rows[e.RowIndex].DataBoundItem;
            OnCurrentRowChange(smartDefectRow);
        }

        public void SetFocus()
        {
            dgvDefecturaList.Select();
        }

        public List<SmartDefectRow> SmartDefectRows { get; private set; }

        public void SetDefectList(MyStore selectedStore, string defectListName, DefectList defectList, List<SmartDefectRow> liSmartDefectRows, List<DefectList> liExcludeLists)
        {
            var liUnprocessedRows = liSmartDefectRows.FindAll(p => p.Status == SmartDefectRowStatusEnum.NotProcessed && !p.RemindAt.HasValue);
            _unprocessedRows = liUnprocessedRows.Count;
            _selectedStore = selectedStore;

            _defectList = defectList;
            _defectListName = defectListName;
            SmartDefectRows = liSmartDefectRows;

            var liDefectDates = new List<DateTime>();
            foreach (var row in liSmartDefectRows)
            {
                if (!liDefectDates.Contains(row.DateLastSale.Date) && !row.RemindAt.HasValue && row.Status == SmartDefectRowStatusEnum.NotProcessed)
                {
                    liDefectDates.Add(row.DateLastSale.Date);
                }
            }

            liDefectDates.Sort();

            this.InvokeInGuiThread(() =>
            {
                cbDateDefect.Items.Clear();
                cbDateDefect.Items.Add("Без фильтра");

                foreach (var date in liDefectDates)
                {
                    cbDateDefect.Items.Insert(0, date);
                }

                smartDefectRowBindingSource.DataSource = liSmartDefectRows;
                smartDefectRowBindingSource.ResetBindings(false);

                cmsDefectlistMenu.Items.Clear();

                if (_defectList != null)
                {
                    if (!_defectList.IsSmartList)
                    {
                        cmsDefectlistMenu.Items.Add("Удалить из списка");
                        cmsDefectlistMenu.Items[cmsDefectlistMenu.Items.Count - 1].Name = "del";
                        var font = cmsDefectlistMenu.Items[cmsDefectlistMenu.Items.Count - 1].Font;
                        cmsDefectlistMenu.Items[cmsDefectlistMenu.Items.Count - 1].Font = new Font(font, FontStyle.Bold);
                    }
                }

                foreach (var excludeDefectList in liExcludeLists)
                {
                    if (_defectListName != excludeDefectList.ID.ToString())
                    {
                        cmsDefectlistMenu.Items.Add(excludeDefectList.Name);
                        cmsDefectlistMenu.Items[cmsDefectlistMenu.Items.Count - 1].Tag = excludeDefectList;
                    }
                }

                cbDelayedFilter.SelectedIndex = 0;

            });

            OnProcessedRowsCountChange();
        }

        #region Events

        #region CurrentRowChanged
        public event EventHandler<CurrentRowChangedEventArgs> CurrentRowChanged;

        private void OnCurrentRowChange(SmartDefectRow smartDefectRow)
        {
            CurrentRowChanged?.Invoke(dgvDefecturaList, new CurrentRowChangedEventArgs(smartDefectRow));

        }

        public class CurrentRowChangedEventArgs : EventArgs
        {
            public CurrentRowChangedEventArgs(SmartDefectRow smartDefectRow)
            {
                SmartDefectRow = smartDefectRow;
            }

            public SmartDefectRow SmartDefectRow { get; set; }
        }
        #endregion

        #region ProcessedRowsCountChanged

        public event EventHandler<ProcessedRowsCountChangedEventArgs> ProcessedRowsCountChanged;

        private void OnProcessedRowsCountChange()
        {
            if (ProcessedRowsCountChanged != null)
            {
                var liDefectRows = (List<SmartDefectRow>)smartDefectRowBindingSource.List;

                var e = new ProcessedRowsCountChangedEventArgs(liDefectRows.Count, _unprocessedRows);

                ProcessedRowsCountChanged.Invoke(this, e);
            }
        }

        public class ProcessedRowsCountChangedEventArgs : EventArgs
        {
            public ProcessedRowsCountChangedEventArgs(int rowCount, int unprocessedRowCount)
            {
                RowCount = rowCount;
                UnprocessedRowCount = unprocessedRowCount;
            }

            public int RowCount { get; set; }

            public int UnprocessedRowCount { get; set; }
        }
        #endregion

        #region RowAddedToExcludeList
        public event EventHandler<RowAddedToExcludeListEventArgs> RowAddedToExcludeList;

        private void OnRowAddToExcludeList(string defectListName)
        {
            if (RowAddedToExcludeList != null)
            {
                var e = new RowAddedToExcludeListEventArgs(defectListName);
                RowAddedToExcludeList.Invoke(this, e);
            }

        }
        public class RowAddedToExcludeListEventArgs : EventArgs
        {
            public string DefectListName { get; set; }

            public RowAddedToExcludeListEventArgs(string defectListName)
            {
                DefectListName = defectListName;
            }

        }
        #endregion

        #endregion

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length > 2)
            {
                var liFiltered = SmartDefectRows.FindAll(p => p.FullProductInfo.ProductName.Contains(tbSearch.Text));

                smartDefectRowBindingSource.DataSource = liFiltered;
            }
            else
            {
                smartDefectRowBindingSource.DataSource = SmartDefectRows;
            }
        }

        private void dgvDefecturaList_MouseDown(object sender, MouseEventArgs e)
        {
            var dgv = (DataGridView)sender;

            // Load context menu on right mouse click
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgv.HitTest(e.X, e.Y);
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
            var dgv = (DataGridView)sender;
            // Load context menu on right mouse click
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dgv.HitTest(e.X, e.Y);
                // If column is first column
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell
                    && hitTestInfo.RowIndex >= 0)
                {
                    cmsDefectlistMenu.Show(dgv, e.Location);
                }
            }
        }

        private void dgvDefecturaList_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbSearch.Text = tbSearch.Text + e.KeyChar;
        }

        private void dgvDefecturaList_KeyDown(object sender, KeyEventArgs e)
        {
            Log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            var dgv = (DataGridView)sender;

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
                        var row = (SmartDefectRow)dgv.CurrentRow.DataBoundItem;
                        row.Status = SmartDefectRowStatusEnum.NotProcessed;

                        using (var dbSatelite = new DbManager(_selectedStore.Name))
                        {
                            var smartDefectRowsAccessor = DataAccessor.CreateInstance<SmartDefectRowsAccessor>(dbSatelite);

                            _unprocessedRows = _unprocessedRows - 1;
                            smartDefectRowsAccessor.UpdateManualAmountToOrderAndStatus(row);
                        }
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
            var dgv = (DataGridView)sender;
            var row = (SmartDefectRow)dgv.Rows[e.RowIndex].DataBoundItem;

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "ManualAmountToOrder":
                    {
                        if (e.Value != null)
                        {
                            var val = (int)e.Value;

                            if (val > 0)
                            {
                                e.CellStyle.BackColor = Color.LightGreen;
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
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
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else if (row.CurrentAmount <= row.RemindAt.Value)
                            {
                                e.CellStyle.BackColor = Color.Red;
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
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
            }
        }

        private void cmsDefectlistMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var defectRow = (SmartDefectRow) dgvDefecturaList.CurrentRow.DataBoundItem;
            cmsDefectlistMenu.Close();

            if (e.ClickedItem.Name == "del")
            {
                var res = MessageBox.Show($@"Вы уверены, что хотите удалить {defectRow.ProductName} {defectRow.PackageName}  из {_defectList.Name}?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    using (var db = new DbManager())
                    {
                        var defectExceptionsAccessor = DataAccessor.CreateInstance<DefectExceptionsAccessor>(db);

                        defectExceptionsAccessor.DeletebyProduct(defectRow.FullProductInfo.ID);
                    }

                    dgvDefecturaList.Rows.Remove(dgvDefecturaList.CurrentRow);

                    OnRowAddToExcludeList(_defectListName);
                }
            }
            else
            {
                var defectList = (DefectList) e.ClickedItem.Tag;

                var res = MessageBox.Show($@"Вы уверены, что хотите добавить {defectRow.ProductName} {defectRow.PackageName} в {defectList.Name}?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    var defectExceptions = new DefectExceptionRow
                    {
                        FullProductInfoID = defectRow.FullProductInfo.ID,
                        DefectListID = defectList.ID
                    };

                    using (var db = new DbManager())
                    {
                        var defectExceptionsAccessor = DataAccessor.CreateInstance<DefectExceptionsAccessor>(db);

                        if (_defectList != null && !_defectList.IsSmartList)
                        {
                            defectExceptionsAccessor.DeletebyProduct(defectExceptions.FullProductInfoID);
                        }

                        defectExceptionsAccessor.Query.Insert(defectExceptions);
                    }

                    dgvDefecturaList.Rows.Remove(dgvDefecturaList.CurrentRow);

                    OnRowAddToExcludeList(_defectListName);
                }
            }
        }

        private void dgvDefecturaList_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var dgv = (DataGridView) sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "ManualAmountToOrder":
                    {
                        var row = (SmartDefectRow) dgv.Rows[e.RowIndex].DataBoundItem;

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

                        Log.Debug("Оповещаем подписчиков об изменении количества обаботанных строк");
                        OnProcessedRowsCountChange();
                        Log.Debug("Оповестили всех подписчиков");

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

                        Log.Debug("Оповещаем подписчиков об изменении количества обаботанных строк");
                        OnProcessedRowsCountChange();
                        Log.Debug("Оповестили всех подписчиков");
                    }
                    break;
            }
        }

        private void cbDateDefect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBox) sender;
            var dt = cb.SelectedItem as DateTime?;
            if (dt.HasValue)
            {
                var liFilteredRows = SmartDefectRows.FindAll(p => p.DateLastSale.Date == (DateTime)cb.SelectedItem);
                smartDefectRowBindingSource.DataSource = liFilteredRows;
            }
            else
            {
                smartDefectRowBindingSource.DataSource = SmartDefectRows;
            }

            dgvDefecturaList.Select();
        }

        private void dgvDefecturaList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dgv = (DataGridView) sender;
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.OwningColumn.Name == "RemindAt")
                {
                    dgv.CurrentCell = cell;
                    dgv.BeginEdit(true);
                }
            }
        }

        private void dgvDefecturaList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = (DataGridView) sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            var defectRow = (SmartDefectRow) dgv.CurrentRow.DataBoundItem;

            switch (cell.OwningColumn.Name)
            {
                case "RemindAt":
                    {
                        if (cell.IsInEditMode)
                        {
                            if (cell.EditedFormattedValue.ToString().Trim() == "")
                            {

                            }
                            else if (int.TryParse(cell.EditedFormattedValue.ToString(), out var remindAt))
                            {
                                if (remindAt >= defectRow.CurrentAmount)
                                {
                                    MessageBox.Show(@"Вы не можете ввести число большее чем текущий остаток", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    e.Cancel = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show(@"Вы ввели некорректное значение! Допускаются только числа.", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                e.Cancel = true;
                            }
                        }
                    }
                    break;
            }
        }

        private void dgvDefecturaList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView) sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            var defectRow = (SmartDefectRow) dgv.Rows[e.RowIndex].DataBoundItem;

            switch (cell.OwningColumn.Name)
            {
                case "ManualAmountToOrder":
                    {
                        using (var dbSatelite = new DbManager(_selectedStore.Name))
                        {
                            var smartDefectRowsAccessor = DataAccessor.CreateInstance<SmartDefectRowsAccessor>(dbSatelite);

                            smartDefectRowsAccessor.UpdateManualAmountToOrderAndStatus(defectRow);
                        }
                    }
                    break;

                case "RemindAt":
                    {
                        using (var dbSatelite = new DbManager(_selectedStore.Name))
                        {
                            var sdra = DataAccessor.CreateInstance<SmartDefectRowsAccessor>(dbSatelite);

                            sdra.UpdateReminder(defectRow);
                        }
                    }
                    break;
            }
        }

        private void cbDelayedFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBox) sender;

            if (cb.SelectedItem.ToString() == "Без отложенных")
            {
                var liFilteredRows = SmartDefectRows.FindAll(p => !p.RemindAt.HasValue || p.CurrentAmount <= p.RemindAt.Value);
                smartDefectRowBindingSource.DataSource = liFilteredRows;
            }
            else if (cb.SelectedItem.ToString() == "Все")
            {
                smartDefectRowBindingSource.DataSource = SmartDefectRows;
            }
            else if (cb.SelectedItem.ToString() == "Отложенные")
            {
                var liFilteredRows = SmartDefectRows.FindAll(p => p.RemindAt.HasValue);
                smartDefectRowBindingSource.DataSource = liFilteredRows;
            }

            dgvDefecturaList.Select();
        }
    }
}
