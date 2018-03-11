using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Properties;
using System.Collections.Generic;
using Apteka.Plus.SettingsUtils;

namespace Apteka.Plus.Forms
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            myStoreBindingSource.DataSource = MyStoresCollection.AllStores;

            RestoreOverrridedIPs();
        }

        private void RestoreOverrridedIPs()
        {
            Dictionary<int, String> dictIps = UserSettings.GetAllOverridedIps();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i].DataBoundItem as MyStore;

                if (dictIps.TryGetValue(row.ID, out string ip))
                {
                    dataGridView1["overridedIP", i].Value = ip;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOverridedIPs();
        }

        private void SaveOverridedIPs()
        {
            Dictionary<int, String> dictIps = new Dictionary<int, string>();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i].DataBoundItem as MyStore;
                if (dataGridView1["overridedIP", i].Value != null
                    && !string.IsNullOrEmpty(((string)dataGridView1["overridedIP", i].Value).Trim()))
                {
                    dictIps.Add(row.ID, dataGridView1["overridedIP", i].Value.ToString());

                }
            }
            UserSettings.SaveOverridedIps(dictIps);

            MyStoresCollection.Refresh();
            Close();
        }
    }
}
