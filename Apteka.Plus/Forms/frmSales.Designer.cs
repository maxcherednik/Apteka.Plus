namespace Apteka.Plus.Forms
{
    partial class frmSales
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.progressIndicator1 = new ProgressControls.ProgressIndicator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslCustomerCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlDayResults = new System.Windows.Forms.TabControl();
            this.tpSales = new System.Windows.Forms.TabPage();
            this.ucSalesHistory1 = new Apteka.Plus.UserControls.ucSalesHistory();
            this.btnReport = new System.Windows.Forms.Button();
            this.mdgvSummary = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpReturns = new System.Windows.Forms.TabPage();
            this.ucSalesReturnHistory1 = new Apteka.Plus.UserControls.ucSalesReturnHistory();
            this.tpLocalTransfers = new System.Windows.Forms.TabPage();
            this.ucLocalBillsTransfersHistory1 = new Apteka.Plus.UserControls.ucLocalBillsTransfersHistory();
            this.tpPriceChanges = new System.Windows.Forms.TabPage();
            this.ucPriceChangesHistory1 = new Apteka.Plus.UserControls.ucPriceChangesHistory();
            this.tpSupplies = new System.Windows.Forms.TabPage();
            this.ucProductSuppliesHistory1 = new Apteka.Plus.UserControls.ucProductSuppliesHistory();
            this.tpSuppliesReturns = new System.Windows.Forms.TabPage();
            this.ucSuppliesReturnHistory1 = new Apteka.Plus.UserControls.ucSuppliesReturnHistory();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cbMyStores = new System.Windows.Forms.ComboBox();
            this.myStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblChooseSatelite = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbSearchHistory = new System.Windows.Forms.TextBox();
            this.ucSalesHistory2 = new Apteka.Plus.UserControls.ucSalesHistory();
            this.btnLoadHistory = new System.Windows.Forms.Button();
            this.cbMystoresHistory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.salesReturnHistoryRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bgwDataLoader = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControlDayResults.SuspendLayout();
            this.tpSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdgvSummary)).BeginInit();
            this.tpReturns.SuspendLayout();
            this.tpLocalTransfers.SuspendLayout();
            this.tpPriceChanges.SuspendLayout();
            this.tpSupplies.SuspendLayout();
            this.tpSuppliesReturns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesReturnHistoryRowBindingSource)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(1106, 629);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.progressIndicator1);
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Controls.Add(this.tabControlDayResults);
            this.tabPage1.Controls.Add(this.btnLoad);
            this.tabPage1.Controls.Add(this.dtpDate);
            this.tabPage1.Controls.Add(this.cbMyStores);
            this.tabPage1.Controls.Add(this.lblChooseSatelite);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1098, 603);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "За день";
            // 
            // progressIndicator1
            // 
            this.progressIndicator1.Location = new System.Drawing.Point(614, 10);
            this.progressIndicator1.Name = "progressIndicator1";
            this.progressIndicator1.Size = new System.Drawing.Size(22, 22);
            this.progressIndicator1.TabIndex = 17;
            this.progressIndicator1.Text = "progressIndicator1";
            this.progressIndicator1.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCustomerCounter,
            this.tsslSum});
            this.statusStrip1.Location = new System.Drawing.Point(3, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1092, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslCustomerCounter
            // 
            this.tsslCustomerCounter.Name = "tsslCustomerCounter";
            this.tsslCustomerCounter.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslSum
            // 
            this.tsslSum.Name = "tsslSum";
            this.tsslSum.Size = new System.Drawing.Size(0, 17);
            // 
            // tabControlDayResults
            // 
            this.tabControlDayResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlDayResults.Controls.Add(this.tpSales);
            this.tabControlDayResults.Controls.Add(this.tpReturns);
            this.tabControlDayResults.Controls.Add(this.tpLocalTransfers);
            this.tabControlDayResults.Controls.Add(this.tpPriceChanges);
            this.tabControlDayResults.Controls.Add(this.tpSupplies);
            this.tabControlDayResults.Controls.Add(this.tpSuppliesReturns);
            this.tabControlDayResults.Location = new System.Drawing.Point(6, 39);
            this.tabControlDayResults.Name = "tabControlDayResults";
            this.tabControlDayResults.SelectedIndex = 0;
            this.tabControlDayResults.Size = new System.Drawing.Size(1084, 536);
            this.tabControlDayResults.TabIndex = 15;
            // 
            // tpSales
            // 
            this.tpSales.Controls.Add(this.ucSalesHistory1);
            this.tpSales.Controls.Add(this.btnReport);
            this.tpSales.Controls.Add(this.mdgvSummary);
            this.tpSales.Location = new System.Drawing.Point(4, 22);
            this.tpSales.Name = "tpSales";
            this.tpSales.Padding = new System.Windows.Forms.Padding(3);
            this.tpSales.Size = new System.Drawing.Size(1076, 510);
            this.tpSales.TabIndex = 0;
            this.tpSales.Text = "Продажи";
            this.tpSales.UseVisualStyleBackColor = true;
            // 
            // ucSalesHistory1
            // 
            this.ucSalesHistory1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSalesHistory1.Location = new System.Drawing.Point(6, 94);
            this.ucSalesHistory1.Name = "ucSalesHistory1";
            this.ucSalesHistory1.Size = new System.Drawing.Size(1064, 410);
            this.ucSalesHistory1.TabIndex = 19;
            // 
            // btnReport
            // 
            this.btnReport.Enabled = false;
            this.btnReport.Location = new System.Drawing.Point(516, 9);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 18;
            this.btnReport.Text = "График";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // mdgvSummary
            // 
            this.mdgvSummary.AllowUserToAddRows = false;
            this.mdgvSummary.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            this.mdgvSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.mdgvSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mdgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mdgvSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FIO,
            this.Sum});
            this.mdgvSummary.Location = new System.Drawing.Point(604, 9);
            this.mdgvSummary.Name = "mdgvSummary";
            this.mdgvSummary.ReadOnly = true;
            this.mdgvSummary.RowTemplate.Height = 18;
            this.mdgvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mdgvSummary.Size = new System.Drawing.Size(469, 79);
            this.mdgvSummary.TabIndex = 16;
            // 
            // FIO
            // 
            this.FIO.DataPropertyName = "FIO";
            this.FIO.HeaderText = "Работник";
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            // 
            // Sum
            // 
            this.Sum.DataPropertyName = "Sum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Sum.DefaultCellStyle = dataGridViewCellStyle4;
            this.Sum.HeaderText = "Сумма";
            this.Sum.Name = "Sum";
            this.Sum.ReadOnly = true;
            // 
            // tpReturns
            // 
            this.tpReturns.Controls.Add(this.ucSalesReturnHistory1);
            this.tpReturns.Location = new System.Drawing.Point(4, 22);
            this.tpReturns.Name = "tpReturns";
            this.tpReturns.Size = new System.Drawing.Size(1076, 510);
            this.tpReturns.TabIndex = 2;
            this.tpReturns.Text = "Возвраты";
            this.tpReturns.UseVisualStyleBackColor = true;
            // 
            // ucSalesReturnHistory1
            // 
            this.ucSalesReturnHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSalesReturnHistory1.Location = new System.Drawing.Point(0, 0);
            this.ucSalesReturnHistory1.Name = "ucSalesReturnHistory1";
            this.ucSalesReturnHistory1.Size = new System.Drawing.Size(1076, 510);
            this.ucSalesReturnHistory1.TabIndex = 0;
            this.ucSalesReturnHistory1.RowCountChanged += new System.EventHandler<Apteka.Plus.UserControls.ucSalesReturnHistory.RowCountChangedEventArgs>(this.ucSalesReturnHistory1_RowCountChanged);
            // 
            // tpLocalTransfers
            // 
            this.tpLocalTransfers.Controls.Add(this.ucLocalBillsTransfersHistory1);
            this.tpLocalTransfers.Location = new System.Drawing.Point(4, 22);
            this.tpLocalTransfers.Name = "tpLocalTransfers";
            this.tpLocalTransfers.Size = new System.Drawing.Size(1076, 510);
            this.tpLocalTransfers.TabIndex = 3;
            this.tpLocalTransfers.Text = "Передачи";
            this.tpLocalTransfers.UseVisualStyleBackColor = true;
            // 
            // ucLocalBillsTransfersHistory1
            // 
            this.ucLocalBillsTransfersHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLocalBillsTransfersHistory1.Location = new System.Drawing.Point(0, 0);
            this.ucLocalBillsTransfersHistory1.Name = "ucLocalBillsTransfersHistory1";
            this.ucLocalBillsTransfersHistory1.Size = new System.Drawing.Size(1076, 510);
            this.ucLocalBillsTransfersHistory1.TabIndex = 0;
            this.ucLocalBillsTransfersHistory1.RowCountChanged += new System.EventHandler<Apteka.Plus.UserControls.ucLocalBillsTransfersHistory.RowCountChangedEventArgs>(this.ucLocalBillsTransfersHistory1_RowCountChanged);
            // 
            // tpPriceChanges
            // 
            this.tpPriceChanges.Controls.Add(this.ucPriceChangesHistory1);
            this.tpPriceChanges.Location = new System.Drawing.Point(4, 22);
            this.tpPriceChanges.Name = "tpPriceChanges";
            this.tpPriceChanges.Size = new System.Drawing.Size(1076, 510);
            this.tpPriceChanges.TabIndex = 4;
            this.tpPriceChanges.Text = "Изменения цен";
            this.tpPriceChanges.UseVisualStyleBackColor = true;
            // 
            // ucPriceChangesHistory1
            // 
            this.ucPriceChangesHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPriceChangesHistory1.Location = new System.Drawing.Point(0, 0);
            this.ucPriceChangesHistory1.Name = "ucPriceChangesHistory1";
            this.ucPriceChangesHistory1.Size = new System.Drawing.Size(1076, 510);
            this.ucPriceChangesHistory1.TabIndex = 0;
            this.ucPriceChangesHistory1.RowCountChanged += new System.EventHandler<Apteka.Plus.UserControls.ucPriceChangesHistory.RowCountChangedEventArgs>(this.ucPriceChangesHistory1_RowCountChanged);
            // 
            // tpSupplies
            // 
            this.tpSupplies.Controls.Add(this.ucProductSuppliesHistory1);
            this.tpSupplies.Location = new System.Drawing.Point(4, 22);
            this.tpSupplies.Name = "tpSupplies";
            this.tpSupplies.Size = new System.Drawing.Size(1076, 510);
            this.tpSupplies.TabIndex = 5;
            this.tpSupplies.Text = "Приход";
            this.tpSupplies.UseVisualStyleBackColor = true;
            // 
            // ucProductSuppliesHistory1
            // 
            this.ucProductSuppliesHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProductSuppliesHistory1.Location = new System.Drawing.Point(0, 0);
            this.ucProductSuppliesHistory1.Name = "ucProductSuppliesHistory1";
            this.ucProductSuppliesHistory1.Size = new System.Drawing.Size(1076, 510);
            this.ucProductSuppliesHistory1.TabIndex = 0;
            this.ucProductSuppliesHistory1.RowCountChanged += new System.EventHandler<Apteka.Plus.UserControls.ucProductSuppliesHistory.RowCountChangedEventArgs>(this.ucProductSuppliesHistory1_RowCountChanged);
            // 
            // tpSuppliesReturns
            // 
            this.tpSuppliesReturns.Controls.Add(this.ucSuppliesReturnHistory1);
            this.tpSuppliesReturns.Location = new System.Drawing.Point(4, 22);
            this.tpSuppliesReturns.Name = "tpSuppliesReturns";
            this.tpSuppliesReturns.Size = new System.Drawing.Size(1076, 510);
            this.tpSuppliesReturns.TabIndex = 6;
            this.tpSuppliesReturns.Text = "Возвраты из поступления";
            this.tpSuppliesReturns.UseVisualStyleBackColor = true;
            // 
            // ucSuppliesReturnHistory1
            // 
            this.ucSuppliesReturnHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSuppliesReturnHistory1.Location = new System.Drawing.Point(0, 0);
            this.ucSuppliesReturnHistory1.Name = "ucSuppliesReturnHistory1";
            this.ucSuppliesReturnHistory1.Size = new System.Drawing.Size(1076, 510);
            this.ucSuppliesReturnHistory1.TabIndex = 0;
            this.ucSuppliesReturnHistory1.RowCountChanged += new System.EventHandler<Apteka.Plus.UserControls.ucSuppliesReturnHistory.RowCountChangedEventArgs>(this.ucSuppliesReturnHistory1_RowCountChanged);
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
            // myStoreBindingSource
            // 
            this.myStoreBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MyStore);
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
            this.tabPage2.Controls.Add(this.tbSearchHistory);
            this.tabPage2.Controls.Add(this.ucSalesHistory2);
            this.tabPage2.Controls.Add(this.btnLoadHistory);
            this.tabPage2.Controls.Add(this.cbMystoresHistory);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1098, 603);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "История";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbSearchHistory
            // 
            this.tbSearchHistory.Location = new System.Drawing.Point(294, 10);
            this.tbSearchHistory.Name = "tbSearchHistory";
            this.tbSearchHistory.Size = new System.Drawing.Size(135, 20);
            this.tbSearchHistory.TabIndex = 17;
            // 
            // ucSalesHistory2
            // 
            this.ucSalesHistory2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSalesHistory2.Location = new System.Drawing.Point(6, 37);
            this.ucSalesHistory2.Name = "ucSalesHistory2";
            this.ucSalesHistory2.Size = new System.Drawing.Size(1084, 563);
            this.ucSalesHistory2.TabIndex = 16;
            // 
            // btnLoadHistory
            // 
            this.btnLoadHistory.Location = new System.Drawing.Point(435, 8);
            this.btnLoadHistory.Name = "btnLoadHistory";
            this.btnLoadHistory.Size = new System.Drawing.Size(75, 23);
            this.btnLoadHistory.TabIndex = 15;
            this.btnLoadHistory.Text = "Показать";
            this.btnLoadHistory.UseVisualStyleBackColor = true;
            this.btnLoadHistory.Click += new System.EventHandler(this.btnLoadHistory_Click);
            // 
            // cbMystoresHistory
            // 
            this.cbMystoresHistory.DataSource = this.myStoreBindingSource;
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
            // salesReturnHistoryRowBindingSource
            // 
            this.salesReturnHistoryRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.SalesReturnHistoryRow);
            // 
            // bgwDataLoader
            // 
            this.bgwDataLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDataLoader_DoWork);
            // 
            // frmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 629);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Продажи";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSales_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControlDayResults.ResumeLayout(false);
            this.tpSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mdgvSummary)).EndInit();
            this.tpReturns.ResumeLayout(false);
            this.tpLocalTransfers.ResumeLayout(false);
            this.tpPriceChanges.ResumeLayout(false);
            this.tpSupplies.ResumeLayout(false);
            this.tpSuppliesReturns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesReturnHistoryRowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbMyStores;
        private System.Windows.Forms.Label lblChooseSatelite;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.BindingSource myStoreBindingSource;
        private System.Windows.Forms.Button btnLoadHistory;
        private System.Windows.Forms.ComboBox cbMystoresHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControlDayResults;
        private System.Windows.Forms.TabPage tpSales;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslCustomerCounter;
        private System.Windows.Forms.ToolStripStatusLabel tsslSum;
        private System.Windows.Forms.TabPage tpReturns;
        private System.Windows.Forms.BindingSource salesReturnHistoryRowBindingSource;
        private Apteka.Plus.UserControls.ucSalesReturnHistory ucSalesReturnHistory1;
        private System.Windows.Forms.TabPage tpLocalTransfers;
        private System.Windows.Forms.TabPage tpPriceChanges;
        private System.Windows.Forms.TabPage tpSupplies;
        private Apteka.Plus.UserControls.ucPriceChangesHistory ucPriceChangesHistory1;
        private Apteka.Plus.UserControls.ucLocalBillsTransfersHistory ucLocalBillsTransfersHistory1;
        private System.Windows.Forms.Button btnReport;
        private Apteka.Plus.Common.Controls.MyDataGridView mdgvSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private ProgressControls.ProgressIndicator progressIndicator1;
        private System.ComponentModel.BackgroundWorker bgwDataLoader;
        private Apteka.Plus.UserControls.ucProductSuppliesHistory ucProductSuppliesHistory1;
        private System.Windows.Forms.TabPage tpSuppliesReturns;
        private Apteka.Plus.UserControls.ucSuppliesReturnHistory ucSuppliesReturnHistory1;
        private Apteka.Plus.UserControls.ucSalesHistory ucSalesHistory2;
        private System.Windows.Forms.TextBox tbSearchHistory;
        private Apteka.Plus.UserControls.ucSalesHistory ucSalesHistory1;
        
    }
}