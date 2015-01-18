namespace Apteka.Plus.UserControls
{
    partial class ucFullProductInfoBase
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dgvFullProductInfoList = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.fullProductInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packageNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eAN13DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryProducerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dividerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDiscountExcluded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFullProductInfoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullProductInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tbSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvFullProductInfoList);
            this.splitContainer1.Size = new System.Drawing.Size(745, 410);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Поиск:";
            // 
            // tbSearch
            // 
            this.tbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSearch.Location = new System.Drawing.Point(64, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(242, 22);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // dgvFullProductInfoList
            // 
            this.dgvFullProductInfoList.AllowUserToAddRows = false;
            this.dgvFullProductInfoList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvFullProductInfoList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFullProductInfoList.AutoGenerateColumns = false;
            this.dgvFullProductInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFullProductInfoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNameDataGridViewTextBoxColumn,
            this.packageNameDataGridViewTextBoxColumn,
            this.eAN13DataGridViewTextBoxColumn,
            this.countryProducerDataGridViewTextBoxColumn,
            this.dividerDataGridViewTextBoxColumn,
            this.IsDiscountExcluded});
            this.dgvFullProductInfoList.DataSource = this.fullProductInfoBindingSource;
            this.dgvFullProductInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFullProductInfoList.Location = new System.Drawing.Point(0, 0);
            this.dgvFullProductInfoList.Name = "dgvFullProductInfoList";
            this.dgvFullProductInfoList.ReadOnly = true;
            this.dgvFullProductInfoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFullProductInfoList.Size = new System.Drawing.Size(745, 373);
            this.dgvFullProductInfoList.TabIndex = 0;
            this.dgvFullProductInfoList.CurrentRowChanged += new System.EventHandler<Apteka.Plus.Common.Controls.MyDataGridView.CurrentRowChangedEventArgs>(this.dgvFullProductInfoList_CurrentRowChanged);
            this.dgvFullProductInfoList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFullProductInfoList_CellFormatting);
            this.dgvFullProductInfoList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFullProductInfoList_KeyDown);
            this.dgvFullProductInfoList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvFullProductInfoList_KeyPress);
            // 
            // fullProductInfoBindingSource
            // 
            this.fullProductInfoBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.FullProductInfo);
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
            // eAN13DataGridViewTextBoxColumn
            // 
            this.eAN13DataGridViewTextBoxColumn.DataPropertyName = "EAN13";
            this.eAN13DataGridViewTextBoxColumn.HeaderText = "Штрих-код";
            this.eAN13DataGridViewTextBoxColumn.Name = "eAN13DataGridViewTextBoxColumn";
            this.eAN13DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countryProducerDataGridViewTextBoxColumn
            // 
            this.countryProducerDataGridViewTextBoxColumn.DataPropertyName = "CountryProducer";
            this.countryProducerDataGridViewTextBoxColumn.HeaderText = "Страна производитель";
            this.countryProducerDataGridViewTextBoxColumn.Name = "countryProducerDataGridViewTextBoxColumn";
            this.countryProducerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dividerDataGridViewTextBoxColumn
            // 
            this.dividerDataGridViewTextBoxColumn.DataPropertyName = "Divider";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dividerDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dividerDataGridViewTextBoxColumn.HeaderText = "Делитель";
            this.dividerDataGridViewTextBoxColumn.Name = "dividerDataGridViewTextBoxColumn";
            this.dividerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // IsDiscountExcluded
            // 
            this.IsDiscountExcluded.DataPropertyName = "IsDiscountExcluded";
            this.IsDiscountExcluded.HeaderText = "Скидка";
            this.IsDiscountExcluded.Name = "IsDiscountExcluded";
            this.IsDiscountExcluded.ReadOnly = true;
            this.IsDiscountExcluded.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsDiscountExcluded.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ucFullProductInfoBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucFullProductInfoBase";
            this.Size = new System.Drawing.Size(745, 410);
            this.Load += new System.EventHandler(this.ucFullProductInfoBase_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFullProductInfoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullProductInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvFullProductInfoList;
        private System.Windows.Forms.BindingSource fullProductInfoBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn packageNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eAN13DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryProducerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dividerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDiscountExcluded;
    }
}
