using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmFullProductInfoSelectBox : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmFullProductInfoSelectBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            FullProductInfo fpi = ucFullProductInfoBase1.SeletedItem;
            if (fpi != null)
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить " + fpi.ProductName + " " + fpi.PackageName + " из списка препаратов?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    FullProductInfoAccessor fpia = FullProductInfoAccessor.CreateInstance<FullProductInfoAccessor>();
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
