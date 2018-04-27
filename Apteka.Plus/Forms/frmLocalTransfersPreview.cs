using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmLocalTransfersPreview : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LocalBillsTransferInfoRow LocalBillsTransferInfoSelected;

        public frmLocalTransfersPreview()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LocalBillsTransferInfoSelected = localBillsTransferInfoRowBindingSource.Current as LocalBillsTransferInfoRow;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmLocalTransfersPreview_Load(object sender, EventArgs e)
        {
            dgvLocalTransfersInfo.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());

            var liLocalBillsTransferInfoRow = new List<LocalBillsTransferInfoRow>();

            foreach (var myStore in MyStoresCollection.AllStores)
            {
                List<LocalBillsTransferInfoRow> liLocalBillsTransferInfoRowTemp;
                using (var dbSatelite = new DbManager(myStore.Name))
                {
                    var lbta = DataAccessor.CreateInstance<LocalBillsTransfersAccessor>(dbSatelite);
                    liLocalBillsTransferInfoRowTemp = lbta.GetTransfersInfoList();
                    liLocalBillsTransferInfoRowTemp.ForEach(row => row.SourceStore = myStore);
                    liLocalBillsTransferInfoRow.AddRange(liLocalBillsTransferInfoRowTemp);
                }

                if (MyStoresCollection.AllStores.Count == 2)
                {
                    foreach (var item in MyStoresCollection.AllStores)
                    {
                        if (item.ID != myStore.ID)
                        {
                            liLocalBillsTransferInfoRowTemp.ForEach(row => row.DestinationStore = item);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"У Вас более 3 пунктов. Обратитесь к разработчикам.", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                    return;
                }

            }

            if (liLocalBillsTransferInfoRow.Count == 0)
            {
                Close();
                return;
            }

            localBillsTransferInfoRowBindingSource.DataSource = liLocalBillsTransferInfoRow;
        }

        private void dgvLocalTransfersInfo_KeyDown(object sender, KeyEventArgs e)
        {
            Log.DebugFormat("Key down:{0}", e.KeyCode.ToString());

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LocalBillsTransferInfoSelected = (LocalBillsTransferInfoRow)localBillsTransferInfoRowBindingSource.Current;
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
