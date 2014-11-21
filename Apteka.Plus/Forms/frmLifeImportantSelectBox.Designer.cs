namespace Apteka.Plus.Forms
{
    partial class frmLifeImportantSelectBox
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
            this.myStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbIsLifeImportant = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // myStoreBindingSource
            // 
            this.myStoreBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MyStore);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(287, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(287, 42);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbIsLifeImportant
            // 
            this.cbIsLifeImportant.AutoSize = true;
            this.cbIsLifeImportant.Location = new System.Drawing.Point(65, 16);
            this.cbIsLifeImportant.Name = "cbIsLifeImportant";
            this.cbIsLifeImportant.Size = new System.Drawing.Size(119, 17);
            this.cbIsLifeImportant.TabIndex = 10;
            this.cbIsLifeImportant.Text = "жизненно важные";
            this.cbIsLifeImportant.UseVisualStyleBackColor = true;
            // 
            // frmLifeImportantSelectBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 143);
            this.Controls.Add(this.cbIsLifeImportant);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLifeImportantSelectBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Укажите тип препаратов";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmLifeImportantSelectBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource myStoreBindingSource;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbIsLifeImportant;
    }
}