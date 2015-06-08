namespace Dota2.WebApp.Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Data.Entity;

    public class ApplicationUser : IdentityUser {}

    public class Dota2Db : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogEntry> BlogEntries { get; set; } 
        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Blog>().Property( b => b.Id ).GenerateValueOnAdd();
            

            base.OnModelCreating( modelBuilder );
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            base.OnConfiguring( optionsBuilder );
        }
    }

    public class Blog
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }

        public virtual ICollection<BlogEntry> Entries { get; set; }
    }

    public class BlogEntry
    {
        public virtual int Id { get; set; }
        public virtual Guid BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
