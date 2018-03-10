namespace Apteka.Plus.UserControls
{
    partial class ucDefectTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsDefectlistMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDefectListOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteList = new System.Windows.Forms.ToolStripMenuItem();
            this.напомнитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.cbDateDefect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDelayedFilter = new System.Windows.Forms.ComboBox();
            this.dgvDefecturaList = new Apteka.Plus.Common.Controls.MyDataGridView();
            this.smartDefectRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemindAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dailyAverageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autoAmountToOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSupplyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAcepted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateLastSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManualAmountToOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDefectlistMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefecturaList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartDefectRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSearch.Location = new System.Drawing.Point(51, 10);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(186, 22);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Поиск:";
            // 
            // cmsDefectlistMenu
            // 
            this.cmsDefectlistMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDefectListOptions,
            this.tsmDeleteList,
            this.напомнитьToolStripMenuItem});
            this.cmsDefectlistMenu.Name = "cmsDefectlistMenu";
            this.cmsDefectlistMenu.Size = new System.Drawing.Size(143, 70);
            this.cmsDefectlistMenu.Text = "Удалить лист";
            this.cmsDefectlistMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsDefectlistMenu_ItemClicked);
            // 
            // tsmDefectListOptions
            // 
            this.tsmDefectListOptions.Name = "tsmDefectListOptions";
            this.tsmDefectListOptions.Size = new System.Drawing.Size(142, 22);
            this.tsmDefectListOptions.Text = "Параметры";
            // 
            // tsmDeleteList
            // 
            this.tsmDeleteList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsmDeleteList.Name = "tsmDeleteList";
            this.tsmDeleteList.Size = new System.Drawing.Size(142, 22);
            this.tsmDeleteList.Text = "Удалить";
            // 
            // напомнитьToolStripMenuItem
            // 
            this.напомнитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.напомнитьToolStripMenuItem.Name = "напомнитьToolStripMenuItem";
            this.напомнитьToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.напомнитьToolStripMenuItem.Text = "Напомнить";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 21);
            // 
            // cbDateDefect
            // 
            this.cbDateDefect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDateDefect.FormattingEnabled = true;
            this.cbDateDefect.Location = new System.Drawing.Point(364, 10);
            this.cbDateDefect.Name = "cbDateDefect";
            this.cbDateDefect.Size = new System.Drawing.Size(163, 21);
            this.cbDateDefect.TabIndex = 4;
            this.cbDateDefect.SelectedIndexChanged += new System.EventHandler(this.cbDateDefect_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Дата дефектуры:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Product";
            dataGridViewCellStyle1.NullValue = "0";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "Название";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Package";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn2.HeaderText = "Фасовка";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CurrentAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "Остаток";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DailyAverage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "Ср. продаваемость в день";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "AutoAmountToOrder";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn5.HeaderText = "Кол-во к заказу";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Supplier";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn6.HeaderText = "Поставщик";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "LastPrice";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn7.HeaderText = "Цена закупки";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DateSupply";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn8.HeaderText = "Дата закупки";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ManualAmountToOrder";
            dataGridViewCellStyle9.NullValue = "0";
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn9.HeaderText = "Заказ";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 94;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ManualAmountToOrder";
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn10.HeaderText = "Заказ";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 94;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ManualAmountToOrder";
            dataGridViewCellStyle11.Format = "d";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn11.HeaderText = "Заказ";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ManualAmountToOrder";
            this.dataGridViewTextBoxColumn12.HeaderText = "Заказ";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsProccessed";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Обработано";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DataPropertyName = "IsProccessed";
            this.dataGridViewButtonColumn1.HeaderText = "IsProccessed";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Фильтр:";
            // 
            // cbDelayedFilter
            // 
            this.cbDelayedFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDelayedFilter.FormattingEnabled = true;
            this.cbDelayedFilter.Items.AddRange(new object[] {
            "Без отложенных",
            "Отложенные",
            "Все"});
            this.cbDelayedFilter.Location = new System.Drawing.Point(634, 10);
            this.cbDelayedFilter.Name = "cbDelayedFilter";
            this.cbDelayedFilter.Size = new System.Drawing.Size(163, 21);
            this.cbDelayedFilter.TabIndex = 6;
            this.cbDelayedFilter.SelectedIndexChanged += new System.EventHandler(this.cbDelayedFilter_SelectedIndexChanged);
            // 
            // dgvDefecturaList
            // 
            this.dgvDefecturaList.AllowUserToAddRows = false;
            this.dgvDefecturaList.AllowUserToDeleteRows = false;
            this.dgvDefecturaList.AllowUserToResizeRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvDefecturaList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDefecturaList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDefecturaList.AutoGenerateColumns = false;
            this.dgvDefecturaList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefecturaList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.PackageName,
            this.currentAmountDataGridViewTextBoxColumn,
            this.RemindAt,
            this.dailyAverageDataGridViewTextBoxColumn,
            this.autoAmountToOrderDataGridViewTextBoxColumn,
            this.lastPriceDataGridViewTextBoxColumn,
            this.supplierDataGridViewTextBoxColumn,
            this.dateSupplyDataGridViewTextBoxColumn,
            this.DateAcepted,
            this.DateLastSale,
            this.ManualAmountToOrder});
            this.dgvDefecturaList.DataSource = this.smartDefectRowBindingSource;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDefecturaList.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvDefecturaList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDefecturaList.Location = new System.Drawing.Point(3, 36);
            this.dgvDefecturaList.Name = "dgvDefecturaList";
            this.dgvDefecturaList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDefecturaList.Size = new System.Drawing.Size(866, 451);
            this.dgvDefecturaList.TabIndex = 1;
            this.dgvDefecturaList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDefecturaList_MouseDown);
            this.dgvDefecturaList.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvDefecturaList_CellParsing);
            this.dgvDefecturaList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDefecturaList_CellFormatting);
            this.dgvDefecturaList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDefecturaList_CellValidating);
            this.dgvDefecturaList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvDefecturaList_MouseUp);
            this.dgvDefecturaList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDefecturaList_CellEndEdit);
            this.dgvDefecturaList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDefecturaList_CellMouseDoubleClick);
            this.dgvDefecturaList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDefecturaList_KeyDown);
            this.dgvDefecturaList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvDefecturaList_KeyPress);
            // 
            // smartDefectRowBindingSource
            // 
            this.smartDefectRowBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.SmartDefectRow);
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Название";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // PackageName
            // 
            this.PackageName.DataPropertyName = "PackageName";
            this.PackageName.HeaderText = "Фасовка";
            this.PackageName.Name = "PackageName";
            this.PackageName.ReadOnly = true;
            // 
            // currentAmountDataGridViewTextBoxColumn
            // 
            this.currentAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.currentAmountDataGridViewTextBoxColumn.DataPropertyName = "CurrentAmount";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.currentAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.currentAmountDataGridViewTextBoxColumn.HeaderText = "Остаток";
            this.currentAmountDataGridViewTextBoxColumn.Name = "currentAmountDataGridViewTextBoxColumn";
            this.currentAmountDataGridViewTextBoxColumn.Width = 74;
            // 
            // RemindAt
            // 
            this.RemindAt.DataPropertyName = "RemindAt";
            this.RemindAt.HeaderText = "Напоминание";
            this.RemindAt.Name = "RemindAt";
            // 
            // dailyAverageDataGridViewTextBoxColumn
            // 
            this.dailyAverageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dailyAverageDataGridViewTextBoxColumn.DataPropertyName = "DailyAverage";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dailyAverageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.dailyAverageDataGridViewTextBoxColumn.HeaderText = "Ср. продаваемость в день";
            this.dailyAverageDataGridViewTextBoxColumn.Name = "dailyAverageDataGridViewTextBoxColumn";
            this.dailyAverageDataGridViewTextBoxColumn.ReadOnly = true;
            this.dailyAverageDataGridViewTextBoxColumn.Width = 130;
            // 
            // autoAmountToOrderDataGridViewTextBoxColumn
            // 
            this.autoAmountToOrderDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.autoAmountToOrderDataGridViewTextBoxColumn.DataPropertyName = "AutoAmountToOrder";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.autoAmountToOrderDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.autoAmountToOrderDataGridViewTextBoxColumn.HeaderText = "Кол-во к заказу";
            this.autoAmountToOrderDataGridViewTextBoxColumn.Name = "autoAmountToOrderDataGridViewTextBoxColumn";
            this.autoAmountToOrderDataGridViewTextBoxColumn.ReadOnly = true;
            this.autoAmountToOrderDataGridViewTextBoxColumn.Width = 104;
            // 
            // lastPriceDataGridViewTextBoxColumn
            // 
            this.lastPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lastPriceDataGridViewTextBoxColumn.DataPropertyName = "LastPrice";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.lastPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.lastPriceDataGridViewTextBoxColumn.HeaderText = "Цена закупки";
            this.lastPriceDataGridViewTextBoxColumn.Name = "lastPriceDataGridViewTextBoxColumn";
            this.lastPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastPriceDataGridViewTextBoxColumn.Width = 94;
            // 
            // supplierDataGridViewTextBoxColumn
            // 
            this.supplierDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.supplierDataGridViewTextBoxColumn.DataPropertyName = "Supplier";
            this.supplierDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.supplierDataGridViewTextBoxColumn.Name = "supplierDataGridViewTextBoxColumn";
            this.supplierDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierDataGridViewTextBoxColumn.Width = 90;
            // 
            // dateSupplyDataGridViewTextBoxColumn
            // 
            this.dateSupplyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dateSupplyDataGridViewTextBoxColumn.DataPropertyName = "DateSupply";
            this.dateSupplyDataGridViewTextBoxColumn.HeaderText = "Дата закупки";
            this.dateSupplyDataGridViewTextBoxColumn.Name = "dateSupplyDataGridViewTextBoxColumn";
            this.dateSupplyDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateSupplyDataGridViewTextBoxColumn.Width = 94;
            // 
            // DateAcepted
            // 
            this.DateAcepted.DataPropertyName = "DateAccepted";
            dataGridViewCellStyle17.Format = "d";
            dataGridViewCellStyle17.NullValue = null;
            this.DateAcepted.DefaultCellStyle = dataGridViewCellStyle17;
            this.DateAcepted.HeaderText = "Дата дефектуры";
            this.DateAcepted.Name = "DateAcepted";
            this.DateAcepted.ReadOnly = true;
            this.DateAcepted.Visible = false;
            // 
            // DateLastSale
            // 
            this.DateLastSale.DataPropertyName = "DateLastSale";
            this.DateLastSale.HeaderText = "Дата последней продажи";
            this.DateLastSale.Name = "DateLastSale";
            this.DateLastSale.ReadOnly = true;
            // 
            // ManualAmountToOrder
            // 
            this.ManualAmountToOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ManualAmountToOrder.DataPropertyName = "ManualAmountToOrder";
            this.ManualAmountToOrder.HeaderText = "Заказ";
            this.ManualAmountToOrder.Name = "ManualAmountToOrder";
            // 
            // ucDefectTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbDelayedFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDateDefect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dgvDefecturaList);
            this.Name = "ucDefectTable";
            this.Size = new System.Drawing.Size(875, 490);
            this.cmsDefectlistMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefecturaList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartDefectRowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Apteka.Plus.Common.Controls.MyDataGridView dgvDefecturaList;
        private System.Windows.Forms.BindingSource smartDefectRowBindingSource;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.ContextMenuStrip cmsDefectlistMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmDefectListOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteList;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.ComboBox cbDateDefect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem напомнитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDelayedFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageName;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemindAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dailyAverageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn autoAmountToOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSupplyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAcepted;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateLastSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManualAmountToOrder;
    }
}
