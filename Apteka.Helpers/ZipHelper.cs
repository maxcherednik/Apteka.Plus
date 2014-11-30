using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;

namespace Apteka.Helpers
{
    public class ZipHelper
    {
        public static void UnzipFile(string zipFileName)
        {
            Unzip(new FileInfo(zipFileName));
        }

        public static void Unzip(FileInfo file)
        {
            DirectoryInfo diDestination = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + Guid.NewGuid().ToString() + ".ext");
            Unzip(file, diDestination);
        }

        public static void Unzip(FileInfo file, DirectoryInfo destDirectory)
        {
            using (Stream fs = file.OpenRead())
            {
                Unzip(fs, destDirectory);
            }
        }

        public static void Unzip(Stream stream)
        {
            DirectoryInfo diDestination = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + Guid.NewGuid().ToString() + ".ext");
            Unzip(stream, diDestination);
        }

        public static void Unzip(Stream stream, DirectoryInfo destDirectory)
        {
            using (ZipInputStream s = new ZipInputStream(stream))
            {

                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {

                    string directoryName = Path.GetDirectoryName(theEntry.Name);
                    string fileName = Path.GetFileName(theEntry.Name);

                    // create directory
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    if (fileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(destDirectory.FullName + "\\" + theEntry.Name))
                        {

                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void ZipFile(string filePath, string zipFileName)
        {


            // Depending on the directory this could be very large and would require more attention
            // in a commercial package.
            string[] filenames = Directory.GetFiles(filePath);

            // 'using' statements gaurantee the stream is closed properly which is a big source
            // of problems otherwise.  Its exception safe as well which is great.
            using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFileName)))
            {

                s.SetLevel(9); // 0 - store only to 9 - means best compression

                byte[] buffer = new byte[4096];

                foreach (string file in filenames)
                {

                    // Using GetFileName makes the result compatible with XP
                    // as the resulting path is not absolute.
                    ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                    // Setup the entry data as required.

                    // Crc and size are handled by the library for seakable streams
                    // so no need to do them here.

                    // Could also use the last write time or similar for the file.
                    entry.DateTime = DateTime.Now;
                    s.PutNextEntry(entry);

                    using (FileStream fs = File.OpenRead(file))
                    {

                        // Using a fixed size buffer here makes no noticeable difference for output
                        // but keeps a lid on memory usage.
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }

                // Finish/Close arent needed strictly as the using statement does this automatically

                // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                // the created file would be invalid.
                s.Finish();
            }
        }
    }
}
