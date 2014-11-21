namespace Apteka.Plus.Forms
{
    partial class frmCopyDataMenu
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbProcessInfo = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStartDataSync = new System.Windows.Forms.Button();
            this.cbMyStoresNet = new System.Windows.Forms.ComboBox();
            this.lblChooseSatelite = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbMyStoresMS = new System.Windows.Forms.ComboBox();
            this.lblSatelites = new System.Windows.Forms.Label();
            this.btnCopyFromSatelitesToBase = new System.Windows.Forms.Button();
            this.btnCopyFromBaseToSatelites = new System.Windows.Forms.Button();
            this.bgwSyncData = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(414, 261);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbProcessInfo);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.btnStartDataSync);
            this.tabPage2.Controls.Add(this.cbMyStoresNet);
            this.tabPage2.Controls.Add(this.lblChooseSatelite);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(406, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Сеть";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbProcessInfo
            // 
            this.tbProcessInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbProcessInfo.Location = new System.Drawing.Point(11, 93);
            this.tbProcessInfo.Multiline = true;
            this.tbProcessInfo.Name = "tbProcessInfo";
            this.tbProcessInfo.Size = new System.Drawing.Size(384, 129);
            this.tbProcessInfo.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 60);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(384, 18);
            this.progressBar1.TabIndex = 7;
            // 
            // btnStartDataSync
            // 
            this.btnStartDataSync.Location = new System.Drawing.Point(291, 15);
            this.btnStartDataSync.Name = "btnStartDataSync";
            this.btnStartDataSync.Size = new System.Drawing.Size(104, 21);
            this.btnStartDataSync.TabIndex = 6;
            this.btnStartDataSync.Text = "Обновить";
            this.btnStartDataSync.UseVisualStyleBackColor = true;
            this.btnStartDataSync.Click += new System.EventHandler(this.btnStartDataSync_Click);
            // 
            // cbMyStoresNet
            // 
            this.cbMyStoresNet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMyStoresNet.FormattingEnabled = true;
            this.cbMyStoresNet.Location = new System.Drawing.Point(105, 15);
            this.cbMyStoresNet.Name = "cbMyStoresNet";
            this.cbMyStoresNet.Size = new System.Drawing.Size(171, 21);
            this.cbMyStoresNet.TabIndex = 5;
            // 
            // lblChooseSatelite
            // 
            this.lblChooseSatelite.AutoSize = true;
            this.lblChooseSatelite.Location = new System.Drawing.Point(8, 18);
            this.lblChooseSatelite.Name = "lblChooseSatelite";
            this.lblChooseSatelite.Size = new System.Drawing.Size(91, 13);
            this.lblChooseSatelite.TabIndex = 4;
            this.lblChooseSatelite.Text = "Выберите пункт:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbMyStoresMS);
            this.tabPage1.Controls.Add(this.lblSatelites);
            this.tabPage1.Controls.Add(this.btnCopyFromSatelitesToBase);
            this.tabPage1.Controls.Add(this.btnCopyFromBaseToSatelites);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(406, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Мобильный носитель";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbMyStoresMS
            // 
            this.cbMyStoresMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMyStoresMS.FormattingEnabled = true;
            this.cbMyStoresMS.Location = new System.Drawing.Point(146, 13);
            this.cbMyStoresMS.Name = "cbMyStoresMS";
            this.cbMyStoresMS.Size = new System.Drawing.Size(171, 21);
            this.cbMyStoresMS.TabIndex = 3;
            // 
            // lblSatelites
            // 
            this.lblSatelites.AutoSize = true;
            this.lblSatelites.Location = new System.Drawing.Point(94, 16);
            this.lblSatelites.Name = "lblSatelites";
            this.lblSatelites.Size = new System.Drawing.Size(46, 13);
            this.lblSatelites.TabIndex = 2;
            this.lblSatelites.Text = "Аптека:";
            // 
            // btnCopyFromSatelitesToBase
            // 
            this.btnCopyFromSatelitesToBase.Location = new System.Drawing.Point(146, 117);
            this.btnCopyFromSatelitesToBase.Name = "btnCopyFromSatelitesToBase";
            this.btnCopyFromSatelitesToBase.Size = new System.Drawing.Size(171, 41);
            this.btnCopyFromSatelitesToBase.TabIndex = 1;
            this.btnCopyFromSatelitesToBase.Text = "Скопировать данные из пунктов";
            this.btnCopyFromSatelitesToBase.UseVisualStyleBackColor = true;
            this.btnCopyFromSatelitesToBase.Click += new System.EventHandler(this.btnCopyFromSatelitesToBase_Click);
            // 
            // btnCopyFromBaseToSatelites
            // 
            this.btnCopyFromBaseToSatelites.Location = new System.Drawing.Point(146, 60);
            this.btnCopyFromBaseToSatelites.Name = "btnCopyFromBaseToSatelites";
            this.btnCopyFromBaseToSatelites.Size = new System.Drawing.Size(171, 40);
            this.btnCopyFromBaseToSatelites.TabIndex = 0;
            this.btnCopyFromBaseToSatelites.Text = "Скопировать данные для пукнтов";
            this.btnCopyFromBaseToSatelites.UseVisualStyleBackColor = true;
            this.btnCopyFromBaseToSatelites.Click += new System.EventHandler(this.btnCopyFromBaseToSatelites_Click);
            // 
            // bgwSyncData
            // 
            this.bgwSyncData.WorkerReportsProgress = true;
            this.bgwSyncData.WorkerSupportsCancellation = true;
            this.bgwSyncData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSyncData_DoWork);
            this.bgwSyncData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSyncData_RunWorkerCompleted);
            this.bgwSyncData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwSyncData_ProgressChanged);
            // 
            // frmCopyDataMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 261);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopyDataMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Копирование данных";
            this.Load += new System.EventHandler(this.frmCopyDataMenu_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCopyDataMenu_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblSatelites;
        private System.Windows.Forms.Button btnCopyFromSatelitesToBase;
        private System.Windows.Forms.Button btnCopyFromBaseToSatelites;
        private System.Windows.Forms.ComboBox cbMyStoresMS;
        private System.Windows.Forms.ComboBox cbMyStoresNet;
        private System.Windows.Forms.Label lblChooseSatelite;
        private System.Windows.Forms.Button btnStartDataSync;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgwSyncData;
        private System.Windows.Forms.TextBox tbProcessInfo;
    }
}