namespace Apteka.Plus.UserControls
{
    partial class ucProductSuppliesHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProductSuppliesHistory = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.localBillsRowExBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAcceptedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localBillNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierBillNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSupplyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myStoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSuppliesHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsRowExBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductSuppliesHistory
            // 
            this.dgvProductSuppliesHistory.AllowUserToAddRows = false;
            this.dgvProductSuppliesHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvProductSuppliesHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductSuppliesHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductSuppliesHistory.AutoGenerateColumns = false;
            this.dgvProductSuppliesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductSuppliesHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNameDataGridViewTextBoxColumn,
            this.packageNameDataGridViewTextBoxColumn,
            this.dateAcceptedDataGridViewTextBoxColumn,
            this.localBillNumberDataGridViewTextBoxColumn,
            this.startPriceDataGridViewTextBoxColumn,
            this.currentPriceDataGridViewTextBoxColumn,
            this.startAmountDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.supplierBillNumberDataGridViewTextBoxColumn,
            this.supplierNameDataGridViewTextBoxColumn,
            this.dateSupplyDataGridViewTextBoxColumn,
            this.myStoreDataGridViewTextBoxColumn});
            this.dgvProductSuppliesHistory.DataSource = this.localBillsRowExBindingSource;
            this.dgvProductSuppliesHistory.Location = new System.Drawing.Point(0, 34);
            this.dgvProductSuppliesHistory.Name = "dgvProductSuppliesHistory";
            this.dgvProductSuppliesHistory.ReadOnly = true;
            this.dgvProductSuppliesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductSuppliesHistory.Size = new System.Drawing.Size(753, 426);
            this.dgvProductSuppliesHistory.TabIndex = 0;
            this.dgvProductSuppliesHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductSuppliesHistory_KeyDown);
            // 
            // localBillsRowExBindingSource
            // 
            this.localBillsRowExBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.LocalBillsRowEx);
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // packageNameDataGridViewTextBoxColumn
            // 
            this.packageNameDataGridViewTextBoxColumn.DataPropertyName = "PackageName";
            this.packageNameDataGridViewTextBoxColumn.HeaderText = "Фасовка";
            this.packageNameDataGridViewTextBoxColumn.Name = "packageNameDataGridViewTextBoxColumn";
            this.packageNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateAcceptedDataGridViewTextBoxColumn
            // 
            this.dateAcceptedDataGridViewTextBoxColumn.DataPropertyName = "DateAccepted";
            this.dateAcceptedDataGridViewTextBoxColumn.HeaderText = "Дата отпуска";
            this.dateAcceptedDataGridViewTextBoxColumn.Name = "dateAcceptedDataGridViewTextBoxColumn";
            this.dateAcceptedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localBillNumberDataGridViewTextBoxColumn
            // 
            this.localBillNumberDataGridViewTextBoxColumn.DataPropertyName = "LocalBillNumber";
            this.localBillNumberDataGridViewTextBoxColumn.HeaderText = "Номер внутренней накладной";
            this.localBillNumberDataGridViewTextBoxColumn.Name = "localBillNumberDataGridViewTextBoxColumn";
            this.localBillNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startPriceDataGridViewTextBoxColumn
            // 
            this.startPriceDataGridViewTextBoxColumn.DataPropertyName = "StartPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.startPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.startPriceDataGridViewTextBoxColumn.HeaderText = "Начальная цена";
            this.startPriceDataGridViewTextBoxColumn.Name = "startPriceDataGridViewTextBoxColumn";
            this.startPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentPriceDataGridViewTextBoxColumn
            // 
            this.currentPriceDataGridViewTextBoxColumn.DataPropertyName = "CurrentPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.currentPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.currentPriceDataGridViewTextBoxColumn.HeaderText = "Текущая цена";
            this.currentPriceDataGridViewTextBoxColumn.Name = "currentPriceDataGridViewTextBoxColumn";
            this.currentPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startAmountDataGridViewTextBoxColumn
            // 
            this.startAmountDataGridViewTextBoxColumn.DataPropertyName = "StartAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.startAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.startAmountDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.startAmountDataGridViewTextBoxColumn.Name = "startAmountDataGridViewTextBoxColumn";
            this.startAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Остаток";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierBillNumberDataGridViewTextBoxColumn
            // 
            this.supplierBillNumberDataGridViewTextBoxColumn.DataPropertyName = "SupplierBillNumber";
            this.supplierBillNumberDataGridViewTextBoxColumn.HeaderText = "Номер накладной поставщика";
            this.supplierBillNumberDataGridViewTextBoxColumn.Name = "supplierBillNumberDataGridViewTextBoxColumn";
            this.supplierBillNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierNameDataGridViewTextBoxColumn
            // 
            this.supplierNameDataGridViewTextBoxColumn.DataPropertyName = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.supplierNameDataGridViewTextBoxColumn.Name = "supplierNameDataGridViewTextBoxColumn";
            this.supplierNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateSupplyDataGridViewTextBoxColumn
            // 
            this.dateSupplyDataGridViewTextBoxColumn.DataPropertyName = "DateSupply";
            this.dateSupplyDataGridViewTextBoxColumn.HeaderText = "Дата прихода";
            this.dateSupplyDataGridViewTextBoxColumn.Name = "dateSupplyDataGridViewTextBoxColumn";
            this.dateSupplyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // myStoreDataGridViewTextBoxColumn
            // 
            this.myStoreDataGridViewTextBoxColumn.DataPropertyName = "MyStore";
            this.myStoreDataGridViewTextBoxColumn.HeaderText = "Передача";
            this.myStoreDataGridViewTextBoxColumn.Name = "myStoreDataGridViewTextBoxColumn";
            this.myStoreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(51, 8);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(171, 20);
            this.tbSearch.TabIndex = 18;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 17;
            this.lblSearch.Text = "Поиск:";
            // 
            // ucProductSuppliesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dgvProductSuppliesHistory);
            this.Name = "ucProductSuppliesHistory";
            this.Size = new System.Drawing.Size(753, 460);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSuppliesHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsRowExBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Apteka.Plus.Common.Controls.MyDataGridView dgvProductSuppliesHistory;
        private System.Windows.Forms.BindingSource localBillsRowExBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcceptedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localBillNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierBillNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSupplyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn myStoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;

    }
}
