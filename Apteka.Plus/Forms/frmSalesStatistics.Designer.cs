namespace Apteka.Plus.Forms
{
    partial class frmSalesStatistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cbMyStores = new System.Windows.Forms.ComboBox();
            this.myStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblChooseSatelite = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSalesStatistics = new Apteka.Plus.Common.Controls.MyDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(100, 37);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(159, 20);
            this.tbSearch.TabIndex = 17;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 40);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 16;
            this.lblSearch.Text = "Поиск:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(687, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(71, 23);
            this.btnLoad.TabIndex = 15;
            this.btnLoad.Text = "Показать";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(295, 6);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(171, 20);
            this.dtpStartDate.TabIndex = 14;
            // 
            // cbMyStores
            // 
            this.cbMyStores.DataSource = this.myStoreBindingSource;
            this.cbMyStores.DisplayMember = "Name";
            this.cbMyStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMyStores.FormattingEnabled = true;
            this.cbMyStores.Location = new System.Drawing.Point(100, 6);
            this.cbMyStores.Name = "cbMyStores";
            this.cbMyStores.Size = new System.Drawing.Size(159, 21);
            this.cbMyStores.TabIndex = 13;
            this.cbMyStores.ValueMember = "ID";
            // 
            // myStoreBindingSource
            // 
            this.myStoreBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MyStore);
            // 
            // lblChooseSatelite
            // 
            this.lblChooseSatelite.AutoSize = true;
            this.lblChooseSatelite.Location = new System.Drawing.Point(3, 9);
            this.lblChooseSatelite.Name = "lblChooseSatelite";
            this.lblChooseSatelite.Size = new System.Drawing.Size(91, 13);
            this.lblChooseSatelite.TabIndex = 12;
            this.lblChooseSatelite.Text = "Выберите пункт:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(500, 5);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(171, 20);
            this.dtpEndDate.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "от:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "до:";
            // 
            // dgvSalesStatistics
            // 
            this.dgvSalesStatistics.AllowUserToAddRows = false;
            this.dgvSalesStatistics.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvSalesStatistics.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalesStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesStatistics.Location = new System.Drawing.Point(6, 63);
            this.dgvSalesStatistics.Name = "dgvSalesStatistics";
            this.dgvSalesStatistics.ReadOnly = true;
            this.dgvSalesStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesStatistics.Size = new System.Drawing.Size(873, 471);
            this.dgvSalesStatistics.TabIndex = 21;
            this.dgvSalesStatistics.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSalesStatistics_KeyDown);
            this.dgvSalesStatistics.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvSalesStatistics_KeyPress);
            // 
            // frmSalesStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 537);
            this.Controls.Add(this.dgvSalesStatistics);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cbMyStores);
            this.Controls.Add(this.lblChooseSatelite);
            this.Name = "frmSalesStatistics";
            this.Text = "Продаваемость";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSalesStatistics_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSalesStatistics_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesStatistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cbMyStores;
        private System.Windows.Forms.Label lblChooseSatelite;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Apteka.Plus.Common.Controls.MyDataGridView dgvSalesStatistics;
        private System.Windows.Forms.BindingSource myStoreBindingSource;
    }
}