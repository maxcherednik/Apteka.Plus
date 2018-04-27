using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Forms
{
    public partial class frmClientBuysDetailed : Form
    {
        private readonly ClientSummaryRow _clientSummaryRow;

        public frmClientBuysDetailed(ClientSummaryRow clientSummaryRow)
        {
            InitializeComponent();

            _clientSummaryRow = clientSummaryRow;
            lblClientID.Text = _clientSummaryRow.ClientID;
        }

        private void frmClientBuysDetailed_Load(object sender, System.EventArgs e)
        {
            dgvSales.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            var liSalesRow = new List<SalesRow>();

            foreach (var myStore in MyStoresCollection.AllStores)
            {
                using (var dbSatelite = new DbManager(myStore.Name))
                {
                    var sa = DataAccessor.CreateInstance<SalesAccessor>(dbSatelite);
                    var salesRowTemp = sa.GetRowsByClientID(_clientSummaryRow.ClientID);
                    salesRowTemp.ForEach(row => row.MyStore = myStore);
                    liSalesRow.AddRange(salesRowTemp);
                }
            }

            liSalesRow.Sort(SalesRow.DateComparison);
            liSalesRow.Reverse();
            salesRowBindingSource.DataSource = liSalesRow;
        }
    }
}
