namespace Apteka.Plus.UserControls
{
    partial class ucProductSuppliesTable
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProductSupplies = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localBillNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAcceptedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysDisposal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeSpan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSupply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyStore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localBillsRowExBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressIndicatorEx1 = new Apteka.Plus.LowLevelControls.ProgressIndicatorEx();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSupplies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsRowExBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MyStore";
            this.dataGridViewTextBoxColumn1.HeaderText = "Передача";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MyStore";
            this.dataGridViewTextBoxColumn2.HeaderText = "Передача";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dgvProductSupplies
            // 
            this.dgvProductSupplies.AllowUserToAddRows = false;
            this.dgvProductSupplies.AllowUserToDeleteRows = false;
            this.dgvProductSupplies.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvProductSupplies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvProductSupplies.AutoGenerateColumns = false;
            this.dgvProductSupplies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductSupplies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.PackageName,
            this.localBillNumberDataGridViewTextBoxColumn,
            this.dateAcceptedDataGridViewTextBoxColumn,
            this.SupplierPrice,
            this.StartPrice,
            this.CurrentPrice,
            this.startAmountDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.DaysDisposal,
            this.DateSupply,
            this.SupplierName,
            this.MyStore,
            this.TimeSpan});
            this.dgvProductSupplies.DataSource = this.localBillsRowExBindingSource;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.NullValue = "Пусто";
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductSupplies.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvProductSupplies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductSupplies.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductSupplies.Location = new System.Drawing.Point(0, 0);
            this.dgvProductSupplies.Name = "dgvProductSupplies";
            this.dgvProductSupplies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductSupplies.Size = new System.Drawing.Size(756, 319);
            this.dgvProductSupplies.TabIndex = 0;
            this.dgvProductSupplies.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductSupplies_CellDoubleClick);
            this.dgvProductSupplies.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvProductSupplies_CellParsing);
            this.dgvProductSupplies.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductSupplies_CellFormatting);
            this.dgvProductSupplies.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProductSupplies_CellValidating);
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Название";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // PackageName
            // 
            this.PackageName.DataPropertyName = "PackageName";
            this.PackageName.HeaderText = "Фасовка";
            this.PackageName.Name = "PackageName";
            this.PackageName.ReadOnly = true;
            // 
            // localBillNumberDataGridViewTextBoxColumn
            // 
            this.localBillNumberDataGridViewTextBoxColumn.DataPropertyName = "LocalBillNumber";
            this.localBillNumberDataGridViewTextBoxColumn.HeaderText = "Номер накладной";
            this.localBillNumberDataGridViewTextBoxColumn.Name = "localBillNumberDataGridViewTextBoxColumn";
            this.localBillNumberDataGridViewTextBoxColumn.Width = 113;
            // 
            // dateAcceptedDataGridViewTextBoxColumn
            // 
            this.dateAcceptedDataGridViewTextBoxColumn.DataPropertyName = "DateAccepted";
            this.dateAcceptedDataGridViewTextBoxColumn.HeaderText = "Дата отпуска";
            this.dateAcceptedDataGridViewTextBoxColumn.Name = "dateAcceptedDataGridViewTextBoxColumn";
            this.dateAcceptedDataGridViewTextBoxColumn.Width = 93;
            // 
            // SupplierPrice
            // 
            this.SupplierPrice.DataPropertyName = "SupplierPrice";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.SupplierPrice.DefaultCellStyle = dataGridViewCellStyle11;
            this.SupplierPrice.HeaderText = "Цена поставщика";
            this.SupplierPrice.Name = "SupplierPrice";
            this.SupplierPrice.ReadOnly = true;
            // 
            // StartPrice
            // 
            this.StartPrice.DataPropertyName = "StartPrice";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.StartPrice.DefaultCellStyle = dataGridViewCellStyle12;
            this.StartPrice.HeaderText = "Начальная цена";
            this.StartPrice.Name = "StartPrice";
            // 
            // CurrentPrice
            // 
            this.CurrentPrice.DataPropertyName = "CurrentPrice";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.CurrentPrice.DefaultCellStyle = dataGridViewCellStyle13;
            this.CurrentPrice.HeaderText = "Цена";
            this.CurrentPrice.Name = "CurrentPrice";
            this.CurrentPrice.Width = 96;
            // 
            // startAmountDataGridViewTextBoxColumn
            // 
            this.startAmountDataGridViewTextBoxColumn.DataPropertyName = "StartAmount";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.startAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.startAmountDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.startAmountDataGridViewTextBoxColumn.Name = "startAmountDataGridViewTextBoxColumn";
            this.startAmountDataGridViewTextBoxColumn.Width = 66;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Остаток";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.Width = 74;
            // 
            // DaysDisposal
            // 
            this.DaysDisposal.DataPropertyName = "DaysDisposal";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DaysDisposal.DefaultCellStyle = dataGridViewCellStyle16;
            this.DaysDisposal.HeaderText = "Дни реализации";
            this.DaysDisposal.Name = "DaysDisposal";
            this.DaysDisposal.ReadOnly = true;
            // 
            // TimeSpan
            // 
            dataGridViewCellStyle17.Format = "N1";
            dataGridViewCellStyle17.NullValue = null;
            this.TimeSpan.DefaultCellStyle = dataGridViewCellStyle17;
            this.TimeSpan.HeaderText = "Опаздание";
            this.TimeSpan.Name = "TimeSpan";
            // 
            // DateSupply
            // 
            this.DateSupply.DataPropertyName = "DateSupply";
            this.DateSupply.HeaderText = "Дата прихода";
            this.DateSupply.Name = "DateSupply";
            this.DateSupply.ReadOnly = true;
            // 
            // SupplierName
            // 
            this.SupplierName.DataPropertyName = "SupplierName";
            this.SupplierName.HeaderText = "Поставщик";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            // 
            // MyStore
            // 
            this.MyStore.DataPropertyName = "MyStore";
            this.MyStore.HeaderText = "Передача";
            this.MyStore.Name = "MyStore";
            // 
            // localBillsRowExBindingSource
            // 
            this.localBillsRowExBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.LocalBillsRowEx);
            // 
            // progressIndicatorEx1
            // 
            this.progressIndicatorEx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressIndicatorEx1.Location = new System.Drawing.Point(13, 41);
            this.progressIndicatorEx1.Name = "progressIndicatorEx1";
            this.progressIndicatorEx1.Size = new System.Drawing.Size(243, 81);
            this.progressIndicatorEx1.TabIndex = 1;
            this.progressIndicatorEx1.Visible = false;
            // 
            // ucProductSuppliesTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressIndicatorEx1);
            this.Controls.Add(this.dgvProductSupplies);
            this.Name = "ucProductSuppliesTable";
            this.Size = new System.Drawing.Size(756, 319);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSupplies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsRowExBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource localBillsRowExBindingSource;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvProductSupplies;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private new System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn localBillNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcceptedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysDisposal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeSpan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSupply;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyStore;
        private Apteka.Plus.LowLevelControls.ProgressIndicatorEx progressIndicatorEx1;
    }
}
