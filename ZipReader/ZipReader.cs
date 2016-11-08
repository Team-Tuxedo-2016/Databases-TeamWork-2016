namespace ZipReader
{
    using System;
    using System.IO;
    using Ionic.Zip;

    public static class ZipReader
    {
        private const string ExtractFolder = "../../../ExtractedExcelFiles";

        public static void Read(string zipLocation)
        {
            using (var zip = ZipFile.Read(zipLocation))
            {
                var entries = zip.Entries;
                foreach (var entry in entries)
                {
                    if (File.Exists(ExtractFolder + $"/{entry.FileName}"))
                    {
                        break;
                    }

                    if (!entry.IsDirectory)
                    {
                            entry.Extract(ExtractFolder);
                            Console.WriteLine(entry.FileName + " Has been extracted");  
                    }
                }
            }
        }
    }
}
