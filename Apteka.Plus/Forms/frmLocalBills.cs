using System;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Properties;
using Apteka.Plus.UserControls;
using Microsoft.Reporting.WinForms;

namespace Apteka.Plus.Forms
{
    public partial class frmLocalBills : Form
    {
        #region Private fields
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Constructor
        public frmLocalBills()
        {
            InitializeComponent();
        }
        #endregion

        private void frmLocalBills_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        private void frmLocalBills_Load(object sender, EventArgs e)
        {
            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            ucGoodsViewer1.FilterByName( tbSearch.Text);
        }


        private void ucGoodsViewer1_CurrentRowChanged(object sender, ucGoodsViewer.RowChangedEventArgs e)
        {
            int DaysForAnalysis = Convert.ToInt16(Settings.Default.DaysForAnalysis);
            int DaysOfStockRotation = Convert.ToInt16(Settings.Default.DaysOfStockRotation);
            int ProductSuppliesTopRows = Convert.ToInt16(Settings.Default.ProductSuppliesTopRows);
            ucProductSupplies1.GetInfo(e.Row.MainStoreRow.FullProductInfo, ProductSuppliesTopRows, DaysOfStockRotation);
        }

        private void myStoreBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            MyStore myStore = myStoreBindingSource.Current as MyStore;
            ucGoodsViewer1.LoadByLetter(myStore, tbSearch.Text);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Checked)
            {
                ucGoodsViewer1.FilterByDate(dateTimePicker1.Value);
            }
            else
            {
                ucGoodsViewer1.ClearDateFilter();
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                tbSearch.Text = "";
            }
        }

        private void ucGoodsViewer1_RowCountChanged(object sender, ucGoodsViewer.RowCountChangedEventArgs e)
        {
            btnPrint.Enabled = e.RowCount > 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportViewer frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.DefectListBySupplier.rdlc");

            MyStore store = myStoreBindingSource.Current as MyStore;

            ReportParameter Date = new ReportParameter("Date", DateTime.Now.ToString());
            ReportParameter MyStore = new ReportParameter("MyStore", store.Name);
            

            frmReportViewer.SetParameters(Date, MyStore);

            frmReportViewer.SetDataSource("SmartDefectRow", ucGoodsViewer1.List);
            frmReportViewer.ShowDialog();
        }
    }
}