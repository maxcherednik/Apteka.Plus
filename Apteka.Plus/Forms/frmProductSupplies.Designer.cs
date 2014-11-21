namespace Apteka.Plus.Forms
{
    partial class frmProductSupplies
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucFullProductInfoBase1 = new Apteka.Plus.UserControls.ucFullProductInfoBase();
            this.ucProductSupplies1 = new Apteka.Plus.UserControls.ucProductSupplies();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::Apteka.Plus.Properties.Settings.Default, "frmProductSupplies_SplitterDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucFullProductInfoBase1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucProductSupplies1);
            this.splitContainer1.Size = new System.Drawing.Size(811, 430);
            this.splitContainer1.SplitterDistance = global::Apteka.Plus.Properties.Settings.Default.frmProductSupplies_SplitterDistance;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucFullProductInfoBase1
            // 
            this.ucFullProductInfoBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFullProductInfoBase1.Location = new System.Drawing.Point(0, 0);
            this.ucFullProductInfoBase1.Name = "ucFullProductInfoBase1";
            this.ucFullProductInfoBase1.Size = new System.Drawing.Size(811, 270);
            this.ucFullProductInfoBase1.TabIndex = 0;
            this.ucFullProductInfoBase1.CurrentRowChanged += new System.EventHandler<Apteka.Plus.UserControls.ucFullProductInfoBase.CurrentRowChangedEventArgs>(this.ucFullProductInfoBase1_CurrentRowChanged);
            // 
            // ucProductSupplies1
            // 
            this.ucProductSupplies1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProductSupplies1.Location = new System.Drawing.Point(0, 0);
            this.ucProductSupplies1.Name = "ucProductSupplies1";
            this.ucProductSupplies1.Size = new System.Drawing.Size(811, 156);
            this.ucProductSupplies1.TabIndex = 0;
            // 
            // frmProductSupplies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 430);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmProductSupplies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приход по накладным";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProductSupplies_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductSupplies_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProductSupplies_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Apteka.Plus.UserControls.ucFullProductInfoBase ucFullProductInfoBase1;
        private Apteka.Plus.UserControls.ucProductSupplies ucProductSupplies1;
    }
}