using System.Data.Entity;

namespace FitnessTracker.DAL.EF
{
    public class StoreDbInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext db)
        {
            /*var example1 = new Example
            {
                Name = "example1",
                Description = "description1"
            };

            var example2 = new Example
            {
                Name = "example2",
                Description = "description2"
            };

            db.Examples.AddRange(new List<Example> { example1, example2 });
            db.SaveChanges();*/
        }
    }
}
