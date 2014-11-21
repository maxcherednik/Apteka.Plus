namespace Apteka.Plus.Forms
{
    partial class frmMainStoreInsertNewPosition
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbApteka7B = new System.Windows.Forms.TextBox();
            this.tbApteka48 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbExpirationDate = new System.Windows.Forms.TextBox();
            this.mainStoreInsertRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.tbSeries = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbLocalPrice = new System.Windows.Forms.TextBox();
            this.tbExtraPercent = new System.Windows.Forms.TextBox();
            this.tbSupplierPrice = new System.Windows.Forms.TextBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCountry = new System.Windows.Forms.TextBox();
            this.fullProductInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbDivider = new System.Windows.Forms.TextBox();
            this.tbPackageName = new System.Windows.Forms.TextBox();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.tbEAN13 = new System.Windows.Forms.TextBox();
            this.btnChooseProduct = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucProductSupplies1 = new Apteka.Plus.UserControls.ucProductSupplies();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainStoreInsertRowBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullProductInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel1.Controls.Add(this.btnOK);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucProductSupplies1);
            this.splitContainer1.Size = new System.Drawing.Size(987, 694);
            this.splitContainer1.SplitterDistance = 481;
            this.splitContainer1.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(900, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(819, 454);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbApteka7B);
            this.groupBox3.Controls.Add(this.tbApteka48);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(457, 235);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(517, 213);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Распределение по пунктам";
            // 
            // tbApteka7B
            // 
            this.tbApteka7B.Location = new System.Drawing.Point(82, 65);
            this.tbApteka7B.Name = "tbApteka7B";
            this.tbApteka7B.Size = new System.Drawing.Size(80, 20);
            this.tbApteka7B.TabIndex = 34;
            this.tbApteka7B.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbApteka7B_KeyDown);
            this.tbApteka7B.Validating += new System.ComponentModel.CancelEventHandler(this.tbApteka7B_Validating);
            // 
            // tbApteka48
            // 
            this.tbApteka48.Location = new System.Drawing.Point(81, 35);
            this.tbApteka48.Name = "tbApteka48";
            this.tbApteka48.Size = new System.Drawing.Size(81, 20);
            this.tbApteka48.TabIndex = 33;
            this.tbApteka48.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbApteka48_KeyDown);
            this.tbApteka48.Validating += new System.ComponentModel.CancelEventHandler(this.tbApteka48_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Аптека 7В";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Аптека 48";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(12, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 213);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация о поступлении";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(433, 194);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbExpirationDate);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.tbSeries);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.tbLocalPrice);
            this.tabPage1.Controls.Add(this.tbExtraPercent);
            this.tabPage1.Controls.Add(this.tbSupplierPrice);
            this.tabPage1.Controls.Add(this.tbAmount);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(425, 168);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Обычный";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbExpirationDate
            // 
            this.tbExpirationDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainStoreInsertRowBindingSource, "ExpirationDate", true));
            this.tbExpirationDate.Location = new System.Drawing.Point(303, 18);
            this.tbExpirationDate.Name = "tbExpirationDate";
            this.tbExpirationDate.Size = new System.Drawing.Size(107, 20);
            this.tbExpirationDate.TabIndex = 35;
            this.tbExpirationDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbExpirationDate_KeyDown);
            this.tbExpirationDate.Validating += new System.ComponentModel.CancelEventHandler(this.tbExpirationDate_Validating);
            // 
            // mainStoreInsertRowBindingSource
            // 
            this.mainStoreInsertRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.MainStoreInsertRow);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(213, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Срок годности:";
            // 
            // tbSeries
            // 
            this.tbSeries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainStoreInsertRowBindingSource, "Series", true));
            this.tbSeries.Location = new System.Drawing.Point(303, 45);
            this.tbSeries.Name = "tbSeries";
            this.tbSeries.Size = new System.Drawing.Size(107, 20);
            this.tbSeries.TabIndex = 32;
            this.tbSeries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSeries_KeyDown);
            this.tbSeries.Validating += new System.ComponentModel.CancelEventHandler(this.tbSeries_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Серия:";
            // 
            // tbLocalPrice
            // 
            this.tbLocalPrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainStoreInsertRowBindingSource, "LocalPrice", true));
            this.tbLocalPrice.Location = new System.Drawing.Point(97, 144);
            this.tbLocalPrice.Name = "tbLocalPrice";
            this.tbLocalPrice.Size = new System.Drawing.Size(94, 20);
            this.tbLocalPrice.TabIndex = 30;
            // 
            // tbExtraPercent
            // 
            this.tbExtraPercent.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainStoreInsertRowBindingSource, "Extra", true));
            this.tbExtraPercent.Location = new System.Drawing.Point(97, 102);
            this.tbExtraPercent.Name = "tbExtraPercent";
            this.tbExtraPercent.Size = new System.Drawing.Size(94, 20);
            this.tbExtraPercent.TabIndex = 29;
            // 
            // tbSupplierPrice
            // 
            this.tbSupplierPrice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainStoreInsertRowBindingSource, "SupplierPrice", true));
            this.tbSupplierPrice.Location = new System.Drawing.Point(97, 60);
            this.tbSupplierPrice.Name = "tbSupplierPrice";
            this.tbSupplierPrice.Size = new System.Drawing.Size(94, 20);
            this.tbSupplierPrice.TabIndex = 28;
            this.tbSupplierPrice.TextChanged += new System.EventHandler(this.tbSupplierPrice_TextChanged);
            this.tbSupplierPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSupplierPrice_KeyDown);
            this.tbSupplierPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSupplierPrice_KeyPress);
            this.tbSupplierPrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbSupplierPrice_Validating);
            // 
            // tbAmount
            // 
            this.tbAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainStoreInsertRowBindingSource, "Amount", true));
            this.tbAmount.Location = new System.Drawing.Point(97, 18);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(94, 20);
            this.tbAmount.TabIndex = 27;
            this.tbAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbAmount_KeyDown);
            this.tbAmount.Validating += new System.ComponentModel.CancelEventHandler(this.tbAmount_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Отпускная цена:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Наценка:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Цена закупки:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Количество:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(425, 168);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "От цены производителя";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbCountry);
            this.groupBox1.Controls.Add(this.tbDivider);
            this.groupBox1.Controls.Add(this.tbPackageName);
            this.groupBox1.Controls.Add(this.tbProductName);
            this.groupBox1.Controls.Add(this.tbEAN13);
            this.groupBox1.Controls.Add(this.btnChooseProduct);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(963, 217);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Наименование товара";
            // 
            // tbCountry
            // 
            this.tbCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCountry.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fullProductInfoBindingSource, "CountryProducer", true));
            this.tbCountry.Location = new System.Drawing.Point(83, 143);
            this.tbCountry.Name = "tbCountry";
            this.tbCountry.Size = new System.Drawing.Size(874, 20);
            this.tbCountry.TabIndex = 14;
            // 
            // fullProductInfoBindingSource
            // 
            this.fullProductInfoBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.FullProductInfo);
            // 
            // tbDivider
            // 
            this.tbDivider.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDivider.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fullProductInfoBindingSource, "Divider", true));
            this.tbDivider.Location = new System.Drawing.Point(83, 113);
            this.tbDivider.Name = "tbDivider";
            this.tbDivider.Size = new System.Drawing.Size(378, 20);
            this.tbDivider.TabIndex = 13;
            // 
            // tbPackageName
            // 
            this.tbPackageName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fullProductInfoBindingSource, "PackageName", true));
            this.tbPackageName.Location = new System.Drawing.Point(83, 83);
            this.tbPackageName.Name = "tbPackageName";
            this.tbPackageName.Size = new System.Drawing.Size(548, 20);
            this.tbPackageName.TabIndex = 12;
            // 
            // tbProductName
            // 
            this.tbProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProductName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fullProductInfoBindingSource, "ProductName", true));
            this.tbProductName.Location = new System.Drawing.Point(83, 53);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(874, 20);
            this.tbProductName.TabIndex = 11;
            // 
            // tbEAN13
            // 
            this.tbEAN13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEAN13.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fullProductInfoBindingSource, "EAN13", true));
            this.tbEAN13.Location = new System.Drawing.Point(83, 23);
            this.tbEAN13.Name = "tbEAN13";
            this.tbEAN13.Size = new System.Drawing.Size(874, 20);
            this.tbEAN13.TabIndex = 10;
            // 
            // btnChooseProduct
            // 
            this.btnChooseProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseProduct.Location = new System.Drawing.Point(882, 188);
            this.btnChooseProduct.Name = "btnChooseProduct";
            this.btnChooseProduct.Size = new System.Drawing.Size(75, 23);
            this.btnChooseProduct.TabIndex = 9;
            this.btnChooseProduct.Text = "Выбрать";
            this.btnChooseProduct.UseVisualStyleBackColor = true;
            this.btnChooseProduct.Click += new System.EventHandler(this.btnChooseProduct_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Страна:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Делитель:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Штрих-код:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Фасовка:";
            // 
            // ucProductSupplies1
            // 
            this.ucProductSupplies1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucProductSupplies1.Location = new System.Drawing.Point(0, 0);
            this.ucProductSupplies1.Name = "ucProductSupplies1";
            this.ucProductSupplies1.Size = new System.Drawing.Size(987, 209);
            this.ucProductSupplies1.TabIndex = 0;
            // 
            // frmMainStoreInsertNewPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 694);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "frmMainStoreInsertNewPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новая позиция";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmMainStoreInsertNewPosition_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMainStoreInsertNewPosition_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainStoreInsertRowBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullProductInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource fullProductInfoBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCountry;
        private System.Windows.Forms.TextBox tbDivider;
        private System.Windows.Forms.TextBox tbPackageName;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.TextBox tbEAN13;
        private System.Windows.Forms.Button btnChooseProduct;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Apteka.Plus.UserControls.ucProductSupplies ucProductSupplies1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbSeries;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbLocalPrice;
        private System.Windows.Forms.TextBox tbExtraPercent;
        private System.Windows.Forms.TextBox tbSupplierPrice;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.BindingSource mainStoreInsertRowBindingSource;
        private System.Windows.Forms.TextBox tbApteka7B;
        private System.Windows.Forms.TextBox tbApteka48;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbExpirationDate;
    }
}