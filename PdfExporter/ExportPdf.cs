using DataSeeder.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq;

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

            var table = new PdfPTable(3);
            table.WidthPercentage = 80;
            
            var cellModel = new PdfPCell(new Phrase("Suit Model"));
            cellModel.BackgroundColor = BaseColor.CYAN;
            var cellPrice = new PdfPCell(new Phrase("Suit Price"));
            cellPrice.BackgroundColor = BaseColor.CYAN;
            var cellBrand = new PdfPCell(new Phrase("Suit Brand"));
            cellBrand.BackgroundColor = BaseColor.CYAN;

            table.AddCell(cellModel);
            table.AddCell(cellPrice);
            table.AddCell(cellBrand);

            foreach (var item in db.Items)
            {
                var brand = db.Brands
                    .Where(b => b.ID == item.BrandID)
                    .Select(br => br.Name)
                    .FirstOrDefault();

                table.AddCell(item.Model);
                table.AddCell(item.Price.ToString());
                table.AddCell(brand);
            }

            doc.Add(table);
            doc.Close();
        }
    }
}
