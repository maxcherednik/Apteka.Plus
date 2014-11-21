namespace Apteka.Plus.Forms
{
    partial class frmFinanceCollection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFinanceCollection = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountComputer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountCollected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financeCollectionRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblChooseSatelite = new System.Windows.Forms.Label();
            this.cbMyStores = new System.Windows.Forms.ComboBox();
            this.myStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinanceCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeCollectionRowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFinanceCollection
            // 
            this.dgvFinanceCollection.AllowUserToAddRows = false;
            this.dgvFinanceCollection.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvFinanceCollection.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvFinanceCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFinanceCollection.AutoGenerateColumns = false;
            this.dgvFinanceCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinanceCollection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Employee,
            this.AmountComputer,
            this.AmountCollected,
            this.Difference,
            this.Comment});
            this.dgvFinanceCollection.DataSource = this.financeCollectionRowBindingSource;
            this.dgvFinanceCollection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFinanceCollection.Location = new System.Drawing.Point(3, 33);
            this.dgvFinanceCollection.Name = "dgvFinanceCollection";
            this.dgvFinanceCollection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFinanceCollection.Size = new System.Drawing.Size(800, 403);
            this.dgvFinanceCollection.TabIndex = 0;
            this.dgvFinanceCollection.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvFinanceCollection_CellParsing);
            this.dgvFinanceCollection.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFinanceCollection_CellFormatting);
            this.dgvFinanceCollection.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvFinanceCollection_CellValidating);
            this.dgvFinanceCollection.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFinanceCollection_CellMouseDoubleClick);
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            // 
            // Employee
            // 
            this.Employee.DataPropertyName = "Employee";
            this.Employee.HeaderText = "Смена";
            this.Employee.Name = "Employee";
            // 
            // AmountComputer
            // 
            this.AmountComputer.DataPropertyName = "AmountComputer";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.AmountComputer.DefaultCellStyle = dataGridViewCellStyle10;
            this.AmountComputer.HeaderText = "Сумма компьютер";
            this.AmountComputer.Name = "AmountComputer";
            // 
            // AmountCollected
            // 
            this.AmountCollected.DataPropertyName = "AmountCollected";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.AmountCollected.DefaultCellStyle = dataGridViewCellStyle11;
            this.AmountCollected.HeaderText = "Сумма получено";
            this.AmountCollected.Name = "AmountCollected";
            // 
            // Difference
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.Difference.DefaultCellStyle = dataGridViewCellStyle12;
            this.Difference.HeaderText = "Разница";
            this.Difference.Name = "Difference";
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Комментарий";
            this.Comment.Name = "Comment";
            // 
            // financeCollectionRowBindingSource
            // 
            this.financeCollectionRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.FinanceCollectionRow);
            // 
            // lblChooseSatelite
            // 
            this.lblChooseSatelite.AutoSize = true;
            this.lblChooseSatelite.Location = new System.Drawing.Point(9, 9);
            this.lblChooseSatelite.Name = "lblChooseSatelite";
            this.lblChooseSatelite.Size = new System.Drawing.Size(91, 13);
            this.lblChooseSatelite.TabIndex = 14;
            this.lblChooseSatelite.Text = "Выберите пункт:";
            // 
            // cbMyStores
            // 
            this.cbMyStores.DataSource = this.myStoreBindingSource;
            this.cbMyStores.DisplayMember = "Name";
            this.cbMyStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMyStores.FormattingEnabled = true;
            this.cbMyStores.Location = new System.Drawing.Point(106, 6);
            this.cbMyStores.Name = "cbMyStores";
            this.cbMyStores.Size = new System.Drawing.Size(171, 21);
            this.cbMyStores.TabIndex = 15;
            this.cbMyStores.ValueMember = "ID";
            // 
            // myStoreBindingSource
            // 
            this.myStoreBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MyStore);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "MMMM yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(301, 6);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(159, 20);
            this.dtpDate.TabIndex = 16;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(477, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 17;
            this.btnLoad.Text = "Показать";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnReport
            // 
            this.btnReport.Enabled = false;
            this.btnReport.Location = new System.Drawing.Point(558, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 28;
            this.btnReport.Text = "График";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmFinanceCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 504);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.lblChooseSatelite);
            this.Controls.Add(this.cbMyStores);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvFinanceCollection);
            this.Name = "frmFinanceCollection";
            this.Text = "Сумма по работникам";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFinanceCollection_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinanceCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financeCollectionRowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Apteka.Plus.Common.Controls.MyDataGridView dgvFinanceCollection;
        private System.Windows.Forms.BindingSource financeCollectionRowBindingSource;
        private System.Windows.Forms.Label lblChooseSatelite;
        private System.Windows.Forms.ComboBox cbMyStores;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.BindingSource myStoreBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountComputer;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountCollected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.Button btnReport;
    }
}