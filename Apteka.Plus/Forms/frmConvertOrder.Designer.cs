namespace Apteka.Plus.Forms
{
    partial class frmConvertOrder
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteOrderMapping = new System.Windows.Forms.Button();
            this.btnEditOrderMapping = new System.Windows.Forms.Button();
            this.btnAddOrderMapping = new System.Windows.Forms.Button();
            this.liFirms = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.externalOrderSupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.externalOrderSupplierBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.externalOrderSupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.externalOrderSupplierBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "DBF files|*.dbf";
            this.openFileDialog1.InitialDirectory = "Foreign";
            this.openFileDialog1.Title = "Выберите файл накладной";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnDeleteOrderMapping);
            this.groupBox1.Controls.Add(this.btnEditOrderMapping);
            this.groupBox1.Controls.Add(this.btnAddOrderMapping);
            this.groupBox1.Controls.Add(this.liFirms);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 252);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фирмы";
            // 
            // btnDeleteOrderMapping
            // 
            this.btnDeleteOrderMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteOrderMapping.Enabled = false;
            this.btnDeleteOrderMapping.Location = new System.Drawing.Point(181, 220);
            this.btnDeleteOrderMapping.Name = "btnDeleteOrderMapping";
            this.btnDeleteOrderMapping.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOrderMapping.TabIndex = 8;
            this.btnDeleteOrderMapping.Text = "Удалить";
            this.btnDeleteOrderMapping.UseVisualStyleBackColor = true;
            this.btnDeleteOrderMapping.Click += new System.EventHandler(this.btnDeleteOrderMapping_Click);
            // 
            // btnEditOrderMapping
            // 
            this.btnEditOrderMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditOrderMapping.AutoSize = true;
            this.btnEditOrderMapping.Enabled = false;
            this.btnEditOrderMapping.Location = new System.Drawing.Point(81, 220);
            this.btnEditOrderMapping.Name = "btnEditOrderMapping";
            this.btnEditOrderMapping.Size = new System.Drawing.Size(94, 23);
            this.btnEditOrderMapping.TabIndex = 7;
            this.btnEditOrderMapping.Text = "Редактировать";
            this.btnEditOrderMapping.UseVisualStyleBackColor = true;
            this.btnEditOrderMapping.Click += new System.EventHandler(this.btnEditOrderMapping_Click);
            // 
            // btnAddOrderMapping
            // 
            this.btnAddOrderMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddOrderMapping.Location = new System.Drawing.Point(6, 220);
            this.btnAddOrderMapping.Name = "btnAddOrderMapping";
            this.btnAddOrderMapping.Size = new System.Drawing.Size(69, 23);
            this.btnAddOrderMapping.TabIndex = 6;
            this.btnAddOrderMapping.Text = "Добавить";
            this.btnAddOrderMapping.UseVisualStyleBackColor = true;
            this.btnAddOrderMapping.Click += new System.EventHandler(this.btnAddOrderMapping_Click);
            // 
            // liFirms
            // 
            this.liFirms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liFirms.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.externalOrderSupplierBindingSource1, "Id", true));
            this.liFirms.DataSource = this.externalOrderSupplierBindingSource;
            this.liFirms.DisplayMember = "Name";
            this.liFirms.FormattingEnabled = true;
            this.liFirms.Location = new System.Drawing.Point(6, 14);
            this.liFirms.Name = "liFirms";
            this.liFirms.Size = new System.Drawing.Size(252, 199);
            this.liFirms.Sorted = true;
            this.liFirms.TabIndex = 5;
            this.liFirms.ValueMember = "Id";
            this.liFirms.SelectedIndexChanged += new System.EventHandler(this.liFirms_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(301, 63);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(111, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Отмена";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(301, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Открыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // externalOrderSupplierBindingSource
            // 
            this.externalOrderSupplierBindingSource.DataSource = typeof(Apteka.Plus.Logic.OrderConverter.BLL.ExternalOrderSupplier);
            // 
            // externalOrderSupplierBindingSource1
            // 
            this.externalOrderSupplierBindingSource1.DataSource = typeof(Apteka.Plus.Logic.OrderConverter.BLL.ExternalOrderSupplier);
            // 
            // frmConvertOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmConvertOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конвертер накладных";
            this.Load += new System.EventHandler(this.frmConvertOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.externalOrderSupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.externalOrderSupplierBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox liFirms;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddOrderMapping;
        private System.Windows.Forms.Button btnDeleteOrderMapping;
        private System.Windows.Forms.Button btnEditOrderMapping;
        private System.Windows.Forms.BindingSource externalOrderSupplierBindingSource1;
        private System.Windows.Forms.BindingSource externalOrderSupplierBindingSource;
    }
}

