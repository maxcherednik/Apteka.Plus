using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Common.Controls;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using BLToolkit.DataAccess;

namespace Apteka.Plus.UserControls
{
    public partial class ucFullProductInfoBase : UserControl
    {
        private List<FullProductInfo> _liFullProductInfo;

        public FullProductInfo SeletedItem { get; private set; }

        public ucFullProductInfoBase()
        {
            InitializeComponent();
        }

        private void ucFullProductInfoBase_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            dgvFullProductInfoList.SetStateSourceAndLoadState(Session.User, DataAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }
        public void Init()
        {
            var fpia = DataAccessor.CreateInstance<FullProductInfoAccessor>();
            _liFullProductInfo = fpia.GetAllActiveProductInfosByLetter("А");
            fullProductInfoBindingSource.DataSource = _liFullProductInfo;
        }

        void dgvFullProductInfoList_CurrentRowChanged(object sender, MyDataGridView.CurrentRowChangedEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var fpi = (FullProductInfo)dgv.Rows[e.RowIndex].DataBoundItem;
            SeletedItem = fpi;
            OnCurrentRowChange(fpi);
        }

        public event EventHandler<CurrentRowChangedEventArgs> CurrentRowChanged;

        private void OnCurrentRowChange(FullProductInfo fullProductInfo)
        {
            CurrentRowChanged?.Invoke(dgvFullProductInfoList, new CurrentRowChangedEventArgs(fullProductInfo));

        }
        public class CurrentRowChangedEventArgs : EventArgs
        {
            public CurrentRowChangedEventArgs(FullProductInfo fullProductInfo)
            {
                FullProductInfo = fullProductInfo;
            }

            public FullProductInfo FullProductInfo { get; }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length == 1)
            {
                var fpia = DataAccessor.CreateInstance<FullProductInfoAccessor>();
                _liFullProductInfo = fpia.GetAllActiveProductInfosByLetter(tbSearch.Text);
                fullProductInfoBindingSource.DataSource = _liFullProductInfo;
            }
            else if (tbSearch.Text.Length > 1)
            {

                var liFiltered = _liFullProductInfo.FindAll(p => p.ProductName.IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0
                                                                 || p.PackageName.IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0
                                                                 || p.EAN13.IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0);

                fullProductInfoBindingSource.DataSource = liFiltered;

            }
            else
            {
                fullProductInfoBindingSource.DataSource = _liFullProductInfo;
            }
        }

        private void dgvFullProductInfoList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    OnKeyDown(e);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Back:
                    {
                        if (tbSearch.Text.Length != 0)
                        {
                            tbSearch.Text = tbSearch.Text.Substring(0, tbSearch.Text.Length - 1);
                        }

                        e.SuppressKeyPress = true;
                    }

                    break;

                case Keys.Escape:
                    {
                        if (tbSearch.Text != "")
                        {
                            tbSearch.Text = "";
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    break;
            }
        }

        private void dgvFullProductInfoList_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbSearch.Text = tbSearch.Text + e.KeyChar;
        }

        private void dgvFullProductInfoList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var row = (FullProductInfo)dgv.Rows[e.RowIndex].DataBoundItem;

            if (dgv.Columns[e.ColumnIndex].DataPropertyName == "Divider")
            {
                if (row.Divider == 0)
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
            else if (dgv.Columns[e.ColumnIndex].DataPropertyName == "IsDiscountExcluded")
            {
                    e.Value = row.IsDiscountExcluded ? "Не разрешена" : "";
                    e.FormattingApplied = true;
            }
        }


        internal void AddNewItem(FullProductInfo fullProductInfo)
        {
            throw new NotImplementedException();
        }

        internal void RemoveItem(FullProductInfo fpi)
        {
            throw new NotImplementedException();
        }
    }
}
