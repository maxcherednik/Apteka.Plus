using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmSuppliesReturnConfirmation : Form
    {
        public frmSuppliesReturnConfirmation()
        {
            InitializeComponent();
        }

        public bool IsDeleteAll { get; private set; }

        public bool IsDeleteAmount { get; private set; }

        public string Comment { get; private set; }

        public int Amount { get; private set; }

        private void rbDeleteAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDeleteAmount.Checked)
            {
                tbAmount.Enabled = true;
                tbAmount.Select();
            }
            else
            {
                tbAmount.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbComment.Text.Trim() == "")
            {
                MessageBox.Show(@"Вы не ввели комментарий", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbComment.Select();
            }
            else
            {
                DialogResult = DialogResult.OK;
                IsDeleteAll = rbDeleteAll.Checked;
                IsDeleteAmount = rbDeleteAmount.Checked;
                Comment = tbComment.Text;

                Close();
            }
        }

        private void tbAmount_Validating(object sender, CancelEventArgs e)
        {
            var tb = (TextBox)sender;
            var strAmount = tb.Text;

            if (int.TryParse(strAmount, out var intAmount))
            {
                if (intAmount <= 0)
                {
                    MessageBox.Show(@"Количество должно быть больше 0", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show(@"Вы ввели некорректное значение! Допускаются только числа.", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }

            Amount = intAmount;
        }

        private void tbAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Validate())
                {
                    tbComment.Select();
                }
                else
                {
                    tbAmount.SelectAll();
                }
            }
        }
    }
}
