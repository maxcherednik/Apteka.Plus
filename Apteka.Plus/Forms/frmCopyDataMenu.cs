using System;
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
using log4net;

namespace Apteka.Plus.Forms
{
    public partial class frmCopyDataMenu : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmCopyDataMenu()
        {
            InitializeComponent();
        }

        private void frmCopyDataMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner?.Show();
        }

        private void btnCopyFromBaseToSatelites_Click(object sender, EventArgs e)
        {
            MakeGenericCopy(CopyDataForMyStore);
        }

        private void btnCopyFromSatelitesToBase_Click(object sender, EventArgs e)
        {
            MakeGenericCopy(ProcessDataFromMyStore);
        }

        private static void CopyDataForMyStore(MyStore store, DriveInfo choosenDriveInfo)
        {
            var newArchiveFileName = SateliteDataHelper.PrepareDataForMyStore(store);

            var fi = new FileInfo(newArchiveFileName);
            fi.CopyTo(choosenDriveInfo.RootDirectory + "\\" + fi.Name, true);
        }

        private static void ProcessDataFromMyStore(MyStore store, DriveInfo choosenDriveInfo)
        {
            var fi = new FileInfo(choosenDriveInfo.RootDirectory + "\\from" + store.ID + ".zip");
            if (fi.Exists)
            {
                var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Download");
                if (!di.Exists)
                    di.Create();

                var localFile = fi.CopyTo(di.FullName + "\\" + Guid.NewGuid(), true);

                using (var fs = localFile.OpenRead())
                {
                    SateliteDataHelper.ProcessNewDataFromSatelite(store, fs);
                }
            }
        }

        private void frmCopyDataMenu_Load(object sender, EventArgs e)
        {
            IList<MyStore> liMyStores = MyStoresCollection.AllStores;

            cbMyStoresNet.ValueMember = "Id";
            cbMyStoresNet.DisplayMember = "Name";
            cbMyStoresNet.DataSource = liMyStores;

            var m = new MyStore
            {
                ID = 0,
                Name = "Все"
            };

            liMyStores.Insert(0, m);

            cbMyStoresMS.ValueMember = "Id";
            cbMyStoresMS.DisplayMember = "Name";
            cbMyStoresMS.DataSource = liMyStores;
        }

        private void MakeGenericCopy(Action<MyStore, DriveInfo> copyAction)
        {
            var choosenDriveInfo = DriveHelper.CheckDrive();

            if (choosenDriveInfo == null)
            {
                MessageBox.Show(@"Не удалось найти носитель информации с меткой 'APTEKA'!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var seletedMyStore = (MyStore)cbMyStoresMS.SelectedItem;

                if (seletedMyStore.ID == 0)
                {
                    for (var i = 1; i < cbMyStoresMS.Items.Count; i++)
                    {
                        copyAction((MyStore)cbMyStoresMS.Items[i], choosenDriveInfo);
                    }
                }
                else
                {
                    copyAction(seletedMyStore, choosenDriveInfo);
                }

                MessageBox.Show(@"Копирование успешно завершено!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnStartDataSync_Click(object sender, EventArgs e)
        {
            if (btnStartDataSync.Text != @"Отмена")
            {
                btnStartDataSync.Text = @"Отмена";
                bgwSyncData.RunWorkerAsync(cbMyStoresNet.SelectedItem);
            }
            else
            {
                btnStartDataSync.Enabled = false;
                bgwSyncData.CancelAsync();
            }
        }

        private void ChangeStyleMarquee()
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
        }

        private void ChangeStyleBlocks()
        {
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
        }

        private void bgwSyncData_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            var seletedMyStore = (MyStore)e.Argument;

            var overridedIp = UserSettings.GetOverridedIpById(seletedMyStore.ID);
            var resultIp = string.IsNullOrEmpty(overridedIp) ? seletedMyStore.IP : overridedIp;

            this.InvokeInGuiThread(() =>
            {
                ChangeStyleMarquee();
                tbProcessInfo.Text = @"1. Подготовка данных для копирования в пункт" + Environment.NewLine +
                    @"Компьютер: " + resultIp;
            });

            var newArchiveFileName = SateliteDataHelper.PrepareDataForMyStore(seletedMyStore);
            var archive = new FileInfo(newArchiveFileName);
            var size = archive.Length / 1024.0;

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            var size1 = size;
            this.InvokeInGuiThread(() =>
            {
                tbProcessInfo.Text = tbProcessInfo.Text + Environment.NewLine + @"2. Копирование данных в пункт. Размер архива " + size1.ToString("0.0 kb");
                ChangeStyleBlocks();
            });

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            this.InvokeInGuiThread(() =>
            {
                ChangeStyleMarquee();
                tbProcessInfo.Text = tbProcessInfo.Text + Environment.NewLine + @"3. Обработка данных в пункте";
            });

            var fact = new ChannelFactory<ISatelite>("SateliteServer");
            var endpoint = new EndpointAddress("net.tcp://" + resultIp + "/SateliteServer");
            fact.Endpoint.Address = endpoint;
            var satelite = fact.CreateChannel();

            using (var fs = archive.OpenRead())
            {
                var data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                satelite.InsertNewData(seletedMyStore.ID, data);
            }

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Download");
            if (!di.Exists)
                di.Create();

            var dataFromSatelite = satelite.GetSateliteData(seletedMyStore.ID);
            var fsSateliteData = new MemoryStream(dataFromSatelite);

            size = fsSateliteData.Length / 1024.0;

            this.InvokeInGuiThread(() =>
            {
                ChangeStyleBlocks();
                tbProcessInfo.Text = tbProcessInfo.Text + Environment.NewLine + @"4. Копирование данных из пункта. Размер архива " + size.ToString("0.0 kb");
            });

            if (worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            this.InvokeInGuiThread(() =>
            {
                ChangeStyleMarquee();
                tbProcessInfo.Text = tbProcessInfo.Text + Environment.NewLine + @"5. Обработка данных из пункта";
            });

            SateliteDataHelper.ProcessNewDataFromSatelite(seletedMyStore, fsSateliteData);

            this.InvokeInGuiThread(ChangeStyleBlocks);
        }

        private void bgwSyncData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwSyncData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 0;
            btnStartDataSync.Text = @"Старт";
            btnStartDataSync.Enabled = true;

            if (e.Error != null)
            {
                Log.Error(e.Error.Message, e.Error);
                MessageBox.Show(e.Error.Message, @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show(@"Копирование отменено!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show(@"Копирование успешно завершено!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}