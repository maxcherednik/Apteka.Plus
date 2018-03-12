using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmFullProductInfoSelectBox : Form
    {
        public FullProductInfo FullProductInfoSelected { get; private set; }

        public frmFullProductInfoSelectBox()
        {
            InitializeComponent();
        }

        private void tsbAddNew_Click(object sender, EventArgs e)
        {
            using (var frmFullProductInfoEdit = new frmFullProductInfoEdit())
            {
                frmFullProductInfoEdit.ShowDialog(this);
                if (frmFullProductInfoEdit.NewFullProductInfo != null)
                {
                    ucFullProductInfoBase1.AddNewItem(frmFullProductInfoEdit.NewFullProductInfo);
                }
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            using (var frmFullProductInfoEdit = new frmFullProductInfoEdit(ucFullProductInfoBase1.SeletedItem))
            {
                frmFullProductInfoEdit.ShowDialog(this);
            }
        }

        private void frmFullProductInfoSelectBox_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            ucFullProductInfoBase1.Init();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FullProductInfoSelected = ucFullProductInfoBase1.SeletedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmFullProductInfoSelectBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var fpi = ucFullProductInfoBase1.SeletedItem;

            if (fpi != null)
            {
                var res = MessageBox.Show($@"Вы уверены, что хотите удалить {fpi.ProductName} {fpi.PackageName} из списка препаратов?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    var fpia = DataAccessor.CreateInstance<FullProductInfoAccessor>();
                    fpia.MarkAsDeleted(fpi);
                    ucFullProductInfoBase1.RemoveItem(fpi);
                }
            }
        }

        private void ucFullProductInfoBase1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.PerformClick();
            }
        }
    }
}
