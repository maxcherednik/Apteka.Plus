namespace Apteka.Plus.UserControls
{
    partial class ucSuppliesReturnHistory
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvSuppliesReturnHistory = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.suppliesReturnHistoryRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DateAccepted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierDateSupply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierBillNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliesReturnHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliesReturnHistoryRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(51, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(171, 20);
            this.tbSearch.TabIndex = 18;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 17;
            this.lblSearch.Text = "Поиск:";
            // 
            // dgvSuppliesReturnHistory
            // 
            this.dgvSuppliesReturnHistory.AllowUserToAddRows = false;
            this.dgvSuppliesReturnHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvSuppliesReturnHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSuppliesReturnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSuppliesReturnHistory.AutoGenerateColumns = false;
            this.dgvSuppliesReturnHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSuppliesReturnHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliesReturnHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateAccepted,
            this.productNameDataGridViewTextBoxColumn,
            this.packageNameDataGridViewTextBoxColumn,
            this.startAmountDataGridViewTextBoxColumn,
            this.Price,
            this.supplierNameDataGridViewTextBoxColumn,
            this.SupplierDateSupply,
            this.SupplierBillNumber,
            this.Employee,
            this.Comment});
            this.dgvSuppliesReturnHistory.DataSource = this.suppliesReturnHistoryRowBindingSource;
            this.dgvSuppliesReturnHistory.Location = new System.Drawing.Point(0, 32);
            this.dgvSuppliesReturnHistory.Name = "dgvSuppliesReturnHistory";
            this.dgvSuppliesReturnHistory.ReadOnly = true;
            this.dgvSuppliesReturnHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliesReturnHistory.Size = new System.Drawing.Size(794, 443);
            this.dgvSuppliesReturnHistory.TabIndex = 19;
            // 
            // suppliesReturnHistoryRowBindingSource
            // 
            this.suppliesReturnHistoryRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.SuppliesReturnHistoryRow);
            // 
            // DateAccepted
            // 
            this.DateAccepted.DataPropertyName = "DateAccepted";
            this.DateAccepted.HeaderText = "Дата возврата";
            this.DateAccepted.Name = "DateAccepted";
            this.DateAccepted.ReadOnly = true;
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
            // startAmountDataGridViewTextBoxColumn
            // 
            this.startAmountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.startAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.startAmountDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.startAmountDataGridViewTextBoxColumn.Name = "startAmountDataGridViewTextBoxColumn";
            this.startAmountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Price.DefaultCellStyle = dataGridViewCellStyle3;
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // supplierNameDataGridViewTextBoxColumn
            // 
            this.supplierNameDataGridViewTextBoxColumn.DataPropertyName = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.supplierNameDataGridViewTextBoxColumn.Name = "supplierNameDataGridViewTextBoxColumn";
            this.supplierNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // SupplierDateSupply
            // 
            this.SupplierDateSupply.DataPropertyName = "SupplierDateSupply";
            this.SupplierDateSupply.HeaderText = "Дата прихода";
            this.SupplierDateSupply.Name = "SupplierDateSupply";
            this.SupplierDateSupply.ReadOnly = true;
            // 
            // SupplierBillNumber
            // 
            this.SupplierBillNumber.DataPropertyName = "SupplierBillNumber";
            this.SupplierBillNumber.HeaderText = "Номер накладной поставщика";
            this.SupplierBillNumber.Name = "SupplierBillNumber";
            this.SupplierBillNumber.ReadOnly = true;
            // 
            // Employee
            // 
            this.Employee.DataPropertyName = "Employee";
            this.Employee.HeaderText = "Смена";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Comment.DefaultCellStyle = dataGridViewCellStyle4;
            this.Comment.HeaderText = "Комментарий";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // ucSuppliesReturnHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSuppliesReturnHistory);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "ucSuppliesReturnHistory";
            this.Size = new System.Drawing.Size(794, 475);
            
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliesReturnHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliesReturnHistoryRowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvSuppliesReturnHistory;
        private System.Windows.Forms.BindingSource suppliesReturnHistoryRowBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAccepted;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierDateSupply;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierBillNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}
