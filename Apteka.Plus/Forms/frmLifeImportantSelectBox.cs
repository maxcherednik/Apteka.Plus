using System;
using System.Windows.Forms;

namespace Apteka.Plus.Forms
{
    public partial class frmLifeImportantSelectBox : Form
    {
        private bool _selectedIsLifeImportant = false;

        public frmLifeImportantSelectBox()
        {
            InitializeComponent();
        }

        public bool SelectedIsLifeImportant
        {
            get { return _selectedIsLifeImportant; }
        }

        private void frmLifeImportantSelectBox_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _selectedIsLifeImportant = cbIsLifeImportant.Checked;
        }
    }
}
