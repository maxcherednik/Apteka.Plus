using System;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
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
            var dictIps = UserSettings.GetAllOverridedIps();

            for (var i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = (MyStore)dataGridView1.Rows[i].DataBoundItem;

                if (dictIps.TryGetValue(row.ID, out var ip))
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
            var dictIps = new Dictionary<int, string>();
            for (var i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = (MyStore)dataGridView1.Rows[i].DataBoundItem;
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
