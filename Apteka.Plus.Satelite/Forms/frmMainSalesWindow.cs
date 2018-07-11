using Apteka.Plus.CashRegister;
using Apteka.Plus.CashRegister.FP5200;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using Apteka.Plus.Satelite.Properties;
using BLToolkit.Data;
using log4net;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Common.Forms;
using BLToolkit.DataAccess;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmMainSalesWindow : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ICashRegister _cashRegister;
        private readonly Employee _currentEmployee;
        private readonly MyStore _currentStore;

        private List<LocalBillsRowEx> _liLocalBillRowsList;
        private readonly List<SalesRow> _liSalesRows = new List<SalesRow>();

        private bool _isPriceUpdatedListEnabled;

        private bool _isDiscountActive;
        private float _discount;
        private int _daysWarning;
        private double _discountExtraLimit;

        public frmMainSalesWindow(Employee empl)
        {
            InitializeComponent();

            try
            {
                _cashRegister = new FPrint5200();
            }
            catch (Exception e)
            {
                Log.Error("Can't initialize cash register module", e);
                MessageBox.Show(@"Не могу инициализировать мудуль управления кассовым аппаратом. Убедитесь, что все необходимые драйвера установлены. Ошибка: " + e.Message, @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }

            _currentEmployee = empl;
            tsEmployeeName.Text = empl.FullName;
            tsCurrentDate.Text = DateTime.Now.Date.ToShortDateString();

            var storeId = int.Parse(Settings.Default.SateliteID);

            _currentStore = MyStoresCollection.AllStores.Find(store => storeId == store.ID);

            InitializeDaysWarning();
            InitializeDiscountExtraLimit();
        }

        private void tsbCopyData_Click(object sender, EventArgs e)
        {
            var frmCopyDataMenu = new frmCopyDataMenu();
            frmCopyDataMenu.ShowDialog(this);
        }

        private void frmMainSalesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            var frmOptions = new frmOptions();
            frmOptions.ShowDialog(this);

            ApplyStyle();
        }

        private void ApplyStyle()
        {
            Font = new Font(Font.FontFamily, Convert.ToSingle(Settings.Default.FontSizeBase));

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
                    var liFiltered = _liLocalBillRowsList.FindAll(p => p.ProductName.StartsWith(tbSearch.Text, StringComparison.CurrentCultureIgnoreCase));

                    localBillsRowExBindingSource.DataSource = liFiltered;
                    localBillsRowExBindingSource.MoveFirst();
                }
            }
        }

        private void dgvLocalBills_KeyDown(object sender, KeyEventArgs e)
        {
            Log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            var dgv = (DataGridView)sender;

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
                        var lba = DataAccessor.CreateInstance<LocalBillsAccessor>();

                        var row = (LocalBillsRowEx)dgv.CurrentRow.DataBoundItem;
                        row.IsPriceUpdated = !row.IsPriceUpdated;

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
            }

            UpdateSum();
        }

        private void ShowClientIdentifyForm()
        {
            var frmIdentifyClient = new frmIdentifyClient();

            if (frmIdentifyClient.ShowDialog(this) == DialogResult.OK)
            {
                lblClientCaption.Visible = true;
                lblClientID.Visible = true;
                lblDiscountValue.Visible = true;
                tbDiscountValue.Visible = true;
                lblDiscountSum.Visible = true;
                tbDiscountSum.Visible = true;
                lblClientID.Text = frmIdentifyClient.ClientId;
                dgvLocalBillsToSale.Columns["PriceWithDiscount"].Visible = true;
                dgvLocalBillsToSale.Columns["Sum"].Visible = false;

                var clientDiscount = GetDiscountForClient(frmIdentifyClient.ClientId);
                if (float.IsNaN(clientDiscount))
                {
                    clientDiscount = GetDefaultDiscount();
                }

                if (_isDiscountActive)
                {
                    if (clientDiscount > _discount)
                    {
                        _discount = clientDiscount;
                    }
                }
                else
                {
                    _isDiscountActive = true;

                    _discount = clientDiscount;
                }
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
            }

            UpdateSum();
        }

        private static float GetDiscountForClient(string clientId)
        {
            var clientAccessor = DataAccessor.CreateInstance<ClientAccessor>();
            var client = clientAccessor.Query.SelectByKey(clientId);

            if (client != null)
            {
                Log.InfoFormat("Found client {0} with discount {1}", client.Id, client.Discount);
                return client.Discount;
            }

            Log.InfoFormat("Can't find discount for client {0}", clientId);
            return float.NaN;
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

            dgvLocalBills.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
            dgvLocalBillsToSale.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());

            LoadLocalBillsByLetter("А");

            salesRowBindingSource.DataSource = _liSalesRows;
        }

        private void LoadLocalBillsByLetter(string letter)
        {
            var lba = DataAccessor.CreateInstance<LocalBillsAccessor>();
            _liLocalBillRowsList = lba.GetRowsByStartLetter(letter);

            localBillsRowExBindingSource.DataSource = _liLocalBillRowsList;
        }

        private void LoadLocalBillsWithChangedPrices()
        {
            var lba = DataAccessor.CreateInstance<LocalBillsAccessor>();
            _liLocalBillRowsList = lba.GetRowsWithChangedPrices();

            localBillsRowExBindingSource.DataSource = _liLocalBillRowsList;
            localBillsRowExBindingSource.MoveFirst();
        }

        private void dgvLocalBillsToSale_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var row = (SalesRow)dgv.Rows[e.RowIndex].DataBoundItem;

            if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Sum")
            {
                if (row != null)
                {
                    e.Value = row.Price * row.Count;
                }
            }
            else if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "PriceWithDiscount")
            {
                {
                    if (row.Price != row.PriceWithDiscount)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 224, 192);
                    }
                }
            }
        }

        private void dgvLocalBillsToSale_KeyDown(object sender, KeyEventArgs e)
        {
            var dgv = (DataGridView)sender;

            switch (e.KeyCode)
            {
                case Keys.Delete:
                    {
                        var row = (SalesRow)dgv.CurrentRow.DataBoundItem;

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

            var res = MessageBox.Show(@"Передача товара очень ответственная операция! Вы уверены?", @"Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                using (var db = new DbManager())
                {
                    db.BeginTransaction();
                    var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(db);
                    var lbta = DataAccessor.CreateInstance<LocalBillsTransfersAccessor>(db);

                    foreach (var salesRow in _liSalesRows)
                    {
                        var i = lba.ChangeAmount(salesRow.LocalBillsRow.ID, -1 * salesRow.Count);
                        if (i != 0)
                        {
                            var trRow = new LocalBillsTransferRow
                            {
                                Price = salesRow.Price,
                                Count = salesRow.Count,
                                LocalBillsRow = salesRow.LocalBillsRow,
                                Employee = _currentEmployee
                            };

                            lbta.Insert(trRow);
                        }
                        else
                        {
                            db.RollbackTransaction();
                            MessageBox.Show($@"Вы попытались передать {salesRow.ProductName} {salesRow.PackageName} в количестве {salesRow.Count}. Данного количества нет в базе.", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            tbInsertedCash.Text = @"0";
        }

        private void PerformCalculation()
        {
            var sum = Convert.ToDouble(tbSum.Text);
            tbInsertedCash.Text = tbInsertedCash.Text.Replace(',', '.');
            var insertedCash = Convert.ToDouble(tbInsertedCash.Text);

            var change = insertedCash - sum;

            tbChange.Text = change.ToString("0.00");
        }

        #endregion

        private void PerformSale()
        {
            if (_liSalesRows.Count == 0) return;

            var liGoods = new List<IGood>();

            using (var db = new DbManager())
            {
                db.BeginTransaction();
                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(db);
                var sa = DataAccessor.CreateInstance<SalesAccessor>(db);

                var nextCustomerNumber = sa.GetMaxCustomerNumber(DateTime.Now.Date) + 1;

                foreach (var salesRow in _liSalesRows)
                {
                    if (Settings.Default.CashRegisterEnabled)
                    {
                        var good = GoodsFactory.CreateGood();
                        good.Name = salesRow.ProductName + " " + salesRow.PackageName;
                        good.Price = salesRow.Price;
                        good.Amount = salesRow.Count;
                        good.Discount = salesRow.Discount;
                        good.PriceWithDiscount = salesRow.PriceWithDiscount;

                        liGoods.Add(good);
                    }

                    if (lblClientID.Visible)
                    {
                        salesRow.ClientID = lblClientID.Text;
                    }

                    var i = lba.ChangeAmount(salesRow.LocalBillsRow.ID, -1 * salesRow.Count);
                    if (i != 0)
                    {
                        salesRow.CustomerNumber = nextCustomerNumber;
                        sa.Insert(salesRow);
                    }
                    else
                    {
                        db.RollbackTransaction();
                        MessageBox.Show(
                            $@"Вы попытались отпустить {salesRow.ProductName} {salesRow.PackageName} в количестве {salesRow.Count}. Данного количества нет в базе.",
                            @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                var cashOperator = OperatorFactory.CreateInstance();
                cashOperator.Name = _currentEmployee.FullName;
                cashOperator.Password = _currentEmployee.ID.ToString();
                var givenCash = double.Parse(tbInsertedCash.Text);
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

            _liSalesRows.ForEach(p =>
            {
                if (_isDiscountActive)
                {
                    p.Discount = _discount;

                    var extra = ((p.Price - p.LocalBillsRow.MainStoreRow.SupplierPrice) /
                                                   p.LocalBillsRow.MainStoreRow.SupplierPrice) * 100.0;

                    if (!p.LocalBillsRow.MainStoreRow.FullProductInfo.IsDiscountExcluded && extra > _discountExtraLimit)
                    {
                        p.PriceWithDiscount = MathHelper.RoundDown(p.Price - p.Price * p.Discount / 100.0, 0.01);
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

        private static float GetDefaultDiscount()
        {
            float discount = 0;

            Log.Info("Will try yo apply default discount value");

            var pa = DataAccessor.CreateInstance<PropertyAccessor>();
            var skidka = pa.GetByName("skidka");

            if (skidka != null)
            {
                if (float.TryParse(skidka.Value, out discount))
                {
                    Log.InfoFormat("Default discount value {0}", discount);
                }
                else
                {
                    Log.ErrorFormat("Can't parse property skidka. Value {0}", skidka.Value);
                }
            }
            else
            {
                Log.Error("Can't find property skidka");
            }

            return discount;
        }

        private void InitializeDaysWarning()
        {
            var pa = DataAccessor.CreateInstance<PropertyAccessor>();
            var den = pa.GetByName("den");

            _daysWarning = 0;

            if (den != null)
            {
                int.TryParse(den.Value, out _daysWarning);
            }
        }

        private void InitializeDiscountExtraLimit()
        {
            var pa = DataAccessor.CreateInstance<PropertyAccessor>();
            var discountExtraLimit = pa.GetByName("DiscountExtraLimit");

            _discountExtraLimit = 0;

            if (discountExtraLimit != null)
            {
                double.TryParse(discountExtraLimit.Value, out _discountExtraLimit);
            }
        }

        private void dgvLocalBills_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {
                case "Count":
                    {
                        var row = (LocalBillsRowEx)dgv.Rows[e.RowIndex].DataBoundItem;

                        var i = Convert.ToInt32(cell.EditedFormattedValue);

                        e.Value = row.Amount;
                        e.ParsingApplied = true;
                        var salesRow = new SalesRow
                        {
                            Count = i,
                            LocalBillsRow = row,
                            Price = row.CurrentPrice,
                            Employee = _currentEmployee
                        };

                        _liSalesRows.Add(salesRow);

                        salesRowBindingSource.ResetBindings(false);
                        salesRowBindingSource.MoveLast();
                        dgvLocalBillsToSale.CurrentCell.Selected = false;

                        ActivateTimeBasedDiscount();
                        UpdateSum();
                        tbSearch.Text = "";
                    }
                    break;
            }
        }

        private void ActivateTimeBasedDiscount()
        {
            if (Settings.Default.TimeBasedDiscountEnabled)
            {
                var start = new TimeSpan(10, 0, 0);
                var end = new TimeSpan(14, 0, 0);
                var now = DateTime.Now.TimeOfDay;
                const float timeBasedDiscount = 4.0f;

                if (now > start && now < end)
                {
                    if (_isDiscountActive)
                    {
                        if (timeBasedDiscount > _discount)
                        {
                            _discount = timeBasedDiscount;
                        }
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

                        _discount = timeBasedDiscount;
                    }
                }
            }
        }

        private void dgvLocalBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var row = (LocalBillsRowEx)dgv.Rows[e.RowIndex].DataBoundItem;
            if (row.IsPriceUpdated)
            {
                e.CellStyle.BackColor = Color.Salmon;
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }

            if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "Count")
            {
                var liFilteredSalesRows = _liSalesRows.FindAll(p => p.LocalBillsRow.ID == row.ID);

                var i = row.Amount;
                foreach (var salesRow in liFilteredSalesRows)
                {
                    i = i - salesRow.Count;
                }

                e.Value = i;
            }
            else if (dgv[e.ColumnIndex, e.RowIndex].OwningColumn.Name == "DateSupply")
            {
                var ts = DateTime.Now - row.MainStoreRow.DateSupply;

                e.Value = ts.Days > _daysWarning ? ts.Days.ToString() : "";

                e.FormattingApplied = true;
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            dgvLocalBills.Select();
        }

        private void tbInsertedCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbChange.Visible = true;
                lblChange.Visible = true;

                PerformCalculation();

                dgvLocalBills.Select();
            }
        }

        private void frmMainSalesWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var lba = DataAccessor.CreateInstance<LocalBillsAccessor>();
            var i = lba.CheckDelayedBills();
            if (i > 0)
            {
                tsbDelayedBills.Enabled = true;
                var liDelayedBills = lba.GetDelayedBills();

                tsbDelayedBills.DropDownItems.Clear();
                foreach (var item in liDelayedBills)
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
                var newPricesAmount = lba.CheckForNewPrices();
                if (newPricesAmount > 0)
                {
                    tsbNewPrices.Enabled = true;
                    tsbNewPrices.Text = $@"Новые цены ({newPricesAmount})";
                }
                else
                {
                    tsbNewPrices.Enabled = false;
                    tsbNewPrices.Text = @"Новых цен нет";
                }
            }
        }

        private void tsbDelayedBills_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var ts = (ToolStripDropDownButton)sender;
            var lba = DataAccessor.CreateInstance<LocalBillsAccessor>();
            lba.MarkAsUndelayedBill(Convert.ToInt64(e.ClickedItem.Text));

            ts.DropDownItems.Remove(e.ClickedItem);
            if (ts.DropDownItems.Count == 0)
            {
                tsbDelayedBills.Enabled = false;
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            if (_liSalesRows.Count > 0)
            {
                var sumPropis = RusCurrency.Str(Convert.ToDouble(tbSum.Text), "RUR");

                var frmReportViewer = new frmReportViewer("Apteka.Plus.Common.Reports.CashMemo.rdlc");

                int iCashMemoNumber = Convert.ToInt16(Settings.Default.CashMemoNumber);

                var companyName = new ReportParameter("CompanyInfo", Settings.Default.CompanyName);
                var additionalInfo = new ReportParameter("AdditionalInfo", Settings.Default.AdditionalInfo);
                var employee = new ReportParameter("EmployeeName", _currentEmployee.FullName);
                var sumPropisParam = new ReportParameter("SumPropis", sumPropis);
                var cashMemoNumber = new ReportParameter("CashMemoNumber", iCashMemoNumber.ToString());
                var sum = new ReportParameter("Sum", tbSum.Text);

                iCashMemoNumber++;
                Settings.Default.CashMemoNumber = iCashMemoNumber.ToString();
                Settings.Default.Save();

                frmReportViewer.SetParameters(companyName, additionalInfo, employee, sumPropisParam, cashMemoNumber, sum);

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

                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>();
                var newPricesAmount = lba.CheckForNewPrices();
                if (newPricesAmount > 0)
                {
                    tsbNewPrices.Enabled = true;
                    tsbNewPrices.Text = $@"Новые цены ({newPricesAmount})";
                }
                else
                {
                    tsbNewPrices.Enabled = false;
                    tsbNewPrices.Text = @"Новых цен нет";
                }
            }
            else
            {
                _isPriceUpdatedListEnabled = true;
                tsbNewPrices.Text = @"Весь список";
                LoadLocalBillsWithChangedPrices();
            }
        }

        private void tsbPrintLocalBills_Click(object sender, EventArgs e)
        {
            new frmPrintBills(_currentStore).Show();
        }

        private void tsbShowObserver_Click(object sender, EventArgs e)
        {
            new frmForeignStoresObserver().Show();
        }

        private void tsmiXReport_Click(object sender, EventArgs e)
        {
            _cashRegister.PerformXReport();
        }

        private void tsmiZReport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Выполнить отчет с гашением?", @"Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _cashRegister.PerformZReport();
            }
        }

        private void tsbAccounting_Click(object sender, EventArgs e)
        {
            var frmAccounting = new frmAccounting();
            frmAccounting.ShowDialog(this);
        }
    }
}
