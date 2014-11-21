namespace Apteka.Plus.Forms
{
    partial class frmLocalTransfersPreview
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
            this.dgvLocalTransfersInfo = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.dateAcceptedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceStoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationStoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localBillsTransferInfoRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalTransfersInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsTransferInfoRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocalTransfersInfo
            // 
            this.dgvLocalTransfersInfo.AllowUserToAddRows = false;
            this.dgvLocalTransfersInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvLocalTransfersInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalTransfersInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocalTransfersInfo.AutoGenerateColumns = false;
            this.dgvLocalTransfersInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalTransfersInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateAcceptedDataGridViewTextBoxColumn,
            this.sourceStoreDataGridViewTextBoxColumn,
            this.destinationStoreDataGridViewTextBoxColumn});
            this.dgvLocalTransfersInfo.DataSource = this.localBillsTransferInfoRowBindingSource;
            this.dgvLocalTransfersInfo.Location = new System.Drawing.Point(12, 12);
            this.dgvLocalTransfersInfo.Name = "dgvLocalTransfersInfo";
            this.dgvLocalTransfersInfo.ReadOnly = true;
            this.dgvLocalTransfersInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalTransfersInfo.Size = new System.Drawing.Size(476, 267);
            this.dgvLocalTransfersInfo.TabIndex = 0;
            this.dgvLocalTransfersInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLocalTransfersInfo_KeyDown);
            // 
            // dateAcceptedDataGridViewTextBoxColumn
            // 
            this.dateAcceptedDataGridViewTextBoxColumn.DataPropertyName = "DateAccepted";
            this.dateAcceptedDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateAcceptedDataGridViewTextBoxColumn.Name = "dateAcceptedDataGridViewTextBoxColumn";
            this.dateAcceptedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateAcceptedDataGridViewTextBoxColumn.Width = 58;
            // 
            // sourceStoreDataGridViewTextBoxColumn
            // 
            this.sourceStoreDataGridViewTextBoxColumn.DataPropertyName = "SourceStore";
            this.sourceStoreDataGridViewTextBoxColumn.HeaderText = "Из";
            this.sourceStoreDataGridViewTextBoxColumn.Name = "sourceStoreDataGridViewTextBoxColumn";
            this.sourceStoreDataGridViewTextBoxColumn.ReadOnly = true;
            this.sourceStoreDataGridViewTextBoxColumn.Width = 46;
            // 
            // destinationStoreDataGridViewTextBoxColumn
            // 
            this.destinationStoreDataGridViewTextBoxColumn.DataPropertyName = "DestinationStore";
            this.destinationStoreDataGridViewTextBoxColumn.HeaderText = "В";
            this.destinationStoreDataGridViewTextBoxColumn.Name = "destinationStoreDataGridViewTextBoxColumn";
            this.destinationStoreDataGridViewTextBoxColumn.ReadOnly = true;
            this.destinationStoreDataGridViewTextBoxColumn.Width = 39;
            // 
            // localBillsTransferInfoRowBindingSource
            // 
            this.localBillsTransferInfoRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.LocalBillsTransferInfoRow);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(413, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(332, 296);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmLocalTransfersPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 331);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvLocalTransfersInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocalTransfersPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Просмотр передач";
            this.Load += new System.EventHandler(this.frmLocalTransfersPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalTransfersInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localBillsTransferInfoRowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Apteka.Plus.Common.Controls.MyDataGridView dgvLocalTransfersInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.BindingSource localBillsTransferInfoRowBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAcceptedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceStoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationStoreDataGridViewTextBoxColumn;
    }
}