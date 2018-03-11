using System;
using System.ComponentModel;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Entities;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmMainStoreInsertNewPosition : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private bool _isEdit = false;
        private MainStoreInsertRow _MainStoreInsertRow;
        private MainStoreInsertRow _MainStoreInsertRowJustAdded;

        public MainStoreInsertRow NewMainStoreInsertRow
        {
            get { return _MainStoreInsertRowJustAdded; }
        }

        public frmMainStoreInsertNewPosition(MainStoreInsertRow MainStoreInsertRow)
        {
            InitializeComponent();
            _MainStoreInsertRow = MainStoreInsertRow;
            mainStoreInsertRowBindingSource.DataSource = _MainStoreInsertRow;
            _isEdit = true;
        }
        public frmMainStoreInsertNewPosition()
        {
            InitializeComponent();
            _MainStoreInsertRow = new MainStoreInsertRow();
            mainStoreInsertRowBindingSource.DataSource = _MainStoreInsertRow;
        }

        private void btnChooseProduct_Click(object sender, EventArgs e)
        {
            ShowProductSelectBox();
        }

        private void ShowProductSelectBox()
        {
            frmFullProductInfoSelectBox frmFullProductInfoSelectBox = new frmFullProductInfoSelectBox();

            if (frmFullProductInfoSelectBox.ShowDialog(this) == DialogResult.OK)
            {

                FullProductInfo selectedFullProductInfo = frmFullProductInfoSelectBox.FullProductInfoSelected;

                fullProductInfoBindingSource.DataSource = selectedFullProductInfo;
                _MainStoreInsertRow.FullProductInfo = selectedFullProductInfo;

                ucProductSupplies1.GetInfo(selectedFullProductInfo, 15, 25);

                tbAmount.Select();
            }
        }

        private void tbAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Validate())
                {
                    tbSupplierPrice.Select();
                }
                else
                {
                    MessageBox.Show("Введен недопустимый символ!");
                    tbAmount.SelectAll();
                }
            }
        }

        private void tbAmount_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string strAmount = tb.Text;
            if (!int.TryParse(strAmount, out int intAmount))
            {
                e.Cancel = true;
            }
        }

        private void tbSupplierPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Validate())
                {
                    _MainStoreInsertRow.Extra = 22.00;
                    _MainStoreInsertRow.LocalPrice = _MainStoreInsertRow.SupplierPrice + _MainStoreInsertRow.SupplierPrice * _MainStoreInsertRow.Extra / 100.00;
                    mainStoreInsertRowBindingSource.ResetBindings(false);
                    tbExpirationDate.Select();
                }
                else
                {
                    MessageBox.Show("Введен недопустимый символ!");
                    tbAmount.SelectAll();
                }
            }
        }

        private void tbSupplierPrice_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string strSupplierPrice = tb.Text;

            if (!double.TryParse(strSupplierPrice, out double doubleSupplierPrice))
            {
                e.Cancel = true;
            }

            if (doubleSupplierPrice < 0)
            {
                e.Cancel = true;
            }
        }

        private void frmMainStoreInsertNewPosition_KeyDown(object sender, KeyEventArgs e)
        {
            log.InfoFormat("Пользователь нажал клавишу {0}", e.KeyCode);
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    {
                        ShowProductSelectBox();

                        break;
                    }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PerformOk();
        }

        private void PerformOk()
        {
            _MainStoreInsertRow.FullProductInfo = (FullProductInfo)fullProductInfoBindingSource.DataSource;

            // делитель проверка

            if (_MainStoreInsertRow.FullProductInfo.Divider > 0)
            {
                _MainStoreInsertRow.Amount = _MainStoreInsertRow.Amount * _MainStoreInsertRow.FullProductInfo.Divider;
                _MainStoreInsertRow.LocalPrice = _MainStoreInsertRow.LocalPrice / _MainStoreInsertRow.FullProductInfo.Divider;
                _MainStoreInsertRow.SupplierPrice = _MainStoreInsertRow.SupplierPrice / _MainStoreInsertRow.FullProductInfo.Divider;
            }

            _MainStoreInsertRow.MyStoresAmount.Clear();
            //TODO СДЕЛАТЬ ДИНАМИЧЕСКИ
            if (int.TryParse(tbApteka48.Text, out int iApteka48))
            {
                if (iApteka48 > 0)
                {
                    if (_MainStoreInsertRow.FullProductInfo.Divider > 0)
                    {
                        _MainStoreInsertRow.MyStoresAmount.Add(1, iApteka48 * _MainStoreInsertRow.FullProductInfo.Divider);
                    }
                    else
                    {
                        _MainStoreInsertRow.MyStoresAmount.Add(1, iApteka48);
                    }
                }
            }

            if (int.TryParse(tbApteka7B.Text, out int iApteka7B))
            {
                if (iApteka7B > 0)
                {
                    if (_MainStoreInsertRow.FullProductInfo.Divider > 0)
                    {
                        _MainStoreInsertRow.MyStoresAmount.Add(2, iApteka7B * _MainStoreInsertRow.FullProductInfo.Divider);
                    }
                    else
                    {
                        _MainStoreInsertRow.MyStoresAmount.Add(2, iApteka7B);
                    }

                }
            }

            _MainStoreInsertRowJustAdded = _MainStoreInsertRow;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMainStoreInsertNewPosition_Shown(object sender, EventArgs e)
        {
            if (_isEdit != true)
            {
                ShowProductSelectBox();
            }
        }

        private void tbExpirationDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Validate())
                {
                    tbSeries.Select();
                }
                else
                {
                    MessageBox.Show("Введен недопустимый символ!");
                    tbExpirationDate.SelectAll();
                }
            }
        }

        private void tbSeries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Validate())
                {
                    tbApteka48.Select();
                }
                else
                {
                    MessageBox.Show("Введен недопустимый символ!");
                    tbSeries.SelectAll();
                }
            }
        }

        private void tbApteka7B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Validate())
                {
                    PerformOk();
                }
                else
                {
                    MessageBox.Show("Введен недопустимый символ!");
                    tbApteka7B.SelectAll();
                }
            }
        }

        private void tbApteka48_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Validate())
                {
                    tbApteka7B.Select();
                }
                else
                {
                    MessageBox.Show("Введен недопустимый символ!");
                    tbApteka48.SelectAll();
                }
            }
        }

        private void tbExpirationDate_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string strExpirationDate = tb.Text.Trim();
            if (strExpirationDate == "")
                return;

            if (!DateTime.TryParse(strExpirationDate, out DateTime dtExpirationDate))
            {
                e.Cancel = true;
            }
        }

        private void tbSeries_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string strSeries = tb.Text.Trim();
            if (strSeries == "")
                return;
        }

        private void tbApteka48_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void tbApteka7B_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void tbSupplierPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }
        }
    }
}
