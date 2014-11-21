using System;
using System.ComponentModel;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Entities;

namespace Apteka.Plus.Forms
{
    public partial class frmMainStoreInsertNewPosition : Form
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        bool _isEdit = false;
        MainStoreInsertRow _MainStoreInsertRow;
        MainStoreInsertRow _MainStoreInsertRowJustAdded;

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

                FullProductInfo selectedFullProductInfo = (FullProductInfo)frmFullProductInfoSelectBox.FullProductInfoSelected;

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
                if (this.Validate())
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
            int intAmount;
            if (!int.TryParse(strAmount, out intAmount))
            {
                e.Cancel = true;
            }
        }

        private void tbSupplierPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.Validate())
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
            
            //else if (e.KeyCode==)
            //{

            //}
        }

        private void tbSupplierPrice_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string strSupplierPrice = tb.Text;
            double doubleSupplierPrice;
            if (!double.TryParse(strSupplierPrice, out doubleSupplierPrice))
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
                //case Keys.F2:
                //    {

                //        break;
                //    }
                //default:
                //    MessageBox.Show(e.KeyValue.ToString());
                //    break;
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
            int iApteka48 = 0;
            int iApteka7B = 0;
            if (int.TryParse(tbApteka48.Text, out iApteka48))
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

            if (int.TryParse(tbApteka7B.Text, out iApteka7B))
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbSupplierPrice_TextChanged(object sender, EventArgs e)
        {

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
                if (this.Validate())
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
                if (this.Validate())
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
                if (this.Validate())
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
                if (this.Validate())
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

            DateTime dtExpirationDate;
            if (!DateTime.TryParse(strExpirationDate, out dtExpirationDate))
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
                e.KeyChar='.';
                
            }
        }
    }
}
