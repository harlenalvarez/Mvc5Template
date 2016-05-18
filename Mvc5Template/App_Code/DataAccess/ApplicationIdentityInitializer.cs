using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mvc5Template.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc5Template.App_Code.DataAccess
{
    public class ApplicationIdentityInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        
        
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeUsersAndRoles(context);
            base.Seed(context);
        }

        private static void InitializeUsersAndRoles(ApplicationDbContext context)
        {
            if(!context.Roles.Any())
            {
                var rs = new RoleStore<IdentityRole>(context);
                var rm = new RoleManager<IdentityRole>(rs);
                var role = new IdentityRole("Admin");
                var userRole = new IdentityRole("User");
                rm.Create(role);
                rm.Create(userRole);
            }
            if (!context.Users.Any())
            {
                var us = new UserStore<ApplicationUser>(context);
                var um = new UserManager<ApplicationUser>(us);
                var adminUser = new ApplicationUser
                {
                    UserName = "harlenalvarez@gmail.com",
                    PhoneNumber = "813-555-5555",
                    Email = "harlenalvarez@gmail.com"

                };

                um.Create(adminUser, @"!@34QWer");
                um.SetLockoutEnabled(adminUser.Id, true);
                um.AddToRole(adminUser.Id, "Admin");
            }
        }

       
    }
}