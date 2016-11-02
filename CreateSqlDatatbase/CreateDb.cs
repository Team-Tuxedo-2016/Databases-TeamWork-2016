using DataSeeder.Data;

namespace CreateSqlDatatbase
{
    public static class CreateDb
    {
        public static void ExecuteScript()
        {
            var db = new TuxedoDb();
            db.Database.CreateIfNotExists();
        }
    }
}
