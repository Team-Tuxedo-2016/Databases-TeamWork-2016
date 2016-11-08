namespace DataSeeder
{
    using DataSeeder.Data;
    using System;
    using System.Data.OleDb;

    public static class SeedXcelToDb
    {
        public static void SeedBrands(string excelFileName, TuxedoDb db)
        {
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\ExtractedExcelFiles\\tables\\"+excelFileName+".xlsx; Extended Properties = \"Excel 12.0 Xml;HDR=YES\"";
            OleDbConnection connection = new OleDbConnection(connectionString);

            connection.Open();

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string Id = reader.GetDouble(0).ToString();
                var Name = (string)reader["Name"];

                Console.WriteLine($@"Brand: {Name} with ID {Id} added to SQL db");

                db.Brands.Add(new Brand()
                {
                    ID = int.Parse(Id),
                    Name = Name
                });
            }
        }

        public static void SeedColors(string excelFileName, TuxedoDb db)
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

                Console.WriteLine($@"Color: {Name} with ID {Id} added to SQL db");

                db.Colors.Add(new Color()
                {
                    ID = int.Parse(Id),
                    Name = Name
                });
            }
        }

        public static void SeedTypes(string excelFileName, TuxedoDb db)
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

                Console.WriteLine($@"Suit type: {Name} with ID {Id} added to SQL db");

                db.Types.Add(new DataSeeder.Data.Type()
                {
                    ID = int.Parse(Id),
                    Name = Name
                });
            }
        }

        public static void SeedCountries(string excelFileName, TuxedoDb db)
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

                Console.WriteLine($@"Country: {Name} with ID {Id} added to SQL db");

                db.Countries.Add(new Country()
                {
                    ID = int.Parse(Id),
                    Name = Name
                });
            }
        }

        public static void SeedMaterials(string excelFileName, TuxedoDb db)
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
                var CountryId = reader.GetDouble(2).ToString();

                Console.WriteLine($@"Material: {Name} with ID {Id} added to SQL db");

                db.Materials.Add(new Material()
                {
                    ID = int.Parse(Id),
                    Name = Name,
                    CountryID = int.Parse(CountryId)
                });
            }
        }

        public static void SeedItems(string excelFileName, TuxedoDb db)
        {
            var connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\ExtractedExcelFiles\\tables\\{excelFileName}.xlsx; Extended Properties = \"Excel 12.0 Xml;HDR=YES\"";
            OleDbConnection connection = new OleDbConnection(connectionString);

            connection.Open();

            OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string Id = reader.GetDouble(0).ToString();
                var model = (string)reader["Model"];
                var BrandId = reader.GetDouble(2).ToString();
                var CountryId = reader.GetDouble(3).ToString();
                var ColorId = reader.GetDouble(4).ToString();
                var TypeId = reader.GetDouble(5).ToString();
                var MaterialId = reader.GetDouble(6).ToString();
                var Price = reader.GetDouble(7).ToString();

                Console.WriteLine($@"Item: {model} with ID {Id} added to SQL db");

                db.Items.Add(new Item()
                {
                    ID = int.Parse(Id),
                    Model = model,
                    BrandID = int.Parse(BrandId),
                    CountryID = int.Parse(CountryId),
                    ColorID = int.Parse(ColorId),
                    TypeID = int.Parse(TypeId),
                    MaterialID = int.Parse(MaterialId),
                    Price = decimal.Parse(Price)
                });
            }

            db.SaveChanges();
        }
    }
}
