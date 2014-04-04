using FullStopDotNet2014.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FullStopDotNet2014.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FullStopDotNet2014.Data.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.TextResources.AddOrUpdate(x => new {x.Name, x.Culture},
                new TextResource
                {
                    Culture = "en-US",
                    Name = "LoremIpsum",
                    Value = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in 
voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                });

            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole("adminstrator"));

        }
    }
}
