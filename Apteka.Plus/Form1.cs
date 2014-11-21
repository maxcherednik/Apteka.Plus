using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Apteka.Plus.LowLevelControls;

namespace Apteka.Plus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filterBar1.ShowGraphicsButtonPressed += new EventHandler<FilterBar.ShowGraphicsButtonPressedEventArgs>(filterBar1_ShowGraphicsButtonPressed);
        }

        void filterBar1_ShowGraphicsButtonPressed(object sender, FilterBar.ShowGraphicsButtonPressedEventArgs e)
        {
            filterBar1.DateTimePickerType = FilterBar.DateRange.Month;
        }
    }
}
