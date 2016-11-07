using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using DataSeeder.Data;

namespace ExcellExporter
{
    public class ExportExcel
    {
        private const string ReportFileInUse =
                    "A new report failed to be created. Make sure you have closed the current last report file before generating a new or choose where to save it.";
        private const string CreatedSuccesfully = "Excel report created at: ";


        public static string Export(TuxedoDb db)
        {
            var xlApp = new Application();
            string executionMessage = CreatedSuccesfully;
            bool reportSuccesfull = true;

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

            var fileLocation = GenerateFileLocation("reports.xls");

            try
            {
                xlWorkBook.SaveAs(fileLocation, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            catch (COMException)
            {
                executionMessage = ReportFileInUse;
                reportSuccesfull = false;
            }

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            if (reportSuccesfull)
            {
                executionMessage = executionMessage + fileLocation;
            }

            return executionMessage;
        }

        private static string GenerateFileLocation(string fileName)
        {
            var directory = Directory.GetCurrentDirectory();
            directory = directory.Replace(@"\StartUpWPF\bin\Debug", "");

            var filePath = directory + "/" + fileName;

            return filePath;
        }
    }
}
