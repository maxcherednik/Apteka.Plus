using System;
using System.IO;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic.BLL;
using Apteka.Plus.Satelite.Properties;

namespace Apteka.Plus.Satelite.Forms
{
    public partial class frmCopyDataMenu : Form
    {
        public frmCopyDataMenu()
        {
            InitializeComponent();
        }

        private void btnNewData_Click(object sender, EventArgs e)
        {
            MakeGenericCopy(CopyDataToStore);
        }

        private void btnCopyDataFromSatelite_Click(object sender, EventArgs e)
        {
            MakeGenericCopy(CopyDataFromStore);
        }

        private static bool CopyDataFromStore(DriveInfo choosenDriveInfo)
        {
            var fileName = SateliteDataHelper.PrepareDataFromSateliteToBase();

            var fi = new FileInfo(fileName);
            fi.CopyTo(choosenDriveInfo.RootDirectory + "\\from" + Settings.Default.SateliteID + ".zip", true);
            return true;
        }

        private bool CopyDataToStore(DriveInfo choosenDriveInfo)
        {
            var sateliteId = int.Parse(Settings.Default.SateliteID);

            var newArchiveFile = new FileInfo(choosenDriveInfo.RootDirectory + "\\to" + sateliteId + ".zip");

            if (!newArchiveFile.Exists)
            {
                MessageBox.Show($@"Не удалось найти файл '{newArchiveFile.Name}' на носителе информации с меткой 'APTEKA'!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            progressBar1.Style = ProgressBarStyle.Marquee;

            using (var fs = newArchiveFile.OpenRead())
            {
                SateliteDataHelper.InsertNewData(fs);
            }

            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = 0;
            return true;
        }

        private static void MakeGenericCopy(Func<DriveInfo, bool> copyAction)
        {
            var choosenDriveInfo = DriveHelper.CheckDrive();

            if (choosenDriveInfo == null)
            {
                MessageBox.Show(@"Не удалось найти носитель информации с меткой 'APTEKA'!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (copyAction(choosenDriveInfo))
                    MessageBox.Show(@"Копирование успешно завершено!", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}