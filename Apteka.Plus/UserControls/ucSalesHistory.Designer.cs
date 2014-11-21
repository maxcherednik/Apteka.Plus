namespace Apteka.Plus.UserControls
{
    partial class ucSalesHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmsSalesGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showCustomerPurchases = new System.Windows.Forms.ToolStripMenuItem();
            this.showWhoBuysThisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvSales = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.CustomerNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAcceptedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceWithDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmsSalesGridMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(51, 13);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(171, 20);
            this.tbSearch.TabIndex = 17;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 16);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 16;
            this.lblSearch.Text = "Поиск:";
            // 
            // cmsSalesGridMenu
            // 
            this.cmsSalesGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCustomerPurchases,
            this.showWhoBuysThisItem});
            this.cmsSalesGridMenu.Name = "contextMenuStrip1";
            this.cmsSalesGridMenu.Size = new System.Drawing.Size(206, 48);
            this.cmsSalesGridMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsSalesGridMenu_ItemClicked);
            this.cmsSalesGridMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsSalesGridMenu_Opening);
            // 
            // showCustomerPurchases
            // 
            this.showCustomerPurchases.Name = "showCustomerPurchases";
            this.showCustomerPurchases.Size = new System.Drawing.Size(205, 22);
            this.showCustomerPurchases.Text = "Что покупает клиент?";
            // 
            // showWhoBuysThisItem
            // 
            this.showWhoBuysThisItem.Enabled = false;
            this.showWhoBuysThisItem.Name = "showWhoBuysThisItem";
            this.showWhoBuysThisItem.Size = new System.Drawing.Size(205, 22);
            this.showWhoBuysThisItem.Text = "Кто покупает препарат?";
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSales.AutoGenerateColumns = false;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerNumber,
            this.dateAcceptedDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.packageNameDataGridViewTextBoxColumn,
            this.Count,
            this.priceDataGridViewTextBoxColumn,
            this.PriceWithDiscount,
            this.Discount1,
            this.employeeDataGridViewTextBoxColumn,
            this.ClientID});
            this.dgvSales.DataSource = this.salesRowBindingSource;
            this.dgvSales.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSales.Location = new System.Drawing.Point(3, 42);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(1209, 597);
            this.dgvSales.TabIndex = 14;
            this.dgvSales.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvSales_MouseDown);
            this.dgvSales.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSales_ColumnHeaderMouseClick);
            this.dgvSales.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvSales_CellParsing);
            this.dgvSales.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSales_CellFormatting);
            this.dgvSales.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSales_CellValidating);
            this.dgvSales.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvSales_MouseUp);
            this.dgvSales.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSales_KeyDown);
            this.dgvSales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvSales_KeyPress);
            // 
            // CustomerNumber
            // 
            this.CustomerNumber.DataPropertyName = "CustomerNumber";
            this.CustomerNumber.HeaderText = "Покупатель";
            this.CustomerNumber.Name = "CustomerNumber";
            this.CustomerNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dateAcceptedDataGridViewTextBoxColumn
            // 
            this.dateAcceptedDataGridViewTextBoxColumn.DataPropertyName = "DateAccepted";
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.dateAcceptedDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dateAcceptedDataGridViewTextBoxColumn.HeaderText = "Время продажи";
            this.dateAcceptedDataGridViewTextBoxColumn.Name = "dateAcceptedDataGridViewTextBoxColumn";
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
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Count.DefaultCellStyle = dataGridViewCellStyle3;
            this.Count.HeaderText = "Кол-во";
            this.Count.Name = "Count";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // PriceWithDiscount
            // 
            this.PriceWithDiscount.DataPropertyName = "PriceWithDiscount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.PriceWithDiscount.DefaultCellStyle = dataGridViewCellStyle5;
            this.PriceWithDiscount.HeaderText = "Цена скидка";
            this.PriceWithDiscount.Name = "PriceWithDiscount";
            // 
            // Discount1
            // 
            this.Discount1.DataPropertyName = "Discount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N1";
            dataGridViewCellStyle6.NullValue = null;
            this.Discount1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Discount1.HeaderText = "Скидка";
            this.Discount1.Name = "Discount1";
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Смена";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            // 
            // ClientID
            // 
            this.ClientID.DataPropertyName = "ClientID";
            this.ClientID.HeaderText = "ID клиента";
            this.ClientID.Name = "ClientID";
            // 
            // salesRowBindingSource
            // 
            this.salesRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.SalesRow);
            // 
            // ucSalesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dgvSales);
            this.Name = "ucSalesHistory";
            this.Size = new System.Drawing.Size(1215, 642);
            this.cmsSalesGridMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesRowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource salesRowBindingSource;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcceptedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceWithDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientID;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ContextMenuStrip cmsSalesGridMenu;
        private System.Windows.Forms.ToolStripMenuItem showCustomerPurchases;
        private System.Windows.Forms.ToolStripMenuItem showWhoBuysThisItem;
    }
}
