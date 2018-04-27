using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Common.Controls;
using Apteka.Plus.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.UserControls
{
    public partial class ucGoodsViewer : UserControl
    {
        private MyStore _currentStore;
        private string _letter;
        private DataLoader<List<LocalBillsRowEx>> _dataLoader;
        private List<LocalBillsRowEx> _liPrevRows;

        public ucGoodsViewer()
        {
            InitializeComponent();
        }

        public void LoadByLetter(MyStore store, string letter)
        {
            lock (_dataLoader.SyncRoot)
            {
                _currentStore = store;
                _letter = letter;
            }
            _dataLoader.MakeRequest();
        }

        private void dgvLocalBills_CurrentRowChanged(object sender, MyDataGridView.CurrentRowChangedEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var row = (LocalBillsRowEx)dgv.Rows[e.RowIndex].DataBoundItem;
            OnCurrentRowChanged(row);
        }

        public class RowChangedEventArgs : EventArgs
        {
            public RowChangedEventArgs(LocalBillsRowEx row)
            {
                Row = row;
            }

            public LocalBillsRowEx Row { get; }
        }

        public event EventHandler<RowChangedEventArgs> CurrentRowChanged;

        protected virtual void OnCurrentRowChanged(LocalBillsRowEx row)
        {
            CurrentRowChanged?.Invoke(this, new RowChangedEventArgs(row));
        }

        public class RowCountChangedEventArgs : EventArgs
        {
            public RowCountChangedEventArgs(int rowCount)
            {
                RowCount = rowCount;
            }
            public int RowCount { get; }
        }

        public event EventHandler<RowCountChangedEventArgs> RowCountChanged;

        protected virtual void OnRowCountChanged(int rowCount)
        {
            RowCountChanged?.Invoke(this, new RowCountChangedEventArgs(rowCount));
        }

        private void dgvLocalBills_KeyDown(object sender, KeyEventArgs e)
        {
            var dgv = (DataGridView)sender;

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                var row = (LocalBillsRowEx)dgv.CurrentRow.DataBoundItem;
                e.Handled = true;

                var res = MessageBox.Show(@"Вы уверены, что хотите осуществить возврат?", @"Внимание",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    var frmSuppliesReturnConfirmation = new frmSuppliesReturnConfirmation();
                    if (frmSuppliesReturnConfirmation.ShowDialog(this) == DialogResult.OK)
                    {
                        using (var dbSatelite = new DbManager(_currentStore.Name))
                        {
                            var raa = DataAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);
                            var remoteAction = new RemoteAction
                            {
                                LocalBillsRowID = row.ID,
                                Comment = frmSuppliesReturnConfirmation.Comment,
                                Employee = Session.User,
                                TypeOfAction = RemoteActionEnum.SuppliesReturn,
                                AmountToReturn =
                                    frmSuppliesReturnConfirmation.IsDeleteAll
                                        ? 0
                                        : frmSuppliesReturnConfirmation.Amount
                            };

                            raa.Insert(remoteAction);
                        }

                        MessageBox.Show(
                            @"Задание на удаление было успешно добавлено. Фактическое удаление произодет после обмена информации.",
                            @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void ucGoodsViewer_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            dgvLocalBills.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            _dataLoader = new DataLoader<List<LocalBillsRowEx>>(MakeRequest, 3000);
            _dataLoader.ItsGonnaTakeAWhile += _dataLoader_ItsGonnaTakeAWhile;
            _dataLoader.RequestCompleted += _dataLoader_RequestCompleted;
        }

        private void _dataLoader_RequestCompleted(object sender, DataLoader<List<LocalBillsRowEx>>.RequestCompletedEventArgs e)
        {
            localBillsRowExBindingSource.DataSource = e.Results;
            _liPrevRows = e.Results;
            progressIndicatorEx1.Hide();
        }

        private void _dataLoader_ItsGonnaTakeAWhile(object sender, DataLoader<List<LocalBillsRowEx>>.ItsGonnaTakeAWhileEventArgs e)
        {
            progressIndicatorEx1.Show();
        }

        private List<LocalBillsRowEx> MakeRequest()
        {
            MyStore store;
            string letter;
            lock (_dataLoader.SyncRoot)
            {
                store = _currentStore;
                letter = _letter;
            }

            using (var db = new DbManager(store.Name))
            {
                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(db);
                return lba.GetRowsByStartLetter(letter);
            }
        }

        public void FilterByName(string name)
        {
            localBillsRowExBindingSource.DataSource = !string.IsNullOrEmpty(name) 
                ? _liPrevRows.FindAll(row => row.ProductName.StartsWith(name, StringComparison.CurrentCultureIgnoreCase)) 
                : _liPrevRows;
        }

        public void FilterByDate(DateTime dateTime)
        {
            localBillsRowExBindingSource.DataSource = _liPrevRows.FindAll(row => row.DateSupply.Date == dateTime.Date);
        }

        public void ClearDateFilter()
        {
            localBillsRowExBindingSource.DataSource = _liPrevRows;
        }

        private void localBillsRowExBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            OnRowCountChanged(localBillsRowExBindingSource.Count);
        }

        public List<LocalBillsRowEx> List => (List<LocalBillsRowEx>)localBillsRowExBindingSource.List;
    }
}
