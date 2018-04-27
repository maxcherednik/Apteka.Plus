using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;

namespace Apteka.Plus.Forms
{
    public partial class frmSalesReturnHistory : Form
    {
        public frmSalesReturnHistory()
        {
            InitializeComponent();
        }

        private void frmSalesReturnHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var myStore = (MyStore)cbMyStores.SelectedItem;
            ucSalesReturnHistory1.LoadData(myStore, dtpStartDate.Value, dtpEndDate.Value);
        }

        private void frmSalesReturnHistory_Load(object sender, EventArgs e)
        {
            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;
        }
    }
}
