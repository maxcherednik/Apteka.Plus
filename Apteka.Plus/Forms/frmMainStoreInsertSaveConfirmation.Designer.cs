﻿namespace Apteka.Plus.Forms
{
    partial class frmMainStoreInsertSaveConfirmation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.tbSupplier = new System.Windows.Forms.TextBox();
            this.tbSupplierBillNumber = new System.Windows.Forms.TextBox();
            this.tbSum = new System.Windows.Forms.TextBox();
            this.cbDelayLocalBills = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Поставщик:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Номер накладной:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(371, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(371, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Сумма:";
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(123, 22);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(195, 20);
            this.tbDate.TabIndex = 9;
            this.tbDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSupplier
            // 
            this.tbSupplier.Location = new System.Drawing.Point(123, 55);
            this.tbSupplier.Name = "tbSupplier";
            this.tbSupplier.Size = new System.Drawing.Size(195, 20);
            this.tbSupplier.TabIndex = 10;
            this.tbSupplier.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSupplierBillNumber
            // 
            this.tbSupplierBillNumber.Location = new System.Drawing.Point(123, 88);
            this.tbSupplierBillNumber.Name = "tbSupplierBillNumber";
            this.tbSupplierBillNumber.Size = new System.Drawing.Size(195, 20);
            this.tbSupplierBillNumber.TabIndex = 11;
            this.tbSupplierBillNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSum
            // 
            this.tbSum.Location = new System.Drawing.Point(123, 121);
            this.tbSum.Name = "tbSum";
            this.tbSum.Size = new System.Drawing.Size(195, 20);
            this.tbSum.TabIndex = 12;
            this.tbSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbDelayLocalBills
            // 
            this.cbDelayLocalBills.AutoSize = true;
            this.cbDelayLocalBills.Location = new System.Drawing.Point(123, 168);
            this.cbDelayLocalBills.Name = "cbDelayLocalBills";
            this.cbDelayLocalBills.Size = new System.Drawing.Size(140, 17);
            this.cbDelayLocalBills.TabIndex = 13;
            this.cbDelayLocalBills.Text = "задержать накладные";
            this.cbDelayLocalBills.UseVisualStyleBackColor = true;
            // 
            // frmMainStoreInsertSaveConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 208);
            this.Controls.Add(this.cbDelayLocalBills);
            this.Controls.Add(this.tbSum);
            this.Controls.Add(this.tbSupplierBillNumber);
            this.Controls.Add(this.tbSupplier);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainStoreInsertSaveConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подтвердите сохранение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.TextBox tbSupplier;
        private System.Windows.Forms.TextBox tbSupplierBillNumber;
        private System.Windows.Forms.TextBox tbSum;
        private System.Windows.Forms.CheckBox cbDelayLocalBills;
    }
}