namespace Apteka.Plus.UserControls
{
    partial class ucPriceChangesHistory
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
            this.dgvPriceChanges = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.dateAcceptedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceChangeRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceChanges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceChangeRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPriceChanges
            // 
            this.dgvPriceChanges.AllowUserToAddRows = false;
            this.dgvPriceChanges.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvPriceChanges.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPriceChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPriceChanges.AutoGenerateColumns = false;
            this.dgvPriceChanges.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPriceChanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceChanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateAcceptedDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.packageNameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.Difference,
            this.OldPrice,
            this.newPriceDataGridViewTextBoxColumn});
            this.dgvPriceChanges.DataSource = this.priceChangeRowBindingSource;
            this.dgvPriceChanges.Location = new System.Drawing.Point(0, 36);
            this.dgvPriceChanges.Name = "dgvPriceChanges";
            this.dgvPriceChanges.ReadOnly = true;
            this.dgvPriceChanges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPriceChanges.Size = new System.Drawing.Size(762, 379);
            this.dgvPriceChanges.TabIndex = 22;
            this.dgvPriceChanges.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPriceChanges_CellFormatting);
            // 
            // dateAcceptedDataGridViewTextBoxColumn
            // 
            this.dateAcceptedDataGridViewTextBoxColumn.DataPropertyName = "DateAccepted";
            this.dateAcceptedDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateAcceptedDataGridViewTextBoxColumn.Name = "dateAcceptedDataGridViewTextBoxColumn";
            this.dateAcceptedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // packageNameDataGridViewTextBoxColumn
            // 
            this.packageNameDataGridViewTextBoxColumn.DataPropertyName = "PackageName";
            this.packageNameDataGridViewTextBoxColumn.HeaderText = "Фасовка";
            this.packageNameDataGridViewTextBoxColumn.Name = "packageNameDataGridViewTextBoxColumn";
            this.packageNameDataGridViewTextBoxColumn.ReadOnly = true;
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
            // Difference
            // 
            this.Difference.DataPropertyName = "Difference";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Difference.DefaultCellStyle = dataGridViewCellStyle3;
            this.Difference.HeaderText = "Разница";
            this.Difference.Name = "Difference";
            this.Difference.ReadOnly = true;
            // 
            // OldPrice
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.OldPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.OldPrice.HeaderText = "Старая цена";
            this.OldPrice.Name = "OldPrice";
            this.OldPrice.ReadOnly = true;
            // 
            // newPriceDataGridViewTextBoxColumn
            // 
            this.newPriceDataGridViewTextBoxColumn.DataPropertyName = "NewPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.newPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.newPriceDataGridViewTextBoxColumn.HeaderText = "Новая цена";
            this.newPriceDataGridViewTextBoxColumn.Name = "newPriceDataGridViewTextBoxColumn";
            this.newPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceChangeRowBindingSource
            // 
            this.priceChangeRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.PriceChangeRow);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(51, 10);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(139, 20);
            this.tbSearch.TabIndex = 21;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 20;
            this.lblSearch.Text = "Поиск:";
            // 
            // ucPriceChangesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPriceChanges);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "ucPriceChangesHistory";
            this.Size = new System.Drawing.Size(762, 415);
            this.Load += new System.EventHandler(this.ucPriceChangesHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceChanges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceChangeRowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Apteka.Plus.Common.Controls.MyDataGridView dgvPriceChanges;
        private System.Windows.Forms.BindingSource priceChangeRowBindingSource;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcceptedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difference;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn newPriceDataGridViewTextBoxColumn;
    }
}
