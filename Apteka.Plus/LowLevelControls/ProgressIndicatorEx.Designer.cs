namespace Apteka.Plus.LowLevelControls
{
    partial class ProgressIndicatorEx
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
            this.progressIndicator1 = new ProgressControls.ProgressIndicator();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressIndicator1
            // 
            this.progressIndicator1.Location = new System.Drawing.Point(16, 15);
            this.progressIndicator1.Name = "progressIndicator1";
            this.progressIndicator1.Size = new System.Drawing.Size(53, 53);
            this.progressIndicator1.TabIndex = 0;
            this.progressIndicator1.Text = "progressIndicator1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(90, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Загрузка данных";
            // 
            // ProgressIndicatorEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressIndicator1);
            this.Name = "ProgressIndicatorEx";
            this.Size = new System.Drawing.Size(243, 81);
            this.VisibleChanged += new System.EventHandler(this.ProgressIndicatorEx_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProgressControls.ProgressIndicator progressIndicator1;
        private System.Windows.Forms.Label label2;
    }
}
