namespace Apteka.Plus.Forms
{
    partial class frmExternalOrderMapEditor
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
            this.btnLoadExternalOrder = new System.Windows.Forms.Button();
            this.dgvExternalOrder = new System.Windows.Forms.DataGridView();
            this.cmsCopyHeaderName = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyHeaderName = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dgvExternalOrderMapping = new System.Windows.Forms.DataGridView();
            this.localNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.externalNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPasteHeaderName = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteHeaderName = new System.Windows.Forms.ToolStripMenuItem();
            this.externalOrderMappingRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.tbSupplierName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExternalOrder)).BeginInit();
            this.cmsCopyHeaderName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExternalOrderMapping)).BeginInit();
            this.cmsPasteHeaderName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.externalOrderMappingRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadExternalOrder
            // 
            this.btnLoadExternalOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadExternalOrder.AutoSize = true;
            this.btnLoadExternalOrder.Location = new System.Drawing.Point(1180, 32);
            this.btnLoadExternalOrder.Name = "btnLoadExternalOrder";
            this.btnLoadExternalOrder.Size = new System.Drawing.Size(119, 23);
            this.btnLoadExternalOrder.TabIndex = 0;
            this.btnLoadExternalOrder.Text = "Открыть накладную";
            this.btnLoadExternalOrder.UseVisualStyleBackColor = true;
            this.btnLoadExternalOrder.Click += new System.EventHandler(this.btnLoadExternalOrder_Click);
            // 
            // dgvExternalOrder
            // 
            this.dgvExternalOrder.AllowUserToAddRows = false;
            this.dgvExternalOrder.AllowUserToDeleteRows = false;
            this.dgvExternalOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExternalOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExternalOrder.ContextMenuStrip = this.cmsCopyHeaderName;
            this.dgvExternalOrder.Location = new System.Drawing.Point(409, 32);
            this.dgvExternalOrder.Name = "dgvExternalOrder";
            this.dgvExternalOrder.ReadOnly = true;
            this.dgvExternalOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvExternalOrder.Size = new System.Drawing.Size(765, 657);
            this.dgvExternalOrder.TabIndex = 1;
            // 
            // cmsCopyHeaderName
            // 
            this.cmsCopyHeaderName.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyHeaderName});
            this.cmsCopyHeaderName.Name = "cmsCopyHeaderName";
            this.cmsCopyHeaderName.Size = new System.Drawing.Size(250, 26);
            // 
            // copyHeaderName
            // 
            this.copyHeaderName.Name = "copyHeaderName";
            this.copyHeaderName.Size = new System.Drawing.Size(249, 22);
            this.copyHeaderName.Text = "Скопировать название колонки";
            this.copyHeaderName.Click += new System.EventHandler(this.copyHeaderName_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "DBF files|*.dbf";
            this.openFileDialog1.InitialDirectory = "Foreign";
            this.openFileDialog1.Title = "Выберите файл накладной";
            // 
            // dgvExternalOrderMapping
            // 
            this.dgvExternalOrderMapping.AllowUserToAddRows = false;
            this.dgvExternalOrderMapping.AllowUserToDeleteRows = false;
            this.dgvExternalOrderMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvExternalOrderMapping.AutoGenerateColumns = false;
            this.dgvExternalOrderMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExternalOrderMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.localNameDataGridViewTextBoxColumn,
            this.externalNameDataGridViewTextBoxColumn});
            this.dgvExternalOrderMapping.ContextMenuStrip = this.cmsPasteHeaderName;
            this.dgvExternalOrderMapping.DataSource = this.externalOrderMappingRowBindingSource;
            this.dgvExternalOrderMapping.Location = new System.Drawing.Point(12, 32);
            this.dgvExternalOrderMapping.Name = "dgvExternalOrderMapping";
            this.dgvExternalOrderMapping.ReadOnly = true;
            this.dgvExternalOrderMapping.Size = new System.Drawing.Size(382, 657);
            this.dgvExternalOrderMapping.TabIndex = 2;
            // 
            // localNameDataGridViewTextBoxColumn
            // 
            this.localNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.localNameDataGridViewTextBoxColumn.DataPropertyName = "LocalNameUI";
            this.localNameDataGridViewTextBoxColumn.HeaderText = "Внутреннее название";
            this.localNameDataGridViewTextBoxColumn.Name = "localNameDataGridViewTextBoxColumn";
            this.localNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.localNameDataGridViewTextBoxColumn.Width = 130;
            // 
            // externalNameDataGridViewTextBoxColumn
            // 
            this.externalNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.externalNameDataGridViewTextBoxColumn.DataPropertyName = "ExternalName";
            this.externalNameDataGridViewTextBoxColumn.HeaderText = "Внешнее название";
            this.externalNameDataGridViewTextBoxColumn.Name = "externalNameDataGridViewTextBoxColumn";
            this.externalNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.externalNameDataGridViewTextBoxColumn.Width = 117;
            // 
            // cmsPasteHeaderName
            // 
            this.cmsPasteHeaderName.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteHeaderName});
            this.cmsPasteHeaderName.Name = "cmsPasteHeaderName";
            this.cmsPasteHeaderName.Size = new System.Drawing.Size(226, 26);
            // 
            // pasteHeaderName
            // 
            this.pasteHeaderName.Name = "pasteHeaderName";
            this.pasteHeaderName.Size = new System.Drawing.Size(225, 22);
            this.pasteHeaderName.Text = "Вставить название колонки";
            this.pasteHeaderName.Click += new System.EventHandler(this.pasteHeaderName_Click);
            // 
            // externalOrderMappingRowBindingSource
            // 
            this.externalOrderMappingRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.OrderConverter.BLL.ExternalOrderMappingRow);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Название:";
            // 
            // tbSupplierName
            // 
            this.tbSupplierName.Location = new System.Drawing.Point(78, 6);
            this.tbSupplierName.Name = "tbSupplierName";
            this.tbSupplierName.Size = new System.Drawing.Size(175, 20);
            this.tbSupplierName.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(259, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmExternalOrderMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 701);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbSupplierName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dgvExternalOrderMapping);
            this.Controls.Add(this.dgvExternalOrder);
            this.Controls.Add(this.btnLoadExternalOrder);
            this.MinimizeBox = false;
            this.Name = "frmExternalOrderMapEditor";
            this.Text = "Маппинг названий колонок";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmExternalOrderMapEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExternalOrder)).EndInit();
            this.cmsCopyHeaderName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExternalOrderMapping)).EndInit();
            this.cmsPasteHeaderName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.externalOrderMappingRowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadExternalOrder;
        private System.Windows.Forms.DataGridView dgvExternalOrder;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgvExternalOrderMapping;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbSupplierName;
        private System.Windows.Forms.BindingSource externalOrderMappingRowBindingSource;
        private System.Windows.Forms.ContextMenuStrip cmsCopyHeaderName;
        private System.Windows.Forms.ToolStripMenuItem copyHeaderName;
        private System.Windows.Forms.ContextMenuStrip cmsPasteHeaderName;
        private System.Windows.Forms.ToolStripMenuItem pasteHeaderName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn localNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn externalNameDataGridViewTextBoxColumn;
    }
}