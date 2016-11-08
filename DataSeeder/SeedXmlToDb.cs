namespace DataSeeder
{
    using System.Collections.Generic;
    using Data;

    public static class SeedXmlToDb
    {
        public static void SeedSales(TuxedoDb db, IEnumerable<Sale> salesList)
        {
            foreach (var sale in salesList)
            {
                db.Sales.Add(new Sale()
                {
                    Id = sale.Id,
                    StoreName = sale.StoreName,
                    TurnOver = sale.TurnOver
                });
            }

            db.SaveChanges();
        }
    }
}
