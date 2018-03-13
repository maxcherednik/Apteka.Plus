using System;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Common.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmMainMenu : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnMainStoreInsert_Click(object sender, EventArgs e)
        {
            var frmMainStoreInsert = new frmMainStoreInsert();

            frmMainStoreInsert.Show(this);
            Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Log.Info("Пользователь вышел");
            Application.Exit();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            if (Session.User.Login == "igor")
            {
                btnFinance.Visible = true;
                btnOptions.Visible = true;
            }

            bgwChecker.RunWorkerAsync();
        }

        private void btnCopyData_Click(object sender, EventArgs e)
        {
            var frmCopyDataMenu = new frmCopyDataMenu();

            frmCopyDataMenu.ShowDialog();
            if (!bgwChecker.IsBusy)
                bgwChecker.RunWorkerAsync();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            var frmSales = new frmSales();

            frmSales.Show(this);
            Hide();
        }

        private void btnPrintBills_Click(object sender, EventArgs e)
        {
            var frmPrintBills = new frmPrintBills();

            frmPrintBills.Show(this);
            Hide();
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            var frmFinance = new frmFinance();

            frmFinance.Show(this);
            Hide();
        }

        private void btnRevision_Click(object sender, EventArgs e)
        {
            var frmLocalBills = new frmLocalBills();

            frmLocalBills.Show(this);
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var frmDefectura = new frmDefectura();

            frmDefectura.Show(this);
            Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var frmFullProductInfoSelectBox = new frmFullProductInfoSelectBox();

            frmFullProductInfoSelectBox.Show(this);
            Hide();
        }

        private void btnProductSupplies_Click(object sender, EventArgs e)
        {
            var frmProductSupplies = new frmProductSupplies();

            frmProductSupplies.Show(this);
            Hide();
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            var frmForeignOrderViewer = new frmForeignOrderViewer();
            frmForeignOrderViewer.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frmClientsSummary = new frmClientsSummary();
            frmClientsSummary.Show(this);
            Hide();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            var frm = new frmOptions();
            frm.ShowDialog(this);
        }

        private void btnSalesStatistics_Click(object sender, EventArgs e)
        {
            var frmSalesStatistics = new frmSalesStatistics();
            frmSalesStatistics.Show(this);
        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.Info("Пользователь вышел");
            Application.Exit();
        }

        private void btnLocalTransfers_Click(object sender, EventArgs e)
        {
            var frmLocalTransfersPreview = new frmLocalTransfersPreview();
            if (frmLocalTransfersPreview.ShowDialog(this) == DialogResult.OK)
            {
                var frmLocalTransfersMain = new frmLocalTransfersMain(frmLocalTransfersPreview.LocalBillsTransferInfoSelected);
                frmLocalTransfersMain.Show(this);
            }
        }

        private void PerformLocalTransfersCheck()
        {
            var counter = 0;
            foreach (var myStore in MyStoresCollection.AllStores)
            {
                using (var dbSatelite = new DbManager(myStore.Name))
                {
                    var lbta = DataAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);
                    if (lbta.CheckIfUnprocessedExist())
                    {
                        counter++;
                    }
                }
            }

            this.InvokeInGuiThread(() =>
            {
                if (counter > 0)
                {
                    btnLocalTransfers.Text = $@"Передачи ({counter})";
                    btnLocalTransfers.Enabled = true;
                }
                else
                {
                    btnLocalTransfers.Text = @"Передачи";
                    btnLocalTransfers.Enabled = false;
                }
            });
        }

        private void bgwChecker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            PerformLocalTransfersCheck();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!bgwChecker.IsBusy)
                bgwChecker.RunWorkerAsync();
        }

        private void btnSuppliersSummaries_Click(object sender, EventArgs e)
        {
            var frmSuppliersSummaries = new frmSuppliersSummaries();
            frmSuppliersSummaries.Show(this);
            Hide();
        }

        private void btnReturnSalesHistory_Click(object sender, EventArgs e)
        {
            var frmSalesReturnHistory = new frmSalesReturnHistory();
            frmSalesReturnHistory.Show(this);
            Hide();
        }

        private void btnSuppliesReturnHistory_Click(object sender, EventArgs e)
        {
            var frmSuppliesReturnHistory = new frmSuppliesReturnHistory();
            frmSuppliesReturnHistory.Show(this);
            Hide();
        }

        private void btnFinanceCollection_Click(object sender, EventArgs e)
        {
            var frmFinanceCollection = new frmFinanceCollection();
            frmFinanceCollection.Show(this);
            Hide();
        }
    }
}