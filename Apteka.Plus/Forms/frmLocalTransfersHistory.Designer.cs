namespace Apteka.Plus.Forms
{
    partial class frmLocalTransfersHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbMyStores = new System.Windows.Forms.ComboBox();
            this.lblChooseSatelite = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbSearchHistory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadHistory = new System.Windows.Forms.Button();
            this.cbMystoresHistory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalTransfers = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.dateAcceptedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localBillsTransferRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSalesHistory = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.myStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsTransferRowBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 514);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvLocalTransfers);
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.tbSearch);
            this.tabPage1.Controls.Add(this.lblSearch);
            this.tabPage1.Controls.Add(this.btnLoad);
            this.tabPage1.Controls.Add(this.dtpDate);
            this.tabPage1.Controls.Add(this.cbMyStores);
            this.tabPage1.Controls.Add(this.lblChooseSatelite);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(779, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "За день";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSum});
            this.statusStrip1.Location = new System.Drawing.Point(3, 463);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(773, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslSum
            // 
            this.tsslSum.Name = "tsslSum";
            this.tsslSum.Size = new System.Drawing.Size(0, 17);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(105, 55);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(171, 20);
            this.tbSearch.TabIndex = 11;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(11, 59);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Поиск:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(526, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Показать";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(300, 11);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 8;
            // 
            // cbMyStores
            // 
            this.cbMyStores.DataSource = this.myStoreBindingSource;
            this.cbMyStores.DisplayMember = "Name";
            this.cbMyStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMyStores.FormattingEnabled = true;
            this.cbMyStores.Location = new System.Drawing.Point(105, 11);
            this.cbMyStores.Name = "cbMyStores";
            this.cbMyStores.Size = new System.Drawing.Size(171, 21);
            this.cbMyStores.TabIndex = 7;
            this.cbMyStores.ValueMember = "ID";
            // 
            // lblChooseSatelite
            // 
            this.lblChooseSatelite.AutoSize = true;
            this.lblChooseSatelite.Location = new System.Drawing.Point(8, 14);
            this.lblChooseSatelite.Name = "lblChooseSatelite";
            this.lblChooseSatelite.Size = new System.Drawing.Size(91, 13);
            this.lblChooseSatelite.TabIndex = 6;
            this.lblChooseSatelite.Text = "Выберите пункт:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvSalesHistory);
            this.tabPage2.Controls.Add(this.tbSearchHistory);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnLoadHistory);
            this.tabPage2.Controls.Add(this.cbMystoresHistory);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(779, 488);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "История";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbSearchHistory
            // 
            this.tbSearchHistory.Location = new System.Drawing.Point(346, 10);
            this.tbSearchHistory.Name = "tbSearchHistory";
            this.tbSearchHistory.Size = new System.Drawing.Size(171, 20);
            this.tbSearchHistory.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Поиск:";
            // 
            // btnLoadHistory
            // 
            this.btnLoadHistory.Location = new System.Drawing.Point(532, 8);
            this.btnLoadHistory.Name = "btnLoadHistory";
            this.btnLoadHistory.Size = new System.Drawing.Size(75, 23);
            this.btnLoadHistory.TabIndex = 15;
            this.btnLoadHistory.Text = "Показать";
            this.btnLoadHistory.UseVisualStyleBackColor = true;
            // 
            // cbMystoresHistory
            // 
            this.cbMystoresHistory.DisplayMember = "Name";
            this.cbMystoresHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMystoresHistory.FormattingEnabled = true;
            this.cbMystoresHistory.Location = new System.Drawing.Point(108, 10);
            this.cbMystoresHistory.Name = "cbMystoresHistory";
            this.cbMystoresHistory.Size = new System.Drawing.Size(171, 21);
            this.cbMystoresHistory.TabIndex = 14;
            this.cbMystoresHistory.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Выберите пункт:";
            // 
            // dgvLocalTransfers
            // 
            this.dgvLocalTransfers.AllowUserToAddRows = false;
            this.dgvLocalTransfers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvLocalTransfers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLocalTransfers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocalTransfers.AutoGenerateColumns = false;
            this.dgvLocalTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalTransfers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateAcceptedDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.packageNameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn});
            this.dgvLocalTransfers.DataSource = this.localBillsTransferRowBindingSource;
            this.dgvLocalTransfers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLocalTransfers.Location = new System.Drawing.Point(6, 81);
            this.dgvLocalTransfers.Name = "dgvLocalTransfers";
            this.dgvLocalTransfers.ReadOnly = true;
            this.dgvLocalTransfers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalTransfers.Size = new System.Drawing.Size(765, 379);
            this.dgvLocalTransfers.TabIndex = 17;
            // 
            // dateAcceptedDataGridViewTextBoxColumn
            // 
            this.dateAcceptedDataGridViewTextBoxColumn.DataPropertyName = "DateAccepted";
            this.dateAcceptedDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateAcceptedDataGridViewTextBoxColumn.Name = "dateAcceptedDataGridViewTextBoxColumn";
            this.dateAcceptedDataGridViewTextBoxColumn.ReadOnly = true;
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
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.countDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.countDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Смена";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localBillsTransferRowBindingSource
            // 
            this.localBillsTransferRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.LocalBillsTransferRow);
            // 
            // dgvSalesHistory
            // 
            this.dgvSalesHistory.AllowUserToAddRows = false;
            this.dgvSalesHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvSalesHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSalesHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesHistory.Location = new System.Drawing.Point(6, 37);
            this.dgvSalesHistory.Name = "dgvSalesHistory";
            this.dgvSalesHistory.ReadOnly = true;
            this.dgvSalesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesHistory.Size = new System.Drawing.Size(765, 443);
            this.dgvSalesHistory.TabIndex = 18;
            // 
            // myStoreBindingSource
            // 
            this.myStoreBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MyStore);
            // 
            // frmLocalTransfersHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 514);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmLocalTransfersHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Передачи";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsTransferRowBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvLocalTransfers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslSum;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cbMyStores;
        private System.Windows.Forms.Label lblChooseSatelite;
        private System.Windows.Forms.TabPage tabPage2;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvSalesHistory;
        private System.Windows.Forms.TextBox tbSearchHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadHistory;
        private System.Windows.Forms.ComboBox cbMystoresHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource localBillsTransferRowBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcceptedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource myStoreBindingSource;
    }
}