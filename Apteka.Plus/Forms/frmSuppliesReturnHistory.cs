using System;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmSuppliesReturnHistory : Form
    {
        public frmSuppliesReturnHistory()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //ucSuppliesReturnHistory1.LoadData(dtpStartDate.Value.Date,dtpEndDate.Value.Date);
        }

        private void frmSuppliesReturnHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();  
        }
    }
}
