using System;
using System.IO;

namespace Apteka.Helpers
{
    public class FileCopyHelper
    {

        public static void FileRemotingUpload(Stream serverFileStream, string localFileName, Action<int> progress)
        {
            FileStream localFileStream = null;
            try
            {

                localFileStream = File.OpenRead(localFileName);
                if (progress != null)
                {
                    progress(0);
                }

                byte[] data = new byte[10240]; //10 Kb
                int b = localFileStream.Read(data, 0, data.Length);
                long curValue = b;

                while (b != 0)
                {
                    serverFileStream.Write(data, 0, b);
                    if (progress != null)
                    {
                        int curPercent = (int)(curValue * 100 / localFileStream.Length);
                        if (curPercent > 100)
                            curPercent = 100;
                        progress(curPercent);
                        //System.Threading.Thread.Sleep(3000);
                    }
                    curValue += b;

                    b = localFileStream.Read(data, 0, data.Length);
                }

                if (progress != null)
                {
                    progress(0);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                serverFileStream.Close();
                localFileStream.Close();
            }
        }

        public static void FileRemotingDownload(Stream serverFileStream, string localFileName, Action<int> progress)
        {
            FileStream localFileStream = null;
            try
            {

                localFileStream = File.OpenWrite(localFileName);

                if (progress != null)
                {
                    progress(0);
                }

                byte[] data = new byte[10240]; //10 Kb                
                int b = serverFileStream.Read(data, 0, data.Length);
                long curValue = b;

                while (b != 0)
                {
                    localFileStream.Write(data, 0, b);
                    if (progress != null)
                    {
                        int curPercent = (int)(curValue * 100 / localFileStream.Length);
                        if (curPercent > 100)
                            curPercent = 100;
                        progress(curPercent);
                    }
                    curValue += b;
                    b = serverFileStream.Read(data, 0, data.Length);
                }

                if (progress != null)
                {
                    progress(0);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                serverFileStream.Close();
                localFileStream.Close();
            }
        }

    }
}
