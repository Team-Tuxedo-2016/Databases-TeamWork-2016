using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZipReader;
using DataSeeder;
using DataSeeder.Data;

namespace StartUpWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            SeedXcelToDb.SeedBrands("Brand", db);
            SeedXcelToDb.SeedColors("Color", db);
            SeedXcelToDb.SeedCountries("Brand", db);
            SeedXcelToDb.SeedMaterials("Materials", db);
            SeedXcelToDb.SeedTypes("Types", db);
            SeedXcelToDb.SeedItems("Items", db);

            Console.WriteLine("Excell data was transfered from Zip to SQL db");
        }

        public void OnGetJsonReportFromDb(object sender, RoutedEventArgs e)
        {
            //TODO: implement and call proper class instance or method
            Console.WriteLine("JSON report file was created from SQL db");
        }

        public void OnGetXmlReportFromDb(object sender, RoutedEventArgs e)
        {
            //TODO: implement and call proper class instance or method
            Console.WriteLine("XML report file was created from SQL db");
        }

        public void OnGetPdfReportFromDb(object sender, RoutedEventArgs e)
        {
            //TODO: implement and call proper class instance or method
            Console.WriteLine("Pdf report file was created from SQL db");
        }

        public void OnGetExcellReportFromDb(object sender, RoutedEventArgs e)
        {
            //TODO: implement and call proper class instance or method
            Console.WriteLine("EXCELL report file was created from SQL db");
        }

        public void OnCreateDatabaseFromScript(object sender, RoutedEventArgs e)
        {
            CreateSqlDatatbase.CreateDb.ExecuteScript();
            Console.WriteLine("Db Tuxedo has been created localy to your PC");
        }
    }
}
