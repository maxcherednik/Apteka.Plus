using Apteka.Plus.Logic.OrderConverter.BLL;

namespace Apteka.Plus.Forms
{
    partial class frmForeignOrderViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForeignOrderViewer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tsbProcess = new System.Windows.Forms.ToolStripButton();
            this.dgvForeignOrder = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.SupplierProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierPriceWithNDSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorPriceWithoutNDSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceReestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eAN13DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLifeImportant = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.localOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForeignOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localOrderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripButton,
            this.tsbProcess});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1362, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(128, 22);
            this.printToolStripButton.Text = "Печать накладной";
            this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // tsbProcess
            // 
            this.tsbProcess.Image = ((System.Drawing.Image)(resources.GetObject("tsbProcess.Image")));
            this.tsbProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProcess.Name = "tsbProcess";
            this.tsbProcess.Size = new System.Drawing.Size(92, 22);
            this.tsbProcess.Text = "Обработать";
            this.tsbProcess.Click += new System.EventHandler(this.tsbProcess_Click);
            // 
            // dgvForeignOrder
            // 
            this.dgvForeignOrder.AllowUserToAddRows = false;
            this.dgvForeignOrder.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvForeignOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvForeignOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvForeignOrder.AutoGenerateColumns = false;
            this.dgvForeignOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForeignOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupplierProductName,
            this.countDataGridViewTextBoxColumn,
            this.supplierPriceWithNDSDataGridViewTextBoxColumn,
            this.vendorPriceWithoutNDSDataGridViewTextBoxColumn,
            this.priceReestrDataGridViewTextBoxColumn,
            this.nDSDataGridViewTextBoxColumn,
            this.seriesDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn,
            this.producerDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.eAN13DataGridViewTextBoxColumn,
            this.IsLifeImportant});
            this.dgvForeignOrder.DataSource = this.localOrderBindingSource;
            this.dgvForeignOrder.Location = new System.Drawing.Point(0, 28);
            this.dgvForeignOrder.Name = "dgvForeignOrder";
            this.dgvForeignOrder.ReadOnly = true;
            this.dgvForeignOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvForeignOrder.Size = new System.Drawing.Size(1362, 443);
            this.dgvForeignOrder.TabIndex = 0;
            // 
            // SupplierProductName
            // 
            this.SupplierProductName.DataPropertyName = "SupplierProductName";
            this.SupplierProductName.HeaderText = "Название";
            this.SupplierProductName.Name = "SupplierProductName";
            this.SupplierProductName.ReadOnly = true;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.countDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.countDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierPriceWithNDSDataGridViewTextBoxColumn
            // 
            this.supplierPriceWithNDSDataGridViewTextBoxColumn.DataPropertyName = "SupplierPriceWithNDS";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.supplierPriceWithNDSDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.supplierPriceWithNDSDataGridViewTextBoxColumn.HeaderText = "Цена поставщика с НДС";
            this.supplierPriceWithNDSDataGridViewTextBoxColumn.Name = "supplierPriceWithNDSDataGridViewTextBoxColumn";
            this.supplierPriceWithNDSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorPriceWithoutNDSDataGridViewTextBoxColumn
            // 
            this.vendorPriceWithoutNDSDataGridViewTextBoxColumn.DataPropertyName = "VendorPriceWithNDS";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.vendorPriceWithoutNDSDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vendorPriceWithoutNDSDataGridViewTextBoxColumn.HeaderText = "Цена производителя с НДС";
            this.vendorPriceWithoutNDSDataGridViewTextBoxColumn.Name = "vendorPriceWithoutNDSDataGridViewTextBoxColumn";
            this.vendorPriceWithoutNDSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceReestrDataGridViewTextBoxColumn
            // 
            this.priceReestrDataGridViewTextBoxColumn.DataPropertyName = "PriceReestr";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.priceReestrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.priceReestrDataGridViewTextBoxColumn.HeaderText = "Реестр";
            this.priceReestrDataGridViewTextBoxColumn.Name = "priceReestrDataGridViewTextBoxColumn";
            this.priceReestrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nDSDataGridViewTextBoxColumn
            // 
            this.nDSDataGridViewTextBoxColumn.DataPropertyName = "NDS";
            this.nDSDataGridViewTextBoxColumn.HeaderText = "НДС";
            this.nDSDataGridViewTextBoxColumn.Name = "nDSDataGridViewTextBoxColumn";
            this.nDSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seriesDataGridViewTextBoxColumn
            // 
            this.seriesDataGridViewTextBoxColumn.DataPropertyName = "Series";
            this.seriesDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.seriesDataGridViewTextBoxColumn.Name = "seriesDataGridViewTextBoxColumn";
            this.seriesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expirationDateDataGridViewTextBoxColumn
            // 
            this.expirationDateDataGridViewTextBoxColumn.DataPropertyName = "ExpirationDate";
            this.expirationDateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expirationDateDataGridViewTextBoxColumn.Name = "expirationDateDataGridViewTextBoxColumn";
            this.expirationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // producerDataGridViewTextBoxColumn
            // 
            this.producerDataGridViewTextBoxColumn.DataPropertyName = "Producer";
            this.producerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.producerDataGridViewTextBoxColumn.Name = "producerDataGridViewTextBoxColumn";
            this.producerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Страна";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eAN13DataGridViewTextBoxColumn
            // 
            this.eAN13DataGridViewTextBoxColumn.DataPropertyName = "EAN13";
            this.eAN13DataGridViewTextBoxColumn.HeaderText = "Штрих-код";
            this.eAN13DataGridViewTextBoxColumn.Name = "eAN13DataGridViewTextBoxColumn";
            this.eAN13DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // IsLifeImportant
            // 
            this.IsLifeImportant.DataPropertyName = "IsLifeImportant";
            this.IsLifeImportant.HeaderText = "Жизненно-важный";
            this.IsLifeImportant.Name = "IsLifeImportant";
            this.IsLifeImportant.ReadOnly = true;
            // 
            // localOrderBindingSource
            // 
            this.localOrderBindingSource.DataSource = typeof(LocalOrder);
            // 
            // frmForeignOrderViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 471);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvForeignOrder);
            this.Name = "frmForeignOrderViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Электронная накладная";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmForeignOrderViewer_Load);
            this.Shown += new System.EventHandler(this.frmForeignOrderViewer_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForeignOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localOrderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Apteka.Plus.Common.Controls.MyDataGridView dgvForeignOrder;
        private System.Windows.Forms.BindingSource localOrderBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton tsbProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierPriceWithNDSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorPriceWithoutNDSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceReestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn producerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eAN13DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLifeImportant;
    }
}