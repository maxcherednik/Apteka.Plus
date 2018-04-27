using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.BLL.Enums;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace Apteka.Plus.UserControls
{
    public partial class ucProductSuppliesTable : UserControl
    {
        private readonly MyStore _myStore;
        private int _daysOfStockRotation;
        private FullProductInfo _fullProductInfo;
        private int _topRows;
        private readonly DataLoader<List<LocalBillsRowEx>> _dataLoader;

        public ucProductSuppliesTable()
        {
            InitializeComponent();
            _dataLoader = new DataLoader<List<LocalBillsRowEx>>(LoadData, 3000);
            _dataLoader.RequestCompleted += _dataLoader_RequestCompleted;
            _dataLoader.ItsGonnaTakeAWhile += _dataLoader_ItsGonnaTakeAWhile;
            dgvProductSupplies.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        public ucProductSuppliesTable(MyStore myStore)
            : this()
        {
            _myStore = myStore;
        }

        public void LoadProductSupples(FullProductInfo fullProductInfo, int topRows, int daysOfStockRotation)
        {
            lock (_dataLoader.SyncRoot)
            {
                _fullProductInfo = fullProductInfo;
                _daysOfStockRotation = daysOfStockRotation;
                _topRows = topRows;
            }

            _dataLoader.MakeRequest();
        }

        private List<LocalBillsRowEx> LoadData()
        {
            FullProductInfo fullProductInfo;
            int topRows;

            lock (_dataLoader.SyncRoot)
            {
                fullProductInfo = _fullProductInfo;
                topRows = _topRows;
            }

            List<LocalBillsRowEx> liLocalBillsRowEx;
            using (var db = new DbManager(_myStore.Name))
            {
                var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(db);

                var fromDate = DateTime.Now.AddDays(-1 * 720); // todo в параметры 
                liLocalBillsRowEx = lba.GetProductSupplies(fullProductInfo.ID, topRows, fromDate);
            }

            return liLocalBillsRowEx;
        }

        private void SetData(List<LocalBillsRowEx> liLocalBillsRowEx)
        {
            localBillsRowExBindingSource.DataSource = liLocalBillsRowEx;
        }

        private void dgvProductSupplies_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            LocalBillsRowEx prevRow = null;
            if (e.RowIndex != 0)
            {
                prevRow = (LocalBillsRowEx)dgv.Rows[e.RowIndex - 1].DataBoundItem;
            }

            var curRow = (LocalBillsRowEx)dgv.Rows[e.RowIndex].DataBoundItem;

            switch (cell.OwningColumn.Name)
            {

                case "DaysDisposal":
                    {
                        if (e.Value != null)
                        {
                            var val = (int)e.Value;

                            if (val > _daysOfStockRotation)
                            {
                                e.CellStyle.BackColor = Color.RosyBrown;
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }
                        else
                        {
                            e.Value = "";
                            e.FormattingApplied = true;
                        }
                    }
                    break;
                case "TimeSpan":
                    {
                        if (prevRow != null && curRow.DateDisposal.HasValue && curRow.DateDisposal < prevRow.DateAccepted)
                        {
                            e.CellStyle.BackColor = Color.Tomato;
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            var endDay = curRow.DateDisposal.Value.Date;
                            endDay = endDay.AddHours(20);
                            TimeSpan ts1;
                            if (curRow.DateDisposal.Value < endDay)
                            {
                                ts1 = endDay - curRow.DateDisposal.Value;
                            }
                            else
                            {
                                ts1 = new TimeSpan();
                            }

                            var tsTemp = prevRow.DateAccepted - curRow.DateDisposal.Value;
                            var ts2 = new TimeSpan(12 * tsTemp.Days, 0, 0);

                            var lastDay = prevRow.DateAccepted.Date;
                            lastDay = lastDay.AddHours(8);

                            TimeSpan ts3;
                            if (prevRow.DateAccepted > lastDay)
                            {
                                ts3 = prevRow.DateAccepted - lastDay;
                            }
                            else
                            {
                                ts3 = new TimeSpan();
                            }

                            var tsResult = ts1 + ts2 + ts3;
                            if (tsResult.Ticks > 0)
                            {
                                if (tsResult.Days >= 1)
                                {
                                    e.Value = tsResult.TotalDays.ToString("0.0") + " дн";
                                }
                                else
                                {
                                    if (tsResult.Hours == 0)
                                    {
                                        if (tsResult.Minutes == 0)
                                        {

                                            e.Value = "";
                                        }
                                        else
                                        {
                                            e.Value = tsResult.Minutes + " м";
                                        }
                                    }
                                    else
                                    {
                                        e.Value = tsResult.Hours + " ч";
                                    }
                                }
                            }
                            else
                            {
                                e.Value = "";
                                e.FormattingApplied = true;
                            }
                        }
                        else
                        {
                            e.Value = "";
                            e.FormattingApplied = true;
                        }
                    }
                    break;
            }
        }

        private void dgvProductSupplies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dgv = (DataGridView)sender;
                var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var localBillsRow = (LocalBillsRowEx)dgv.Rows[e.RowIndex].DataBoundItem;

                if (cell.OwningColumn.Name == "CurrentPrice")
                {
                    if (localBillsRow.Amount > 0)
                    {
                        dgv.BeginEdit(true);
                    }
                }
            }
        }

        private void dgvProductSupplies_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.OwningColumn.Name == "CurrentPrice")
            {
                if (cell.IsInEditMode)
                {
                    var newPrice = cell.EditedFormattedValue.ToString().Replace(",", ".");

                    if (double.TryParse(newPrice, out var localPrice))
                    {
                        if (localPrice < 0)
                        {
                            MessageBox.Show(@"Цена не может быть отрицательной", @"Внимание", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Вы ввели некорректное значение! Допускаются только числа.", @"Внимание",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dgvProductSupplies_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.OwningColumn.Name == "CurrentPrice")
            {
                var localBillsRow = (LocalBillsRowEx)dgv.Rows[e.RowIndex].DataBoundItem;

                var newPrice = e.Value.ToString().Replace(",", ".");
                var dNewPrice = double.Parse(newPrice);
                e.Value = dNewPrice;
                if (localBillsRow.CurrentPrice != dNewPrice)
                {
                    using (var dbSatelite = new DbManager(_myStore.Name))
                    {
                        try
                        {
                            dbSatelite.BeginTransaction();

                            var lba = DataAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                            var raa = DataAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);

                            lba.UpdatePrice(localBillsRow.ID, dNewPrice);

                            var ra = new RemoteAction
                            {
                                LocalBillsRowID = localBillsRow.ID,
                                NewPrice = dNewPrice,
                                TypeOfAction = RemoteActionEnum.PriceChange,
                                Employee = Session.User
                            };
                            raa.Insert(ra);

                            dbSatelite.CommitTransaction();
                        }
                        catch
                        {
                            dbSatelite.RollbackTransaction();

                            throw;
                        }
                    }
                }

                e.ParsingApplied = true;
            }
        }

        private void _dataLoader_ItsGonnaTakeAWhile(object sender, DataLoader<List<LocalBillsRowEx>>.ItsGonnaTakeAWhileEventArgs e)
        {
            progressIndicatorEx1.Show();
        }

        private void _dataLoader_RequestCompleted(object sender, DataLoader<List<LocalBillsRowEx>>.RequestCompletedEventArgs e)
        {
            SetData(e.Results);
            progressIndicatorEx1.Hide();
        }
    }
}
