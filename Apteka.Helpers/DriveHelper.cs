using System.IO;

namespace Apteka.Helpers
{
    public class DriveHelper
    {
        public static  DriveInfo CheckDrive()
        {
            DriveInfo[] driveInfos = DriveInfo.GetDrives();

            DriveInfo choosenDriveInfo = null;
            foreach (DriveInfo driveInfo in driveInfos)
            {
                if (driveInfo.IsReady)
                {
                    if (driveInfo.VolumeLabel.ToLower() == "apteka")
                    {
                        choosenDriveInfo = driveInfo;
                        break;
                    }
                }
            }

            return choosenDriveInfo;
        }
    }
}
