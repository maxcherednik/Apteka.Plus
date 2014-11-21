namespace Apteka.Plus.Forms
{
    partial class frmClientsDiscountSettings
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
            this.label4 = new System.Windows.Forms.Label();
            this.tbExtraLimit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDefaultDiscount = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Предел наценки:";
            // 
            // tbExtraLimit
            // 
            this.tbExtraLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExtraLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbExtraLimit.Location = new System.Drawing.Point(147, 42);
            this.tbExtraLimit.Name = "tbExtraLimit";
            this.tbExtraLimit.Size = new System.Drawing.Size(69, 20);
            this.tbExtraLimit.TabIndex = 32;
            this.tbExtraLimit.Text = "14.5";
            this.tbExtraLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbExtraLimit, "Предел наценки, ниже которого скидка не возможна.\r\n");
            this.tbExtraLimit.Validating += new System.ComponentModel.CancelEventHandler(this.tbExtraLimit_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Стандартная скидка:";
            // 
            // tbDefaultDiscount
            // 
            this.tbDefaultDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDefaultDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDefaultDiscount.Location = new System.Drawing.Point(147, 6);
            this.tbDefaultDiscount.Name = "tbDefaultDiscount";
            this.tbDefaultDiscount.Size = new System.Drawing.Size(69, 20);
            this.tbDefaultDiscount.TabIndex = 28;
            this.tbDefaultDiscount.Text = "2.0";
            this.tbDefaultDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDefaultDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.tbDefaultDiscount_Validating);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(244, 35);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(244, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 29;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Тест";
            // 
            // frmClientsDiscountSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(328, 86);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbExtraLimit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDefaultDiscount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientsDiscountSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка скидки";
            this.Load += new System.EventHandler(this.frmClientsDiscountSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbExtraLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDefaultDiscount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}