using System;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmDefecturaOptions : Form
    {
        public frmDefecturaOptions()
        {
            InitializeComponent();
        }

       

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
