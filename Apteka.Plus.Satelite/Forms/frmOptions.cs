using System;
using System.Windows.Forms;
using Apteka.Plus.Satelite.Properties;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }

        private void tbStoreId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var tb = (TextBox)sender;
            e.Cancel = !int.TryParse(tb.Text, out _);
            if (e.Cancel)
            {
                errorProvider1.SetError(tb, "Введите число");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void tbFontSize_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var tb = (TextBox)sender;
            e.Cancel = !(int.TryParse(tb.Text, out var result) && result > 1);
            if (e.Cancel)
            {
                errorProvider1.SetError(tb, "Введите число больше 0");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
