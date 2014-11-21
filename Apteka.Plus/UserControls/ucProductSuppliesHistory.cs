using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.UserControls
{
    public partial class ucProductSuppliesHistory : UserControl
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private MyStore _myStore;
        private int _rowCount;
        private List<LocalBillsRowEx> _liLocalBillsRows;

        public ucProductSuppliesHistory()
        {
            InitializeComponent();
        }

        public void LoadData(MyStore myStore, DateTime startDate, DateTime endDate)
        {
            _myStore = myStore;

            using (DbManager dbSatelite = new DbManager(myStore.Name))
            {
                LocalBillsAccessor lba =
                    LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);

                _liLocalBillsRows = lba.GetRows(startDate, endDate);

                _rowCount = _liLocalBillsRows.Count;

                this.InvokeInGUIThread(() =>
                {
                    OnRowCountChanged(_liLocalBillsRows.Count);
                    localBillsRowExBindingSource.DataSource = _liLocalBillsRows;
                });

            }

        }

        public int RowCount
        {
            get
            {
                return _rowCount;
            }
        }

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
            var eventHandler = RowCountChanged;
            if (eventHandler != null)
                eventHandler(this, new RowCountChangedEventArgs(rowCount));
        }

        private void dgvProductSuppliesHistory_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            LocalBillsRowEx row = dgv.CurrentRow.DataBoundItem as LocalBillsRowEx;

            log.InfoFormat("Пользователь нажал клавишу {0}", e.KeyCode);
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

                case Keys.Escape:
                    {

                        tbSearch.Text = "";
                        e.Handled = true;
                        e.SuppressKeyPress = true;

                    }
                    break;

                case Keys.Delete:
                    {
                        e.Handled = true;
                        if (MessageBox.Show("Вы уверены, что хотите осуществить возврат?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {

                            frmSuppliesReturnConfirmation frmSuppliesReturnConfirmation = new frmSuppliesReturnConfirmation();
                            if (frmSuppliesReturnConfirmation.ShowDialog(this) == DialogResult.OK)
                            {
                                using (DbManager dbSatelite = new DbManager(_myStore.Name))
                                {

                                    RemoteActionAccessor raa =
                                        RemoteActionAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);
                                    RemoteAction remoteAction = new RemoteAction();
                                    remoteAction.LocalBillsRowID = row.ID;
                                    remoteAction.Comment = frmSuppliesReturnConfirmation.Comment;
                                    remoteAction.Employee = Session.User;
                                    remoteAction.TypeOfAction = RemoteActionEnum.SuppliesReturn;
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

                                MessageBox.Show("Задание на удаление было успешно добавлено. Фактическое удаление произодет после обмена информации.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                        break;
                    }

            }
        }

    }
}
