using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Apteka.Plus.Logic.DAL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;

namespace Apteka.Plus.Forms
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            //ProductsGateway productsGateway = new ProductsGateway();
            //IList<Product> liProducts = ProductsCollection.GetAllProducts;
            //comboBox1.DisplayMember = "Name";
            //comboBox1.ValueMember = "id";
            //comboBox1.DataSource = liProducts;
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedIndex.ToString();
            
            
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true; 
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}