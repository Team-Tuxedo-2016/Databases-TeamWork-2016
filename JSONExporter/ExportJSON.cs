using DataSeeder.Data;
using Newtonsoft.Json;
using System.IO;
using System.Linq;


namespace JSONExporter
{
    public static class ExportJSON
    {
        public static void MadeInBulgaria(TuxedoDb db)
        {
            var filePath = "../../../MadeIn.json";
            var countryName = "Bulgaria";
            var countryId = db.Countries.Where(name => name.Name == countryName).Select(i=>i.ID).ToList()[0];

            var report = db.Items
                .Where(z => z.CountryID == countryId)
                .Select(x => new
                {
                    Brand = x.Brand.Name,
                    Model = x.Model,
                    Type = x.Type.Name,
                    Price = x.Price
                });

            using (var stream = new StreamWriter(filePath))
            {
                var json = JsonConvert.SerializeObject(report, Formatting.Indented);
                stream.Write(json);
            }
        }
    }
}
