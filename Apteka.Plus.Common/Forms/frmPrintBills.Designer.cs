namespace Apteka.Plus.Forms
{
    partial class frmPrintBills
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintBills));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbMyStores = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstbLocalBillNumber = new System.Windows.Forms.ToolStripTextBox();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrintBill = new System.Windows.Forms.ToolStripDropDownButton();
            this.накладнаяФармацевтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.накладнаяПровизораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbPrintLabels = new System.Windows.Forms.ToolStripDropDownButton();
            this.большиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.средниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маленькиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbRecentLocalBills = new System.Windows.Forms.GroupBox();
            this.dgvRecentLocalBills = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.DateAccepted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalBillNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLocalBill = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startPriceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAmountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabelsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localBillsRowExBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceForLabels = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsmiPrintWarehouseLabels = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.gbRecentLocalBills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentLocalBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsRowExBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceForLabels)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbMyStores,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.tstbLocalBillNumber,
            this.tsbOpen,
            this.toolStripSeparator1,
            this.tsbPrintBill,
            this.tsbPrintLabels});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(849, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel1.Text = "Выберите пункт";
            // 
            // tscbMyStores
            // 
            this.tscbMyStores.BackColor = System.Drawing.SystemColors.Window;
            this.tscbMyStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbMyStores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tscbMyStores.Name = "tscbMyStores";
            this.tscbMyStores.Size = new System.Drawing.Size(121, 25);
            this.tscbMyStores.SelectedIndexChanged += new System.EventHandler(this.tscbMyStores_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(107, 22);
            this.toolStripLabel2.Text = "Номер накладной";
            // 
            // tstbLocalBillNumber
            // 
            this.tstbLocalBillNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbLocalBillNumber.Name = "tstbLocalBillNumber";
            this.tstbLocalBillNumber.Size = new System.Drawing.Size(100, 25);
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(74, 22);
            this.tsbOpen.Text = "Открыть";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrintBill
            // 
            this.tsbPrintBill.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.накладнаяФармацевтаToolStripMenuItem,
            this.накладнаяПровизораToolStripMenuItem});
            this.tsbPrintBill.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrintBill.Image")));
            this.tsbPrintBill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintBill.Name = "tsbPrintBill";
            this.tsbPrintBill.Size = new System.Drawing.Size(137, 22);
            this.tsbPrintBill.Text = "Печать накладной";
            // 
            // накладнаяФармацевтаToolStripMenuItem
            // 
            this.накладнаяФармацевтаToolStripMenuItem.Name = "накладнаяФармацевтаToolStripMenuItem";
            this.накладнаяФармацевтаToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.накладнаяФармацевтаToolStripMenuItem.Text = "Накладная фармацевта";
            this.накладнаяФармацевтаToolStripMenuItem.Click += new System.EventHandler(this.накладнаяФармацевтаToolStripMenuItem_Click);
            // 
            // накладнаяПровизораToolStripMenuItem
            // 
            this.накладнаяПровизораToolStripMenuItem.Name = "накладнаяПровизораToolStripMenuItem";
            this.накладнаяПровизораToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.накладнаяПровизораToolStripMenuItem.Text = "Накладная провизора";
            this.накладнаяПровизораToolStripMenuItem.Click += new System.EventHandler(this.накладнаяПровизораToolStripMenuItem_Click);
            // 
            // tsbPrintLabels
            // 
            this.tsbPrintLabels.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.большиеToolStripMenuItem,
            this.средниеToolStripMenuItem,
            this.маленькиеToolStripMenuItem,
            this.tsmiPrintWarehouseLabels});
            this.tsbPrintLabels.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrintLabels.Image")));
            this.tsbPrintLabels.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintLabels.Name = "tsbPrintLabels";
            this.tsbPrintLabels.Size = new System.Drawing.Size(126, 22);
            this.tsbPrintLabels.Text = "Печать этикеток";
            // 
            // большиеToolStripMenuItem
            // 
            this.большиеToolStripMenuItem.Name = "большиеToolStripMenuItem";
            this.большиеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.большиеToolStripMenuItem.Text = "Большие";
            this.большиеToolStripMenuItem.Click += new System.EventHandler(this.большиеToolStripMenuItem_Click);
            // 
            // средниеToolStripMenuItem
            // 
            this.средниеToolStripMenuItem.Name = "средниеToolStripMenuItem";
            this.средниеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.средниеToolStripMenuItem.Text = "Средние";
            this.средниеToolStripMenuItem.Click += new System.EventHandler(this.средниеToolStripMenuItem_Click);
            // 
            // маленькиеToolStripMenuItem
            // 
            this.маленькиеToolStripMenuItem.Name = "маленькиеToolStripMenuItem";
            this.маленькиеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.маленькиеToolStripMenuItem.Text = "Маленькие";
            this.маленькиеToolStripMenuItem.Click += new System.EventHandler(this.маленькиеToolStripMenuItem_Click);
            // 
            // gbRecentLocalBills
            // 
            this.gbRecentLocalBills.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbRecentLocalBills.Controls.Add(this.dgvRecentLocalBills);
            this.gbRecentLocalBills.Location = new System.Drawing.Point(16, 28);
            this.gbRecentLocalBills.Name = "gbRecentLocalBills";
            this.gbRecentLocalBills.Padding = new System.Windows.Forms.Padding(7);
            this.gbRecentLocalBills.Size = new System.Drawing.Size(264, 205);
            this.gbRecentLocalBills.TabIndex = 11;
            this.gbRecentLocalBills.TabStop = false;
            this.gbRecentLocalBills.Text = "Недавние накладные";
            // 
            // dgvRecentLocalBills
            // 
            this.dgvRecentLocalBills.AllowUserToAddRows = false;
            this.dgvRecentLocalBills.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvRecentLocalBills.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecentLocalBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentLocalBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateAccepted,
            this.LocalBillNumber});
            this.dgvRecentLocalBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentLocalBills.Location = new System.Drawing.Point(7, 20);
            this.dgvRecentLocalBills.Name = "dgvRecentLocalBills";
            this.dgvRecentLocalBills.ReadOnly = true;
            this.dgvRecentLocalBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentLocalBills.Size = new System.Drawing.Size(250, 178);
            this.dgvRecentLocalBills.TabIndex = 0;
            this.dgvRecentLocalBills.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRecentLocalBills_CellMouseDoubleClick);
            // 
            // DateAccepted
            // 
            this.DateAccepted.DataPropertyName = "DateAccepted";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.DateAccepted.DefaultCellStyle = dataGridViewCellStyle2;
            this.DateAccepted.HeaderText = "Дата отпуска";
            this.DateAccepted.Name = "DateAccepted";
            this.DateAccepted.ReadOnly = true;
            // 
            // LocalBillNumber
            // 
            this.LocalBillNumber.DataPropertyName = "LocalBillNumber";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LocalBillNumber.DefaultCellStyle = dataGridViewCellStyle3;
            this.LocalBillNumber.HeaderText = "Номер накладной";
            this.LocalBillNumber.Name = "LocalBillNumber";
            this.LocalBillNumber.ReadOnly = true;
            // 
            // dgvLocalBill
            // 
            this.dgvLocalBill.AllowUserToAddRows = false;
            this.dgvLocalBill.AllowUserToDeleteRows = false;
            this.dgvLocalBill.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvLocalBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLocalBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocalBill.AutoGenerateColumns = false;
            this.dgvLocalBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.PackageName,
            this.startPriceDataGridViewTextBoxColumn1,
            this.startAmountDataGridViewTextBoxColumn1,
            this.LabelsCount,
            this.SupplierName});
            this.dgvLocalBill.DataSource = this.localBillsRowExBindingSource;
            this.dgvLocalBill.Location = new System.Drawing.Point(298, 28);
            this.dgvLocalBill.Name = "dgvLocalBill";
            this.dgvLocalBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalBill.Size = new System.Drawing.Size(539, 205);
            this.dgvLocalBill.TabIndex = 1;
            this.dgvLocalBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLocalBill_KeyDown);
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
            // startPriceDataGridViewTextBoxColumn1
            // 
            this.startPriceDataGridViewTextBoxColumn1.DataPropertyName = "StartPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.startPriceDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.startPriceDataGridViewTextBoxColumn1.HeaderText = "Цена";
            this.startPriceDataGridViewTextBoxColumn1.Name = "startPriceDataGridViewTextBoxColumn1";
            this.startPriceDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // startAmountDataGridViewTextBoxColumn1
            // 
            this.startAmountDataGridViewTextBoxColumn1.DataPropertyName = "StartAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.startAmountDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.startAmountDataGridViewTextBoxColumn1.HeaderText = "Кол-во";
            this.startAmountDataGridViewTextBoxColumn1.Name = "startAmountDataGridViewTextBoxColumn1";
            this.startAmountDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // LabelsCount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.LabelsCount.DefaultCellStyle = dataGridViewCellStyle7;
            this.LabelsCount.HeaderText = "Кол-во этикеток";
            this.LabelsCount.Name = "LabelsCount";
            // 
            // SupplierName
            // 
            this.SupplierName.DataPropertyName = "SupplierName";
            this.SupplierName.HeaderText = "Поставщик";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            // 
            // localBillsRowExBindingSource
            // 
            this.localBillsRowExBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.LocalBillsRowEx);
            // 
            // bindingSourceForLabels
            // 
            this.bindingSourceForLabels.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.LocalBillsRowEx);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DateAccepted";
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MyStore";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "StartPrice";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "Фасовка";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CurrentPrice";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn4.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "StartAmount";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn5.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DateOtpusk";
            this.dataGridViewTextBoxColumn6.HeaderText = "Дата поставки";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DateSupply";
            this.dataGridViewTextBoxColumn7.HeaderText = "Поставщик";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "SupplierBillNumber";
            this.dataGridViewTextBoxColumn8.HeaderText = "SupplierBillNumber";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Product";
            this.dataGridViewTextBoxColumn9.HeaderText = "Product";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Package";
            this.dataGridViewTextBoxColumn10.HeaderText = "Package";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Supplier";
            this.dataGridViewTextBoxColumn11.HeaderText = "Supplier";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "MyStore";
            this.dataGridViewTextBoxColumn12.HeaderText = "MyStore";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // tsmiPrintWarehouseLabels
            // 
            this.tsmiPrintWarehouseLabels.Name = "tsmiPrintWarehouseLabels";
            this.tsmiPrintWarehouseLabels.Size = new System.Drawing.Size(152, 22);
            this.tsmiPrintWarehouseLabels.Text = "Стеллажные";
            this.tsmiPrintWarehouseLabels.Click += new System.EventHandler(this.tsmiPrintWarehouseLabels_Click);
            // 
            // frmPrintBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 245);
            this.Controls.Add(this.gbRecentLocalBills);
            this.Controls.Add(this.dgvLocalBill);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmPrintBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Печать накладных";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrintBills_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrintBills_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbRecentLocalBills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentLocalBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsRowExBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceForLabels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.BindingSource localBillsRowExBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvLocalBill;
        private System.Windows.Forms.GroupBox gbRecentLocalBills;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvRecentLocalBills;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscbMyStores;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox tstbLocalBillNumber;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAccepted;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalBillNumber;
        private System.Windows.Forms.BindingSource bindingSourceForLabels;
        private System.Windows.Forms.ToolStripDropDownButton tsbPrintLabels;
        private System.Windows.Forms.ToolStripMenuItem большиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маленькиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem средниеToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsbPrintBill;
        private System.Windows.Forms.ToolStripMenuItem накладнаяФармацевтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem накладнаяПровизораToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn startPriceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAmountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LabelsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintWarehouseLabels;
    }
}