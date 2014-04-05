using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using FullStopDotNet2014.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FullStopDotNet2014.Data.Migrations
{
    internal sealed class DataSeeder
    {
        public static void CreateAdminUserAndRole(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create Admin Role
            const string roleName = "adminstrator";

            // Check to see if Role Exists, if not create it
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
            const string userName = "Admin";
            var user = userManager.FindByName(userName);
            if (user != null) return;
            user = new ApplicationUser {UserName = userName};
            const string password = "FSN-OWC-2014";
            var createUserResult = userManager.Create(user, password);

            //Add User Admin to Role Admin
            if (createUserResult.Succeeded)
            {
                userManager.AddToRole(user.Id, roleName);
            }
        }

        public static void CreateInitialTextResources(ApplicationDbContext context)
        {
            var textResource = new TextResource
            {
                Culture = "en-US",
                Name = "LoremIpsum",
                Value =
                    @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in 
voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            };
            AddDataIfNew(context, textResource, x => x.Name == textResource.Name && x.Culture == textResource.Culture);
        }

        private static void AddDataIfNew<T>(DbContext context, T data, Expression<Func<T, bool>> keyExpression) where T : class
        {
            var dbSet = context.Set<T>();
            if (dbSet.Any(keyExpression))
            {
                return;
            }
            dbSet.Add(data);
        }
    }
}