using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Apteka.Plus.Logic.OrderConverter.BLL;
using Apteka.Plus.Logic.OrderConverter.DAL;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmConvertOrder : Form
    {
        private IExternalOrderMappingAccessor _externalOrderMappingAccessor;

        public frmConvertOrder()
        {
            InitializeComponent();

            _externalOrderMappingAccessor = DataAccessor.CreateInstance<ExternalOrderMappingAccessor>();
        }

        public IList<LocalOrder> ConvertedOrder;
        public string SupplierName;
        public string FileName;
        private IList<ExternalOrderSupplier> _externalSuppliers;

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (liFirms.SelectedIndex == -1)
            {
                MessageBox.Show(@"Вы не выбрали фирму", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var gwForeignOrderAccessor = new DbfFileReader(openFileDialog1.FileName);

                var selectedSupplier = (ExternalOrderSupplier)liFirms.SelectedItem;

                var externalSupplierFieldsMapping = _externalOrderMappingAccessor.GetMappingFor(selectedSupplier);

                var liLocalOrderRows = gwForeignOrderAccessor.GetLocalOrderRows(externalSupplierFieldsMapping.ToDictionary(item => item.LocalName, item => item.ExternalName));

                var file = new FileInfo(openFileDialog1.FileName);

                var di = file.Directory;
                foreach (var fileInfo in di.GetFiles("*.dbf"))
                {
                    if (fileInfo.CreationTime < DateTime.Today.AddDays(-2))
                        fileInfo.Delete();
                }

                FileName = file.Name;

                SupplierName = liFirms.Text;
                ConvertedOrder = liLocalOrderRows;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnAddOrderMapping_Click(object sender, EventArgs e)
        {
            new frmExternalOrderMapEditor(_externalOrderMappingAccessor).ShowDialog(this);
            LoadData();
        }

        private void btnEditOrderMapping_Click(object sender, EventArgs e)
        {
            var selectedSupplier = (ExternalOrderSupplier)liFirms.SelectedItem;
            new frmExternalOrderMapEditor(_externalOrderMappingAccessor, selectedSupplier).ShowDialog(this);
            LoadData();
        }

        private void btnDeleteOrderMapping_Click(object sender, EventArgs e)
        {
            var selectedSupplier = (ExternalOrderSupplier)liFirms.SelectedItem;

            var res = MessageBox.Show($@"Вы уверены, что хотите удалить фирму {selectedSupplier.Name}?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {   
                _externalOrderMappingAccessor.Delete(selectedSupplier);

                _externalSuppliers.Remove(selectedSupplier);
                liFirms.DataSource = new List<ExternalOrderSupplier>(_externalSuppliers);

                if (_externalSuppliers.Count == 0)
                {
                    btnDeleteOrderMapping.Enabled = false;
                    btnEditOrderMapping.Enabled = false;
                }
            }
        }

        private void liFirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditOrderMapping.Enabled = true;
            btnDeleteOrderMapping.Enabled = true;
        }

        private void frmConvertOrder_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _externalSuppliers = _externalOrderMappingAccessor.GetSuppliers();
            liFirms.DataSource = _externalSuppliers;
        }
    }
}