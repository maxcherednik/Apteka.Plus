using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmSuppliesReturnConfirmation : Form
    {
        private bool _deleteAll;

        private bool _deleteAmount;

        private string _comment;

        private int _amount;

        public frmSuppliesReturnConfirmation()
        {
            InitializeComponent();
        }

        public bool IsDeleteAll
        {
            get { return _deleteAll; }
        }

        public bool IsDeleteAmount
        {
            get { return _deleteAmount; }
        }

        public string Comment
        {
            get { return _comment; }
        }

        public int Amount
        {
            get { return _amount; }
        }

        private void rbDeleteAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDeleteAmount.Checked == true)
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
                MessageBox.Show("Вы не ввели комментарий", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbComment.Select();
            }
            else
            {
                DialogResult = DialogResult.OK;
                _deleteAll = rbDeleteAll.Checked;
                _deleteAmount = rbDeleteAmount.Checked;
                _comment = tbComment.Text;

                Close();
            }
        }

        private void tbAmount_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string strAmount = tb.Text;

            if (int.TryParse(strAmount, out int intAmount))
            {
                if (intAmount <= 0)
                {
                    MessageBox.Show("Количество должно быть больше 0", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("Вы ввели некорректное значение! Допускаются только числа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }

            _amount = intAmount;
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
