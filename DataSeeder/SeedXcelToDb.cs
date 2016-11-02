using DataSeeder.Data;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeeder
{
    public static class SeedXcelToDb
    {
        public static void SeedBrands(string excelFileName, TuxedoDb db)
        {
            using (db)
            {
                var connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\ExtractedExcelFiles\\tables\\{excelFileName}.xlsx; Extended Properties = \"Excel 12.0 Xml;HDR=YES\"";
                OleDbConnection connection = new OleDbConnection(connectionString);

                connection.Open();

                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string Id = reader.GetDouble(0).ToString();
                    var Name = (string)reader["Name"];

                    Console.WriteLine($@"Brand: {Name} with {Id} added to SQL db");

                    db.Brands.Add(new Brand()
                    {
                        ID = int.Parse(Id),
                        Name = Name
                    });
                }

                db.SaveChanges();
            }
        }

        public static void SeedColors(string excelFileName, TuxedoDb db)
        {
            //TODO: Implement
        }

        public static void SeedTypes(string excelFileName, TuxedoDb db)
        {
            //TODO: Implement
        }

        public static void SeedCountries(string excelFileName, TuxedoDb db)
        {
            //TODO: Implement
        }

        public static void SeedMaterials(string excelFileName, TuxedoDb db)
        {
            //TODO: Implement
        }

        public static void SeedItems(string excelFileName, TuxedoDb db)
        {
            //TODO: Implement
        }
    }
}
