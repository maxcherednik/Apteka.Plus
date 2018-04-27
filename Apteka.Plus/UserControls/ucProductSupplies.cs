using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using log4net;

namespace Apteka.Plus.UserControls
{
    public partial class ucProductSupplies : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool _isInited;
        private int _daysOfStockRotation;
        private FullProductInfo _selectedProduct;
        private int _topRows;

        public ucProductSupplies()
        {
            InitializeComponent();
        }

        private void Init()
        {
            Log.DebugFormat("Init controls");
            tabControl1.TabPages.Clear();

            foreach (var myStore in MyStoresCollection.AllStores)
            {
                var ucProductSuppliesTable = new ucProductSuppliesTable(myStore)
                {
                    Dock = DockStyle.Fill
                };

                tabControl1.TabPages.Add(myStore.ID.ToString(), myStore.Name);

                tabControl1.TabPages[myStore.ID.ToString()].Controls.Add(ucProductSuppliesTable);
                tabControl1.TabPages[myStore.ID.ToString()].Tag = ucProductSuppliesTable;
            }

            _isInited = true;
        }

        public void GetInfo(FullProductInfo fullProductInfo, int topRows, int daysOfStockRotation)
        {
            Log.DebugFormat("Get info: {0} - {1}", fullProductInfo.ProductName, fullProductInfo.PackageName);

            if (!_isInited)
                Init();
            _daysOfStockRotation = daysOfStockRotation;

            _selectedProduct = fullProductInfo;

            _topRows = topRows;

            LoadProductSupplesForSelectedTab();
        }

        private void LoadProductSupplesForSelectedTab()
        {
            var productSuppliesTable = (ucProductSuppliesTable) tabControl1.SelectedTab.Tag;
            productSuppliesTable.LoadProductSupples(_selectedProduct, _topRows, _daysOfStockRotation);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == null) return;

            LoadProductSupplesForSelectedTab();
        }
    }
}
