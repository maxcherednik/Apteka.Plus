namespace Apteka.Plus.Forms
{
    partial class frmClientsSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientsSummary));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvClientsSummary = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.clientSummaryRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbClientDiscountSettings = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslSummary = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslPersonalDiscount = new System.Windows.Forms.ToolStripStatusLabel();
            this.clientIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfRegistrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateofLastBuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientsSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientSummaryRowBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientsSummary
            // 
            this.dgvClientsSummary.AllowUserToAddRows = false;
            this.dgvClientsSummary.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvClientsSummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientsSummary.AutoGenerateColumns = false;
            this.dgvClientsSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientsSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clientIDDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn,
            this.buyCountDataGridViewTextBoxColumn,
            this.RowCount,
            this.dateOfRegistrationDataGridViewTextBoxColumn,
            this.DateofLastBuy,
            this.DiscountSize});
            this.dgvClientsSummary.DataSource = this.clientSummaryRowBindingSource;
            this.dgvClientsSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientsSummary.Location = new System.Drawing.Point(0, 25);
            this.dgvClientsSummary.Name = "dgvClientsSummary";
            this.dgvClientsSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientsSummary.Size = new System.Drawing.Size(906, 484);
            this.dgvClientsSummary.TabIndex = 0;
            this.dgvClientsSummary.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClientsSummary_ColumnHeaderMouseClick);
            this.dgvClientsSummary.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvClientsSummary_CellValidating);
            this.dgvClientsSummary.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientsSummary_CellEndEdit);
            this.dgvClientsSummary.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClientsSummary_CellMouseDoubleClick);
            this.dgvClientsSummary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvClientsSummary_KeyDown);
            // 
            // clientSummaryRowBindingSource
            // 
            this.clientSummaryRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.ClientSummaryRow);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClientDiscountSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(906, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbClientDiscountSettings
            // 
            this.tsbClientDiscountSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbClientDiscountSettings.Image")));
            this.tsbClientDiscountSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClientDiscountSettings.Name = "tsbClientDiscountSettings";
            this.tsbClientDiscountSettings.Size = new System.Drawing.Size(132, 22);
            this.tsbClientDiscountSettings.Text = "Параметры скидки";
            this.tsbClientDiscountSettings.Click += new System.EventHandler(this.tsbClientDiscountSettings_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslSummary,
            this.tslPersonalDiscount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 509);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(906, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslSummary
            // 
            this.tslSummary.Name = "tslSummary";
            this.tslSummary.Size = new System.Drawing.Size(112, 17);
            this.tslSummary.Text = "Покупателей всего";
            // 
            // tslPersonalDiscount
            // 
            this.tslPersonalDiscount.Name = "tslPersonalDiscount";
            this.tslPersonalDiscount.Size = new System.Drawing.Size(127, 17);
            this.tslPersonalDiscount.Text = "Персональная скидка";
            // 
            // clientIDDataGridViewTextBoxColumn
            // 
            this.clientIDDataGridViewTextBoxColumn.DataPropertyName = "ClientID";
            this.clientIDDataGridViewTextBoxColumn.HeaderText = "ID клиента";
            this.clientIDDataGridViewTextBoxColumn.Name = "clientIDDataGridViewTextBoxColumn";
            this.clientIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.sumDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.sumDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            this.sumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // discountDataGridViewTextBoxColumn
            // 
            this.discountDataGridViewTextBoxColumn.DataPropertyName = "Discount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.discountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.discountDataGridViewTextBoxColumn.HeaderText = "Сумма скидки";
            this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
            this.discountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // buyCountDataGridViewTextBoxColumn
            // 
            this.buyCountDataGridViewTextBoxColumn.DataPropertyName = "BuyCount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.buyCountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.buyCountDataGridViewTextBoxColumn.HeaderText = "Кол-во посещений";
            this.buyCountDataGridViewTextBoxColumn.Name = "buyCountDataGridViewTextBoxColumn";
            this.buyCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RowCount
            // 
            this.RowCount.DataPropertyName = "RowCount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RowCount.DefaultCellStyle = dataGridViewCellStyle5;
            this.RowCount.HeaderText = "Кол-во покупок";
            this.RowCount.Name = "RowCount";
            this.RowCount.ReadOnly = true;
            // 
            // dateOfRegistrationDataGridViewTextBoxColumn
            // 
            this.dateOfRegistrationDataGridViewTextBoxColumn.DataPropertyName = "DateOfRegistration";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.dateOfRegistrationDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.dateOfRegistrationDataGridViewTextBoxColumn.HeaderText = "Дата регистрации";
            this.dateOfRegistrationDataGridViewTextBoxColumn.Name = "dateOfRegistrationDataGridViewTextBoxColumn";
            this.dateOfRegistrationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DateofLastBuy
            // 
            this.DateofLastBuy.DataPropertyName = "DateofLastBuy";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.DateofLastBuy.DefaultCellStyle = dataGridViewCellStyle7;
            this.DateofLastBuy.HeaderText = "Дата последней покупки";
            this.DateofLastBuy.Name = "DateofLastBuy";
            this.DateofLastBuy.ReadOnly = true;
            // 
            // DiscountSize
            // 
            this.DiscountSize.DataPropertyName = "DiscountSize";
            this.DiscountSize.HeaderText = "Скидка %";
            this.DiscountSize.Name = "DiscountSize";
            // 
            // frmClientsSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 531);
            this.Controls.Add(this.dgvClientsSummary);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmClientsSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Статистика по клиентам";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmClientsSummary_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClientsSummary_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientsSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientSummaryRowBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Apteka.Plus.Common.Controls.MyDataGridView dgvClientsSummary;
        private System.Windows.Forms.BindingSource clientSummaryRowBindingSource;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbClientDiscountSettings;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslSummary;
        private System.Windows.Forms.ToolStripStatusLabel tslPersonalDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfRegistrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateofLastBuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountSize;
    }
}