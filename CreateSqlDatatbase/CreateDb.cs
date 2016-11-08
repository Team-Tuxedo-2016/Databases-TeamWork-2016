namespace CreateSqlDatatbase
{
    using DataSeeder.Data;

    public static class CreateDb
    {
        public static void ExecuteScript()
        {
            var db = new TuxedoDb();
            db.Database.CreateIfNotExists();
        }
    }
}
