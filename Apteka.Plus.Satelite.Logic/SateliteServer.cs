﻿using System;
using System.IO;
using Apteka.Plus.Logic;
using Apteka.Plus.Logic.BLL;
using log4net;

namespace Apteka.Plus.Satelite.Logic
{
    public class SateliteServer : ISatelite
    {
        public static int SateliteID = 0;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
    }
}
