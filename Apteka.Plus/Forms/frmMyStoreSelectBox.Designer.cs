namespace Apteka.Plus.Forms
{
    partial class frmMyStoreSelectBox
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMyStore = new System.Windows.Forms.Label();
            this.cbMyStores = new System.Windows.Forms.ComboBox();
            this.myStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(288, 44);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(288, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMyStore
            // 
            this.lblMyStore.AutoSize = true;
            this.lblMyStore.Location = new System.Drawing.Point(12, 17);
            this.lblMyStore.Name = "lblMyStore";
            this.lblMyStore.Size = new System.Drawing.Size(40, 13);
            this.lblMyStore.TabIndex = 6;
            this.lblMyStore.Text = "Пункт:";
            // 
            // cbMyStores
            // 
            this.cbMyStores.DataSource = this.myStoreBindingSource;
            this.cbMyStores.DisplayMember = "Name";
            this.cbMyStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMyStores.FormattingEnabled = true;
            this.cbMyStores.Location = new System.Drawing.Point(71, 14);
            this.cbMyStores.Name = "cbMyStores";
            this.cbMyStores.Size = new System.Drawing.Size(188, 21);
            this.cbMyStores.TabIndex = 7;
            this.cbMyStores.ValueMember = "ID";
            // 
            // myStoreBindingSource
            // 
            this.myStoreBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MyStore);
            // 
            // frmMyStoreSelectBox
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(375, 145);
            this.Controls.Add(this.cbMyStores);
            this.Controls.Add(this.lblMyStore);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMyStoreSelectBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выберите пункт";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMyStoreSelectBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMyStore;
        private System.Windows.Forms.ComboBox cbMyStores;
        private System.Windows.Forms.BindingSource myStoreBindingSource;
    }
}