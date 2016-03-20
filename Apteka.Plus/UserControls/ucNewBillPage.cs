using Apteka.Helpers;
using Apteka.Plus.Common.Controls;
using Apteka.Plus.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Properties;
using BLToolkit.Data;
using OrderConverter.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Apteka.Plus.UserControls
{
    public partial class UcNewBillPage : UserControl
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IList<MyStore> _liMyStores;
        private MyStore _selectedStoreForEOrder;

        private DateTime _billDate;

        public DateTime BillDate
        {
            get { return _billDate; }

        }

        public double BillSum
        {
            get
            {
                double sum = 0;
                foreach (MainStoreInsertRow mainStoreInsertRow in _liMainStoreInsertRows)
                {
                    sum += mainStoreInsertRow.SupplierPrice * mainStoreInsertRow.Amount;
                }

                return sum;

            }

        }
        private string _billNumber;
        private Supplier _supplier;

        public string BillNumber
        {
            get { return _billNumber; }

        }
        public Supplier Supplier
        {
            get { return _supplier; }
        }

        private List<MainStoreInsertRow> _liMainStoreInsertRows = new List<MainStoreInsertRow>();

        private bool _lifeImportant;

        public UcNewBillPage()
        {
            InitializeComponent();
            mainStoreInsertRowBindingSource.DataSource = _liMainStoreInsertRows;
        }

        #region Public
        public void Initialize(IList<MyStore> liMyStores)
        {
            _liMyStores = liMyStores;

            int i = 3;

            foreach (MyStore varMyStore in liMyStores)
            {
                var column = new DataGridViewTextBoxColumn();
                column.HeaderText = varMyStore.Name;
                column.Tag = varMyStore;
                column.Name = varMyStore.ID.ToString();
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                column.ValueType = typeof(int);
                dgvBill.Columns.Insert(i, column);

                i++;
            }

            dgvBill.CurrentRowChanged += new EventHandler<MyDataGridView.CurrentRowChangedEventArgs>(dgvBill_CurrentRowChanged);

        }

        void dgvBill_CurrentRowChanged(object sender, MyDataGridView.CurrentRowChangedEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            MainStoreInsertRow msir = dgv.Rows[e.RowIndex].DataBoundItem as MainStoreInsertRow;
            OnCurrentRowChange(msir.FullProductInfo);
        }

        public bool IsEverythingOK()
        {
            if (_liMainStoreInsertRows.Count == 0)
            {
                MessageBox.Show("Нечего сохранять. Вы не ввели ни одной позиции!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            int i = 0;
            foreach (var varMainStoreInsertRow in _liMainStoreInsertRows)
            {
                if (varMainStoreInsertRow.FullProductInfo.ID == 0)
                {
                    MessageBox.Show("Вы не до конца обработали накладную!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    mainStoreInsertRowBindingSource.Position = i;
                    return false;
                }

                int amountSum = 0;
                foreach (var myStoresAmount in varMainStoreInsertRow.MyStoresAmount)
                {
                    amountSum += myStoresAmount.Value;
                }

                if (amountSum != varMainStoreInsertRow.Amount)
                {
                    MessageBox.Show("Вы отпустили не все позиции!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    mainStoreInsertRowBindingSource.Position = i;
                    return false;
                }

                i++;
            }

            if (!IsLocalPricesOk())
                return false;

            return true;
        }

        private bool IsLocalPricesOk()
        {
            int i = 0;
            foreach (var row in _liMainStoreInsertRows)
            {
                if (row.IsSomethingWrongWithLocalPrice)
                {
                    if (DialogResult.Yes == MessageBox.Show("Цены на некоторые позиции отличаются от предыдущих! Вы уверены, что хотите сохранить накладную так как есть? ",
                        "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                    {
                        return true;
                    }
                    else
                    {
                        mainStoreInsertRowBindingSource.Position = i;
                        return false;
                    }
                }
                i++;
            }

            return true;
        }

        public bool IsBillOpen
        {
            get
            {
                return _liMainStoreInsertRows.Count > 0;
            }
        }

        public void SaveNewBill(bool delayLocalBills)
        {

            DbManager dbSklad = new DbManager();

            try
            {

                dbSklad.BeginTransaction();
                MainStoreRowsAccessor msra = MainStoreRowsAccessor.CreateInstance<MainStoreRowsAccessor>(dbSklad);

                int i = 0;
                foreach (MainStoreInsertRow varMainStoreInsertRow in _liMainStoreInsertRows)
                {
                    OnProcessNotification("Подготовка данных для сохраниения", i, _liMainStoreInsertRows.Count);

                    #region New MainStoreRow Preparing
                    MainStoreRow newMainStoreRow = new MainStoreRow();
                    newMainStoreRow.Amount = varMainStoreInsertRow.Amount;
                    newMainStoreRow.StartAmount = varMainStoreInsertRow.Amount;
                    newMainStoreRow.SupplierPrice = varMainStoreInsertRow.SupplierPrice;
                    newMainStoreRow.Extra = varMainStoreInsertRow.Extra;
                    newMainStoreRow.LocalPrice = varMainStoreInsertRow.LocalPrice;
                    newMainStoreRow.FullProductInfo = varMainStoreInsertRow.FullProductInfo;
                    newMainStoreRow.Series = varMainStoreInsertRow.Series;
                    newMainStoreRow.ExpirationDate = varMainStoreInsertRow.ExpirationDate;
                    newMainStoreRow.EAN13 = varMainStoreInsertRow.EAN13;
                    newMainStoreRow.DateSupply = _billDate;
                    newMainStoreRow.Supplier = _supplier;
                    newMainStoreRow.SupplierBillNumber = _billNumber;

                    #endregion

                    long id = msra.Insert(newMainStoreRow);
                    newMainStoreRow.ID = id;
                    varMainStoreInsertRow.MainStoreRow = newMainStoreRow;

                    i++;

                }

                dbSklad.CommitTransaction();

                OnProcessNotification("Сохраниение в базу данных", 0, dgvBill.RowCount);

            }
            catch (Exception)
            {
                dbSklad.RollbackTransaction();
                OnProcessNotification("Ошибка сохранения! Данные не сохранены!", 0, dgvBill.RowCount);

                throw;
            }

            foreach (MyStore varMyStore in _liMyStores)
            {
                DbManager db = new DbManager(varMyStore.Name);
                try
                {
                    dbSklad.BeginTransaction();
                    db.BeginTransaction();
                    PropertyAccessor pa = PropertyAccessor.CreateInstance<PropertyAccessor>(db);
                    Property pLocalBillNumber = pa.GetByName("LocalBillNumber");
                    long LocalBillNumber = long.Parse(pLocalBillNumber.Value);

                    LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);
                    MainStoreRowsAccessor msra = MainStoreRowsAccessor.CreateInstance<MainStoreRowsAccessor>(dbSklad);

                    bool SaveFlag = false;
                    foreach (MainStoreInsertRow varMainStoreInsertRow in _liMainStoreInsertRows)
                    {

                        int myStoresAmount = 0;

                        if (varMainStoreInsertRow.MyStoresAmount.TryGetValue(varMyStore.ID, out myStoresAmount))
                        {
                            LocalBillsRowEx newLocalBillsRowEx = new LocalBillsRowEx();
                            newLocalBillsRowEx.StartAmount = myStoresAmount;
                            newLocalBillsRowEx.Amount = myStoresAmount;
                            newLocalBillsRowEx.CurrentPrice = varMainStoreInsertRow.LocalPrice;
                            newLocalBillsRowEx.StartPrice = varMainStoreInsertRow.LocalPrice;
                            newLocalBillsRowEx.MainStoreRow = varMainStoreInsertRow.MainStoreRow;
                            newLocalBillsRowEx.LocalBillNumber = LocalBillNumber;
                            newLocalBillsRowEx.DateAccepted = DateTime.Today.Date;
                            newLocalBillsRowEx.IsDelayed = delayLocalBills;

                            lba.Insert(newLocalBillsRowEx);
                            msra.ChangeAmount(newLocalBillsRowEx.MainStoreRow.ID, -1 * newLocalBillsRowEx.Amount);
                            SaveFlag = true;
                        }

                    }
                    if (SaveFlag == true)
                    {
                        LocalBillNumber++;
                        pLocalBillNumber.Value = LocalBillNumber.ToString();
                        pa.Update(pLocalBillNumber);
                    }

                    db.CommitTransaction();
                    dbSklad.CommitTransaction();
                }
                catch (Exception)
                {
                    OnProcessNotification("Ошибка сохранения! Данные не сохранены!", 0, dgvBill.RowCount);

                    dbSklad.RollbackTransaction();
                    db.RollbackTransaction();
                    throw;
                }
            }
            mainStoreInsertRowBindingSource.Clear();

            MessageBox.Show("Накладная успешно сохранена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #endregion

        #region CurrentRowChanged
        public event EventHandler<CurrentRowChangedEventArgs> CurrentRowChanged;

        private void OnCurrentRowChange(FullProductInfo fullProductInfo)
        {
            if (CurrentRowChanged != null)
            {
                CurrentRowChangedEventArgs e = new CurrentRowChangedEventArgs(fullProductInfo);
                CurrentRowChanged.Invoke(dgvBill, e);
            }

        }
        public class CurrentRowChangedEventArgs : EventArgs
        {
            public CurrentRowChangedEventArgs(FullProductInfo fullProductInfo)
            {
                FullProductInfo = fullProductInfo;
            }

            public FullProductInfo FullProductInfo
            {
                get;
                private set;
            }
        }
        #endregion

        public event EventHandler<ProcessNotificationEventArgs> ProcessNotification;
        public class ProcessNotificationEventArgs : EventArgs
        {
            public ProcessNotificationEventArgs(string currentAction, int currentValue, int maxValue)
            {
                CurrentAction = currentAction;
                CurrentValue = currentValue;
                MaxValue = maxValue;
            }

            public string CurrentAction { get; private set; }
            public int CurrentValue { get; private set; }
            public int MaxValue { get; private set; }

        }
        protected virtual void OnProcessNotification(string currentAction, int currentValue, int maxValue)
        {
            if (ProcessNotification != null)
                ProcessNotification(this, new ProcessNotificationEventArgs(currentAction, currentValue, maxValue));
        }

        private void dgvBill_KeyUp(object sender, KeyEventArgs e)
        {
            log.InfoFormat("Пользователь нажал клавишу {0}", e.KeyCode);
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    {
                        frmMainStoreInsertNewPosition frmMainStoreInsertNewPosition = new frmMainStoreInsertNewPosition();
                        if (frmMainStoreInsertNewPosition.ShowDialog() == DialogResult.OK)
                        {
                            _liMainStoreInsertRows.Add(frmMainStoreInsertNewPosition.NewMainStoreInsertRow);
                            mainStoreInsertRowBindingSource.ResetBindings(false);

                            mainStoreInsertRowBindingSource.MoveLast();

                        }

                        break;
                    }
                case Keys.Delete:
                    {
                        if (mainStoreInsertRowBindingSource.Current != null)
                            mainStoreInsertRowBindingSource.RemoveCurrent();
                        break;
                    }

            }
        }

        private void ucNewBillPage_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            dgvBill.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        private void dgvBill_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            MainStoreInsertRow row = dgv.Rows[e.RowIndex].DataBoundItem as MainStoreInsertRow;

            foreach (MyStore varMyStore in _liMyStores)
            {

                if (varMyStore.ID.ToString() == dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
                {
                    int myStoresAmount = 0;
                    if (row.MyStoresAmount.TryGetValue(varMyStore.ID, out myStoresAmount))
                    {
                        e.Value = myStoresAmount;
                    }
                    else
                    {
                        e.Value = "";
                        e.FormattingApplied = true;
                    }
                }
            }

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "LocalPrice":
                    {
                        if (row.IsSomethingWrongWithLocalPrice)
                        {

                            if (row.IsLocalPriceGrows)
                            {
                                e.CellStyle.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                e.CellStyle.BackColor = Color.Red;
                            }
                        }

                    }
                    break;
            }

        }

        private void dgvBill_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                MainStoreInsertRow mainStoreInsertCurrentRow = dgv.Rows[e.RowIndex].DataBoundItem as MainStoreInsertRow;

                switch (cell.OwningColumn.Name)
                {
                    case "ProductName":
                        {
                            frmFullProductInfoSelectBox frmFullProductInfoSelectBox = new frmFullProductInfoSelectBox();

                            if (frmFullProductInfoSelectBox.ShowDialog(this) == DialogResult.OK)
                            {

                                FullProductInfo selectedFullProductInfo = (FullProductInfo)frmFullProductInfoSelectBox.FullProductInfoSelected;
                                mainStoreInsertCurrentRow.FullProductInfo = selectedFullProductInfo;

                                if (mainStoreInsertCurrentRow.ProductIntegrationInfo != null)
                                {

                                    ProductIntegrationInfoAccessor piia = ProductIntegrationInfoAccessor.CreateInstance<ProductIntegrationInfoAccessor>();
                                    piia.DeleteByKey(mainStoreInsertCurrentRow.ProductIntegrationInfo.ID);

                                    ProductIntegrationInfo pii = new ProductIntegrationInfo();
                                    pii.SupplierProductID = mainStoreInsertCurrentRow.ProductIntegrationInfo.SupplierProductID;
                                    pii.Supplier = _supplier;
                                    pii.ParentFullProductInfo = selectedFullProductInfo;
                                    pii.ID = piia.Insert(pii);
                                    mainStoreInsertCurrentRow.ProductIntegrationInfo = pii;

                                    ProcessEOrderRow(_selectedStoreForEOrder, mainStoreInsertCurrentRow);
                                }
                                mainStoreInsertRowBindingSource.ResetCurrentItem();

                            }

                        }
                        break;

                    case "Amount":
                    case "LocalPrice":
                    case "SupplierPrice":
                    case "Extra":
                        {
                            //dgv.CurrentCell = dgv.CurrentRow.Cells["LocalPrice"];
                            dgv.BeginEdit(true);
                        }
                        break;

                }
            }
        }

        private void dgvBill_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            MainStoreInsertRow MainStoreInsertRow = dgv.CurrentRow.DataBoundItem as MainStoreInsertRow;

            switch (cell.OwningColumn.Name)
            {
                case "Amount":
                    {
                        if (cell.IsInEditMode)
                        {
                            int Amount;
                            string sAmount = cell.EditedFormattedValue.ToString().Replace(",", ".");

                            if (int.TryParse(sAmount, out Amount))
                            {
                                if (Amount < 0)
                                {
                                    MessageBox.Show("Количество не может быть отрицательном", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    e.Cancel = true;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Вы ввели некорректное значение! Допускаются только числа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                e.Cancel = true;
                            }

                        }

                    }
                    break;

                case "LocalPrice":
                    {
                        if (cell.IsInEditMode)
                        {
                            double LocalPrice;
                            string newPrice = cell.EditedFormattedValue.ToString().Replace(",", ".");

                            if (double.TryParse(newPrice, out LocalPrice))
                            {
                                if (LocalPrice < 0)
                                {
                                    MessageBox.Show("Цена не может быть отрицательной", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    e.Cancel = true;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Вы ввели некорректное значение! Допускаются только числа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                e.Cancel = true;
                            }

                        }

                    }
                    break;

                case "SupplierPrice":
                    {
                        if (cell.IsInEditMode)
                        {
                            double SupplierPrice;
                            string newPrice = cell.EditedFormattedValue.ToString().Replace(",", ".");

                            if (double.TryParse(newPrice, out SupplierPrice))
                            {
                                if (SupplierPrice < 0)
                                {
                                    MessageBox.Show("Цена не может быть отрицательной", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    e.Cancel = true;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Вы ввели некорректное значение! Допускаются только числа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                e.Cancel = true;
                            }

                        }

                    }
                    break;

                case "Extra":
                    {
                        if (cell.IsInEditMode)
                        {
                            double Extra;
                            string newExtra = cell.EditedFormattedValue.ToString().Replace(",", ".");

                            if (double.TryParse(newExtra, out Extra))
                            {
                                if (Extra < 0)
                                {
                                    MessageBox.Show("Наценка не может быть отрицательной", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    e.Cancel = true;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Вы ввели некорректное значение! Допускаются только числа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                e.Cancel = true;
                            }

                        }

                    }
                    break;

            }
        }

        private void dgvBill_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                //case "Amount":
                //    {
                //        MainStoreInsertRow mainStoreInsertRow = dgv.Rows[e.RowIndex].DataBoundItem as MainStoreInsertRow;

                //        string newPrice = e.Value.ToString().Replace(",", ".");
                //        double dNewPrice = double.Parse(newPrice);
                //        e.Value = dNewPrice;

                //        mainStoreInsertRow.Extra = ((dNewPrice - mainStoreInsertRow.SupplierPrice) / mainStoreInsertRow.SupplierPrice) * 100.0;

                //        e.ParsingApplied = true;
                //    }
                //    break;

                case "LocalPrice":
                    {
                        MainStoreInsertRow mainStoreInsertRow = dgv.Rows[e.RowIndex].DataBoundItem as MainStoreInsertRow;

                        string newPrice = e.Value.ToString().Replace(",", ".");
                        double dNewPrice = double.Parse(newPrice);
                        e.Value = dNewPrice;

                        mainStoreInsertRow.Extra = ((dNewPrice - mainStoreInsertRow.SupplierPrice) / mainStoreInsertRow.SupplierPrice) * 100.0;

                        e.ParsingApplied = true;
                    }
                    break;

                case "SupplierPrice":
                    {
                        MainStoreInsertRow mainStoreInsertRow = dgv.Rows[e.RowIndex].DataBoundItem as MainStoreInsertRow;

                        string newPrice = e.Value.ToString().Replace(",", ".");
                        double dNewPrice = double.Parse(newPrice);
                        e.Value = dNewPrice;

                        mainStoreInsertRow.LocalPrice = dNewPrice + dNewPrice * mainStoreInsertRow.Extra / 100.0;

                        e.ParsingApplied = true;
                    }
                    break;

                case "Extra":
                    {
                        MainStoreInsertRow mainStoreInsertRow = dgv.Rows[e.RowIndex].DataBoundItem as MainStoreInsertRow;

                        string newExtra = e.Value.ToString().Replace(",", ".");
                        double dnewExtra = double.Parse(newExtra);
                        e.Value = dnewExtra;

                        mainStoreInsertRow.LocalPrice = mainStoreInsertRow.SupplierPrice + mainStoreInsertRow.SupplierPrice * dnewExtra / 100.0;

                        e.ParsingApplied = true;
                    }
                    break;

            }
        }

        internal void ProcessEOrder(List<LocalOrder> liLocalOrderRows, MyStore selectedStore, bool LifeImportant)
        {
            _selectedStoreForEOrder = selectedStore;
            _lifeImportant = LifeImportant;
            List<MainStoreInsertRow> liNewMainStoreInsertRows = new List<MainStoreInsertRow>(liLocalOrderRows.Count);
            foreach (LocalOrder varLocalOrderRow in liLocalOrderRows)
            {
                MainStoreInsertRow newMainStoreInsertRow = new MainStoreInsertRow();
                newMainStoreInsertRow.EOrderRow = varLocalOrderRow;

                ProcessEOrderRow(_selectedStoreForEOrder, newMainStoreInsertRow);

                liNewMainStoreInsertRows.Add(newMainStoreInsertRow);

            }

            AddNewRows(liNewMainStoreInsertRows);
        }

        internal void ProcessEOrderRow(MyStore selectedStore, MainStoreInsertRow newMainStoreInsertRow)
        {
            newMainStoreInsertRow.Amount = newMainStoreInsertRow.EOrderRow.Count;
            newMainStoreInsertRow.SupplierPrice = newMainStoreInsertRow.EOrderRow.SupplierPriceWithNDS;
            newMainStoreInsertRow.VendorPriceWithoutNDS = newMainStoreInsertRow.EOrderRow.VendorPriceWithoutNDS;
            newMainStoreInsertRow.Series = newMainStoreInsertRow.EOrderRow.Series;
            newMainStoreInsertRow.ExpirationDate = newMainStoreInsertRow.EOrderRow.ExpirationDate;
            newMainStoreInsertRow.EAN13 = newMainStoreInsertRow.EOrderRow.EAN13;

            #region ProductName searching

            ProductIntegrationInfoAccessor piia = ProductIntegrationInfoAccessor.CreateInstance<ProductIntegrationInfoAccessor>();
            FullProductInfoAccessor fpia = FullProductInfoAccessor.CreateInstance<FullProductInfoAccessor>();

            DbManager db = new DbManager(selectedStore.Name);
            LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);
            ProductIntegrationInfo productIntegrationInfo = piia.Get(newMainStoreInsertRow.EOrderRow.SupplierProductID, _supplier.ID);
            FullProductInfo fullProductInfo = null;
            if (productIntegrationInfo == null)
            {
                productIntegrationInfo = new ProductIntegrationInfo();
                newMainStoreInsertRow.ProductIntegrationInfo = productIntegrationInfo;

                productIntegrationInfo.SupplierProductID = newMainStoreInsertRow.EOrderRow.SupplierProductID;
                productIntegrationInfo.Supplier.ID = _supplier.ID;

            }
            else
            {
                newMainStoreInsertRow.ProductIntegrationInfo = productIntegrationInfo;
                fullProductInfo = fpia.SelectByKey(productIntegrationInfo.ParentFullProductInfo.ID);
            }

            #endregion

            #region Price Processing

            if (newMainStoreInsertRow.EOrderRow.NDS == 10 && (_lifeImportant || newMainStoreInsertRow.EOrderRow.IsLifeImportant))
            {

                double chosenPrice = newMainStoreInsertRow.EOrderRow.VendorPriceWithoutNDS;
                double extra = 0;
                if (newMainStoreInsertRow.EOrderRow.VendorPriceWithNDS < 200)
                {
                    extra = 0.28;
                }
                else if (newMainStoreInsertRow.EOrderRow.VendorPriceWithNDS >= 200 &&
                         newMainStoreInsertRow.EOrderRow.VendorPriceWithNDS < 500)
                {
                    extra = 0.25;
                }
                else
                {
                    extra = 0.18;
                }

                newMainStoreInsertRow.LocalPrice = RoundDown(newMainStoreInsertRow.SupplierPrice + chosenPrice * extra, 0.05);
                newMainStoreInsertRow.Extra = ((newMainStoreInsertRow.LocalPrice -
                                                newMainStoreInsertRow.SupplierPrice) /
                                               newMainStoreInsertRow.SupplierPrice) * 100.0;
            }
            else
            {
                double standardExtra = double.Parse(Settings.Default.StandartExtra);
                if (newMainStoreInsertRow.SupplierPrice < 100)
                {
                    standardExtra = 28.0;
                }
                else if (newMainStoreInsertRow.SupplierPrice >= 100 && newMainStoreInsertRow.SupplierPrice < 200)
                {
                    standardExtra = 25.0;
                }
                else if (newMainStoreInsertRow.SupplierPrice >= 200 && newMainStoreInsertRow.SupplierPrice < 500)
                {
                    standardExtra = 20.0;
                }
                else if (newMainStoreInsertRow.SupplierPrice >= 500)
                {
                    standardExtra = 15.0;
                }

                newMainStoreInsertRow.LocalPrice = RoundUp(newMainStoreInsertRow.SupplierPrice + newMainStoreInsertRow.SupplierPrice * standardExtra / 100.0, 0.5);
                newMainStoreInsertRow.Extra = standardExtra;

            }

            #endregion

            #region Divider
            if (fullProductInfo != null)
            {
                newMainStoreInsertRow.FullProductInfo = fullProductInfo;

                // делитель проверка

                if (newMainStoreInsertRow.FullProductInfo.Divider > 0)
                {
                    newMainStoreInsertRow.Amount = newMainStoreInsertRow.Amount * newMainStoreInsertRow.FullProductInfo.Divider;
                    newMainStoreInsertRow.LocalPrice = newMainStoreInsertRow.LocalPrice / newMainStoreInsertRow.FullProductInfo.Divider;
                    newMainStoreInsertRow.SupplierPrice = newMainStoreInsertRow.SupplierPrice / newMainStoreInsertRow.FullProductInfo.Divider;
                }

            }
            #endregion

            newMainStoreInsertRow.MyStoresAmount.Clear();
            newMainStoreInsertRow.MyStoresAmount.Add(selectedStore.ID, newMainStoreInsertRow.Amount);

            #region Prev LocalPrice Checking

            List<LocalBillsRowEx> liLastSupplies = lba.GetProductSupplies(newMainStoreInsertRow.FullProductInfo.ID, 1, DateTime.Today.AddDays(-365));

            if (liLastSupplies.Count != 0)
            {
                newMainStoreInsertRow.PrevLocalPrice = liLastSupplies[0].CurrentPrice;
            }
            #endregion

        }

        private static double RoundDown(double value, Double roundto)
        {
            // 105.5 down to nearest 1 = 105
            // 105.5 down to nearest 10 = 100
            // 105.5 down to nearest 7 = 105
            // 105.5 down to nearest 100 = 100
            // 105.5 down to nearest 0.2 = 105.4
            // 105.5 down to nearest 0.3 = 105.3

            //if no roundto then just pass original number back
            if (roundto == 0)
            {
                return value;
            }
            else
            {
                return Math.Floor(value / roundto) * roundto;
            }
        }

        private static double RoundUp(double value, Double roundto)
        {
            // 105.5 up to nearest 1 = 106
            // 105.5 up to nearest 10 = 110
            // 105.5 up to nearest 7 = 112
            // 105.5 up to nearest 100 = 200
            // 105.5 up to nearest 0.2 = 105.6
            // 105.5 up to nearest 0.3 = 105.6

            //if no roundto then just pass original number back
            if (roundto == 0)
            {
                return value;
            }
            else
            {
                return Math.Ceiling(value / roundto) * roundto;
            }
        }


        internal void AddNewRows(List<MainStoreInsertRow> liNewMainStoreInsertRows)
        {
            _liMainStoreInsertRows.AddRange(liNewMainStoreInsertRows);
            mainStoreInsertRowBindingSource.ResetBindings(false);
            mainStoreInsertRowBindingSource.MoveLast();
        }
        internal void UpdateOrderInfo(DateTime billDate, string billNumber, Supplier supplier)
        {
            _billDate = billDate;
            _billNumber = billNumber;
            _supplier = supplier;
        }
    }
}
