using DataSeeder.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace PdfExporter
{
    public static class ExportPdfFile
    {
        public static void ExportItems(TuxedoDb db)
        {
            var pdfFileDestination = "../../../Catalogue.pdf";
            FileStream fs = new FileStream(pdfFileDestination, FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.AddHeader("","Catalogue of Suits");

            
            var heading = new Phrase("Catalogue of Suits");
            doc.Add(heading);

            var table = new PdfPTable(2);
            table.WidthPercentage = 80;
            
            var cellModel = new PdfPCell(new Phrase("Suit Model"));
            cellModel.BackgroundColor = BaseColor.CYAN;
            var cellPrice = new PdfPCell(new Phrase("Suit Price"));
            cellPrice.BackgroundColor = BaseColor.CYAN;

            table.AddCell(cellModel);
            table.AddCell(cellPrice);

            foreach (var item in db.Items)
            {
                table.AddCell(item.Model);
                table.AddCell(item.Price.ToString());
            }

            doc.Add(table);
            doc.Close();
        }
    }
}
