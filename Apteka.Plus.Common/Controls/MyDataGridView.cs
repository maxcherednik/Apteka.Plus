using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.Logic.DAL.Accessors;

namespace Apteka.Plus.Common.Controls
{
    public class MyDataGridView : DataGridView
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<DataGridViewColumnSettingsRow> _liDataGridViewColumnSettingsLoaded;
        private DataGridViewColumnSettingsAccessor _stateDataSource;
        private Employee _employee;
        private bool _currentlyLoading = false;

        private bool _onRowChangedBlocked;
        private int _previousRowIndex = -1;

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        { //this method overrides the DataGridView's RowPostPaint event 
            //in order to automatically draw numbers on the row header cells
            //and to automatically adjust the width of the column containing
            //the row header cells so that it can accommodate the new row
            //numbers,

            //store a string representation of the row number in 'strRowNumber'
            string strRowNumber = (e.RowIndex + 1).ToString();

            //prepend leading zeros to the string if necessary to improve
            //appearance. For example, if there are ten rows in the grid,
            //row seven will be numbered as "07" instead of "7". Similarly, if 
            //there are 100 rows in the grid, row seven will be numbered as "007".
            while (strRowNumber.Length < this.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

            //determine the display size of the row number string using
            //the DataGridView's current font.
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

            //adjust the width of the column that contains the row header cells 
            //if necessary
            if (this.RowHeadersWidth < (int)(size.Width + 20)) this.RowHeadersWidth = (int)(size.Width + 20);

            //this brush will be used to draw the row number string on the
            //row header cell using the system's current ControlText color
            Brush b;
            if ((e.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.Selected)
            {
                b = SystemBrushes.ControlText;
            }
            else
            {
                b = SystemBrushes.ActiveCaptionText;
            }

            //draw the row number string on the current row header cell using
            //the brush defined above and the DataGridView's default font
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

            //call the base object's OnRowPostPaint method
            base.OnRowPostPaint(e);
        } //end OnRowPostPaint method

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MyDataGridView
            // 
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            if (!_currentlyLoading && _stateDataSource != null && this.IsColumnWidthChanged)
            {
                List<DataGridViewColumnSettingsRow> liSettingsRow = this.GetColumnsSizeExt();
                _stateDataSource.SaveSettings(liSettingsRow);
            }

            base.OnColumnWidthChanged(e);
        }

        public void SetStateSourceAndLoadState(Employee employee, DataGridViewColumnSettingsAccessor dataSource)
        {
            _employee = employee;
            _stateDataSource = dataSource;

            List<DataGridViewColumnSettingsRow> liColumnSettings = _stateDataSource.GetSettings(employee.ID, this.Parent.Name + "_" + this.Name);

            _currentlyLoading = true;
            try
            {
                this.LoadColumnsSize(liColumnSettings);
            }
            finally
            {
                _currentlyLoading = false;
            }
        }

        private DataGridViewCell m_Cell;
        protected override void OnGotFocus(EventArgs e)
        {
            if (this.m_Cell != null)
            {
                if (m_Cell.RowIndex >= 0)
                {
                    this.CurrentCell = this.m_Cell;
                }
            }

            if (this.CurrentCell != null)
            {
                this.CurrentCell.Selected = true;
            }

            base.OnGotFocus(e);
        }
        protected override void OnLostFocus(EventArgs e)
        {
            this.m_Cell = this.CurrentCell;
            if (this.CurrentCell != null)
            {
                this.CurrentCell.Selected = false;
            }
            base.OnLostFocus(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Up:
                case Keys.Down:
                    {
                        _onRowChangedBlocked = true;
                    }
                    break;

                default:
                    break;
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Up:
                case Keys.Down:
                    {
                        _onRowChangedBlocked = false;

                        if (CurrentRow != null)
                            OnCurrentRowChange(CurrentRow.Index);
                    }
                    break;

                default:
                    break;
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

        #region CurrentRowChanged
        public event EventHandler<CurrentRowChangedEventArgs> CurrentRowChanged;

        private void OnCurrentRowChange(int RowIndex)
        {
            if (CurrentRowChanged != null)
            {
                _previousRowIndex = RowIndex;
                CurrentRowChangedEventArgs e = new CurrentRowChangedEventArgs(RowIndex);
                CurrentRowChanged.Invoke(this, e);
            }

        }
        public class CurrentRowChangedEventArgs : EventArgs
        {
            public CurrentRowChangedEventArgs(int RowIndex)
            {
                _RowIndex = RowIndex;
            }

            private int _RowIndex;

            public int RowIndex
            {
                get { return _RowIndex; }
                set { _RowIndex = value; }
            }
        }
        #endregion

        #region ColumnSizeLogic
        public void LoadColumnsSize(List<DataGridViewColumnSettingsRow> liDataGridViewColumnSettingsRow)
        {
            _liDataGridViewColumnSettingsLoaded = liDataGridViewColumnSettingsRow;
            foreach (DataGridViewColumnSettingsRow settingsRow in liDataGridViewColumnSettingsRow)
            {
                if (settingsRow.ColumnIndex < this.Columns.Count)
                {
                    this.Columns[settingsRow.ColumnIndex].Width = settingsRow.ColumnSize;
                }
            }
        }

        public List<DataGridViewColumnSettingsRow> GetColumnsSizeExt()
        {
            List<DataGridViewColumnSettingsRow> liDataGridViewColumnSettingsRows = new List<DataGridViewColumnSettingsRow>(this.Columns.Count);

            for (int i = 0; i < this.Columns.Count; i++)
            {
                DataGridViewColumnSettingsRow settingsRow = new DataGridViewColumnSettingsRow();
                settingsRow.ColumnIndex = i;
                settingsRow.ColumnSize = this.Columns[i].Width;
                settingsRow.GridName = this.Parent.Name + "_" + this.Name;
                settingsRow.Employee = _employee;
                liDataGridViewColumnSettingsRows.Add(settingsRow);
            }
            return liDataGridViewColumnSettingsRows;
        }

        public bool IsColumnWidthChanged
        {
            get
            {
                if (this.Columns.Count > _liDataGridViewColumnSettingsLoaded.Count)
                {
                    return true;
                }

                for (int i = 0; i < this.Columns.Count; i++)
                {
                    if (_liDataGridViewColumnSettingsLoaded[i].ColumnSize != this.Columns[i].Width)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        #endregion
    }
}
