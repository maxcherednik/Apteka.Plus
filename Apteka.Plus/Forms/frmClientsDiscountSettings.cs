using System;
using System.ComponentModel;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.Forms
{
    public partial class frmClientsDiscountSettings : Form
    {
        public frmClientsDiscountSettings()
        {
            InitializeComponent();
        }

        private void tbDefaultDiscount_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBox((TextBox)sender,e);
        }

        private void ValidateTextBox(TextBox textBox,CancelEventArgs e)
        {
            string stringToCheck = textBox.Text.Replace('.', ',');
            if (!Double.TryParse(stringToCheck, out double doubleValue))
            {
                MessageBox.Show("Вы ввели неверное значение. Поле должно содержать число.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                textBox.SelectAll();
            }
        }

        private void tbExtraLimit_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBox((TextBox)sender, e);
        }

        private void frmClientsDiscountSettings_Load(object sender, EventArgs e)
        {
            DbManager dbSource = new DbManager(MyStoresCollection.AllStores[1].Name);
            PropertyAccessor pa = PropertyAccessor.CreateInstance<PropertyAccessor>(dbSource);
            Property pDefaultDiscount = pa.GetByName("skidka");
            double defaultDiscount = double.Parse(pDefaultDiscount.Value.Replace('.', ','));

            tbDefaultDiscount.Text = defaultDiscount.ToString("0.0");

            Property pExtraLimit = pa.GetByName("DiscountExtraLimit");
            double extraLimit = double.Parse(pExtraLimit.Value.Replace('.', ','));

            tbExtraLimit.Text = extraLimit.ToString("0.0");
            
        }

    }
}
