using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;

namespace Apteka.Plus.Forms
{
    public partial class frmMyStoreSelectBox : Form
    {
        public MyStore SelectedStore { get; private set; }

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
            SelectedStore = (MyStore)cbMyStores.SelectedItem;
        }
    }
}
