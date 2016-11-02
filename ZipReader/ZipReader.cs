using System;
using Ionic.Zip;
using System.IO;

namespace ZipReader
{
    public static class ZipReader
    {
        private const string extractFolder = "../../../ExtractedExcelFiles";

        public static void Read(string zipLocation)
        {
            using (var zip = ZipFile.Read(zipLocation))
            {
                var entries = zip.Entries;
                foreach (var entry in entries)
                {
                    if (File.Exists(extractFolder + $"/{entry.FileName}"))
                    {
                        break;
                    }

                    if (!entry.IsDirectory)
                    {
                            entry.Extract(extractFolder);
                            Console.WriteLine(entry.FileName + " Has been extracted");  
                    }
                }
            }
        }
    }
}
