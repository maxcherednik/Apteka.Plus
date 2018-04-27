using System;
using System.IO;
using Apteka.Plus.Logic;
using Apteka.Plus.Logic.BLL;

namespace Apteka.Plus.Satelite.Logic
{
    public class SateliteServer : ISatelite
    {
        public static int SateliteID = 0;

        public byte[] GetSateliteData(int sateliteID)
        {
            AssertCorrectStore(sateliteID);
            var fileName = SateliteDataHelper.PrepareDataFromSateliteToBase();

            var fi = new FileInfo(fileName);
            using (var fs = fi.OpenRead())
            {
                var data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                return data;
            }
        }

        public void InsertNewData(int sateliteID, byte[] file)
        {
            AssertCorrectStore(sateliteID);
            var ms = new MemoryStream(file);
            SateliteDataHelper.InsertNewData(ms);
        }

        private static void AssertCorrectStore(int sateliteId)
        {
            if (SateliteID != sateliteId)
                throw new Exception("Вы подсоединились не к тому пункту");
        }
    }
}
