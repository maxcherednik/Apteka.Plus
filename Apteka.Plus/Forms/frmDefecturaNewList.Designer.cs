namespace Apteka.Plus.Forms
{
    partial class frmDefecturaNewList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.chkbIsSmartList = new System.Windows.Forms.CheckBox();
            this.gbCriteriaManager = new System.Windows.Forms.GroupBox();
            this.btnAddCriteria = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbSearchValue = new System.Windows.Forms.TextBox();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.fieldNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.defectListCriteriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelList = new System.Windows.Forms.Button();
            this.gbCriteriaManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defectListCriteriaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(467, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(467, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Название:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(78, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(263, 20);
            this.tbName.TabIndex = 0;
            // 
            // chkbIsSmartList
            // 
            this.chkbIsSmartList.AutoSize = true;
            this.chkbIsSmartList.Location = new System.Drawing.Point(78, 45);
            this.chkbIsSmartList.Name = "chkbIsSmartList";
            this.chkbIsSmartList.Size = new System.Drawing.Size(98, 17);
            this.chkbIsSmartList.TabIndex = 13;
            this.chkbIsSmartList.Text = "умный список";
            this.chkbIsSmartList.UseVisualStyleBackColor = true;
            this.chkbIsSmartList.CheckedChanged += new System.EventHandler(this.chkbIsSmartList_CheckedChanged);
            // 
            // gbCriteriaManager
            // 
            this.gbCriteriaManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCriteriaManager.Controls.Add(this.btnAddCriteria);
            this.gbCriteriaManager.Controls.Add(this.label2);
            this.gbCriteriaManager.Controls.Add(this.dataGridView1);
            this.gbCriteriaManager.Controls.Add(this.tbSearchValue);
            this.gbCriteriaManager.Controls.Add(this.cboCriteria);
            this.gbCriteriaManager.Enabled = false;
            this.gbCriteriaManager.Location = new System.Drawing.Point(15, 68);
            this.gbCriteriaManager.Name = "gbCriteriaManager";
            this.gbCriteriaManager.Size = new System.Drawing.Size(421, 230);
            this.gbCriteriaManager.TabIndex = 14;
            this.gbCriteriaManager.TabStop = false;
            this.gbCriteriaManager.Text = "Условия поиска";
            // 
            // btnAddCriteria
            // 
            this.btnAddCriteria.Location = new System.Drawing.Point(338, 18);
            this.btnAddCriteria.Name = "btnAddCriteria";
            this.btnAddCriteria.Size = new System.Drawing.Size(75, 23);
            this.btnAddCriteria.TabIndex = 17;
            this.btnAddCriteria.Text = "Добавить";
            this.btnAddCriteria.UseVisualStyleBackColor = true;
            this.btnAddCriteria.Click += new System.EventHandler(this.btnAddCriteria_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "=";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldNameDataGridViewTextBoxColumn,
            this.searchValueDataGridViewTextBoxColumn,
            this.Action});
            this.dataGridView1.DataSource = this.defectListCriteriaBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(407, 177);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tbSearchValue
            // 
            this.tbSearchValue.Location = new System.Drawing.Point(208, 20);
            this.tbSearchValue.Name = "tbSearchValue";
            this.tbSearchValue.Size = new System.Drawing.Size(124, 20);
            this.tbSearchValue.TabIndex = 14;
            // 
            // cboCriteria
            // 
            this.cboCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriteria.FormattingEnabled = true;
            this.cboCriteria.Items.AddRange(new object[] {
            "Фирма"});
            this.cboCriteria.Location = new System.Drawing.Point(6, 19);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(177, 21);
            this.cboCriteria.TabIndex = 13;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewButtonColumn1.HeaderText = "Действие";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Text = "Удалить";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // fieldNameDataGridViewTextBoxColumn
            // 
            this.fieldNameDataGridViewTextBoxColumn.DataPropertyName = "FieldName";
            this.fieldNameDataGridViewTextBoxColumn.HeaderText = "Критерий";
            this.fieldNameDataGridViewTextBoxColumn.Name = "fieldNameDataGridViewTextBoxColumn";
            this.fieldNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // searchValueDataGridViewTextBoxColumn
            // 
            this.searchValueDataGridViewTextBoxColumn.DataPropertyName = "SearchValue";
            this.searchValueDataGridViewTextBoxColumn.HeaderText = "Значение";
            this.searchValueDataGridViewTextBoxColumn.Name = "searchValueDataGridViewTextBoxColumn";
            this.searchValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Action
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.Action.DefaultCellStyle = dataGridViewCellStyle6;
            this.Action.HeaderText = "Действие";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Action.Text = "Удалить";
            this.Action.UseColumnTextForButtonValue = true;
            // 
            // defectListCriteriaBindingSource
            // 
            this.defectListCriteriaBindingSource.DataSource = typeof(Apteka.Plus.Logic.BLL.Entities.DefectListCriteria);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FieldName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Критерий";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SearchValue";
            this.dataGridViewTextBoxColumn2.HeaderText = "Значение";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // btnDelList
            // 
            this.btnDelList.Location = new System.Drawing.Point(467, 275);
            this.btnDelList.Name = "btnDelList";
            this.btnDelList.Size = new System.Drawing.Size(75, 23);
            this.btnDelList.TabIndex = 15;
            this.btnDelList.Text = "Удалить";
            this.btnDelList.UseVisualStyleBackColor = true;
            this.btnDelList.Visible = false;
            this.btnDelList.Click += new System.EventHandler(this.btnDelList_Click);
            // 
            // frmDefecturaNewList
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(555, 313);
            this.Controls.Add(this.btnDelList);
            this.Controls.Add(this.gbCriteriaManager);
            this.Controls.Add(this.chkbIsSmartList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDefecturaNewList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание нового листа";
            this.Load += new System.EventHandler(this.frmDefecturaNewList_Load);
            this.gbCriteriaManager.ResumeLayout(false);
            this.gbCriteriaManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defectListCriteriaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.BindingSource defectListCriteriaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.CheckBox chkbIsSmartList;
        private System.Windows.Forms.GroupBox gbCriteriaManager;
        private System.Windows.Forms.Button btnAddCriteria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbSearchValue;
        private System.Windows.Forms.ComboBox cboCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn searchValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.Button btnDelList;
    }
}