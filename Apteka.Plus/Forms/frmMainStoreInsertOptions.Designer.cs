namespace Apteka.Plus.Forms
{
    partial class frmMainStoreInsertOptions
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbRows = new System.Windows.Forms.TextBox();
            this.tbExtra = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Кол-во строк прихода по накладным:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Стандартная наценка:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(393, 35);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(393, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tbRows
            // 
            this.tbRows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRows.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Apteka.Plus.Properties.Settings.Default, "frmMainStoreInsert_ProductSuppliesTopRows", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbRows.Location = new System.Drawing.Point(222, 42);
            this.tbRows.Name = "tbRows";
            this.tbRows.Size = new System.Drawing.Size(111, 20);
            this.tbRows.TabIndex = 26;
            this.tbRows.Text = global::Apteka.Plus.Properties.Settings.Default.frmMainStoreInsert_ProductSuppliesTopRows;
            // 
            // tbExtra
            // 
            this.tbExtra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbExtra.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Apteka.Plus.Properties.Settings.Default, "StandartExtra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbExtra.Location = new System.Drawing.Point(222, 6);
            this.tbExtra.Name = "tbExtra";
            this.tbExtra.Size = new System.Drawing.Size(111, 20);
            this.tbExtra.TabIndex = 18;
            this.tbExtra.Text = global::Apteka.Plus.Properties.Settings.Default.StandartExtra;
            // 
            // frmMainStoreInsertOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 100);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbExtra);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainStoreInsertOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExtra;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}