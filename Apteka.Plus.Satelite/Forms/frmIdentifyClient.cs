using System;
using System.Windows.Forms;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmIdentifyClient : Form
    {
        private string _clientId;

        public frmIdentifyClient()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _clientId = tbClientID.Text;
        }

        public string ClientID
        {
            get
            {
                return _clientId;
            }
        }
    }
}
