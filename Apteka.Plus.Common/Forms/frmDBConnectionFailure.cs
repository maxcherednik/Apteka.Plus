using System.Windows.Forms;

namespace Apteka.Plus.Common.Forms
{
    public partial class frmDBConnectionFailure : Form
    {
        public frmDBConnectionFailure(string connectionString)
        {
            ConnectionString = connectionString;
            InitializeComponent();
        }

        public string ConnectionString { get; private set; }

        private void btnRetry_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            ConnectionString = tbConnectionString.Text;
        }

        private void frmDBConnectionFailure_Load(object sender, System.EventArgs e)
        {
            tbConnectionString.Text = ConnectionString;
        }
    }
}
