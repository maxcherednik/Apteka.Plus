namespace Apteka.Plus.Forms
{
    partial class frmFullProductInfoEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSummary = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.fullProductInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.tbDivider = new System.Windows.Forms.TextBox();
            this.tbPackageName = new System.Windows.Forms.TextBox();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEAN13 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpIntegration = new System.Windows.Forms.TabPage();
            this.dgvProductsIntegrationInfo = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.supplierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierProductIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.productIntegrationInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAddIntegrationInfo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.cboSuppliers = new System.Windows.Forms.ComboBox();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chbDiscountExclude = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tpSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullProductInfoBindingSource)).BeginInit();
            this.tpIntegration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsIntegrationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productIntegrationInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSummary);
            this.tabControl1.Controls.Add(this.tpIntegration);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(487, 391);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tpSummary
            // 
            this.tpSummary.Controls.Add(this.chbDiscountExclude);
            this.tpSummary.Controls.Add(this.btnCancel);
            this.tpSummary.Controls.Add(this.btnSave);
            this.tpSummary.Controls.Add(this.tbCountry);
            this.tpSummary.Controls.Add(this.label6);
            this.tpSummary.Controls.Add(this.tbDivider);
            this.tpSummary.Controls.Add(this.tbPackageName);
            this.tpSummary.Controls.Add(this.tbProductName);
            this.tpSummary.Controls.Add(this.label5);
            this.tpSummary.Controls.Add(this.label4);
            this.tpSummary.Controls.Add(this.tbEAN13);
            this.tpSummary.Controls.Add(this.label3);
            this.tpSummary.Controls.Add(this.label1);
            this.tpSummary.Location = new System.Drawing.Point(4, 22);
            this.tpSummary.Name = "tpSummary";
            this.tpSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tpSummary.Size = new System.Drawing.Size(479, 365);
            this.tpSummary.TabIndex = 0;
            this.tpSummary.Text = "Общее";
            this.tpSummary.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(365, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(270, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbCountry
            // 
            this.tbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCountry.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fullProductInfoBindingSource, "CountryProducer", true));
            this.tbCountry.Location = new System.Drawing.Point(100, 219);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(340, 20);
            this.tbCountry.TabIndex = 9;
            // 
            // fullProductInfoBindingSource
            // 
            this.fullProductInfoBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.FullProductInfo);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Страна:";
            // 
            // tbDivider
            // 
            this.tbDivider.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fullProductInfoBindingSource, "Divider", true));
            this.tbDivider.Location = new System.Drawing.Point(100, 171);
            this.tbDivider.Name = "tbDivider";
            this.tbDivider.Size = new System.Drawing.Size(78, 20);
            this.tbDivider.TabIndex = 7;
            // 
            // tbPackageName
            // 
            this.tbPackageName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPackageName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fullProductInfoBindingSource, "PackageName", true));
            this.tbPackageName.Location = new System.Drawing.Point(100, 126);
            this.tbPackageName.Name = "tbPackageName";
            this.tbPackageName.Size = new System.Drawing.Size(340, 20);
            this.tbPackageName.TabIndex = 6;
            // 
            // tbProductName
            // 
            this.tbProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProductName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fullProductInfoBindingSource, "ProductName", true));
            this.tbProductName.Location = new System.Drawing.Point(100, 75);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(340, 20);
            this.tbProductName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Делитель:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Фасовка:";
            // 
            // tbEAN13
            // 
            this.tbEAN13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEAN13.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fullProductInfoBindingSource, "EAN13", true));
            this.tbEAN13.Location = new System.Drawing.Point(100, 27);
            this.tbEAN13.Name = "tbEAN13";
            this.tbEAN13.Size = new System.Drawing.Size(340, 20);
            this.tbEAN13.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Название:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Штрих-код:";
            // 
            // tpIntegration
            // 
            this.tpIntegration.Controls.Add(this.dgvProductsIntegrationInfo);
            this.tpIntegration.Controls.Add(this.btnAddIntegrationInfo);
            this.tpIntegration.Controls.Add(this.label2);
            this.tpIntegration.Controls.Add(this.tbID);
            this.tpIntegration.Controls.Add(this.cboSuppliers);
            this.tpIntegration.Location = new System.Drawing.Point(4, 22);
            this.tpIntegration.Name = "tpIntegration";
            this.tpIntegration.Padding = new System.Windows.Forms.Padding(3);
            this.tpIntegration.Size = new System.Drawing.Size(479, 323);
            this.tpIntegration.TabIndex = 1;
            this.tpIntegration.Text = "Интеграция";
            this.tpIntegration.UseVisualStyleBackColor = true;
            // 
            // dgvProductsIntegrationInfo
            // 
            this.dgvProductsIntegrationInfo.AllowUserToAddRows = false;
            this.dgvProductsIntegrationInfo.AllowUserToDeleteRows = false;
            this.dgvProductsIntegrationInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductsIntegrationInfo.AutoGenerateColumns = false;
            this.dgvProductsIntegrationInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductsIntegrationInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.supplierDataGridViewTextBoxColumn,
            this.supplierProductIDDataGridViewTextBoxColumn,
            this.Column1});
            this.dgvProductsIntegrationInfo.DataSource = this.productIntegrationInfoBindingSource;
            this.dgvProductsIntegrationInfo.Location = new System.Drawing.Point(9, 34);
            this.dgvProductsIntegrationInfo.Name = "dgvProductsIntegrationInfo";
            this.dgvProductsIntegrationInfo.ReadOnly = true;
            this.dgvProductsIntegrationInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductsIntegrationInfo.Size = new System.Drawing.Size(462, 281);
            this.dgvProductsIntegrationInfo.TabIndex = 22;
            this.dgvProductsIntegrationInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductsIntegrationInfo_CellContentClick);
            // 
            // supplierDataGridViewTextBoxColumn
            // 
            this.supplierDataGridViewTextBoxColumn.DataPropertyName = "Supplier";
            this.supplierDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.supplierDataGridViewTextBoxColumn.Name = "supplierDataGridViewTextBoxColumn";
            this.supplierDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierProductIDDataGridViewTextBoxColumn
            // 
            this.supplierProductIDDataGridViewTextBoxColumn.DataPropertyName = "SupplierProductID";
            this.supplierProductIDDataGridViewTextBoxColumn.HeaderText = "Идентификтор товара поставщика";
            this.supplierProductIDDataGridViewTextBoxColumn.Name = "supplierProductIDDataGridViewTextBoxColumn";
            this.supplierProductIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Действие";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Text = "Удалить";
            this.Column1.UseColumnTextForButtonValue = true;
            // 
            // productIntegrationInfoBindingSource
            // 
            this.productIntegrationInfoBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.ProductIntegrationInfo);
            // 
            // btnAddIntegrationInfo
            // 
            this.btnAddIntegrationInfo.Location = new System.Drawing.Point(340, 5);
            this.btnAddIntegrationInfo.Name = "btnAddIntegrationInfo";
            this.btnAddIntegrationInfo.Size = new System.Drawing.Size(75, 23);
            this.btnAddIntegrationInfo.TabIndex = 21;
            this.btnAddIntegrationInfo.Text = "Добавить";
            this.btnAddIntegrationInfo.UseVisualStyleBackColor = true;
            this.btnAddIntegrationInfo.Click += new System.EventHandler(this.btnAddIntegrationInfo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "=";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(210, 7);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(124, 20);
            this.tbID.TabIndex = 19;
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.DataSource = this.supplierBindingSource;
            this.cboSuppliers.DisplayMember = "Name";
            this.cboSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.Location = new System.Drawing.Point(8, 6);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(177, 21);
            this.cboSuppliers.TabIndex = 18;
            this.cboSuppliers.ValueMember = "ID";
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.Supplier);
            // 
            // chbDiscountExclude
            // 
            this.chbDiscountExclude.AutoSize = true;
            this.chbDiscountExclude.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.fullProductInfoBindingSource, "IsDiscountExcluded", true));
            this.chbDiscountExclude.Location = new System.Drawing.Point(98, 265);
            this.chbDiscountExclude.Name = "chbDiscountExclude";
            this.chbDiscountExclude.Size = new System.Drawing.Size(116, 17);
            this.chbDiscountExclude.TabIndex = 12;
            this.chbDiscountExclude.Text = "запретить скидку";
            this.chbDiscountExclude.UseVisualStyleBackColor = true;
            // 
            // frmFullProductInfoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(487, 391);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmFullProductInfoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры товара";
            this.tabControl1.ResumeLayout(false);
            this.tpSummary.ResumeLayout(false);
            this.tpSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullProductInfoBindingSource)).EndInit();
            this.tpIntegration.ResumeLayout(false);
            this.tpIntegration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsIntegrationInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productIntegrationInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSummary;
        private System.Windows.Forms.TabPage tpIntegration;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvProductsIntegrationInfo;
        private System.Windows.Forms.Button btnAddIntegrationInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.ComboBox cboSuppliers;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private System.Windows.Forms.BindingSource productIntegrationInfoBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEAN13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDivider;
        private System.Windows.Forms.TextBox tbPackageName;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource fullProductInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierProductIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.CheckBox chbDiscountExclude;
    }
}