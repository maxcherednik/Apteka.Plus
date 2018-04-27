using System.IO;
using System.Linq;

namespace Apteka.Helpers
{
    public class DriveHelper
    {
        public static DriveInfo CheckDrive()
        {
            return DriveInfo.GetDrives().Where(driveInfo => driveInfo.IsReady)
                 .FirstOrDefault(driveInfo => driveInfo.VolumeLabel.ToLower() == "apteka");
        }
    }
}
