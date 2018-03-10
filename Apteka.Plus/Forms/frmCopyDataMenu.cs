﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.ServiceModel;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Logic.BLL.Collections;
using Apteka.Plus.Logic.BLL.Entities;
using Apteka.Plus.SettingsUtils;

namespace Apteka.Plus.Forms
{
    public partial class frmCopyDataMenu : Form
    {
        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmCopyDataMenu()
        {
            InitializeComponent();
        }

        private void frmCopyDataMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
                this.Owner.Show();
        }

        private void btnCopyFromBaseToSatelites_Click(object sender, EventArgs e)
        {
            MakeGenericCopy(CopyDataForMyStore);
        }

        private void btnCopyFromSatelitesToBase_Click(object sender, EventArgs e)
        {
            MakeGenericCopy(ProcessDataFromMyStore);
        }

        private void CopyDataForMyStore(MyStore store, DriveInfo choosenDriveInfo)
        {
            string newArchiveFileName = SateliteDataHelper.PrepareDataForMyStore(store);

            FileInfo fi = new FileInfo(newArchiveFileName);
            fi.CopyTo(choosenDriveInfo.RootDirectory + "\\" + fi.Name, true);
        }

        private void ProcessDataFromMyStore(MyStore store, DriveInfo choosenDriveInfo)
        {
            FileInfo fi = new FileInfo(choosenDriveInfo.RootDirectory + "\\from" + store.ID + ".zip");
            if (fi.Exists)
            {
                DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Download");
                if (!di.Exists)
                    di.Create();

                FileInfo localFile = fi.CopyTo(di.FullName + "\\" + Guid.NewGuid().ToString(), true);
                #region Process New Data From Satelite
                using (var fs = localFile.OpenRead())
                {
                    SateliteDataHelper.ProcessNewDataFromSatelite(store, fs);
                }
                #endregion
            }
        }

        #region Form Load
        private void frmCopyDataMenu_Load(object sender, EventArgs e)
        {

            IList<MyStore> liMyStores = MyStoresCollection.AllStores;

            cbMyStoresNet.ValueMember = "Id";
            cbMyStoresNet.DisplayMember = "Name";
            cbMyStoresNet.DataSource = liMyStores;

            MyStore m = new MyStore();
            m.ID = 0;
            m.Name = "Все";
            liMyStores.Insert(0, m);

            cbMyStoresMS.ValueMember = "Id";
            cbMyStoresMS.DisplayMember = "Name";
            cbMyStoresMS.DataSource = liMyStores;
        }

        #endregion


        private void MakeGenericCopy(Action<MyStore,DriveInfo> copyAction)
        {
            DriveInfo choosenDriveInfo = DriveHelper.CheckDrive();

            if (choosenDriveInfo == null)
            {
                MessageBox.Show("Не удалось найти носитель информации с меткой 'APTEKA'!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MyStore seletedMyStore = (MyStore)cbMyStoresMS.SelectedItem;

                if (seletedMyStore.ID == 0)
                {
                    for (int i = 1; i < cbMyStoresMS.Items.Count; i++)
                    {
                        copyAction((MyStore)cbMyStoresMS.Items[i], choosenDriveInfo);
                    }
                }
                else
                {
                    copyAction(seletedMyStore, choosenDriveInfo);
                }

                MessageBox.Show("Копирование успешно завершено!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnStartDataSync_Click(object sender, EventArgs e)
        {
            if (btnStartDataSync.Text != "Отмена")
            {

                btnStartDataSync.Text = "Отмена";
                bgwSyncData.RunWorkerAsync(cbMyStoresNet.SelectedItem);
            }
            else
            {
                btnStartDataSync.Enabled = false;
                bgwSyncData.CancelAsync();
            }

        }

        #region ProgressBar Style Change Functions

        private void ChangeStyleMarquee()
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
        }

        private void ChangeStyleBlocks()
        {
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
        }
        #endregion

        #region BackgroundWorker Sync Satelite
        private void bgwSyncData_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            MyStore seletedMyStore = (MyStore)e.Argument;

            string overridedIp = UserSettings.GetOverridedIpById(seletedMyStore.ID);
            var resultIp = string.IsNullOrEmpty(overridedIp) ? seletedMyStore.IP : overridedIp;

            this.InvokeInGUIThread(() =>
            {
                ChangeStyleMarquee();
                tbProcessInfo.Text = "1. Подготовка данных для копирования в пункт" + Environment.NewLine +
                    "Компьютер: " + resultIp;
            });

            #region Prepare Data For My Store
            string newArchiveFileName = SateliteDataHelper.PrepareDataForMyStore(seletedMyStore);
            #endregion
            FileInfo archive = new FileInfo(newArchiveFileName);
            double size = archive.Length / 1024.0;

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }

            #region Upload
            this.InvokeInGUIThread(() =>
            {
                tbProcessInfo.Text = tbProcessInfo.Text + System.Environment.NewLine + "2. Копирование данных в пункт. Размер архива " + size.ToString("0.0 kb");
                ChangeStyleBlocks();
            });

            #endregion

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }

            this.InvokeInGUIThread(() =>
            {
                ChangeStyleMarquee();
                tbProcessInfo.Text = tbProcessInfo.Text + System.Environment.NewLine + "3. Обработка данных в пункте";
            });

            #region Insert New Data To Satelite

            
            ChannelFactory<ISatelite> fact = new ChannelFactory<ISatelite>("SateliteServer");
            var endpoint = new EndpointAddress("net.tcp://" + resultIp + "/SateliteServer");
            fact.Endpoint.Address = endpoint;
            ISatelite satelite = fact.CreateChannel();

            using (FileStream fs = archive.OpenRead())
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                satelite.InsertNewData(seletedMyStore.ID, data);

            }

            #endregion

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }

            #region Download

            DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Download");
            if (!di.Exists)
                di.Create();

            byte[] dataFromSatelite = satelite.GetSateliteData(seletedMyStore.ID);
            MemoryStream fsSateliteData = new MemoryStream(dataFromSatelite);

            size = fsSateliteData.Length / 1024.0;

            this.InvokeInGUIThread(() =>
            {
                ChangeStyleBlocks();
                tbProcessInfo.Text = tbProcessInfo.Text + System.Environment.NewLine + "4. Копирование данных из пункта. Размер архива " + size.ToString("0.0 kb");
            });

            #endregion

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
                return;
            }

            this.InvokeInGUIThread(() =>
            {
                ChangeStyleMarquee();
                tbProcessInfo.Text = tbProcessInfo.Text + System.Environment.NewLine + "5. Обработка данных из пункта";
            });

            #region Process New Data From Satelite
            SateliteDataHelper.ProcessNewDataFromSatelite(seletedMyStore, fsSateliteData);
            #endregion

            this.InvokeInGUIThread(() =>
            {
                ChangeStyleBlocks();
            });

        }

        private void bgwSyncData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwSyncData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 0;
            btnStartDataSync.Text = "Старт";
            btnStartDataSync.Enabled = true;

            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                log.Error(e.Error.Message, e.Error);
                MessageBox.Show(e.Error.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Копирование отменено!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Копирование успешно завершено!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

    }
}