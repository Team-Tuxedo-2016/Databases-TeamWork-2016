using DataSeeder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeeder
{
    public static class SeedXmlToDb
    {
        public static void SeedSales(TuxedoDb db, IEnumerable<Sale> salesList)
        {
            foreach (var sale in salesList)
            {
                db.Sales.Add(new Sale()
                {
                    Id=sale.Id,
                    StoreName = sale.StoreName,
                    TurnOver = sale.TurnOver
                });
            }

            db.SaveChanges();
        }
    }
}
