using System;
using System.Windows.Forms;
using Apteka.Plus.Properties;
using Apteka.Plus.UserControls;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmProductSupplies : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmProductSupplies()
        {
            InitializeComponent();
        }

        private void frmProductSupplies_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            ucFullProductInfoBase1.Init();
            ucFullProductInfoBase1.Select();
        }

        void ucFullProductInfoBase1_CurrentRowChanged(object sender, ucFullProductInfoBase.CurrentRowChangedEventArgs e)
        {
            ucProductSupplies1.GetInfo(e.FullProductInfo, 15, 25);
        }

        private void frmProductSupplies_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void frmProductSupplies_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }
    }
}
