namespace Apteka.Plus.UserControls
{
    partial class ucSuppliesHistory
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvSuppliesHistory = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.mainStoreRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSupplyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierBillNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eAN13DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliesHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainStoreRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(51, 17);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(171, 20);
            this.tbSearch.TabIndex = 16;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 15;
            this.lblSearch.Text = "Поиск:";
            // 
            // dgvSuppliesHistory
            // 
            this.dgvSuppliesHistory.AllowUserToAddRows = false;
            this.dgvSuppliesHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvSuppliesHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSuppliesHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSuppliesHistory.AutoGenerateColumns = false;
            this.dgvSuppliesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliesHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNameDataGridViewTextBoxColumn,
            this.packageNameDataGridViewTextBoxColumn,
            this.supplierPriceDataGridViewTextBoxColumn,
            this.extraDataGridViewTextBoxColumn,
            this.localPriceDataGridViewTextBoxColumn,
            this.startAmountDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.dateSupplyDataGridViewTextBoxColumn,
            this.supplierBillNumberDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn,
            this.seriesDataGridViewTextBoxColumn,
            this.eAN13DataGridViewTextBoxColumn,
            this.supplierNameDataGridViewTextBoxColumn});
            this.dgvSuppliesHistory.DataSource = this.mainStoreRowBindingSource;
            this.dgvSuppliesHistory.Location = new System.Drawing.Point(0, 54);
            this.dgvSuppliesHistory.Name = "dgvSuppliesHistory";
            this.dgvSuppliesHistory.ReadOnly = true;
            this.dgvSuppliesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliesHistory.Size = new System.Drawing.Size(867, 508);
            this.dgvSuppliesHistory.TabIndex = 14;
            // 
            // mainStoreRowBindingSource
            // 
            this.mainStoreRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MainStoreRow);
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
            // supplierPriceDataGridViewTextBoxColumn
            // 
            this.supplierPriceDataGridViewTextBoxColumn.DataPropertyName = "SupplierPrice";
            this.supplierPriceDataGridViewTextBoxColumn.HeaderText = "Цена поставщика";
            this.supplierPriceDataGridViewTextBoxColumn.Name = "supplierPriceDataGridViewTextBoxColumn";
            this.supplierPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // extraDataGridViewTextBoxColumn
            // 
            this.extraDataGridViewTextBoxColumn.DataPropertyName = "Extra";
            this.extraDataGridViewTextBoxColumn.HeaderText = "Наценка";
            this.extraDataGridViewTextBoxColumn.Name = "extraDataGridViewTextBoxColumn";
            this.extraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localPriceDataGridViewTextBoxColumn
            // 
            this.localPriceDataGridViewTextBoxColumn.DataPropertyName = "LocalPrice";
            this.localPriceDataGridViewTextBoxColumn.HeaderText = "Наша цена";
            this.localPriceDataGridViewTextBoxColumn.Name = "localPriceDataGridViewTextBoxColumn";
            this.localPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startAmountDataGridViewTextBoxColumn
            // 
            this.startAmountDataGridViewTextBoxColumn.DataPropertyName = "StartAmount";
            this.startAmountDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.startAmountDataGridViewTextBoxColumn.Name = "startAmountDataGridViewTextBoxColumn";
            this.startAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Остаток";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateSupplyDataGridViewTextBoxColumn
            // 
            this.dateSupplyDataGridViewTextBoxColumn.DataPropertyName = "DateSupply";
            this.dateSupplyDataGridViewTextBoxColumn.HeaderText = "Дата поступления";
            this.dateSupplyDataGridViewTextBoxColumn.Name = "dateSupplyDataGridViewTextBoxColumn";
            this.dateSupplyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierBillNumberDataGridViewTextBoxColumn
            // 
            this.supplierBillNumberDataGridViewTextBoxColumn.DataPropertyName = "SupplierBillNumber";
            this.supplierBillNumberDataGridViewTextBoxColumn.HeaderText = "Номер накладной";
            this.supplierBillNumberDataGridViewTextBoxColumn.Name = "supplierBillNumberDataGridViewTextBoxColumn";
            this.supplierBillNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expirationDateDataGridViewTextBoxColumn
            // 
            this.expirationDateDataGridViewTextBoxColumn.DataPropertyName = "ExpirationDate";
            this.expirationDateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expirationDateDataGridViewTextBoxColumn.Name = "expirationDateDataGridViewTextBoxColumn";
            this.expirationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seriesDataGridViewTextBoxColumn
            // 
            this.seriesDataGridViewTextBoxColumn.DataPropertyName = "Series";
            this.seriesDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.seriesDataGridViewTextBoxColumn.Name = "seriesDataGridViewTextBoxColumn";
            this.seriesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eAN13DataGridViewTextBoxColumn
            // 
            this.eAN13DataGridViewTextBoxColumn.DataPropertyName = "EAN13";
            this.eAN13DataGridViewTextBoxColumn.HeaderText = "Штрих-код";
            this.eAN13DataGridViewTextBoxColumn.Name = "eAN13DataGridViewTextBoxColumn";
            this.eAN13DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierNameDataGridViewTextBoxColumn
            // 
            this.supplierNameDataGridViewTextBoxColumn.DataPropertyName = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.supplierNameDataGridViewTextBoxColumn.Name = "supplierNameDataGridViewTextBoxColumn";
            this.supplierNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ucSuppliesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dgvSuppliesHistory);
            this.Name = "ucSuppliesHistory";
            this.Size = new System.Drawing.Size(867, 562);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliesHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainStoreRowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvSuppliesHistory;
        private System.Windows.Forms.BindingSource mainStoreRowBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSupplyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierBillNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eAN13DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameDataGridViewTextBoxColumn;

    }
}
