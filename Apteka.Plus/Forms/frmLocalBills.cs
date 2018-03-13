using System;
using System.Windows.Forms;
using Apteka.Plus.Common.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Properties;
using Apteka.Plus.UserControls;
using Microsoft.Reporting.WinForms;

namespace Apteka.Plus.Forms
{
    public partial class frmLocalBills : Form
    {
        public frmLocalBills()
        {
            InitializeComponent();
        }

        private void frmLocalBills_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        private void frmLocalBills_Load(object sender, EventArgs e)
        {
            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            ucGoodsViewer1.FilterByName(tbSearch.Text);
        }

        private void ucGoodsViewer1_CurrentRowChanged(object sender, ucGoodsViewer.RowChangedEventArgs e)
        {
            int daysOfStockRotation = Convert.ToInt16(Settings.Default.DaysOfStockRotation);
            int productSuppliesTopRows = Convert.ToInt16(Settings.Default.ProductSuppliesTopRows);
            ucProductSupplies1.GetInfo(e.Row.MainStoreRow.FullProductInfo, productSuppliesTopRows, daysOfStockRotation);
        }

        private void myStoreBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var myStore = (MyStore)myStoreBindingSource.Current;
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
            var frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.DefectListBySupplier.rdlc");

            var store = (MyStore)myStoreBindingSource.Current;

            var date = new ReportParameter("Date", DateTime.Now.ToString());
            var myStore = new ReportParameter("MyStore", store.Name);


            frmReportViewer.SetParameters(date, myStore);

            frmReportViewer.SetDataSource("SmartDefectRow", ucGoodsViewer1.List);
            frmReportViewer.ShowDialog();
        }
    }
}