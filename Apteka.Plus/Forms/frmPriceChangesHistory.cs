using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using System;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmPriceChangesHistory : Form
    {
        private MyStore _mystoreSelected;

        public frmPriceChangesHistory()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            PerformLoadData();
        }

        private void PerformLoadData()
        {
            _mystoreSelected = (MyStore)cbMyStores.SelectedItem;

            ucPriceChangesHistory1.LoadData(_mystoreSelected, dtpDate.Value.Date, dtpDate.Value.Date);

            tsslSum.Text = $@"Изменения на сумму: {ucPriceChangesHistory1.DiffSum:### ##0.00}";
        }

        public void LoadDataFor(MyStore mystore, DateTime date)
        {
            cbMyStores.SelectedItem = mystore;
            dtpDate.Value = date;

            PerformLoadData();
        }

        private void frmPriceChangesHistory_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;
        }
    }
}
