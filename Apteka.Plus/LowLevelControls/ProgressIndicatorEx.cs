using System.Windows.Forms;

namespace Apteka.Plus.LowLevelControls
{
    public partial class ProgressIndicatorEx : UserControl
    {
        public ProgressIndicatorEx()
        {
            InitializeComponent();
        }

        private void ProgressIndicatorEx_VisibleChanged(object sender, System.EventArgs e)
        {
            if (!DesignMode && Visible)
            {
                progressIndicator1.Start();
            }
            else
            {
                progressIndicator1.Stop();
            }
        }
    }
}
