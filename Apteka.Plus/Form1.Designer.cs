namespace Apteka.Plus
{
    partial class Form1
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
            this.filterBar1 = new Apteka.Plus.LowLevelControls.FilterBar();
            this.ucPriceChangesHistory1 = new Apteka.Plus.UserControls.ucPriceChangesHistory();
            this.SuspendLayout();
            // 
            // filterBar1
            // 
            this.filterBar1.DateTimePickerType = Apteka.Plus.LowLevelControls.FilterBar.DateRange.MonthRange;
            this.filterBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterBar1.Location = new System.Drawing.Point(0, 0);
            this.filterBar1.Name = "filterBar1";
            this.filterBar1.Size = new System.Drawing.Size(818, 82);
            this.filterBar1.TabIndex = 0;
            // 
            // ucPriceChangesHistory1
            // 
            this.ucPriceChangesHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPriceChangesHistory1.Location = new System.Drawing.Point(0, 82);
            this.ucPriceChangesHistory1.Name = "ucPriceChangesHistory1";
            this.ucPriceChangesHistory1.Size = new System.Drawing.Size(818, 262);
            this.ucPriceChangesHistory1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 344);
            this.Controls.Add(this.ucPriceChangesHistory1);
            this.Controls.Add(this.filterBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Apteka.Plus.LowLevelControls.FilterBar filterBar1;
        private Apteka.Plus.UserControls.ucPriceChangesHistory ucPriceChangesHistory1;


    }
}