using System;
using System.ComponentModel;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Entities;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmMainStoreInsertNewPosition : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly bool _isEdit;
        private readonly MainStoreInsertRow _mainStoreInsertRow;

        public MainStoreInsertRow NewMainStoreInsertRow { get; private set; }

        public frmMainStoreInsertNewPosition(MainStoreInsertRow mainStoreInsertRow)
        {
            InitializeComponent();
            _mainStoreInsertRow = mainStoreInsertRow;
            mainStoreInsertRowBindingSource.DataSource = _mainStoreInsertRow;
            _isEdit = true;
        }

        public frmMainStoreInsertNewPosition()
        {
            InitializeComponent();
            _mainStoreInsertRow = new MainStoreInsertRow();
            mainStoreInsertRowBindingSource.DataSource = _mainStoreInsertRow;
        }

        private void btnChooseProduct_Click(object sender, EventArgs e)
        {
            ShowProductSelectBox();
        }

        private void ShowProductSelectBox()
        {
            var frmFullProductInfoSelectBox = new frmFullProductInfoSelectBox();

            if (frmFullProductInfoSelectBox.ShowDialog(this) == DialogResult.OK)
            {
                var selectedFullProductInfo = frmFullProductInfoSelectBox.FullProductInfoSelected;

                fullProductInfoBindingSource.DataSource = selectedFullProductInfo;
                _mainStoreInsertRow.FullProductInfo = selectedFullProductInfo;

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
                    MessageBox.Show(@"Введен недопустимый символ!");
                    tbAmount.SelectAll();
                }
            }
        }

        private void tbAmount_Validating(object sender, CancelEventArgs e)
        {
            var tb = (TextBox)sender;
            var strAmount = tb.Text;

            if (!int.TryParse(strAmount, out var _))
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
                    _mainStoreInsertRow.Extra = 22.00;
                    _mainStoreInsertRow.LocalPrice = _mainStoreInsertRow.SupplierPrice + _mainStoreInsertRow.SupplierPrice * _mainStoreInsertRow.Extra / 100.00;
                    mainStoreInsertRowBindingSource.ResetBindings(false);
                    tbExpirationDate.Select();
                }
                else
                {
                    MessageBox.Show(@"Введен недопустимый символ!");
                    tbAmount.SelectAll();
                }
            }
        }

        private void tbSupplierPrice_Validating(object sender, CancelEventArgs e)
        {
            var tb = (TextBox)sender;
            var strSupplierPrice = tb.Text;

            if (!double.TryParse(strSupplierPrice, out var doubleSupplierPrice))
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
            Log.InfoFormat("Пользователь нажал клавишу {0}", e.KeyCode);
            if (e.KeyCode == Keys.Insert) ShowProductSelectBox();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PerformOk();
        }

        private void PerformOk()
        {
            _mainStoreInsertRow.FullProductInfo = (FullProductInfo)fullProductInfoBindingSource.DataSource;

            // делитель проверка

            if (_mainStoreInsertRow.FullProductInfo.Divider > 0)
            {
                _mainStoreInsertRow.Amount = _mainStoreInsertRow.Amount * _mainStoreInsertRow.FullProductInfo.Divider;
                _mainStoreInsertRow.LocalPrice = _mainStoreInsertRow.LocalPrice / _mainStoreInsertRow.FullProductInfo.Divider;
                _mainStoreInsertRow.SupplierPrice = _mainStoreInsertRow.SupplierPrice / _mainStoreInsertRow.FullProductInfo.Divider;
            }

            _mainStoreInsertRow.MyStoresAmount.Clear();
            //TODO СДЕЛАТЬ ДИНАМИЧЕСКИ
            if (int.TryParse(tbApteka48.Text, out var iApteka48))
            {
                if (iApteka48 > 0)
                {
                    if (_mainStoreInsertRow.FullProductInfo.Divider > 0)
                    {
                        _mainStoreInsertRow.MyStoresAmount.Add(1, iApteka48 * _mainStoreInsertRow.FullProductInfo.Divider);
                    }
                    else
                    {
                        _mainStoreInsertRow.MyStoresAmount.Add(1, iApteka48);
                    }
                }
            }

            if (int.TryParse(tbApteka7B.Text, out var iApteka7B))
            {
                if (iApteka7B > 0)
                {
                    if (_mainStoreInsertRow.FullProductInfo.Divider > 0)
                    {
                        _mainStoreInsertRow.MyStoresAmount.Add(2, iApteka7B * _mainStoreInsertRow.FullProductInfo.Divider);
                    }
                    else
                    {
                        _mainStoreInsertRow.MyStoresAmount.Add(2, iApteka7B);
                    }
                }
            }

            NewMainStoreInsertRow = _mainStoreInsertRow;
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
                    MessageBox.Show(@"Введен недопустимый символ!");
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
                    MessageBox.Show(@"Введен недопустимый символ!");
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
                    MessageBox.Show(@"Введен недопустимый символ!");
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
                    MessageBox.Show(@"Введен недопустимый символ!");
                    tbApteka48.SelectAll();
                }
            }
        }

        private void tbExpirationDate_Validating(object sender, CancelEventArgs e)
        {
            var tb = (TextBox)sender;
            var strExpirationDate = tb.Text.Trim();

            if (strExpirationDate == "")
                return;

            if (!DateTime.TryParse(strExpirationDate, out var _))
            {
                e.Cancel = true;
            }
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
