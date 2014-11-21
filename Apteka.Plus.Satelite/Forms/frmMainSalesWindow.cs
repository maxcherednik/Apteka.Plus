using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.CashRegister;
using Apteka.Plus.CashRegister.FP5200;
using Apteka.Plus.Forms;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Satelite.Properties;
using BLToolkit.Data;
using Microsoft.Reporting.WinForms;
using RSDN;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmMainSalesWindow : Form
    {
        #region Private Fields
        private readonly static Logger _log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ICashRegister _cashRegister = new FPrint5200();
        readonly Employee _currentEmployee;
        readonly MyStore _currentStore;

        List<LocalBillsRowEx> _liLocalBillRowsList;
        List<SalesRow> _liSalesRows = new List<SalesRow>();

        bool _isPriceUpdatedListEnabled = false;

        private bool _isDiscountActive;
        private float _discount;
        private int _daysWarning;
        private double _discountExtraLimit;

        #endregion

        public frmMainSalesWindow(Employee empl)
        {
            InitializeComponent();

            _currentEmployee = empl;
            tsEmployeeName.Text = empl.FullName;
            tsCurrentDate.Text = DateTime.Now.Date.ToShortDateString();

            int _storeID = int.Parse(Settings.Default.SateliteID);

            _currentStore = MyStoresCollection.AllStores.Find(store => _storeID == store.ID);

            InitializeDaysWarning();
            InitializeDiscountExtraLimit();

        }

        private void tsbCopyData_Click(object sender, EventArgs e)
        {
            frmCopyDataMenu frmCopyDataMenu = new frmCopyDataMenu();
            frmCopyDataMenu.ShowDialog(this);
        }

        private void frmMainSalesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            frmOptions frmOptions = new frmOptions();
            frmOptions.ShowDialog(this);

            ApplyStyle();
        }

        private void ApplyStyle()
        {
            Font f = new Font(this.Font.FontFamily, Convert.ToSingle(Settings.Default.FontSizeBase));
            this.Font = f;

            splitContainer2.SplitterDistance = splitContainer2.Height - (tbSearch.Top + tbSearch.Height + tbSearch.Top);
            splitContainer3.SplitterDistance = splitContainer3.Height - (tbSearch.Top + tbSearch.Height + tbSearch.Top);

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_isPriceUpdatedListEnabled)
            {
                if (tbSearch.Text.Length == 1)
                {
                    LoadLocalBillsByLetter(tbSearch.Text[0].ToString());
                    localBillsRowExBindingSource.MoveFirst();

                }
                else if (tbSearch.Text.Length > 1)
                {

                    List<LocalBillsRowEx> liFiltered = _liLocalBillRowsList.FindAll(delegate(LocalBillsRowEx p)
                    {
                        return p.ProductName.StartsWith(tbSearch.Text, StringComparison.CurrentCultureIgnoreCase);

                    });

                    localBillsRowExBindingSource.DataSource = liFiltered;
                    localBillsRowExBindingSource.MoveFirst();
                }
            }
        }

        private void dgvLocalBills_KeyDown(object sender, KeyEventArgs e)
        {
            _log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            DataGridView dgv = sender as DataGridView;

            switch (e.KeyCode)
            {

                case Keys.Back:
                    {
                        if (tbSearch.Text.Length != 0)
                        {
                            tbSearch.Text = tbSearch.Text.Substring(0, tbSearch.Text.Length - 1);
                        }

                        e.SuppressKeyPress = true;
                    }

                    break;

                case Keys.Enter:
                    {
                        if (dgv.CurrentRow != null)
                        {
                            dgv.CurrentCell = dgv.CurrentRow.Cells["Count"];
                            dgv.BeginEdit(true);
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;

                    }
                    break;

                case Keys.Escape:
                    {

                        tbSearch.Text = "";
                        localBillsRowExBindingSource.DataSource = _liLocalBillRowsList;

                        e.SuppressKeyPress = true;
                    }
                    break;

                case Keys.Tab:
                    {
                        dgvLocalBillsToSale.Select();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;

                case Keys.F2:
                    {
                        PerformSale();
                    }
                    break;

                case Keys.F6:
                    {
                        PerformTransfer();
                    }
                    break;
                case Keys.F7:
                    {
                        PerformDiscount();
                    }
                    break;

                case Keys.F8:
                    {
                        ShowCalculator();

                    }
                    break;

                case Keys.F10:
                    {
                        ShowClientIdentifyForm();
                    }
                    break;

                case Keys.F12:
                    {
                        LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>();

                        LocalBillsRowEx row = dgv.CurrentRow.DataBoundItem as LocalBillsRowEx;
                        if (row.IsPriceUpdated)
                        {
                            row.IsPriceUpdated = false;

                        }
                        else
                        {
                            row.IsPriceUpdated = true;

                        }

                        lba.UpdatePriceChangedMark(row.ID, row.IsPriceUpdated);
                        localBillsRowExBindingSource.MoveNext();

                    }
                    break;
            }
        }

        private void PerformDiscount()
        {
            if (_isDiscountActive)
            {
                _isDiscountActive = false;
                lblDiscountValue.Visible = false;
                tbDiscountValue.Visible = false;
                lblDiscountSum.Visible = false;
                tbDiscountSum.Visible = false;
                dgvLocalBillsToSale.Columns["PriceWithDiscount"].Visible = false;
                dgvLocalBillsToSale.Columns["Sum"].Visible = true;
                UpdateSum();

            }
            else
            {
                _isDiscountActive = true;
                lblDiscountValue.Visible = true;
                tbDiscountValue.Visible = true;
                lblDiscountSum.Visible = true;
                tbDiscountSum.Visible = true;
                dgvLocalBillsToSale.Columns["PriceWithDiscount"].Visible = true;
                dgvLocalBillsToSale.Columns["Sum"].Visible = false;
                _discount = GetDefaultDiscount();
                UpdateSum();
            }
        }

        private void ShowClientIdentifyForm()
        {
            frmIdentifyClient frmIdentifyClient = new frmIdentifyClient();

            if (frmIdentifyClient.ShowDialog(this) == DialogResult.OK)
            {
                lblClientCaption.Visible = true;
                lblClientID.Visible = true;
                lblDiscountValue.Visible = true;
                tbDiscountValue.Visible = true;
                lblDiscountSum.Visible = true;
                tbDiscountSum.Visible = true;
                lblClientID.Text = frmIdentifyClient.ClientID;
                dgvLocalBillsToSale.Columns["PriceWithDiscount"].Visible = true;
                dgvLocalBillsToSale.Columns["Sum"].Visible = false;
                _isDiscountActive = true;
                _discount = GetDiscountForClient(frmIdentifyClient.ClientID);
                if (float.IsNaN(_discount))
                {
                    _discount = GetDefaultDiscount();
                }

                UpdateSum();

            }
            else
            {
                lblClientCaption.Visible = false;
                lblClientID.Visible = false;
                lblDiscountValue.Visible = false;
                tbDiscountValue.Visible = false;
                lblDiscountSum.Visible = false;
                tbDiscountSum.Visible = false;
                lblClientID.Text = "";
                dgvLocalBillsToSale.Columns["PriceWithDiscount"].Visible = false;
                dgvLocalBillsToSale.Columns["Sum"].Visible = true;
                _isDiscountActive = false;
                UpdateSum();
            }
        }

        private float GetDiscountForClient(string clientId)
        {
            ClientAccessor clientAccessor = ClientAccessor.CreateInstance<ClientAccessor>();
            Client client = clientAccessor.Query.SelectByKey(clientId);

            if (client != null)
            {
                _log.InfoFormat("Found client {0} with discount {1}", client.Id, client.Discount);
                return client.Discount;
            }
            else
            {
                _log.InfoFormat("Can't find discount for client {0}", clientId);
                return float.NaN;
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                tbSearch.Text = "";
                e.SuppressKeyPress = true;
            }
        }

        private void dgvLocalBills_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbSearch.Text = tbSearch.Text + e.KeyChar;
        }

        private void frmMainSalesWindow_Load(object sender, EventArgs e)
        {
            ApplyStyle();

            dgvLocalBills.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            dgvLocalBillsToSale.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());

            LoadLocalBillsByLetter("А");

            salesRowBindingSource.DataSource = _liSalesRows;

        }

        private void LoadLocalBillsByLetter(string letter)
        {
            LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>();
            _liLocalBillRowsList = lba.GetRowsByStartLetter(letter);

            localBillsRowExBindingSource.DataSource = _liLocalBillRowsList;
        }

        private void LoadLocalBillsWithChangedPrices()
        {
            LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>();
            _liLocalBillRowsList = lba.GetRowsWithChangedPrices();

            localBillsRowExBindingSource.DataSource = _liLocalBillRowsList;
            localBillsRowExBindingSource.MoveFirst();
        }

        private void dgvLocalBillsToSale_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            SalesRow row = dgv.Rows[e.RowIndex].DataBoundItem as SalesRow;
            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "Sum":
                    {
                        if (row != null)
                        {
                            e.Value = row.Price * row.Count;
                        }
                    }
                    break;
                case "PriceWithDiscount":
                    {
                        if (row.Price != row.PriceWithDiscount)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(255, 224, 192);
                        }
                    }
                    break;

                default:
                    break;
            }

        }

        private void dgvLocalBillsToSale_KeyDown(object sender, KeyEventArgs e)
        {
            _log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            DataGridView dgv = sender as DataGridView;

            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        SalesRow row = dgv.CurrentRow.DataBoundItem as SalesRow;

                        _liSalesRows.Remove(row);
                        if (_liSalesRows.Count == 0)
                        {
                            HideCalculator();
                            dgvLocalBills.Select();

                        }

                        salesRowBindingSource.ResetBindings(false);
                        dgvLocalBills.Refresh();

                        e.SuppressKeyPress = true;
                        UpdateSum();
                        PerformCalculation();
                    }

                    break;

                case Keys.Tab:
                    {
                        dgvLocalBills.Select();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;

                case Keys.F2:
                    {
                        PerformSale();
                    }
                    break;

                case Keys.F6:
                    {
                        PerformTransfer();
                    }
                    break;
                case Keys.F7:
                    {
                        PerformDiscount();
                    }
                    break;

                case Keys.F8:
                    {
                        ShowCalculator();
                    }
                    break;

                case Keys.F10:
                    {
                        ShowClientIdentifyForm();
                    }
                    break;
            }
        }

        private void PerformTransfer()
        {
            if (_liSalesRows.Count == 0) return;

            DialogResult res = MessageBox.Show("Передача товара очень ответственная операция! Вы уверены?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                using (DbManager db = new DbManager())
                {
                    db.BeginTransaction();
                    LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);
                    LocalBillsTransfersAccessor lbta = LocalBillsTransfersAccessor.CreateInstance<LocalBillsTransfersAccessor>(db);

                    foreach (SalesRow salesRow in _liSalesRows)
                    {
                        int i = lba.ChangeAmount(salesRow.LocalBillsRow.ID, -1 * salesRow.Count);
                        if (i != 0)
                        {
                            LocalBillsTransferRow trRow = new LocalBillsTransferRow();
                            trRow.Price = salesRow.Price;
                            trRow.Count = salesRow.Count;
                            trRow.LocalBillsRow = salesRow.LocalBillsRow;
                            trRow.Employee = _currentEmployee;
                            lbta.Insert(trRow);
                        }
                        else
                        {
                            db.RollbackTransaction();
                            MessageBox.Show("Вы попытались передать " + salesRow.ProductName + " " + salesRow.PackageName + " в количестве " + salesRow.Count.ToString() + ". Данного количества нет в базе.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            LoadLocalBillsByLetter(salesRow.ProductName[0].ToString());
                            tbSearch.Text = salesRow.ProductName;
                            _liSalesRows.Remove(salesRow);
                            salesRowBindingSource.ResetBindings(false);
                            UpdateSum();
                            PerformCalculation();
                            return;

                        }
                    }
                    db.CommitTransaction();

                    PerformClear();

                }
            }
        }

        #region Calculator methods
        private void ShowCalculator()
        {
            if (_liSalesRows.Count == 0) return;

            lblInsCash.Visible = true;
            tbInsertedCash.Visible = true;
            tbInsertedCash.Text = "";
            tbInsertedCash.Select();
        }

        private void HideCalculator()
        {
            lblInsCash.Visible = false;
            tbInsertedCash.Visible = false;

            lblChange.Visible = false;
            tbChange.Visible = false;
            tbInsertedCash.Text = "0";

        }

        private void PerformCalculation()
        {

            double Sum = Convert.ToDouble(tbSum.Text);
            tbInsertedCash.Text = tbInsertedCash.Text.Replace(',', '.');
            double insertedCash = Convert.ToDouble(tbInsertedCash.Text);

            double change = insertedCash - Sum;

            tbChange.Text = change.ToString("0.00");

        }

        #endregion

        private void PerformSale()
        {
            if (_liSalesRows.Count == 0) return;

            IList<IGood> liGoods = new List<IGood>();

            using (DbManager db = new DbManager())
            {
                db.BeginTransaction();
                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);
                SalesAccessor sa = SalesAccessor.CreateInstance<SalesAccessor>(db);

                int nextCustomerNumber = sa.GetMaxCustomerNumber(DateTime.Now.Date) + 1;

                foreach (SalesRow salesRow in _liSalesRows)
                {
                    if (Settings.Default.CashRegisterEnabled)
                    {
                        IGood good = GoodsFactory.CreateGood();
                        good.Name = salesRow.ProductName + " " + salesRow.PackageName;
                        good.Price = salesRow.Price;
                        good.Amount = salesRow.Count;
                        good.Discount = salesRow.Discount;

                        liGoods.Add(good);
                    }

                    if (lblClientID.Visible)
                    {
                        salesRow.ClientID = lblClientID.Text;
                    }
                    int i = lba.ChangeAmount(salesRow.LocalBillsRow.ID, -1 * salesRow.Count);
                    if (i != 0)
                    {
                        salesRow.CustomerNumber = nextCustomerNumber;
                        sa.Insert(salesRow);
                    }
                    else
                    {
                        db.RollbackTransaction();
                        MessageBox.Show(
                            "Вы попытались отпустить " + salesRow.ProductName + " " + salesRow.PackageName +
                            " в количестве " + salesRow.Count.ToString() + ". Данного количества нет в базе.",
                            "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LoadLocalBillsByLetter(salesRow.ProductName[0].ToString());
                        tbSearch.Text = salesRow.ProductName;
                        _liSalesRows.Remove(salesRow);
                        salesRowBindingSource.ResetBindings(false);
                        UpdateSum();
                        PerformCalculation();

                        return;
                    }
                }

                db.CommitTransaction();
            }

            if (Settings.Default.CashRegisterEnabled)
            {
                IOperator cashOperator = OperatorFactory.CreateInstance();
                cashOperator.Name = _currentEmployee.FullName;
                cashOperator.Password = _currentEmployee.ID.ToString();
                double givenCash = double.Parse(tbInsertedCash.Text);
                _cashRegister.RegisterGoods(cashOperator, liGoods, givenCash);

            }
            PerformClear();

        }

        private void PerformClear()
        {
            dgvLocalBillsToSale.Columns["PriceWithDiscount"].Visible = false;
            dgvLocalBillsToSale.Columns["Sum"].Visible = true;
            _isDiscountActive = false;
            lblDiscountSum.Visible = false;
            tbDiscountSum.Visible = false;
            tbDiscountValue.Visible = false;
            lblDiscountSum.Visible = false;

            _liSalesRows.Clear();
            salesRowBindingSource.ResetBindings(false);
            dgvLocalBills.Select();
            HideCalculator();

            tbSum.Text = "";
            LoadLocalBillsByLetter("А");
            tbSearch.Text = "";

            lblClientCaption.Visible = false;
            lblClientID.Visible = false;
            lblClientID.Text = "";

        }

        private void UpdateSum()
        {
            double sum = 0;
            double sumWithDiscount = 0;

            _liSalesRows.FindAll(p =>
            {
                if (_isDiscountActive)
                {
                    p.Discount = _discount;

                    double extra = ((p.Price - p.LocalBillsRow.MainStoreRow.SupplierPrice) /
                                                   p.LocalBillsRow.MainStoreRow.SupplierPrice) * 100.0;
                    if (extra > _discountExtraLimit)
                    {
                        p.PriceWithDiscount = p.Price - p.Price * p.Discount / 100.0;
                    }
                    else
                    {
                        p.Discount = 0;
                        p.PriceWithDiscount = p.Price;
                    }

                    sum = sum + p.Count * p.Price;
                    sumWithDiscount = sumWithDiscount + p.Count * p.PriceWithDiscount;

                }
                else
                {
                    p.Discount = 0;
                    p.PriceWithDiscount = 0;
                    sum = sum + p.Count * p.Price;
                }

                return false;
            });

            if (_isDiscountActive)
            {
                tbSum.Text = sumWithDiscount.ToString("0.00");
                tbDiscountSum.Text = (sum - sumWithDiscount).ToString("0.00");
                tbDiscountValue.Text = _discount.ToString("0.00");
            }
            else
            {
                tbSum.Text = sum.ToString("0.00");
            }

        }

        private float GetDefaultDiscount()
        {
            float discount = 0;

            _log.Info("Will try yo apply default discount value");

            PropertyAccessor pa = PropertyAccessor.CreateInstance<PropertyAccessor>();
            Property skidka = pa.GetByName("skidka");
            if (skidka != null)
            {
                if (float.TryParse(skidka.Value, out discount))
                {
                    _log.InfoFormat("Default discount value {0}", discount);
                }
                else
                {
                    _log.ErrorFormat("Can't parse property skidka. Value {0}", skidka.Value);
                }
            }
            else
            {
                _log.Error("Can't find property skidka");
            }
            return discount;
        }

        private void InitializeDaysWarning()
        {
            PropertyAccessor pa = PropertyAccessor.CreateInstance<PropertyAccessor>();
            Property den = pa.GetByName("den");
            if (den != null)
            {
                if (!int.TryParse(den.Value, out _daysWarning))
                {
                    _daysWarning = 0;
                }
            }
            else
            {
                _daysWarning = 0;
            }

        }

        private void InitializeDiscountExtraLimit()
        {
            PropertyAccessor pa = PropertyAccessor.CreateInstance<PropertyAccessor>();
            Property DiscountExtraLimit = pa.GetByName("DiscountExtraLimit");
            if (DiscountExtraLimit != null)
            {
                if (!double.TryParse(DiscountExtraLimit.Value, out _discountExtraLimit))
                {
                    _discountExtraLimit = 0;
                }
            }
            else
            {
                _discountExtraLimit = 0;
            }

        }

        private void dgvLocalBills_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "Count":
                    {
                        LocalBillsRowEx row = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;

                        int i = Convert.ToInt32(cell.EditedFormattedValue);

                        e.Value = row.Amount;
                        e.ParsingApplied = true;
                        SalesRow salesRow = new SalesRow();
                        salesRow.Count = i;
                        salesRow.LocalBillsRow = row;
                        salesRow.Price = row.CurrentPrice;
                        salesRow.Employee = _currentEmployee;

                        _liSalesRows.Add(salesRow);

                        salesRowBindingSource.ResetBindings(false);
                        salesRowBindingSource.MoveLast();
                        dgvLocalBillsToSale.CurrentCell.Selected = false;

                        UpdateSum();
                        tbSearch.Text = "";

                    }
                    break;

            }
        }

        private void dgvLocalBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            LocalBillsRowEx row1 = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;
            if (row1.IsPriceUpdated)
            {

                e.CellStyle.BackColor = Color.Salmon;
                Font f = new Font(e.CellStyle.Font, FontStyle.Bold);
                e.CellStyle.Font = f;
            }

            switch (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name)
            {
                case "Count":
                    {
                        LocalBillsRowEx row = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;

                        List<SalesRow> liFilteredSalesRows = _liSalesRows.FindAll(delegate(SalesRow p) { return p.LocalBillsRow.ID == row.ID; });

                        int i = row.Amount;
                        foreach (SalesRow salesRow in liFilteredSalesRows)
                        {
                            i = i - salesRow.Count;
                        }

                        e.Value = i;

                    }
                    break;
                case "DateSupply":
                    {
                        LocalBillsRowEx row = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;

                        TimeSpan ts = DateTime.Now - row.MainStoreRow.DateSupply;

                        if (ts.Days > _daysWarning)
                        {
                            e.Value = ts.Days.ToString();
                        }
                        else
                        {
                            e.Value = "";
                        }
                        e.FormattingApplied = true;

                    }
                    break;

                default:
                    break;
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            dgvLocalBills.Select();
        }

        private void tbInsertedCash_KeyDown(object sender, KeyEventArgs e)
        {
            _log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            DataGridView dgv = sender as DataGridView;

            switch (e.KeyCode)
            {

                case Keys.Enter:
                    {
                        tbChange.Visible = true;
                        lblChange.Visible = true;

                        PerformCalculation();

                        dgvLocalBills.Select();

                    }
                    break;
            }
        }

        private void frmMainSalesWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>();
            int i = lba.CheckDelayedBills();
            if (i > 0)
            {
                tsbDelayedBills.Enabled = true;
                List<long> liDelayedBills = lba.GetDelayedBills();

                tsbDelayedBills.DropDownItems.Clear();
                foreach (long item in liDelayedBills)
                {
                    tsbDelayedBills.DropDownItems.Add(item.ToString());
                }

            }
            else
            {
                tsbDelayedBills.Enabled = false;
            }

            if (!_isPriceUpdatedListEnabled)
            {
                int newPricesAmount = lba.CheckForNewPrices();
                if (newPricesAmount > 0)
                {
                    tsbNewPrices.Enabled = true;
                    tsbNewPrices.Text = String.Format("Новые цены ({0})", newPricesAmount);
                }
                else
                {
                    tsbNewPrices.Enabled = false;
                    tsbNewPrices.Text = "Новых цен нет";
                }
            }
        }

        private void tsbDelayedBills_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripDropDownButton ts = sender as ToolStripDropDownButton;
            LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>();
            lba.MarkAsUndelayedBill(Convert.ToInt64(e.ClickedItem.Text));

            ts.DropDownItems.Remove(e.ClickedItem);
            if (ts.DropDownItems.Count == 0)
                tsbDelayedBills.Enabled = false;

        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            if (_liSalesRows.Count > 0)
            {
                string sumPropis = RusCurrency.Str(Convert.ToDouble(tbSum.Text), "RUR");

                frmReportViewer frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.CashMemo.rdlc");

                int iCashMemoNumber = Convert.ToInt16(Properties.Settings.Default.CashMemoNumber);

                ReportParameter CompanyName = new ReportParameter("CompanyInfo", Properties.Settings.Default.CompanyName);
                ReportParameter AdditionalInfo = new ReportParameter("AdditionalInfo", Properties.Settings.Default.AdditionalInfo);
                ReportParameter employee = new ReportParameter("EmployeeName", _currentEmployee.FullName);
                ReportParameter SumPropis = new ReportParameter("SumPropis", sumPropis);
                ReportParameter CashMemoNumber = new ReportParameter("CashMemoNumber", iCashMemoNumber.ToString());
                ReportParameter Sum = new ReportParameter("Sum", tbSum.Text);

                iCashMemoNumber++;
                Settings.Default.CashMemoNumber = iCashMemoNumber.ToString();
                Settings.Default.Save();

                frmReportViewer.SetParameters(CompanyName, AdditionalInfo, employee, SumPropis, CashMemoNumber, Sum);

                frmReportViewer.SetDataSource("SalesRow", salesRowBindingSource);

                frmReportViewer.ShowDialog();
            }

        }

        private void tsbNewPrices_Click(object sender, EventArgs e)
        {
            if (_isPriceUpdatedListEnabled)
            {
                _isPriceUpdatedListEnabled = false;

                LoadLocalBillsByLetter("А");
                tbSearch.Text = "";

                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>();
                int newPricesAmount = lba.CheckForNewPrices();
                if (newPricesAmount > 0)
                {
                    tsbNewPrices.Enabled = true;
                    tsbNewPrices.Text = String.Format("Новые цены ({0})", newPricesAmount);
                }
                else
                {
                    tsbNewPrices.Enabled = false;
                    tsbNewPrices.Text = "Новых цен нет";
                }
            }
            else
            {
                _isPriceUpdatedListEnabled = true;
                tsbNewPrices.Text = "Весь список";
                LoadLocalBillsWithChangedPrices();
            }
        }

        private void tsbPrintLocalBills_Click(object sender, EventArgs e)
        {
            frmPrintBills frmPrintBills = new frmPrintBills(_currentStore);
            frmPrintBills.Show();
        }

        private void tsbShowObserver_Click(object sender, EventArgs e)
        {
            frmForeignStoresObserver frmForeignStoresObserver = new frmForeignStoresObserver();
            frmForeignStoresObserver.Show();
        }

        private void tsmiXReport_Click(object sender, EventArgs e)
        {
            _cashRegister.PerformXReport();
        }

        private void tsmiZReport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выполнить отчет с гашением?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _cashRegister.PerformZReport();
            }
        }

        private void tsbAccounting_Click(object sender, EventArgs e)
        {
            frmAccounting frmAccounting = new frmAccounting();
            frmAccounting.ShowDialog(this);
        }
    }
}
