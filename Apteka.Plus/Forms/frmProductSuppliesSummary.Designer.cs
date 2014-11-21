namespace Apteka.Plus.Forms
{
    partial class frmProductSuppliesSummary
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvProductSuppliesSummary = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.mainStoreRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateSupplyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierBillNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSuppliesSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainStoreRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductSuppliesSummary
            // 
            this.dgvProductSuppliesSummary.AllowUserToAddRows = false;
            this.dgvProductSuppliesSummary.AllowUserToDeleteRows = false;
            this.dgvProductSuppliesSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductSuppliesSummary.AutoGenerateColumns = false;
            this.dgvProductSuppliesSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductSuppliesSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateSupplyDataGridViewTextBoxColumn,
            this.supplierBillNumberDataGridViewTextBoxColumn,
            this.ProductName,
            this.PackageName,
            this.supplierPriceDataGridViewTextBoxColumn,
            this.startAmountDataGridViewTextBoxColumn,
            this.extraDataGridViewTextBoxColumn,
            this.localPriceDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn,
            this.seriesDataGridViewTextBoxColumn,
            this.SupplierName});
            this.dgvProductSuppliesSummary.DataSource = this.mainStoreRowBindingSource;
            this.dgvProductSuppliesSummary.Location = new System.Drawing.Point(12, 66);
            this.dgvProductSuppliesSummary.Name = "dgvProductSuppliesSummary";
            this.dgvProductSuppliesSummary.ReadOnly = true;
            this.dgvProductSuppliesSummary.Size = new System.Drawing.Size(862, 374);
            this.dgvProductSuppliesSummary.TabIndex = 0;
            // 
            // mainStoreRowBindingSource
            // 
            this.mainStoreRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MainStoreRow);
            // 
            // dateSupplyDataGridViewTextBoxColumn
            // 
            this.dateSupplyDataGridViewTextBoxColumn.DataPropertyName = "DateSupply";
            this.dateSupplyDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateSupplyDataGridViewTextBoxColumn.Name = "dateSupplyDataGridViewTextBoxColumn";
            this.dateSupplyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierBillNumberDataGridViewTextBoxColumn
            // 
            this.supplierBillNumberDataGridViewTextBoxColumn.DataPropertyName = "SupplierBillNumber";
            this.supplierBillNumberDataGridViewTextBoxColumn.HeaderText = "№ накладной";
            this.supplierBillNumberDataGridViewTextBoxColumn.Name = "supplierBillNumberDataGridViewTextBoxColumn";
            this.supplierBillNumberDataGridViewTextBoxColumn.ReadOnly = true;
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
            // supplierPriceDataGridViewTextBoxColumn
            // 
            this.supplierPriceDataGridViewTextBoxColumn.DataPropertyName = "SupplierPrice";
            this.supplierPriceDataGridViewTextBoxColumn.HeaderText = "Цена поставщика";
            this.supplierPriceDataGridViewTextBoxColumn.Name = "supplierPriceDataGridViewTextBoxColumn";
            this.supplierPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startAmountDataGridViewTextBoxColumn
            // 
            this.startAmountDataGridViewTextBoxColumn.DataPropertyName = "StartAmount";
            this.startAmountDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.startAmountDataGridViewTextBoxColumn.Name = "startAmountDataGridViewTextBoxColumn";
            this.startAmountDataGridViewTextBoxColumn.ReadOnly = true;
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
            // SupplierName
            // 
            this.SupplierName.DataPropertyName = "SupplierName";
            this.SupplierName.HeaderText = "Фирма";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            // 
            // frmProductSuppliesSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 452);
            this.Controls.Add(this.dgvProductSuppliesSummary);
            this.Name = "frmProductSuppliesSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поступление товара";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSuppliesSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainStoreRowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Apteka.Plus.Common.Controls.MyDataGridView dgvProductSuppliesSummary;
        private System.Windows.Forms.BindingSource mainStoreRowBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSupplyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierBillNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
    }
}