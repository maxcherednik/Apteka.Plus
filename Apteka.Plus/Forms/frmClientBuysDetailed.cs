using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;

namespace Apteka.Plus.Forms
{
    public partial class frmClientBuysDetailed : Form
    {
        private ClientSummaryRow _ClientSummaryRow;

        public frmClientBuysDetailed(ClientSummaryRow clientSummaryRow)
        {
            InitializeComponent();

            _ClientSummaryRow = clientSummaryRow;
            lblClientID.Text = _ClientSummaryRow.ClientID;
        }

        private void frmClientBuysDetailed_Load(object sender, System.EventArgs e)
        {
            dgvSales.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            List<SalesRow> liSalesRow = new List<SalesRow>();

            foreach (MyStore myStore in MyStoresCollection.AllStores)
            {
                using (DbManager dbSatelite = new DbManager(myStore.Name))
                {
                    SalesAccessor sa = SalesAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                    List<SalesRow> SalesRowTemp = sa.GetRowsByClientID(_ClientSummaryRow.ClientID);
                    SalesRowTemp.ForEach(row => row.MyStore = myStore);
                    liSalesRow.AddRange(SalesRowTemp);
                }
            }
            liSalesRow.Sort(SalesRow.DateComparison);
            liSalesRow.Reverse();
            salesRowBindingSource.DataSource = liSalesRow;

        }
    }
}
