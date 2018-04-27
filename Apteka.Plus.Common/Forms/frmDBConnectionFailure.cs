using System.Windows.Forms;

namespace Apteka.Plus.Common.Forms
{
    public partial class frmDBConnectionFailure : Form
    {
        public frmDBConnectionFailure(string dbHost, string dbUser, string dbPassword)
        {
            DbHost = dbHost;
            DbUser = dbUser;
            DbPassword = dbPassword;
            InitializeComponent();
        }

        public string DbHost { get; private set; }
        public string DbUser { get; private set; }
        public string DbPassword { get; private set; }

        private void btnRetry_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            DbHost = tbDbHost.Text;
            DbUser = tbDbUserName.Text;
            DbPassword = tbDbPassword.Text;
        }

        private void frmDBConnectionFailure_Load(object sender, System.EventArgs e)
        {
            tbDbHost.Text = DbHost;
            tbDbUserName.Text = DbUser;
            tbDbPassword.Text = DbPassword;
        }
    }
}
