namespace Apteka.Plus.Forms
{
    partial class frmSuppliersSummaries
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvSuppliersSummaries = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.supplierSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cbSuppliers = new System.Windows.Forms.ComboBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateSupplyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierBillNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliersSummaries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierSummaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "до:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "от:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(476, 4);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(171, 20);
            this.dtpEndDate.TabIndex = 23;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(663, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(71, 23);
            this.btnLoad.TabIndex = 22;
            this.btnLoad.Text = "Показать";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvSuppliersSummaries
            // 
            this.dgvSuppliersSummaries.AllowUserToAddRows = false;
            this.dgvSuppliersSummaries.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvSuppliersSummaries.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSuppliersSummaries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSuppliersSummaries.AutoGenerateColumns = false;
            this.dgvSuppliersSummaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuppliersSummaries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateSupplyDataGridViewTextBoxColumn,
            this.SupplierName,
            this.supplierBillNumberDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn});
            this.dgvSuppliersSummaries.DataSource = this.supplierSummaryBindingSource;
            this.dgvSuppliersSummaries.Location = new System.Drawing.Point(12, 31);
            this.dgvSuppliersSummaries.Name = "dgvSuppliersSummaries";
            this.dgvSuppliersSummaries.ReadOnly = true;
            this.dgvSuppliersSummaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliersSummaries.Size = new System.Drawing.Size(888, 388);
            this.dgvSuppliersSummaries.TabIndex = 26;
            // 
            // supplierSummaryBindingSource
            // 
            this.supplierSummaryBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.SupplierSummary);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Поставщик:";
            // 
            // cbSuppliers
            // 
            this.cbSuppliers.DataSource = this.supplierBindingSource;
            this.cbSuppliers.DisplayMember = "Name";
            this.cbSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSuppliers.FormattingEnabled = true;
            this.cbSuppliers.Location = new System.Drawing.Point(86, 5);
            this.cbSuppliers.Name = "cbSuppliers";
            this.cbSuppliers.Size = new System.Drawing.Size(152, 21);
            this.cbSuppliers.TabIndex = 28;
            this.cbSuppliers.ValueMember = "ID";
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.Supplier);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Checked = false;
            this.dtpStartDate.Location = new System.Drawing.Point(271, 5);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(171, 20);
            this.dtpStartDate.TabIndex = 21;
            this.dtpStartDate.Value = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            // 
            // dateSupplyDataGridViewTextBoxColumn
            // 
            this.dateSupplyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateSupplyDataGridViewTextBoxColumn.DataPropertyName = "DateSupply";
            this.dateSupplyDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateSupplyDataGridViewTextBoxColumn.Name = "dateSupplyDataGridViewTextBoxColumn";
            this.dateSupplyDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateSupplyDataGridViewTextBoxColumn.Width = 58;
            // 
            // SupplierName
            // 
            this.SupplierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SupplierName.DataPropertyName = "SupplierName";
            this.SupplierName.HeaderText = "Поставщик";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            this.SupplierName.Width = 90;
            // 
            // supplierBillNumberDataGridViewTextBoxColumn
            // 
            this.supplierBillNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.supplierBillNumberDataGridViewTextBoxColumn.DataPropertyName = "SupplierBillNumber";
            this.supplierBillNumberDataGridViewTextBoxColumn.HeaderText = "Накладная";
            this.supplierBillNumberDataGridViewTextBoxColumn.Name = "supplierBillNumberDataGridViewTextBoxColumn";
            this.supplierBillNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierBillNumberDataGridViewTextBoxColumn.Width = 88;
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.sumDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.sumDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            this.sumDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumDataGridViewTextBoxColumn.Width = 66;
            // 
            // btnReport
            // 
            this.btnReport.Enabled = false;
            this.btnReport.Location = new System.Drawing.Point(740, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 29;
            this.btnReport.Text = "График";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmSuppliersSummaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 431);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.cbSuppliers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvSuppliersSummaries);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dtpStartDate);
            this.Name = "frmSuppliersSummaries";
            this.Text = "Приход по фирмам";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSuppliersSummaries_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSuppliersSummaries_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliersSummaries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierSummaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvSuppliersSummaries;
        private System.Windows.Forms.BindingSource supplierSummaryBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSuppliers;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSupplyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierBillNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnReport;
    }
}