namespace Apteka.Plus.UserControls
{
    partial class UcNewBillPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvBill = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.mainStoreInsertRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainStoreInsertRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(777, 435);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvBill);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(769, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Накладная";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvBill
            // 
            this.dgvBill.AllowUserToAddRows = false;
            this.dgvBill.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBill.AutoGenerateColumns = false;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.PackageName,
            this.Amount,
            this.SupplierPrice,
            this.Extra,
            this.LocalPrice});
            this.dgvBill.DataSource = this.mainStoreInsertRowBindingSource;
            this.dgvBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBill.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBill.Location = new System.Drawing.Point(3, 3);
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBill.Size = new System.Drawing.Size(763, 403);
            this.dgvBill.TabIndex = 0;
            this.dgvBill.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvBill_CellParsing);
            this.dgvBill.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBill_CellFormatting);
            this.dgvBill.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvBill_CellValidating);
            this.dgvBill.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBill_CellMouseDoubleClick);
            this.dgvBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBill_KeyUp);
            // 
            // mainStoreInsertRowBindingSource
            // 
            this.mainStoreInsertRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MainStoreInsertRow);
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Название";
            this.ProductName.Name = "ProductName";
            // 
            // PackageName
            // 
            this.PackageName.DataPropertyName = "PackageName";
            this.PackageName.HeaderText = "Фасовка";
            this.PackageName.Name = "PackageName";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Кол-во";
            this.Amount.Name = "Amount";
            // 
            // SupplierPrice
            // 
            this.SupplierPrice.DataPropertyName = "SupplierPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.SupplierPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.SupplierPrice.HeaderText = "Цена";
            this.SupplierPrice.Name = "SupplierPrice";
            // 
            // Extra
            // 
            this.Extra.DataPropertyName = "Extra";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Extra.DefaultCellStyle = dataGridViewCellStyle4;
            this.Extra.HeaderText = "Наценка";
            this.Extra.Name = "Extra";
            // 
            // LocalPrice
            // 
            this.LocalPrice.DataPropertyName = "LocalPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.LocalPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.LocalPrice.HeaderText = "Наша цена";
            this.LocalPrice.Name = "LocalPrice";
            // 
            // UcNewBillPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UcNewBillPage";
            this.Size = new System.Drawing.Size(777, 435);
            this.Load += new System.EventHandler(this.ucNewBillPage_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainStoreInsertRowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvBill;
        private System.Windows.Forms.BindingSource mainStoreInsertRowBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Extra;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalPrice;
    }
}
