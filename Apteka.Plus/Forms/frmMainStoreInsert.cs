using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.UserControls;
using log4net;
using OrderConverter;
using OrderConverter.BLL;

namespace Apteka.Plus.Forms
{
    public partial class frmMainStoreInsert : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<LocalOrder> _liLocalOrderRows;

        public frmMainStoreInsert()
        {
            InitializeComponent();
        }

        public frmMainStoreInsert(List<LocalOrder> liLocalOrderRows)
            : this()
        {
            _liLocalOrderRows = liLocalOrderRows;
        }

        private void frmMainStoreInsert_Load(object sender, EventArgs e)
        {
            ucNewBillPage1.Initialize(MyStoresCollection.AllStores);
            ucNewBillPage1.ProcessNotification += new EventHandler<UcNewBillPage.ProcessNotificationEventArgs>(ucNewBillPage1_ProcessNotification);
            ucNewBillPage1.CurrentRowChanged += new EventHandler<UcNewBillPage.CurrentRowChangedEventArgs>(ucNewBillPage1_CurrentRowChanged);
            ucNewBillPage1.Select();

        }

        void ucNewBillPage1_ProcessNotification(object sender, UcNewBillPage.ProcessNotificationEventArgs e)
        {
            tsStatusLabel.Text = e.CurrentAction;
            tsProgressBar.Maximum = e.MaxValue;
            tsProgressBar.Value = e.CurrentValue;
        }

        void ucNewBillPage1_CurrentRowChanged(object sender, UcNewBillPage.CurrentRowChangedEventArgs e)
        {
            log.DebugFormat("Current row changed: {0} - {1}", e.FullProductInfo.ProductName, e.FullProductInfo.PackageName);

            ucProductSupplies1.GetInfo(e.FullProductInfo, 15, 25);
            log.DebugFormat("Current row changed end");

        }

        private void frmMainStoreInsert_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void frmMainStoreInsert_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MainStoreInsertSplitterDistance = splitContainer1.SplitterDistance;
            Properties.Settings.Default.Save();


            if (ucNewBillPage1.IsBillOpen)
            {
                DialogResult res = MessageBox.Show("У вас остались несохраненные данные! Вернуться и закончить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (res == DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void frmMainStoreInsert_Shown(object sender, EventArgs e)
        {
            frmNewBillInfo frmNewBillInfo = new frmNewBillInfo();
           
            if (frmNewBillInfo.ShowDialog(this) == DialogResult.OK)
            {
                ucNewBillPage1.UpdateOrderInfo(frmNewBillInfo.BillDate, frmNewBillInfo.BillNumber, frmNewBillInfo.Supplier);

                if (_liLocalOrderRows != null)
                {
                    frmMyStoreSelectBox frmMyStoreSelectBox = new frmMyStoreSelectBox();
                    if (frmMyStoreSelectBox.ShowDialog(this) == DialogResult.OK)
                    {
                        frmLifeImportantSelectBox lifeImportantSelectBox = new frmLifeImportantSelectBox();

                        if (lifeImportantSelectBox.ShowDialog(this) == DialogResult.OK)
                        {
                            ucNewBillPage1.ProcessEOrder(_liLocalOrderRows, frmMyStoreSelectBox.SelectedStore, lifeImportantSelectBox.SelectedIsLifeImportant);
                        }
                    }
                }
            }
            else
            {
                Close();
            }
        }

        private void tsbOpenEOrder_Click(object sender, EventArgs e)
        {
            frmConvertOrder frmConvertOrder = new frmConvertOrder();
            if (frmConvertOrder.ShowDialog(this) == DialogResult.OK)
            {
                _liLocalOrderRows = frmConvertOrder.ConvertedOrder;
                frmMyStoreSelectBox frmMyStoreSelectBox = new frmMyStoreSelectBox();
                if (frmMyStoreSelectBox.ShowDialog(this) == DialogResult.OK)
                {
                    frmLifeImportantSelectBox lifeImportantSelectBox = new frmLifeImportantSelectBox();

                    if (lifeImportantSelectBox.ShowDialog(this) == DialogResult.OK)
                    {
                        ucNewBillPage1.ProcessEOrder(_liLocalOrderRows, frmMyStoreSelectBox.SelectedStore, lifeImportantSelectBox.SelectedIsLifeImportant);
                    }
                }
            }
        }

        private void tsbSaveBill_Click(object sender, EventArgs e)
        {
            log.Info("Пользователь нажал кнопку меню \"Сохранить накладную\"");

            if (ucNewBillPage1.IsEverythingOK())
            {
                frmMainStoreInsertSaveConfirmation frmMainStoreInsertSaveConfirmation = new frmMainStoreInsertSaveConfirmation(ucNewBillPage1.Supplier, ucNewBillPage1.BillDate, ucNewBillPage1.BillNumber, ucNewBillPage1.BillSum);
                if (frmMainStoreInsertSaveConfirmation.ShowDialog(this) == DialogResult.OK)
                {
                    ucNewBillPage1.SaveNewBill(frmMainStoreInsertSaveConfirmation.DelayLocalBills);
                    this.Close();
                    frmPrintBills frmPrintBills = new frmPrintBills();
                    frmPrintBills.Show();
                }
            }
        }

        private void tsbBillOptions_Click(object sender, EventArgs e)
        {
            frmNewBillInfo frmNewBillInfo = new frmNewBillInfo(ucNewBillPage1.BillDate, ucNewBillPage1.BillNumber, ucNewBillPage1.Supplier);
            DialogResult dres = frmNewBillInfo.ShowDialog(this);

            if (dres == DialogResult.OK)
            {
                ucNewBillPage1.UpdateOrderInfo(frmNewBillInfo.BillDate, frmNewBillInfo.BillNumber, frmNewBillInfo.Supplier);
            }
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            frmMainStoreInsertOptions frmMainStoreInsertOptions = new frmMainStoreInsertOptions();
            frmMainStoreInsertOptions.ShowDialog();
        }
    }
}