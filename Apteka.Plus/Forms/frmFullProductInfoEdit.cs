using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmFullProductInfoEdit : Form
    {
        private readonly FullProductInfo _fullProductInfo;
        private List<ProductIntegrationInfo> _liProductIntegrationInfos;

        public FullProductInfo NewFullProductInfo { get; private set; }

        public frmFullProductInfoEdit(FullProductInfo fullProductInfo)
        {
            InitializeComponent();
            _fullProductInfo = fullProductInfo;
            fullProductInfoBindingSource.DataSource = _fullProductInfo;
        }

        public frmFullProductInfoEdit()
        {
            InitializeComponent();
            _fullProductInfo = new FullProductInfo();
            fullProductInfoBindingSource.DataSource = _fullProductInfo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var fpia = DataAccessor.CreateInstance<FullProductInfoAccessor>();
            if (_fullProductInfo.ID != 0)
            {
                fpia.Query.Update(_fullProductInfo);
            }
            else
            {
                var i = fpia.Insert(_fullProductInfo);
                _fullProductInfo.ID = i;
                NewFullProductInfo = _fullProductInfo;
            }

            Close();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name == "tpIntegration")
            {
                if (cboSuppliers.Items.Count == 0)
                {
                    supplierBindingSource.DataSource = SuppliersCollection.AllSuppliers;
                }

                var piia = DataAccessor.CreateInstance<ProductIntegrationInfoAccessor>();

                _liProductIntegrationInfos = piia.SelectByFullProductInfoID(_fullProductInfo.ID);

                productIntegrationInfoBindingSource.DataSource = _liProductIntegrationInfos;
            }
        }

        private void dgvProductsIntegrationInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var dgv = (DataGridView)sender;

                var value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (value == "Удалить")
                {
                    var pii = (ProductIntegrationInfo)dgv.Rows[e.RowIndex].DataBoundItem;
                    var res = MessageBox.Show($@"Вы уверены, что хотите удалить соответствие для поставщика {pii.Supplier}?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {
                        var piia = DataAccessor.CreateInstance<ProductIntegrationInfoAccessor>();

                        piia.DeleteByKey(pii.ID);
                        dgv.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void btnAddIntegrationInfo_Click(object sender, EventArgs e)
        {
            var piia = DataAccessor.CreateInstance<ProductIntegrationInfoAccessor>();
            var pii = new ProductIntegrationInfo
            {
                SupplierProductID = Convert.ToInt32(tbID.Text),
                Supplier = cboSuppliers.SelectedItem as Supplier,
                ParentFullProductInfo = _fullProductInfo
            };

            pii.ID = piia.Insert(pii);
            _liProductIntegrationInfos.Add(pii);
            productIntegrationInfoBindingSource.ResetBindings(false);
        }
    }
}
