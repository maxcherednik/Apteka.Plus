namespace Apteka.Plus.Forms
{
    partial class frmSuppliesReturnConfirmation
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.rbDeleteAll = new System.Windows.Forms.RadioButton();
            this.rbDeleteAmount = new System.Windows.Forms.RadioButton();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(444, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(363, 307);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(27, 110);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(489, 170);
            this.tbComment.TabIndex = 6;
            // 
            // rbDeleteAll
            // 
            this.rbDeleteAll.AutoSize = true;
            this.rbDeleteAll.Checked = true;
            this.rbDeleteAll.Location = new System.Drawing.Point(27, 22);
            this.rbDeleteAll.Name = "rbDeleteAll";
            this.rbDeleteAll.Size = new System.Drawing.Size(86, 17);
            this.rbDeleteAll.TabIndex = 10;
            this.rbDeleteAll.TabStop = true;
            this.rbDeleteAll.Text = "удалить все";
            this.rbDeleteAll.UseVisualStyleBackColor = true;
            // 
            // rbDeleteAmount
            // 
            this.rbDeleteAmount.AutoSize = true;
            this.rbDeleteAmount.Location = new System.Drawing.Point(27, 45);
            this.rbDeleteAmount.Name = "rbDeleteAmount";
            this.rbDeleteAmount.Size = new System.Drawing.Size(101, 17);
            this.rbDeleteAmount.TabIndex = 11;
            this.rbDeleteAmount.Text = "удалить кол-во";
            this.rbDeleteAmount.UseVisualStyleBackColor = true;
            this.rbDeleteAmount.CheckedChanged += new System.EventHandler(this.rbDeleteAmount_CheckedChanged);
            // 
            // tbAmount
            // 
            this.tbAmount.Enabled = false;
            this.tbAmount.Location = new System.Drawing.Point(137, 45);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(56, 20);
            this.tbAmount.TabIndex = 12;
            this.tbAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAmount_KeyDown);
            this.tbAmount.Validating += new System.ComponentModel.CancelEventHandler(this.tbAmount_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Комментарий:";
            // 
            // frmSuppliesReturnConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(545, 342);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.rbDeleteAmount);
            this.Controls.Add(this.rbDeleteAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbComment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSuppliesReturnConfirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подтвердите удаление";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.RadioButton rbDeleteAll;
        private System.Windows.Forms.RadioButton rbDeleteAmount;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label2;
    }
}