using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;

namespace Apteka.Plus.Common.Controls
{
    public class MyDataGridView : DataGridView
    {
        private List<DataGridViewColumnSettingsRow> _liDataGridViewColumnSettingsLoaded;
        private DataGridViewColumnSettingsAccessor _stateDataSource;
        private Employee _employee;
        private bool _currentlyLoading;

        private bool _onRowChangedBlocked;

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        { //this method overrides the DataGridView's RowPostPaint event 
            //in order to automatically draw numbers on the row header cells
            //and to automatically adjust the width of the column containing
            //the row header cells so that it can accommodate the new row
            //numbers,

            //store a string representation of the row number in 'strRowNumber'
            var strRowNumber = (e.RowIndex + 1).ToString();

            //prepend leading zeros to the string if necessary to improve
            //appearance. For example, if there are ten rows in the grid,
            //row seven will be numbered as "07" instead of "7". Similarly, if 
            //there are 100 rows in the grid, row seven will be numbered as "007".
            while (strRowNumber.Length < RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

            //determine the display size of the row number string using
            //the DataGridView's current font.
            var size = e.Graphics.MeasureString(strRowNumber, Font);

            //adjust the width of the column that contains the row header cells 
            //if necessary
            if (RowHeadersWidth < (int)(size.Width + 20)) RowHeadersWidth = (int)(size.Width + 20);

            //this brush will be used to draw the row number string on the
            //row header cell using the system's current ControlText color
            var b = (e.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.Selected 
                ? SystemBrushes.ControlText 
                : SystemBrushes.ActiveCaptionText;

            //draw the row number string on the current row header cell using
            //the brush defined above and the DataGridView's default font
            e.Graphics.DrawString(strRowNumber, Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + (e.RowBounds.Height - size.Height) / 2);

            //call the base object's OnRowPostPaint method
            base.OnRowPostPaint(e);
        } //end OnRowPostPaint method

        private void InitializeComponent()
        {
            var dataGridViewCellStyle1 = new DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            SuspendLayout();
            // 
            // MyDataGridView
            // 
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.AliceBlue;
            AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
            ResumeLayout(false);
        }

        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            if (!_currentlyLoading && _stateDataSource != null && IsColumnWidthChanged)
            {
                var liSettingsRow = GetColumnsSizeExt();
                _stateDataSource.SaveSettings(liSettingsRow);
            }

            base.OnColumnWidthChanged(e);
        }

        public void SetStateSourceAndLoadState(Employee employee, DataGridViewColumnSettingsAccessor dataSource)
        {
            _employee = employee;
            _stateDataSource = dataSource;

            var liColumnSettings = _stateDataSource.GetSettings(employee.ID, Parent.Name + "_" + Name);

            _currentlyLoading = true;
            try
            {
                LoadColumnsSize(liColumnSettings);
            }
            finally
            {
                _currentlyLoading = false;
            }
        }

        private DataGridViewCell _mCell;

        protected override void OnGotFocus(EventArgs e)
        {
            if (_mCell?.RowIndex >= 0)
            {
                CurrentCell = _mCell;
            }

            if (CurrentCell != null)
            {
                CurrentCell.Selected = true;
            }

            base.OnGotFocus(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            _mCell = CurrentCell;
            if (CurrentCell != null)
            {
                CurrentCell.Selected = false;
            }
            base.OnLostFocus(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Down)
            {
                _onRowChangedBlocked = true;
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Down)
            {
                _onRowChangedBlocked = false;

                if (CurrentRow != null)
                    OnCurrentRowChange(CurrentRow.Index);
            }

            base.OnKeyUp(e);
        }

        protected override void OnRowEnter(DataGridViewCellEventArgs e)
        {
            if (_onRowChangedBlocked != true)
            {
                OnCurrentRowChange(e.RowIndex);
            }
            base.OnRowEnter(e);
        }

        public event EventHandler<CurrentRowChangedEventArgs> CurrentRowChanged;

        private void OnCurrentRowChange(int rowIndex)
        {
            if (CurrentRowChanged != null)
            {
                var e = new CurrentRowChangedEventArgs(rowIndex);
                CurrentRowChanged.Invoke(this, e);
            }
        }

        public class CurrentRowChangedEventArgs : EventArgs
        {
            public CurrentRowChangedEventArgs(int rowIndex)
            {
                RowIndex = rowIndex;
            }

            public int RowIndex { get; set; }
        }
        public void LoadColumnsSize(List<DataGridViewColumnSettingsRow> liDataGridViewColumnSettingsRow)
        {
            _liDataGridViewColumnSettingsLoaded = liDataGridViewColumnSettingsRow;
            foreach (var settingsRow in liDataGridViewColumnSettingsRow)
            {
                if (settingsRow.ColumnIndex < Columns.Count)
                {
                    Columns[settingsRow.ColumnIndex].Width = settingsRow.ColumnSize;
                }
            }
        }

        public List<DataGridViewColumnSettingsRow> GetColumnsSizeExt()
        {
            var liDataGridViewColumnSettingsRows = new List<DataGridViewColumnSettingsRow>(Columns.Count);

            for (var i = 0; i < Columns.Count; i++)
            {
                var settingsRow = new DataGridViewColumnSettingsRow
                {
                    ColumnIndex = i,
                    ColumnSize = Columns[i].Width,
                    GridName = Parent.Name + "_" + Name,
                    Employee = _employee
                };

                liDataGridViewColumnSettingsRows.Add(settingsRow);
            }

            return liDataGridViewColumnSettingsRows;
        }

        public bool IsColumnWidthChanged
        {
            get
            {
                if (Columns.Count > _liDataGridViewColumnSettingsLoaded.Count)
                {
                    return true;
                }

                for (var i = 0; i < Columns.Count; i++)
                {
                    if (_liDataGridViewColumnSettingsLoaded[i].ColumnSize != Columns[i].Width)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
