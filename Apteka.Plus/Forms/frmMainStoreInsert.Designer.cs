namespace Apteka.Plus.Forms
{
    partial class frmMainStoreInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainStoreInsert));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBillOptions = new System.Windows.Forms.ToolStripButton();
            this.tsbRowEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveBill = new System.Windows.Forms.ToolStripButton();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenEOrder = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucNewBillPage1 = new Apteka.Plus.UserControls.UcNewBillPage();
            this.ucProductSupplies1 = new Apteka.Plus.UserControls.ucProductSupplies();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBillOptions,
            this.tsbRowEdit,
            this.tsbSaveBill,
            this.tsbOptions,
            this.tsbOpenEOrder});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(927, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbBillOptions
            // 
            this.tsbBillOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbBillOptions.Image")));
            this.tsbBillOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBillOptions.Name = "tsbBillOptions";
            this.tsbBillOptions.Size = new System.Drawing.Size(153, 22);
            this.tsbBillOptions.Text = "Параметры накладной";
            this.tsbBillOptions.Click += new System.EventHandler(this.tsbBillOptions_Click);
            // 
            // tsbRowEdit
            // 
            this.tsbRowEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbRowEdit.Image")));
            this.tsbRowEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRowEdit.Name = "tsbRowEdit";
            this.tsbRowEdit.Size = new System.Drawing.Size(107, 22);
            this.tsbRowEdit.Text = "Редактировать";
            // 
            // tsbSaveBill
            // 
            this.tsbSaveBill.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveBill.Image")));
            this.tsbSaveBill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveBill.Name = "tsbSaveBill";
            this.tsbSaveBill.Size = new System.Drawing.Size(85, 22);
            this.tsbSaveBill.Text = "Сохранить";
            this.tsbSaveBill.Click += new System.EventHandler(this.tsbSaveBill_Click);
            // 
            // tsbOptions
            // 
            this.tsbOptions.Image = ((System.Drawing.Image)(resources.GetObject("tsbOptions.Image")));
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(91, 22);
            this.tsbOptions.Text = "Параметры";
            this.tsbOptions.Click += new System.EventHandler(this.tsbOptions_Click);
            // 
            // tsbOpenEOrder
            // 
            this.tsbOpenEOrder.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenEOrder.Image")));
            this.tsbOpenEOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenEOrder.Name = "tsbOpenEOrder";
            this.tsbOpenEOrder.Size = new System.Drawing.Size(138, 22);
            this.tsbOpenEOrder.Text = "Открыть накладную";
            this.tsbOpenEOrder.Click += new System.EventHandler(this.tsbOpenEOrder_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLabel,
            this.tsProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 512);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(927, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusLabel
            // 
            this.tsStatusLabel.Name = "tsStatusLabel";
            this.tsStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.ForeColor = System.Drawing.Color.DarkGreen;
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(100, 16);
            this.tsProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // splitContainer1
            // 
            this.splitContainer1.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::Apteka.Plus.Properties.Settings.Default, "MainStoreInsertSplitterDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucNewBillPage1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucProductSupplies1);
            this.splitContainer1.Size = new System.Drawing.Size(927, 487);
            this.splitContainer1.SplitterDistance = global::Apteka.Plus.Properties.Settings.Default.MainStoreInsertSplitterDistance;
            this.splitContainer1.TabIndex = 5;
            // 
            // ucNewBillPage1
            // 
            this.ucNewBillPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucNewBillPage1.Location = new System.Drawing.Point(0, 0);
            this.ucNewBillPage1.Name = "ucNewBillPage1";
            this.ucNewBillPage1.Size = new System.Drawing.Size(927, 257);
            this.ucNewBillPage1.TabIndex = 0;
            // 
            // ucProductSupplies1
            // 
            this.ucProductSupplies1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProductSupplies1.Location = new System.Drawing.Point(0, 0);
            this.ucProductSupplies1.Name = "ucProductSupplies1";
            this.ucProductSupplies1.Size = new System.Drawing.Size(927, 226);
            this.ucProductSupplies1.TabIndex = 0;
            // 
            // frmMainStoreInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 534);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMainStoreInsert";
            this.Text = "Новое поступление";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainStoreInsert_Load);
            this.Shown += new System.EventHandler(this.frmMainStoreInsert_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainStoreInsert_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainStoreInsert_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton tsbOpenEOrder;
        private System.Windows.Forms.ToolStripButton tsbSaveBill;
        private Apteka.Plus.UserControls.ucProductSupplies ucProductSupplies1;
        private Apteka.Plus.UserControls.UcNewBillPage ucNewBillPage1;
        private System.Windows.Forms.ToolStripButton tsbBillOptions;
        private System.Windows.Forms.ToolStripButton tsbRowEdit;
        private System.Windows.Forms.ToolStripButton tsbOptions;
    }
}