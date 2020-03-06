namespace MCUWebAPPTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MCUWebAPPTest.Models.ClassesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MCUWebAPPTest.Models.ClassesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //DbContext dbContext = new DbContext();
            //House stark = new House("Stark", "Winter Is Coming", )
            //if(!dbConext.Houses.Contains("Stark")
            //{
            //      dbContext.Houses.Add(Stark)

        }
    }
}
