using System;
using System.Windows.Forms;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmIdentifyClient : Form
    {
        public frmIdentifyClient()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ClientId = tbClientID.Text;
        }

        public string ClientId { get; private set; }
    }
}
