using System;
using System.Windows;
using DataSeeder;
using DataSeeder.Data;
using PdfExporter;
using XmlExporter;
using XmlImporter;
using JSONExporter;

namespace StartUpWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string createdMessage = "{0} data was transfered from Zip to SQL db";
        private const string databaseCreatedMessage = "{0} has been created localy to your PC";
        private const string importedMessage = "{0} were imported from {1} file";


        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowFormLoaded(object sender, RoutedEventArgs e)
        {

        }

        public void OnGetExcellFromZip(object sender, RoutedEventArgs e)
        {
            ZipReader.ZipReader.Read("../../../tables.zip");
            var db = new TuxedoDb();
            using (db)
            {
                SeedXcelToDb.SeedBrands("Brand", db);
                SeedXcelToDb.SeedColors("Color", db);
                SeedXcelToDb.SeedCountries("Countries", db);
                SeedXcelToDb.SeedMaterials("Materials", db);
                SeedXcelToDb.SeedTypes("Types", db);
                SeedXcelToDb.SeedItems("Items", db);
            }

            Console.WriteLine(createdMessage, "Excell");
        }

        public void OnGetJsonReportFromDb(object sender, RoutedEventArgs e)
        {
            ExportJSON.ExportFile();
            Console.WriteLine(createdMessage, "JSON");
        }

        public void OnGetXmlReportFromDb(object sender, RoutedEventArgs e)
        {
            var db = new TuxedoDb();
            ExportXmlFile.ExportTypes(db);
            Console.WriteLine(createdMessage, "XML");
        }

        public void OnGetPdfReportFromDb(object sender, RoutedEventArgs e)
        {
            var db = new TuxedoDb();
            ExportPdfFile.ExportItems(db);
            Console.WriteLine(createdMessage, "PDF");
        }

        public void OnGetExcellReportFromDb(object sender, RoutedEventArgs e)
        {
            //TODO: implement and call proper class instance or method
            Console.WriteLine(createdMessage, "Excell");
        }

        public void OnCreateDatabaseFromScript(object sender, RoutedEventArgs e)
        {
            CreateSqlDatatbase.CreateDb.ExecuteScript();
            Console.WriteLine(databaseCreatedMessage, "Db Tuxedo");
        }

        public void OnGetXmlAndLoadItToDb(object sender, RoutedEventArgs e)
        {
            var db = new TuxedoDb();
            var salesFromXml = ParseXml.Deserialize<Sale>();
            using (db)
            {
                SeedXmlToDb.SeedSales(db, salesFromXml);
            }

            Console.WriteLine(importedMessage, "Sales", "XML");
        }
    }
}
