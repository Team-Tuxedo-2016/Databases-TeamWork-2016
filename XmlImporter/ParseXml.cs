namespace XmlImporter
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    public static class ParseXml
    {
        private const string RootElement = "Sales";
        private const string FileName = "../../../XmlToImport.xml";

        public static IEnumerable<TModel> Deserialize<TModel>()
        {
            if (!File.Exists(FileName))
            {
                throw new FileNotFoundException("File not found!", FileName);
            }

            var serializer = new XmlSerializer(typeof(List<TModel>), new XmlRootAttribute(RootElement));
            IEnumerable<TModel> result;
            using (var fs = new FileStream(FileName, FileMode.Open))
            {
                result = (IEnumerable<TModel>)serializer.Deserialize(fs);
            }

            return result;
        }
    }
}
