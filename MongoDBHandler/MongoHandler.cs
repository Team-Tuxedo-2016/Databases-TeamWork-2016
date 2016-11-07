using DataSeeder.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace MongoDBHandler
{
    public class MongoHandler
    {
        private const string conString = "mongodb://localhost:27017";
        private readonly IMongoDatabase dataBase;

        public MongoHandler(string dataBaseName)
        {
            this.dataBase = new MongoClient(conString).GetDatabase(dataBaseName);
        }

        private async Task<IList<T>> GetData<T>(string collectionName) where T : class
        {
            var collection = this.dataBase.GetCollection<BsonDocument>(collectionName);

            var result = (await collection.Find(new BsonDocument()).ToListAsync())
                .Select(bs => BsonSerializer.Deserialize<T>(bs)).ToList();

            return result;
        }

        public async Task TransferToMSSQL()
        {
            var contexSql = new TuxedoDb();

            var brands = (await this.GetData<Brand>("Brands")).ToList();
            var items = (await this.GetData<Item>("Items")).ToList();

            try
            {
                using (contexSql)
                {
                    foreach (var brand in brands)
                    {
                        contexSql.Brands.Add(brand);
                    }

                    foreach (var item in items)
                    {
                        contexSql.Items.Add(item);
                    }
                    contexSql.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
