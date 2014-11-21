using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.Forms
{
    public partial class frmLocalTransfersPreview : Form
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LocalBillsTransferInfoRow LocalBillsTransferInfoSelected;
        public frmLocalTransfersPreview()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LocalBillsTransferInfoSelected = localBillsTransferInfoRowBindingSource.Current as LocalBillsTransferInfoRow;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmLocalTransfersPreview_Load(object sender, EventArgs e)
        {
            dgvLocalTransfersInfo.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());

            List<LocalBillsTransferInfoRow> liLocalBillsTransferInfoRow = new List<LocalBillsTransferInfoRow>();

            foreach (MyStore myStore in MyStoresCollection.AllStores)
            {
                List<LocalBillsTransferInfoRow> liLocalBillsTransferInfoRowTemp;
                using (DbManager dbSatelite = new DbManager(myStore.Name))
                {
                    LocalBillsTransfersAccessor lbta = LocalBillsTransfersAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);
                    liLocalBillsTransferInfoRowTemp = lbta.GetTransfersInfoList();
                    liLocalBillsTransferInfoRowTemp.ForEach(row => row.SourceStore = myStore);
                    liLocalBillsTransferInfoRow.AddRange(liLocalBillsTransferInfoRowTemp);
                }

                if (MyStoresCollection.AllStores.Count == 2)
                {
                    foreach (MyStore item in MyStoresCollection.AllStores)
                    {
                        if (item.ID != myStore.ID)
                        {
                            liLocalBillsTransferInfoRowTemp.ForEach(row => row.DestinationStore = item);
                        }
                    }
                }
                else
                {

                    MessageBox.Show("У Вас более 3 пунктов. Обратитесь к разработчикам.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

            }

            if (liLocalBillsTransferInfoRow.Count == 0)
            {
                this.Close();
                return;
            }
            localBillsTransferInfoRowBindingSource.DataSource = liLocalBillsTransferInfoRow;

        }

        private void dgvLocalTransfersInfo_KeyDown(object sender, KeyEventArgs e)
        {
            log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            DataGridView dgv = sender as DataGridView;

            switch (e.KeyCode)
            {

                case Keys.Enter:
                    {

                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        LocalBillsTransferInfoSelected = localBillsTransferInfoRowBindingSource.Current as LocalBillsTransferInfoRow;
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    break;

                case Keys.Escape:
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();

                    }
                    break;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
