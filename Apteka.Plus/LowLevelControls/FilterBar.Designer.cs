namespace Apteka.Plus.LowLevelControls
{
    partial class FilterBar
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStore = new System.Windows.Forms.Label();
            this.cbStores = new System.Windows.Forms.ComboBox();
            this.myStoreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDateFirst = new System.Windows.Forms.Label();
            this.dtpFirst = new System.Windows.Forms.DateTimePicker();
            this.lblDateSecond = new System.Windows.Forms.Label();
            this.dtpSecond = new System.Windows.Forms.DateTimePicker();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnShowGraphics = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.lblStore);
            this.flowLayoutPanel1.Controls.Add(this.cbStores);
            this.flowLayoutPanel1.Controls.Add(this.lblDateFirst);
            this.flowLayoutPanel1.Controls.Add(this.dtpFirst);
            this.flowLayoutPanel1.Controls.Add(this.lblDateSecond);
            this.flowLayoutPanel1.Controls.Add(this.dtpSecond);
            this.flowLayoutPanel1.Controls.Add(this.btnShow);
            this.flowLayoutPanel1.Controls.Add(this.btnShowGraphics);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(704, 39);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Location = new System.Drawing.Point(8, 10);
            this.lblStore.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(40, 13);
            this.lblStore.TabIndex = 0;
            this.lblStore.Text = "Пункт:";
            // 
            // cbStores
            // 
            this.cbStores.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.myStoreBindingSource, "ID", true));
            this.cbStores.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myStoreBindingSource, "Name", true));
            this.cbStores.DataSource = this.myStoreBindingSource;
            this.cbStores.DisplayMember = "Name";
            this.cbStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStores.FormattingEnabled = true;
            this.cbStores.Location = new System.Drawing.Point(54, 8);
            this.cbStores.Name = "cbStores";
            this.cbStores.Size = new System.Drawing.Size(121, 21);
            this.cbStores.TabIndex = 2;
            this.cbStores.ValueMember = "ID";
            // 
            // myStoreBindingSource
            // 
            this.myStoreBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MyStore);
            // 
            // lblDateFirst
            // 
            this.lblDateFirst.AutoSize = true;
            this.lblDateFirst.Location = new System.Drawing.Point(181, 10);
            this.lblDateFirst.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblDateFirst.Name = "lblDateFirst";
            this.lblDateFirst.Size = new System.Drawing.Size(17, 13);
            this.lblDateFirst.TabIndex = 7;
            this.lblDateFirst.Text = "С:";
            // 
            // dtpFirst
            // 
            this.dtpFirst.Location = new System.Drawing.Point(204, 8);
            this.dtpFirst.Name = "dtpFirst";
            this.dtpFirst.Size = new System.Drawing.Size(147, 20);
            this.dtpFirst.TabIndex = 3;
            // 
            // lblDateSecond
            // 
            this.lblDateSecond.AutoSize = true;
            this.lblDateSecond.Location = new System.Drawing.Point(357, 10);
            this.lblDateSecond.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblDateSecond.Name = "lblDateSecond";
            this.lblDateSecond.Size = new System.Drawing.Size(24, 13);
            this.lblDateSecond.TabIndex = 8;
            this.lblDateSecond.Text = "По:";
            // 
            // dtpSecond
            // 
            this.dtpSecond.Location = new System.Drawing.Point(387, 8);
            this.dtpSecond.Name = "dtpSecond";
            this.dtpSecond.Size = new System.Drawing.Size(147, 20);
            this.dtpSecond.TabIndex = 5;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(540, 8);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Показать";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnShowGraphics
            // 
            this.btnShowGraphics.Location = new System.Drawing.Point(621, 8);
            this.btnShowGraphics.Name = "btnShowGraphics";
            this.btnShowGraphics.Size = new System.Drawing.Size(75, 23);
            this.btnShowGraphics.TabIndex = 5;
            this.btnShowGraphics.Text = "График";
            this.btnShowGraphics.UseVisualStyleBackColor = true;
            this.btnShowGraphics.Click += new System.EventHandler(this.btnShowGraphics_Click);
            // 
            // FilterBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FilterBar";
            this.Size = new System.Drawing.Size(704, 39);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myStoreBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.ComboBox cbStores;
        private System.Windows.Forms.DateTimePicker dtpFirst;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnShowGraphics;
        private System.Windows.Forms.BindingSource myStoreBindingSource;
        private System.Windows.Forms.Label lblDateFirst;
        private System.Windows.Forms.Label lblDateSecond;
        private System.Windows.Forms.DateTimePicker dtpSecond;
    }
}
