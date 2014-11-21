namespace Apteka.Plus.Forms
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.btnMainStoreInsert = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCopyData = new System.Windows.Forms.Button();
            this.btnFinance = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnPrintBills = new System.Windows.Forms.Button();
            this.btnRevision = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSuppliersList = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnProductSupplies = new System.Windows.Forms.Button();
            this.btnConverter = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnLocalTransfers = new System.Windows.Forms.Button();
            this.btnSalesStatistics = new System.Windows.Forms.Button();
            this.bgwChecker = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSuppliersSummaries = new System.Windows.Forms.Button();
            this.btnReturnSalesHistory = new System.Windows.Forms.Button();
            this.btnSuppliesReturnHistory = new System.Windows.Forms.Button();
            this.btnFinanceCollection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMainStoreInsert
            // 
            this.btnMainStoreInsert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMainStoreInsert.AutoSize = true;
            this.btnMainStoreInsert.ImageKey = "Blue New.ico";
            this.btnMainStoreInsert.ImageList = this.imageList1;
            this.btnMainStoreInsert.Location = new System.Drawing.Point(187, 144);
            this.btnMainStoreInsert.Name = "btnMainStoreInsert";
            this.btnMainStoreInsert.Size = new System.Drawing.Size(127, 56);
            this.btnMainStoreInsert.TabIndex = 0;
            this.btnMainStoreInsert.Text = "Новый товар";
            this.btnMainStoreInsert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMainStoreInsert.UseVisualStyleBackColor = true;
            this.btnMainStoreInsert.Click += new System.EventHandler(this.btnMainStoreInsert_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ColumnChart.ico");
            this.imageList1.Images.SetKeyName(1, "Blue Developer.ico");
            this.imageList1.Images.SetKeyName(2, "Blue External Drive USB.ico");
            this.imageList1.Images.SetKeyName(3, "Blue Favorites.ico");
            this.imageList1.Images.SetKeyName(4, "printer.ico");
            this.imageList1.Images.SetKeyName(5, "Blue Books.ico");
            this.imageList1.Images.SetKeyName(6, "Blue New.ico");
            this.imageList1.Images.SetKeyName(7, "1268818928_User.png");
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Location = new System.Drawing.Point(604, 435);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 56);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCopyData
            // 
            this.btnCopyData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCopyData.ImageKey = "Blue External Drive USB.ico";
            this.btnCopyData.ImageList = this.imageList1;
            this.btnCopyData.Location = new System.Drawing.Point(339, 144);
            this.btnCopyData.Name = "btnCopyData";
            this.btnCopyData.Size = new System.Drawing.Size(127, 56);
            this.btnCopyData.TabIndex = 2;
            this.btnCopyData.Text = "Копирование данных";
            this.btnCopyData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyData.UseVisualStyleBackColor = true;
            this.btnCopyData.Click += new System.EventHandler(this.btnCopyData_Click);
            // 
            // btnFinance
            // 
            this.btnFinance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinance.ImageKey = "ColumnChart.ico";
            this.btnFinance.ImageList = this.imageList1;
            this.btnFinance.Location = new System.Drawing.Point(339, 217);
            this.btnFinance.Name = "btnFinance";
            this.btnFinance.Size = new System.Drawing.Size(127, 56);
            this.btnFinance.TabIndex = 3;
            this.btnFinance.Text = "Касса";
            this.btnFinance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFinance.UseVisualStyleBackColor = true;
            this.btnFinance.Visible = false;
            this.btnFinance.Click += new System.EventHandler(this.btnFinance_Click);
            // 
            // btnSales
            // 
            this.btnSales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSales.ImageKey = "Blue Favorites.ico";
            this.btnSales.ImageList = this.imageList1;
            this.btnSales.Location = new System.Drawing.Point(187, 279);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(127, 56);
            this.btnSales.TabIndex = 4;
            this.btnSales.Text = "Итоги дня";
            this.btnSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOptions.ImageKey = "Blue Developer.ico";
            this.btnOptions.ImageList = this.imageList1;
            this.btnOptions.Location = new System.Drawing.Point(339, 279);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(127, 56);
            this.btnOptions.TabIndex = 5;
            this.btnOptions.Text = "Настройки";
            this.btnOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Visible = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnPrintBills
            // 
            this.btnPrintBills.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrintBills.ImageKey = "printer.ico";
            this.btnPrintBills.ImageList = this.imageList1;
            this.btnPrintBills.Location = new System.Drawing.Point(487, 279);
            this.btnPrintBills.Name = "btnPrintBills";
            this.btnPrintBills.Size = new System.Drawing.Size(127, 56);
            this.btnPrintBills.TabIndex = 6;
            this.btnPrintBills.Text = "Печать накладных";
            this.btnPrintBills.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintBills.UseVisualStyleBackColor = true;
            this.btnPrintBills.Click += new System.EventHandler(this.btnPrintBills_Click);
            // 
            // btnRevision
            // 
            this.btnRevision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRevision.ImageKey = "Blue Books.ico";
            this.btnRevision.ImageList = this.imageList1;
            this.btnRevision.Location = new System.Drawing.Point(339, 82);
            this.btnRevision.Name = "btnRevision";
            this.btnRevision.Size = new System.Drawing.Size(127, 56);
            this.btnRevision.TabIndex = 7;
            this.btnRevision.Text = "Ревизия";
            this.btnRevision.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRevision.UseVisualStyleBackColor = true;
            this.btnRevision.Click += new System.EventHandler(this.btnRevision_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.AutoSize = true;
            this.button2.ImageKey = "Blue New.ico";
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point(187, 341);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 56);
            this.button2.TabIndex = 9;
            this.button2.Text = "Дефектура";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSuppliersList
            // 
            this.btnSuppliersList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSuppliersList.ImageKey = "Blue Developer.ico";
            this.btnSuppliersList.ImageList = this.imageList1;
            this.btnSuppliersList.Location = new System.Drawing.Point(487, 144);
            this.btnSuppliersList.Name = "btnSuppliersList";
            this.btnSuppliersList.Size = new System.Drawing.Size(127, 56);
            this.btnSuppliersList.TabIndex = 10;
            this.btnSuppliersList.Text = "Список поставщиков";
            this.btnSuppliersList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuppliersList.UseVisualStyleBackColor = true;
            this.btnSuppliersList.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.ImageKey = "Blue Developer.ico";
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(187, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 56);
            this.button1.TabIndex = 11;
            this.button1.Text = "Список препаратов";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnProductSupplies
            // 
            this.btnProductSupplies.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProductSupplies.ImageKey = "Blue Books.ico";
            this.btnProductSupplies.ImageList = this.imageList1;
            this.btnProductSupplies.Location = new System.Drawing.Point(187, 217);
            this.btnProductSupplies.Name = "btnProductSupplies";
            this.btnProductSupplies.Size = new System.Drawing.Size(127, 56);
            this.btnProductSupplies.TabIndex = 12;
            this.btnProductSupplies.Text = "Приход по накладным";
            this.btnProductSupplies.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductSupplies.UseVisualStyleBackColor = true;
            this.btnProductSupplies.Click += new System.EventHandler(this.btnProductSupplies_Click);
            // 
            // btnConverter
            // 
            this.btnConverter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConverter.ImageKey = "Blue Developer.ico";
            this.btnConverter.ImageList = this.imageList1;
            this.btnConverter.Location = new System.Drawing.Point(339, 341);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(127, 56);
            this.btnConverter.TabIndex = 13;
            this.btnConverter.Text = "Электронная накладная";
            this.btnConverter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConverter.UseVisualStyleBackColor = true;
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageIndex = 7;
            this.button4.ImageList = this.imageList1;
            this.button4.Location = new System.Drawing.Point(48, 279);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 56);
            this.button4.TabIndex = 14;
            this.button4.Text = "Клиенты";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnLocalTransfers
            // 
            this.btnLocalTransfers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLocalTransfers.Enabled = false;
            this.btnLocalTransfers.ImageKey = "Blue Books.ico";
            this.btnLocalTransfers.ImageList = this.imageList1;
            this.btnLocalTransfers.Location = new System.Drawing.Point(487, 341);
            this.btnLocalTransfers.Name = "btnLocalTransfers";
            this.btnLocalTransfers.Size = new System.Drawing.Size(127, 56);
            this.btnLocalTransfers.TabIndex = 15;
            this.btnLocalTransfers.Text = "Передачи";
            this.btnLocalTransfers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLocalTransfers.UseVisualStyleBackColor = true;
            this.btnLocalTransfers.Click += new System.EventHandler(this.btnLocalTransfers_Click);
            // 
            // btnSalesStatistics
            // 
            this.btnSalesStatistics.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalesStatistics.ImageKey = "ColumnChart.ico";
            this.btnSalesStatistics.ImageList = this.imageList1;
            this.btnSalesStatistics.Location = new System.Drawing.Point(48, 341);
            this.btnSalesStatistics.Name = "btnSalesStatistics";
            this.btnSalesStatistics.Size = new System.Drawing.Size(133, 56);
            this.btnSalesStatistics.TabIndex = 16;
            this.btnSalesStatistics.Text = "Продаваемость";
            this.btnSalesStatistics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalesStatistics.UseVisualStyleBackColor = true;
            this.btnSalesStatistics.Click += new System.EventHandler(this.btnSalesStatistics_Click);
            // 
            // bgwChecker
            // 
            this.bgwChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwChecker_DoWork);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSuppliersSummaries
            // 
            this.btnSuppliersSummaries.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSuppliersSummaries.ImageKey = "ColumnChart.ico";
            this.btnSuppliersSummaries.ImageList = this.imageList1;
            this.btnSuppliersSummaries.Location = new System.Drawing.Point(487, 217);
            this.btnSuppliersSummaries.Name = "btnSuppliersSummaries";
            this.btnSuppliersSummaries.Size = new System.Drawing.Size(127, 56);
            this.btnSuppliersSummaries.TabIndex = 17;
            this.btnSuppliersSummaries.Text = "Приход по фирмам";
            this.btnSuppliersSummaries.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuppliersSummaries.UseVisualStyleBackColor = true;
            this.btnSuppliersSummaries.Click += new System.EventHandler(this.btnSuppliersSummaries_Click);
            // 
            // btnReturnSalesHistory
            // 
            this.btnReturnSalesHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReturnSalesHistory.ImageKey = "Blue Favorites.ico";
            this.btnReturnSalesHistory.ImageList = this.imageList1;
            this.btnReturnSalesHistory.Location = new System.Drawing.Point(187, 403);
            this.btnReturnSalesHistory.Name = "btnReturnSalesHistory";
            this.btnReturnSalesHistory.Size = new System.Drawing.Size(127, 56);
            this.btnReturnSalesHistory.TabIndex = 18;
            this.btnReturnSalesHistory.Text = "История возвратов продаж";
            this.btnReturnSalesHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturnSalesHistory.UseVisualStyleBackColor = true;
            this.btnReturnSalesHistory.Click += new System.EventHandler(this.btnReturnSalesHistory_Click);
            // 
            // btnSuppliesReturnHistory
            // 
            this.btnSuppliesReturnHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSuppliesReturnHistory.ImageKey = "Blue Favorites.ico";
            this.btnSuppliesReturnHistory.ImageList = this.imageList1;
            this.btnSuppliesReturnHistory.Location = new System.Drawing.Point(339, 403);
            this.btnSuppliesReturnHistory.Name = "btnSuppliesReturnHistory";
            this.btnSuppliesReturnHistory.Size = new System.Drawing.Size(127, 56);
            this.btnSuppliesReturnHistory.TabIndex = 19;
            this.btnSuppliesReturnHistory.Text = "История возвратов поступлений";
            this.btnSuppliesReturnHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuppliesReturnHistory.UseVisualStyleBackColor = true;
            this.btnSuppliesReturnHistory.Click += new System.EventHandler(this.btnSuppliesReturnHistory_Click);
            // 
            // btnFinanceCollection
            // 
            this.btnFinanceCollection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFinanceCollection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinanceCollection.ImageIndex = 7;
            this.btnFinanceCollection.ImageList = this.imageList1;
            this.btnFinanceCollection.Location = new System.Drawing.Point(48, 144);
            this.btnFinanceCollection.Name = "btnFinanceCollection";
            this.btnFinanceCollection.Size = new System.Drawing.Size(133, 56);
            this.btnFinanceCollection.TabIndex = 20;
            this.btnFinanceCollection.Text = "  Отчет по сотрудникам";
            this.btnFinanceCollection.UseVisualStyleBackColor = true;
            this.btnFinanceCollection.Click += new System.EventHandler(this.btnFinanceCollection_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 524);
            this.Controls.Add(this.btnFinanceCollection);
            this.Controls.Add(this.btnSuppliesReturnHistory);
            this.Controls.Add(this.btnReturnSalesHistory);
            this.Controls.Add(this.btnSuppliersSummaries);
            this.Controls.Add(this.btnSalesStatistics);
            this.Controls.Add(this.btnLocalTransfers);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnConverter);
            this.Controls.Add(this.btnProductSupplies);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSuppliersList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRevision);
            this.Controls.Add(this.btnPrintBills);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnFinance);
            this.Controls.Add(this.btnCopyData);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMainStoreInsert);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apteka.Plus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainMenu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMainStoreInsert;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCopyData;
        private System.Windows.Forms.Button btnFinance;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnPrintBills;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnRevision;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSuppliersList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnProductSupplies;
        private System.Windows.Forms.Button btnConverter;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnLocalTransfers;
        private System.Windows.Forms.Button btnSalesStatistics;
        private System.ComponentModel.BackgroundWorker bgwChecker;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSuppliersSummaries;
        private System.Windows.Forms.Button btnReturnSalesHistory;
        private System.Windows.Forms.Button btnSuppliesReturnHistory;
        private System.Windows.Forms.Button btnFinanceCollection;
    }
}