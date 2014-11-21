using System;
using System.IO;
using Apteka.Helpers;
using Apteka.Plus.Logic;
using Apteka.Plus.Logic.BLL;

namespace Apteka.Plus.Satelite.Logic
{
    public class SateliteServer : ISatelite
    {
        public static int SateliteID = 0;

        private readonly static Logger log = new Logger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region ISatelite Members

        public byte[] GetSateliteData(int sateliteID)
        {
            CheckIfCorrectStore(sateliteID);
            string fileName = SateliteDataHelper.PrepareDataFromSateliteToBase();

            FileInfo fi = new FileInfo(fileName);
            using (var fs = fi.OpenRead())
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                return data;
            }

        }

        public void InsertNewData(int sateliteID, byte[] file)
        {
            CheckIfCorrectStore(sateliteID);
            MemoryStream ms = new MemoryStream(file);
            SateliteDataHelper.InsertNewData(ms);
        }

        private static void CheckIfCorrectStore(int sateliteID)
        {
            if (SateliteID != sateliteID)
                throw new Exception("Вы подсоединились не к тому пункту");
        }

        #endregion

    }
}
