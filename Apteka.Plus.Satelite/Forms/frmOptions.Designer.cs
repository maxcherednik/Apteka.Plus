namespace Apteka.Plus.Satelite.Forms
{
    partial class frmOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStoreId = new System.Windows.Forms.TextBox();
            this.cbCashRegisterEnabled = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbFontSize = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.tbConnectionStringForSecondStore = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер шрифта:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(358, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(358, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер чека:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Организация:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Доп. информация:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Идентификатор пункта:";
            // 
            // tbStoreId
            // 
            this.tbStoreId.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Apteka.Plus.Satelite.Properties.Settings.Default, "SateliteID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbStoreId.Location = new System.Drawing.Point(145, 14);
            this.tbStoreId.Name = "tbStoreId";
            this.tbStoreId.Size = new System.Drawing.Size(59, 20);
            this.tbStoreId.TabIndex = 0;
            this.tbStoreId.Text = global::Apteka.Plus.Satelite.Properties.Settings.Default.SateliteID;
            this.tbStoreId.Validating += new System.ComponentModel.CancelEventHandler(this.tbStoreId_Validating);
            // 
            // cbCashRegisterEnabled
            // 
            this.cbCashRegisterEnabled.AutoSize = true;
            this.cbCashRegisterEnabled.Checked = global::Apteka.Plus.Satelite.Properties.Settings.Default.CashRegisterEnabled;
            this.cbCashRegisterEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCashRegisterEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Apteka.Plus.Satelite.Properties.Settings.Default, "CashRegisterEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbCashRegisterEnabled.Location = new System.Drawing.Point(12, 277);
            this.cbCashRegisterEnabled.Name = "cbCashRegisterEnabled";
            this.cbCashRegisterEnabled.Size = new System.Drawing.Size(108, 17);
            this.cbCashRegisterEnabled.TabIndex = 5;
            this.cbCashRegisterEnabled.Text = "касса включена";
            this.cbCashRegisterEnabled.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Apteka.Plus.Satelite.Properties.Settings.Default, "AdditionalInfo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.Location = new System.Drawing.Point(145, 130);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(206, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = global::Apteka.Plus.Satelite.Properties.Settings.Default.AdditionalInfo;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Apteka.Plus.Satelite.Properties.Settings.Default, "CompanyName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(145, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(206, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = global::Apteka.Plus.Satelite.Properties.Settings.Default.CompanyName;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Apteka.Plus.Satelite.Properties.Settings.Default, "CashMemoNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(145, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = global::Apteka.Plus.Satelite.Properties.Settings.Default.CashMemoNumber;
            // 
            // tbFontSize
            // 
            this.tbFontSize.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Apteka.Plus.Satelite.Properties.Settings.Default, "FontSizeBase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbFontSize.Location = new System.Drawing.Point(145, 43);
            this.tbFontSize.Name = "tbFontSize";
            this.tbFontSize.Size = new System.Drawing.Size(59, 20);
            this.tbFontSize.TabIndex = 1;
            this.tbFontSize.Text = global::Apteka.Plus.Satelite.Properties.Settings.Default.FontSizeBase;
            this.tbFontSize.Validating += new System.ComponentModel.CancelEventHandler(this.tbFontSize_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 51);
            this.label6.TabIndex = 12;
            this.label6.Text = "Строка соединения для второго пункта:";
            // 
            // tbConnectionStringForSecondStore
            // 
            this.tbConnectionStringForSecondStore.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Apteka.Plus.Satelite.Properties.Settings.Default, "ConnectionStringForSecondStore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbConnectionStringForSecondStore.Location = new System.Drawing.Point(145, 164);
            this.tbConnectionStringForSecondStore.Multiline = true;
            this.tbConnectionStringForSecondStore.Name = "tbConnectionStringForSecondStore";
            this.tbConnectionStringForSecondStore.Size = new System.Drawing.Size(206, 102);
            this.tbConnectionStringForSecondStore.TabIndex = 13;
            this.tbConnectionStringForSecondStore.Text = global::Apteka.Plus.Satelite.Properties.Settings.Default.ConnectionStringForSecondStore;
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(445, 331);
            this.Controls.Add(this.tbConnectionStringForSecondStore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbStoreId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbCashRegisterEnabled);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbFontSize);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFontSize;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox cbCashRegisterEnabled;
        private System.Windows.Forms.TextBox tbStoreId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbConnectionStringForSecondStore;
    }
}