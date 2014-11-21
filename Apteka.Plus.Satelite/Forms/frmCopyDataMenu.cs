using System;
using System.IO;
using System.ServiceModel;
using System.Windows.Forms;
using Apteka.Helpers;
using Apteka.Plus.Logic;
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

        private bool CopyDataFromStore(DriveInfo choosenDriveInfo)
        {
            string fileName = SateliteDataHelper.PrepareDataFromSateliteToBase();

            FileInfo fi = new FileInfo(fileName);
            fi.CopyTo(choosenDriveInfo.RootDirectory + "\\from" + Settings.Default.SateliteID + ".zip", true);
            return true;
        }

        private bool CopyDataToStore(DriveInfo choosenDriveInfo)
        {
            int SateliteID = int.Parse(Settings.Default.SateliteID);

            FileInfo newArchiveFile = new FileInfo(choosenDriveInfo.RootDirectory + "\\to" + SateliteID + ".zip");

            if (!newArchiveFile.Exists)
            {
                MessageBox.Show("Не удалось найти файл '" + newArchiveFile.Name + "' на носителе информации с меткой 'APTEKA'!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void MakeGenericCopy(Func<DriveInfo, bool> copyAction)
        {
            DriveInfo choosenDriveInfo = DriveHelper.CheckDrive();

            if (choosenDriveInfo == null)
            {
                MessageBox.Show("Не удалось найти носитель информации с меткой 'APTEKA'!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if(copyAction(choosenDriveInfo))
                    MessageBox.Show("Копирование успешно завершено!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}