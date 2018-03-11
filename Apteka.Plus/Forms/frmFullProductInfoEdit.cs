using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;

namespace Apteka.Plus.Forms
{
    public partial class frmFullProductInfoEdit : Form
    {
        private FullProductInfo _FullProductInfo;
        private FullProductInfo _FullProductInfoJustAdded;
        private List<ProductIntegrationInfo> _liProductIntegrationInfos;

        public FullProductInfo NewFullProductInfo
        {
            get { return _FullProductInfoJustAdded; }
        }

        public frmFullProductInfoEdit(FullProductInfo FullProductInfo)
        {
            InitializeComponent();
            _FullProductInfo = FullProductInfo;
            fullProductInfoBindingSource.DataSource = _FullProductInfo;
        }

        public frmFullProductInfoEdit()
        {
            InitializeComponent();
            _FullProductInfo = new FullProductInfo();
            fullProductInfoBindingSource.DataSource = _FullProductInfo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FullProductInfoAccessor fpia = FullProductInfoAccessor.CreateInstance<FullProductInfoAccessor>();
            if (_FullProductInfo.ID != 0)
            {

                int i = fpia.Query.Update(_FullProductInfo);
            }
            else
            {
                long i = fpia.Insert(_FullProductInfo);
                _FullProductInfo.ID = i;
                _FullProductInfoJustAdded = _FullProductInfo;
            }
            this.Close();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name == "tpIntegration")
            {

                if (cboSuppliers.Items.Count == 0)
                {
                    supplierBindingSource.DataSource = SuppliersCollection.AllSuppliers;
                }

                ProductIntegrationInfoAccessor piia = ProductIntegrationInfoAccessor.CreateInstance<ProductIntegrationInfoAccessor>();

                _liProductIntegrationInfos = piia.SelectByFullProductInfoID(_FullProductInfo.ID);

                productIntegrationInfoBindingSource.DataSource = _liProductIntegrationInfos;

            }
        }

        private void dgvProductsIntegrationInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;

                string value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (value == "Удалить")
                {
                    ProductIntegrationInfo pii = dgv.Rows[e.RowIndex].DataBoundItem as ProductIntegrationInfo;
                    DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить соответствие для поставщика " + pii.Supplier + "?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        ProductIntegrationInfoAccessor piia = ProductIntegrationInfoAccessor.CreateInstance<ProductIntegrationInfoAccessor>();

                        piia.DeleteByKey(pii.ID);
                        dgv.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void btnAddIntegrationInfo_Click(object sender, EventArgs e)
        {
            ProductIntegrationInfoAccessor piia = ProductIntegrationInfoAccessor.CreateInstance<ProductIntegrationInfoAccessor>();
            ProductIntegrationInfo pii = new ProductIntegrationInfo
            {
                SupplierProductID = Convert.ToInt32(tbID.Text),
                Supplier = cboSuppliers.SelectedItem as Supplier,
                ParentFullProductInfo = _FullProductInfo
            };

            pii.ID = piia.Insert(pii);
            _liProductIntegrationInfos.Add(pii);
            productIntegrationInfoBindingSource.ResetBindings(false);
        }
    }
}
