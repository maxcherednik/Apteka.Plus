using System;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmCommentWindows : Form
    {
        private string _comment;

        public frmCommentWindows()
        {
            InitializeComponent();
        }

        public string Comment { get { return _comment; } }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbComment.Text.Trim()=="")
            {
                MessageBox.Show("Вы не ввели комментарий","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                _comment = tbComment.Text;
            }
        }
    }
}
