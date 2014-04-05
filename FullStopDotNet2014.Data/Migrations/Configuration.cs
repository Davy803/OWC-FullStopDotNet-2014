using System.Data.Entity.Migrations;

namespace FullStopDotNet2014.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FullStopDotNet2014.Data.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            DataSeeder.CreateInitialTextResources(context);
            DataSeeder.CreateAdminUserAndRole(context);
        }
    }
}