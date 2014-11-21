using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;

namespace Apteka.Plus.Forms
{
    public partial class frmMyStoreSelectBox : Form
    {

        private MyStore _selectedStore;

        public MyStore SelectedStore
        {
            get { return _selectedStore; }
        }

        public frmMyStoreSelectBox()
        {
            InitializeComponent();
        }

        private void frmMyStoreSelectBox_Load(object sender, EventArgs e)
        {
            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _selectedStore = (MyStore)cbMyStores.SelectedItem;
        }
    }
}
