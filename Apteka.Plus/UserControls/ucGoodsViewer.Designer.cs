namespace Apteka.Plus.UserControls
{
    partial class ucGoodsViewer
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
            this.localBillsRowExBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvLocalBills = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.progressIndicatorEx1 = new Apteka.Plus.LowLevelControls.ProgressIndicatorEx();
            this.dateAcceptedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localBillNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierBillNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSupplyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myStoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsRowExBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalBills)).BeginInit();
            this.SuspendLayout();
            // 
            // localBillsRowExBindingSource
            // 
            this.localBillsRowExBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.LocalBillsRowEx);
            this.localBillsRowExBindingSource.DataSourceChanged += new System.EventHandler(this.localBillsRowExBindingSource_DataSourceChanged);
            // 
            // dgvLocalBills
            // 
            this.dgvLocalBills.AllowUserToAddRows = false;
            this.dgvLocalBills.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvLocalBills.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalBills.AutoGenerateColumns = false;
            this.dgvLocalBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateAcceptedDataGridViewTextBoxColumn,
            this.localBillNumberDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.packageNameDataGridViewTextBoxColumn,
            this.supplierPriceDataGridViewTextBoxColumn,
            this.currentPriceDataGridViewTextBoxColumn,
            this.startAmountDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.supplierNameDataGridViewTextBoxColumn,
            this.SupplierBillNumber,
            this.dateSupplyDataGridViewTextBoxColumn,
            this.myStoreDataGridViewTextBoxColumn,
            this.ExpirationDate});
            this.dgvLocalBills.DataSource = this.localBillsRowExBindingSource;
            this.dgvLocalBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocalBills.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLocalBills.Location = new System.Drawing.Point(0, 0);
            this.dgvLocalBills.Name = "dgvLocalBills";
            this.dgvLocalBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalBills.Size = new System.Drawing.Size(1921, 526);
            this.dgvLocalBills.TabIndex = 1;
            this.dgvLocalBills.CurrentRowChanged += new System.EventHandler<Apteka.Plus.Common.Controls.MyDataGridView.CurrentRowChangedEventArgs>(this.dgvLocalBills_CurrentRowChanged);
            this.dgvLocalBills.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLocalBills_KeyDown);
            // 
            // progressIndicatorEx1
            // 
            this.progressIndicatorEx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressIndicatorEx1.Location = new System.Drawing.Point(14, 52);
            this.progressIndicatorEx1.Name = "progressIndicatorEx1";
            this.progressIndicatorEx1.Size = new System.Drawing.Size(243, 81);
            this.progressIndicatorEx1.TabIndex = 2;
            this.progressIndicatorEx1.Visible = false;
            // 
            // dateAcceptedDataGridViewTextBoxColumn
            // 
            this.dateAcceptedDataGridViewTextBoxColumn.DataPropertyName = "DateAccepted";
            this.dateAcceptedDataGridViewTextBoxColumn.HeaderText = "Дата поступления";
            this.dateAcceptedDataGridViewTextBoxColumn.Name = "dateAcceptedDataGridViewTextBoxColumn";
            this.dateAcceptedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localBillNumberDataGridViewTextBoxColumn
            // 
            this.localBillNumberDataGridViewTextBoxColumn.DataPropertyName = "LocalBillNumber";
            this.localBillNumberDataGridViewTextBoxColumn.HeaderText = "Номер накладной";
            this.localBillNumberDataGridViewTextBoxColumn.Name = "localBillNumberDataGridViewTextBoxColumn";
            this.localBillNumberDataGridViewTextBoxColumn.ReadOnly = true;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.supplierPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.supplierPriceDataGridViewTextBoxColumn.HeaderText = "Цена поставщика";
            this.supplierPriceDataGridViewTextBoxColumn.Name = "supplierPriceDataGridViewTextBoxColumn";
            this.supplierPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // currentPriceDataGridViewTextBoxColumn
            // 
            this.currentPriceDataGridViewTextBoxColumn.DataPropertyName = "CurrentPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
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
            // supplierNameDataGridViewTextBoxColumn
            // 
            this.supplierNameDataGridViewTextBoxColumn.DataPropertyName = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.supplierNameDataGridViewTextBoxColumn.Name = "supplierNameDataGridViewTextBoxColumn";
            this.supplierNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SupplierBillNumber
            // 
            this.SupplierBillNumber.DataPropertyName = "SupplierBillNumber";
            this.SupplierBillNumber.HeaderText = "Накладная поставщика";
            this.SupplierBillNumber.Name = "SupplierBillNumber";
            this.SupplierBillNumber.ReadOnly = true;
            // 
            // dateSupplyDataGridViewTextBoxColumn
            // 
            this.dateSupplyDataGridViewTextBoxColumn.DataPropertyName = "DateSupply";
            this.dateSupplyDataGridViewTextBoxColumn.HeaderText = "Дата закупки";
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
            // ExpirationDate
            // 
            this.ExpirationDate.DataPropertyName = "ExpirationDate";
            this.ExpirationDate.HeaderText = "Срок годности";
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.ReadOnly = true;
            // 
            // ucGoodsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressIndicatorEx1);
            this.Controls.Add(this.dgvLocalBills);
            this.Name = "ucGoodsViewer";
            this.Size = new System.Drawing.Size(1921, 526);
            this.Load += new System.EventHandler(this.ucGoodsViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.localBillsRowExBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalBills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource localBillsRowExBindingSource;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvLocalBills;
        private Apteka.Plus.LowLevelControls.ProgressIndicatorEx progressIndicatorEx1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcceptedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localBillNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierBillNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSupplyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn myStoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpirationDate;

    }
}
