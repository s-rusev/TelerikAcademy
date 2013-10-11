namespace Store.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Store.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Store.Data.StoreDataContext>
    {
        private const string AdministratorRole = "Administrator";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StoreDataContext context)
        {
            SeedAdministrator(context);

            if (context.Roles.FirstOrDefault() == null)
            {
                context.Database.ExecuteSqlCommand("ALTER TABLE Categories ADD UNIQUE (Name)");
            }

            var userRole = new Role("User");

            context.Roles.AddOrUpdate(x => x.Name, userRole);
        }

        private void SeedAdministrator(StoreDataContext context)
        {
            var hasAdminRole = context.Roles.Any(x => x.Name == AdministratorRole);
            if (!hasAdminRole)
            {
                var roleToAdd = new Role("Administrator");
                context.Roles.Add(roleToAdd);
                context.SaveChanges();
            }

            var adminRole = context.Roles.FirstOrDefault(x => x.Name == AdministratorRole);
            var userAdmin = new StoreUser()
            {
                UserName = "administrator",
                Email = "globaladmin@globals.glo",
                Logins = new Collection<UserLogin>()
                {
                    new UserLogin()
                    {
                        LoginProvider = "Local",
                        ProviderKey = "administrator",
                    }
                },
                Roles = new Collection<UserRole>()
                {
                    new UserRole()
                    {
                        Role=adminRole
                    }
                }
            };

            context.Users.AddOrUpdate(x => x.UserName, userAdmin);
            context.UserSecrets.AddOrUpdate(x => x.UserName, new UserSecret("administrator",
                "AGNf4FJ3UGKHbGrp317KbH+R2kTpLtAos6nxFqjpGoLb7EAHDtATmEz/UJdVpowKPg=="));//administrator
            context.SaveChanges();
        }
    }
}
