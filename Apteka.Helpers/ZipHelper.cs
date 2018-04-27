﻿using ICSharpCode.SharpZipLib.Zip;
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
            var diDestination = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + Guid.NewGuid() + ".ext");
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
            var diDestination = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Temp\\" + Guid.NewGuid() + ".ext");
            Unzip(stream, diDestination);
        }

        public static void Unzip(Stream stream, DirectoryInfo destDirectory)
        {
            using (var s = new ZipInputStream(stream))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    var directoryName = Path.GetDirectoryName(theEntry.Name);
                    var fileName = Path.GetFileName(theEntry.Name);

                    // create directory
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    if (fileName != string.Empty)
                    {
                        using (var streamWriter = File.Create(destDirectory.FullName + "\\" + theEntry.Name))
                        {
                            var data = new byte[2048];
                            while (true)
                            {
                                var size = s.Read(data, 0, data.Length);
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
            var filenames = Directory.GetFiles(filePath);

            using (var s = new ZipOutputStream(File.Create(zipFileName)))
            {
                s.SetLevel(9); // 0 - store only to 9 - means best compression

                var buffer = new byte[4096];

                foreach (var file in filenames)
                {
                    // Using GetFileName makes the result compatible with XP
                    // as the resulting path is not absolute.
                    var entry = new ZipEntry(Path.GetFileName(file))
                    {
                        DateTime = DateTime.Now
                    };

                    s.PutNextEntry(entry);

                    using (var fs = File.OpenRead(file))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }

                s.Finish();
            }
        }
    }
}
