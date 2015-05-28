namespace Dota2.WebApp.Model
{
    using Microsoft.Data.Entity;

    public class Dota2Db : DbContext
    {
         public DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
        }
    }
}