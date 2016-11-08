namespace JSONExporter
{
    using System.IO;
    using System.Linq;
    using DataSeeder.Data;
    using Newtonsoft.Json;

    public static class ExportJSON
    {
        private const string CountryName = "Bulgaria";

        private static TuxedoDb db;

        static ExportJSON()
        {
            db = new TuxedoDb();
        }

        public static void ExportFile()
        {
            var id = 1;
            var path = "../../../JSON-Reports-MadeIN";

            Directory.CreateDirectory(path);

            var reports = ExportJSON.MadeInBulgaria();

            foreach (var report in reports)
            {
                var filePath = path + "/" + id + ".json";
                File.Create(filePath).Close();
                using (var stream = new StreamWriter(filePath))
                {
                    var json = JsonConvert.SerializeObject(report, Formatting.Indented);
                    stream.Write(json);
                }

                id++;
            }
        }

        private static IQueryable MadeInBulgaria()
        {
            var countryId = db.Countries.Where(name => name.Name == CountryName).Select(i => i.ID).ToList()[0];

            var report = db.Items
                .Where(z => z.CountryID == countryId)
                .Select(x => new
                {
                    Brand = x.Brand.Name,
                    Model = x.Model,
                    Type = x.Type.Name,
                    Price = x.Price
                });

            return report;
        }
    }
}
