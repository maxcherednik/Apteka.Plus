using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmSuppliesReturnHistory : Form
    {
        public frmSuppliesReturnHistory()
        {
            InitializeComponent();
        }

        private void frmSuppliesReturnHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();  
        }
    }
}
