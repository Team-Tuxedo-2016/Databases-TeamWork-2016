using DataSeeder.Data;
using System.Text;
using System.Xml;

namespace XmlExporter
{
    public static class ExportXmlFile
    {
        public static void ExportTypes(TuxedoDb db)
        {
            string fileName = "../../../Types.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("types");

                foreach ( var type in db.Types)
                {
                    writer.WriteStartElement("type");
                    writer.WriteElementString("name", type.Name);
                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }
        }
    }
}
