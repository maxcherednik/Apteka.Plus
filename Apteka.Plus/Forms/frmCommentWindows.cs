using System;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmCommentWindows : Form
    {
        public frmCommentWindows()
        {
            InitializeComponent();
        }

        public string Comment { get; private set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbComment.Text.Trim() == "")
            {
                MessageBox.Show(@"Вы не ввели комментарий", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Comment = tbComment.Text;
            }
        }
    }
}
