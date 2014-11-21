using System;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.Forms
{
    public partial class frmMainMenu : Form
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnMainStoreInsert_Click(object sender, EventArgs e)
        {
            frmMainStoreInsert frmMainStoreInsert = new frmMainStoreInsert();

            frmMainStoreInsert.Show(this);
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            log.Info("Пользователь вышел");
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
            frmCopyDataMenu frmCopyDataMenu = new frmCopyDataMenu();

            frmCopyDataMenu.ShowDialog();
            if (!bgwChecker.IsBusy)
                bgwChecker.RunWorkerAsync();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            frmSales frmSales = new frmSales();

            frmSales.Show(this);
            this.Hide();
        }

        private void btnPrintBills_Click(object sender, EventArgs e)
        {
            frmPrintBills frmPrintBills = new frmPrintBills();

            frmPrintBills.Show(this);
            this.Hide();
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            frmFinance frmFinance = new frmFinance();

            frmFinance.Show(this);
            this.Hide();
        }

        private void btnRevision_Click(object sender, EventArgs e)
        {
            frmLocalBills frmLocalBills = new frmLocalBills();

            frmLocalBills.Show(this);
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmFullProductInfoSelectBox frmFullProductInfoSelectBox = new frmFullProductInfoSelectBox();
            frmFullProductInfoSelectBox.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDefectura frmDefectura = new frmDefectura();

            frmDefectura.Show(this);
            this.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmFullProductInfoSelectBox frmFullProductInfoSelectBox = new frmFullProductInfoSelectBox();

            frmFullProductInfoSelectBox.Show(this);
            this.Hide();
        }

        private void btnProductSupplies_Click(object sender, EventArgs e)
        {
            frmProductSupplies frmProductSupplies = new frmProductSupplies();

            frmProductSupplies.Show(this);
            this.Hide();
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            frmForeignOrderViewer frmForeignOrderViewer = new frmForeignOrderViewer();
            frmForeignOrderViewer.ShowDialog(this);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmClientsSummary frmClientsSummary = new frmClientsSummary();
            frmClientsSummary.Show(this);
            this.Hide();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmOptions frm = new frmOptions();
            frm.ShowDialog(this);
        }

        private void btnSalesStatistics_Click(object sender, EventArgs e)
        {
            frmSalesStatistics frmSalesStatistics = new frmSalesStatistics();
            frmSalesStatistics.Show(this);
        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Info("Пользователь вышел");
            Application.Exit();
        }

        private void btnLocalTransfers_Click(object sender, EventArgs e)
        {
            frmLocalTransfersPreview frmLocalTransfersPreview = new frmLocalTransfersPreview();
            if (frmLocalTransfersPreview.ShowDialog(this) == DialogResult.OK)
            {
                frmLocalTransfersMain frmLocalTransfersMain = new frmLocalTransfersMain(frmLocalTransfersPreview.LocalBillsTransferInfoSelected);
                frmLocalTransfersMain.Show(this);

            }
        }

        private void PerformLocalTransfersCheck()
        {
            int counter = 0;
            foreach (MyStore myStore in MyStoresCollection.AllStores)
            {
                using (DbManager dbSatelite = new DbManager(myStore.Name))
                {
                    LocalBillsTransfersAccessor lbta = LocalBillsTransfersAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);
                    if (lbta.CheckIfUnprocessedExist())
                    {
                        counter++;
                    }
                }

            }

            this.InvokeInGUIThread(() =>
            {
                if (counter > 0)
                {
                    btnLocalTransfers.Text = string.Format("Передачи ({0})", counter);
                    btnLocalTransfers.Enabled = true;
                }
                else
                {
                    btnLocalTransfers.Text = "Передачи";
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
            frmSuppliersSummaries frmSuppliersSummaries = new frmSuppliersSummaries();
            frmSuppliersSummaries.Show(this);
            this.Hide();
        }

        private void btnReturnSalesHistory_Click(object sender, EventArgs e)
        {
            frmSalesReturnHistory frmSalesReturnHistory = new frmSalesReturnHistory();
            frmSalesReturnHistory.Show(this);
            this.Hide();
        }

        private void btnSuppliesReturnHistory_Click(object sender, EventArgs e)
        {
            frmSuppliesReturnHistory frmSuppliesReturnHistory = new frmSuppliesReturnHistory();
            frmSuppliesReturnHistory.Show(this);

            this.Hide();
        }

        private void btnFinanceCollection_Click(object sender, EventArgs e)
        {
            frmFinanceCollection frmFinanceCollection = new frmFinanceCollection();
            frmFinanceCollection.Show(this);
            this.Hide();
        }
    }
}