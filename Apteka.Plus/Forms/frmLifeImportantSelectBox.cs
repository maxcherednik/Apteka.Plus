using System;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmLifeImportantSelectBox : Form
    {
        public frmLifeImportantSelectBox()
        {
            InitializeComponent();
        }

        public bool SelectedIsLifeImportant { get; private set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedIsLifeImportant = cbIsLifeImportant.Checked;
        }
    }
}
