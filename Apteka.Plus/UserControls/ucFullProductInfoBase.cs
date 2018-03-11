using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Apteka.Plus.Common.Controls;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;
using log4net;

namespace Apteka.Plus.UserControls
{
    public partial class ucFullProductInfoBase : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<FullProductInfo> _liFullProductInfo;

        public FullProductInfo SeletedItem { get; private set; }

        public ucFullProductInfoBase()
        {
            InitializeComponent();
        }

        private void ucFullProductInfoBase_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            dgvFullProductInfoList.SetStateSourceAndLoadState(Session.User, DataGridViewColumnSettingsAccessor.CreateInstance<DataGridViewColumnSettingsAccessor>());
        }
        public void Init()
        {
            FullProductInfoAccessor fpia = FullProductInfoAccessor.CreateInstance<FullProductInfoAccessor>();
            _liFullProductInfo = fpia.GetAllActiveProductInfosByLetter("А");
            fullProductInfoBindingSource.DataSource = _liFullProductInfo;
        }

        void dgvFullProductInfoList_CurrentRowChanged(object sender, MyDataGridView.CurrentRowChangedEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            FullProductInfo fpi = dgv.Rows[e.RowIndex].DataBoundItem as FullProductInfo;
            SeletedItem = fpi;
            OnCurrentRowChange(fpi);
        }

        #region CurrentRowChanged
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

            public FullProductInfo FullProductInfo { get; private set; }
        }
        #endregion

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Length == 1)
            {
                FullProductInfoAccessor fpia = FullProductInfoAccessor.CreateInstance<FullProductInfoAccessor>();
                _liFullProductInfo = fpia.GetAllActiveProductInfosByLetter(tbSearch.Text);
                fullProductInfoBindingSource.DataSource = _liFullProductInfo;
            }
            else if (tbSearch.Text.Length > 1)
            {

                List<FullProductInfo> liFiltered = _liFullProductInfo.FindAll(p =>
                {

                    return p.ProductName.IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0
                        || p.PackageName.IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0
                        || p.EAN13.IndexOf(tbSearch.Text, StringComparison.InvariantCultureIgnoreCase) >= 0;
                });

                fullProductInfoBindingSource.DataSource = liFiltered;

            }
            else
            {
                fullProductInfoBindingSource.DataSource = _liFullProductInfo;
            }
        }

        private void dgvFullProductInfoList_KeyDown(object sender, KeyEventArgs e)
        {
            log.DebugFormat("Key down:{0}", e.KeyCode.ToString());
            DataGridView dgv = sender as DataGridView;

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
            DataGridView dgv = sender as DataGridView;
            FullProductInfo row = dgv.Rows[e.RowIndex].DataBoundItem as FullProductInfo;

            switch (dgv.Columns[e.ColumnIndex].DataPropertyName)
            {
                case "Divider":
                    {
                        if (row.Divider == 0)
                        {
                            e.Value = "";
                            e.FormattingApplied = true;
                        }

                    }
                    break;

                case "IsDiscountExcluded":
                    {
                        if (row.IsDiscountExcluded)
                        {
                            e.Value = "Не разрешена";
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
