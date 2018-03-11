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

namespace Apteka.Plus.UserControls
{
    public partial class ucProductSuppliesTable : UserControl
    {
        #region Private fields

        private MyStore _myStore;
        private int _DaysOfStockRotation;
        private FullProductInfo _fullProductInfo;
        private int _topRows;
        private DataLoader<List<LocalBillsRowEx>> _dataLoader;
        #endregion

        #region Constructors
        public ucProductSuppliesTable()
        {
            InitializeComponent();
            _dataLoader = new DataLoader<List<LocalBillsRowEx>>(() => LoadData(), 3000);
            _dataLoader.RequestCompleted += new EventHandler<DataLoader<List<LocalBillsRowEx>>.RequestCompletedEventArgs>(_dataLoader_RequestCompleted);
            _dataLoader.ItsGonnaTakeAWhile += new EventHandler<DataLoader<List<LocalBillsRowEx>>.ItsGonnaTakeAWhileEventArgs>(_dataLoader_ItsGonnaTakeAWhile);
            dgvProductSupplies.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }

        public ucProductSuppliesTable(MyStore myStore)
            : this()
        {
            _myStore = myStore;
        }
        #endregion

        #region Public Methods
        public void LoadProductSupples(FullProductInfo fullProductInfo, int topRows, int daysOfStockRotation)
        {

            lock (_dataLoader.SyncRoot)
            {
                _fullProductInfo = fullProductInfo;
                _DaysOfStockRotation = daysOfStockRotation;
                _topRows = topRows;
            }

            _dataLoader.MakeRequest();

        }

        private List<LocalBillsRowEx> LoadData()
        {
            int daysOfStockRotation;
            FullProductInfo fullProductInfo;
            int topRows;

            lock (_dataLoader.SyncRoot)
            {
                fullProductInfo = _fullProductInfo;
                daysOfStockRotation = _DaysOfStockRotation;
                topRows = _topRows;
            }

            List<LocalBillsRowEx> liLocalBillsRowEx;
            using (DbManager db = new DbManager(_myStore.Name))
            {
                LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(db);

                DateTime fromDate = DateTime.Now.AddDays(-1 * 720); // todo в параметры 
                liLocalBillsRowEx = lba.GetProductSupplies(fullProductInfo.ID, topRows, fromDate);
            }

            return liLocalBillsRowEx;
        }
        #endregion

        #region Private Methods
        private void SetData(List<LocalBillsRowEx> liLocalBillsRowEx)
        {
            localBillsRowExBindingSource.DataSource = liLocalBillsRowEx;

        }
        #endregion

        #region Local handlers

        private void dgvProductSupplies_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            LocalBillsRowEx prevRow = null;
            if (e.RowIndex != 0)
                prevRow = dgv.Rows[e.RowIndex - 1].DataBoundItem as LocalBillsRowEx;
            LocalBillsRowEx curRow = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;

            switch (cell.OwningColumn.Name)
            {

                case "DaysDisposal":
                    {
                        if (e.Value != null)
                        {
                            int val = (int)e.Value;

                            if (val > _DaysOfStockRotation)
                            {

                                e.CellStyle.BackColor = Color.RosyBrown;
                                Font f = new Font(e.CellStyle.Font, FontStyle.Bold);
                                e.CellStyle.Font = f;
                                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //e.FormattingApplied = true;
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
                            Font f = new Font(e.CellStyle.Font, FontStyle.Bold);
                            e.CellStyle.Font = f;
                            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            DateTime endDay = curRow.DateDisposal.Value.Date;
                            endDay = endDay.AddHours(20);
                            TimeSpan ts1 = new TimeSpan();
                            if (curRow.DateDisposal.Value < endDay)
                            {
                                ts1 = endDay - curRow.DateDisposal.Value;
                            }
                            else
                            {
                                ts1 = new TimeSpan();
                            }

                            TimeSpan tsTemp = prevRow.DateAccepted - curRow.DateDisposal.Value;
                            TimeSpan ts2 = new TimeSpan(12 * tsTemp.Days, 0, 0);

                            DateTime lastDay = prevRow.DateAccepted.Date;
                            lastDay = lastDay.AddHours(8);

                            TimeSpan ts3 = new TimeSpan();
                            if (prevRow.DateAccepted > lastDay)
                            {
                                ts3 = prevRow.DateAccepted - lastDay;
                            }
                            else
                            {
                                ts3 = new TimeSpan();
                            }

                            TimeSpan tsResult = ts1 + ts2 + ts3;
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
                DataGridView dgv = sender as DataGridView;
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                LocalBillsRowEx localBillsRow = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;

                switch (cell.OwningColumn.Name)
                {

                    case "CurrentPrice":
                        {
                            if (localBillsRow.Amount > 0)
                            {
                                dgv.BeginEdit(true);
                            }
                        }
                        break;

                }
            }
        }

        private void dgvProductSupplies_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {

                case "CurrentPrice":
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
            }

        }

        private void dgvProductSupplies_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

            switch (cell.OwningColumn.Name)
            {

                case "CurrentPrice":
                    {
                        LocalBillsRowEx localBillsRow = dgv.Rows[e.RowIndex].DataBoundItem as LocalBillsRowEx;

                        string newPrice = e.Value.ToString().Replace(",", ".");
                        double dNewPrice = double.Parse(newPrice);
                        e.Value = dNewPrice;
                        if (localBillsRow.CurrentPrice != dNewPrice)
                        {
                            using (DbManager dbSatelite = new DbManager(_myStore.Name))
                            {

                                try
                                {

                                    dbSatelite.BeginTransaction();

                                    LocalBillsAccessor lba = LocalBillsAccessor.CreateInstance<LocalBillsAccessor>(dbSatelite);
                                    RemoteActionAccessor raa = RemoteActionAccessor.CreateInstance<RemoteActionAccessor>(dbSatelite);

                                    lba.UpdatePrice(localBillsRow.ID, dNewPrice);

                                    RemoteAction ra = new RemoteAction();
                                    ra.LocalBillsRowID = localBillsRow.ID;
                                    ra.NewPrice = dNewPrice;
                                    ra.TypeOfAction = RemoteActionEnum.PriceChange;
                                    ra.Employee = Session.User;
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
                    break;

            }
        }
        #endregion

        void _dataLoader_ItsGonnaTakeAWhile(object sender, DataLoader<List<LocalBillsRowEx>>.ItsGonnaTakeAWhileEventArgs e)
        {
            progressIndicatorEx1.Show();
        }

        void _dataLoader_RequestCompleted(object sender, DataLoader<List<LocalBillsRowEx>>.RequestCompletedEventArgs e)
        {
            SetData(e.Results);
            progressIndicatorEx1.Hide();
        }
    }
}
