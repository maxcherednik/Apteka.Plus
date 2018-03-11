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

namespace Apteka.Plus.UserControls
{
    public partial class ucGoodsViewer : UserControl
    {
        private MyStore _currentStore;
        private string _letter;
        private DataLoader<List<LocalBillsRowEx>> _dataLoader;
        private List<LocalBillsRowEx> _liPrevRows;

        #region Constructor
        public ucGoodsViewer()
        {
            InitializeComponent();
        }
        #endregion

        #region Public methods
        public void LoadByLetter(MyStore store, string letter)
        {
            lock (_dataLoader.SyncRoot)
            {
                _currentStore = store;
                _letter = letter;
            }
            _dataLoader.MakeRequest();
        }
        #endregion

        private void dgvLocalBills_CurrentRowChanged(object sender, MyDataGridView.CurrentRowChangedEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            LocalBillsRowEx row = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;
            OnCurrentRowChanged(row);
        }

        #region CurrentRowChanged Event
        public class RowChangedEventArgs : EventArgs
        {
            public RowChangedEventArgs(LocalBillsRowEx row)
            {
                Row = row;
            }
            public LocalBillsRowEx Row { get; private set; }
        }

        public event EventHandler<RowChangedEventArgs> CurrentRowChanged;

        protected virtual void OnCurrentRowChanged(LocalBillsRowEx row)
        {
            CurrentRowChanged?.Invoke(this, new RowChangedEventArgs(row));
        }
        #endregion

        #region RowCountChanged Event
        public class RowCountChangedEventArgs : EventArgs
        {
            public RowCountChangedEventArgs(int rowCount)
            {
                RowCount = rowCount;
            }
            public int RowCount { get; private set; }
        }

        public event EventHandler<RowCountChangedEventArgs> RowCountChanged;

        protected virtual void OnRowCountChanged(int rowCount)
        {
            RowCountChanged?.Invoke(this, new RowCountChangedEventArgs(rowCount));
        }
        #endregion


        private void dgvLocalBills_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            switch (e.KeyCode)
            {

                case Keys.Escape:
                    {
                        e.SuppressKeyPress = true;
                    }
                    break;

                case Keys.Delete:
                    {
                        LocalBillsRowEx row = dgv.CurrentRow.DataBoundItem as LocalBillsRowEx;
                        e.Handled = true;
                        if (
                            MessageBox.Show("Вы уверены, что хотите осуществить возврат?", "Внимание",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {

                            frmSuppliesReturnConfirmation frmSuppliesReturnConfirmation = new frmSuppliesReturnConfirmation();
                            if (frmSuppliesReturnConfirmation.ShowDialog(this) == DialogResult.OK)
                            {
                                using (DbManager dbSatelite = new DbManager(_currentStore.Name))
                                {

                                    RemoteActionAccessor raa = RemoteActionAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);
                                    var remoteAction = new RemoteAction
                                    {
                                        LocalBillsRowID = row.ID,
                                        Comment = frmSuppliesReturnConfirmation.Comment,
                                        Employee = Session.User,
                                        TypeOfAction = RemoteActionEnum.SuppliesReturn
                                    };

                                    if (frmSuppliesReturnConfirmation.IsDeleteAll)
                                    {
                                        remoteAction.AmountToReturn = 0;
                                    }
                                    else
                                    {
                                        remoteAction.AmountToReturn = frmSuppliesReturnConfirmation.Amount;
                                    }

                                    raa.Insert(remoteAction);
                                }

                                MessageBox.Show(
                                    "Задание на удаление было успешно добавлено. Фактическое удаление произодет после обмена информации.",
                                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        break;
                    }

            }
        }

        private void ucGoodsViewer_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            dgvLocalBills.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            _dataLoader = new DataLoader<List<LocalBillsRowEx>>(MakeRequest, 3000);
            _dataLoader.ItsGonnaTakeAWhile += new EventHandler<DataLoader<List<LocalBillsRowEx>>.ItsGonnaTakeAWhileEventArgs>(_dataLoader_ItsGonnaTakeAWhile);
            _dataLoader.RequestCompleted += new EventHandler<DataLoader<List<LocalBillsRowEx>>.RequestCompletedEventArgs>(_dataLoader_RequestCompleted);
        }

        void _dataLoader_RequestCompleted(object sender, DataLoader<List<LocalBillsRowEx>>.RequestCompletedEventArgs e)
        {
            localBillsRowExBindingSource.DataSource = e.Results;
            _liPrevRows = e.Results;
            progressIndicatorEx1.Hide();
        }

        void _dataLoader_ItsGonnaTakeAWhile(object sender, DataLoader<List<LocalBillsRowEx>>.ItsGonnaTakeAWhileEventArgs e)
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
                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);
                return lba.GetRowsByStartLetter(letter);
            }
        }

        public void FilterByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                localBillsRowExBindingSource.DataSource = _liPrevRows.FindAll(row => row.ProductName.StartsWith(name, StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                localBillsRowExBindingSource.DataSource = _liPrevRows;
            }
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

        public List<LocalBillsRowEx> List
        {
            get
            {
                return (List<LocalBillsRowEx>)localBillsRowExBindingSource.List;
            }
        }
    }
}
