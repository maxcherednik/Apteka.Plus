namespace Apteka.Plus.Satelite.Forms
{
    partial class frmCopyDataMenu
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
            this.btnNewData = new System.Windows.Forms.Button();
            this.btnCopyDataFromSatelite = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnNewData
            // 
            this.btnNewData.Location = new System.Drawing.Point(59, 52);
            this.btnNewData.Name = "btnNewData";
            this.btnNewData.Size = new System.Drawing.Size(148, 39);
            this.btnNewData.TabIndex = 0;
            this.btnNewData.Text = "Новые данные";
            this.btnNewData.UseVisualStyleBackColor = true;
            this.btnNewData.Click += new System.EventHandler(this.btnNewData_Click);
            // 
            // btnCopyDataFromSatelite
            // 
            this.btnCopyDataFromSatelite.Location = new System.Drawing.Point(59, 120);
            this.btnCopyDataFromSatelite.Name = "btnCopyDataFromSatelite";
            this.btnCopyDataFromSatelite.Size = new System.Drawing.Size(148, 45);
            this.btnCopyDataFromSatelite.TabIndex = 1;
            this.btnCopyDataFromSatelite.Text = "Копировать данные из аптеки";
            this.btnCopyDataFromSatelite.UseVisualStyleBackColor = true;
            this.btnCopyDataFromSatelite.Click += new System.EventHandler(this.btnCopyDataFromSatelite_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 197);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(236, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // frmCopyDataMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 232);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCopyDataFromSatelite);
            this.Controls.Add(this.btnNewData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopyDataMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Копирование данных";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewData;
        private System.Windows.Forms.Button btnCopyDataFromSatelite;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

