using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using DataSeeder.Data;

namespace ExcellExporter
{
    public class ExportExcell
    {
        public static void Export(TuxedoDb db)
        {
            var xlApp = new Application();
            object misValue = System.Reflection.Missing.Value;

            var xlWorkBook = xlApp.Workbooks.Add(misValue);
            var xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.Item[1];

            xlWorkSheet.Cells[1, 1] = "Model";
            xlWorkSheet.Cells[1, 2] = "Brand";
            xlWorkSheet.Cells[1, 3] = "Color";
            xlWorkSheet.Cells[1, 4] = "Type";
            xlWorkSheet.Cells[1, 5] = "Material";
            xlWorkSheet.Cells[1, 6] = "Price";

            var row = 2;
            foreach (var item in db.Items)
            {
                xlWorkSheet.Cells[row, 1] = item.Model;
                xlWorkSheet.Cells[row, 2] = item.Brand.Name;
                xlWorkSheet.Cells[row, 3] = item.Color.Name;
                xlWorkSheet.Cells[row, 4] = item.Type.Name;
                xlWorkSheet.Cells[row, 5] = item.Material.Name;
                xlWorkSheet.Cells[row, 6] = $"{item.Price:C}";

                row++;
            }

            //TODO revert 3 directories back
            string currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory.Replace(@"StartUpWPF\bin\Debug", "");

            var fileLocation = currentDirectory + @"\reports.xls";

            xlWorkBook.SaveAs(fileLocation, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            //TODO Return as message
            Console.WriteLine($"Excel file created at {fileLocation}");
        }
    }
}
