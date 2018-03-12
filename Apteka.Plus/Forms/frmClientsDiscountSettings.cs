using System;
using System.ComponentModel;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

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
            ValidateTextBox((TextBox)sender, e);
        }

        private static void ValidateTextBox(TextBox textBox, CancelEventArgs e)
        {
            var stringToCheck = textBox.Text.Replace('.', ',');
            if (!double.TryParse(stringToCheck, out var _))
            {
                MessageBox.Show(@"Вы ввели неверное значение. Поле должно содержать число.", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            using (var dbSource = new DbManager(MyStoresCollection.AllStores[1].Name))
            {
                var pa = DataAccessor.CreateInstance<PropertyAccessor>(dbSource);
                var pDefaultDiscount = pa.GetByName("skidka");
                var defaultDiscount = double.Parse(pDefaultDiscount.Value.Replace('.', ','));

                tbDefaultDiscount.Text = defaultDiscount.ToString("0.0");

                var pExtraLimit = pa.GetByName("DiscountExtraLimit");
                var extraLimit = double.Parse(pExtraLimit.Value.Replace('.', ','));

                tbExtraLimit.Text = extraLimit.ToString("0.0");
            }
        }

    }
}
