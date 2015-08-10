namespace EOH.DAL.Migrations
{
    using EOH.DAL.Repositories;
    using EOH.Domain.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EOH.DAL.RoleRatingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EOH.DAL.RoleRatingContext context)
        {
            
            AddRates(context);
            AddRoleToService(context);
            AddIndetificationTypes(context);
            AddEmployee(context);
        }



        private void AddRates(RoleRatingContext context)
        {
            context.Rates.AddOrUpdate(a => a.Amount,
                new Rate {Amount = 250 },
                new Rate { Amount = 300 },
                new Rate { Amount = 350 },
                new Rate { Amount = 400 },
                new Rate { Amount = 450 },
                new Rate { Amount = 500 },
                new Rate { Amount = 550 },
                new Rate { Amount = 600 });
        }

        

        private void AddIndetificationTypes(RoleRatingContext context)
        {
            context.IndentificationTypes.AddOrUpdate(a => a.IndentificationTypeId,
                    new IndentificationType { Name = "SA ID", Description = "South Afrcan id number" });
        }

        private void AddRoleToService(RoleRatingContext context)
        {
            context.Roles.AddOrUpdate(a => a.RoleId,
                    new Role { RoleId = 1, Name = ".Net Developer", Description = "This is a software developer specializing in .net"},
                    new Role { RoleId = 2, Name = "Technical Team Lead", Description = "Technical Team Lead" },
                    new Role { RoleId = 3, Name = "Scrum Master", Description = "Scrum Master" },
                    new Role { RoleId = 4, Name = "Tester", Description = "Tester" },
                    new Role { RoleId = 5, Name = "Architect", Description = "Architect" },
                    new Role { RoleId = 6, Name = "Database Administrator", Description = "Database Administrator" },
                    new Role { RoleId = 7, Name = "SharePoint Developer", Description = "SharePoint Developer" },
                    new Role { RoleId = 8, Name = "BI Developer", Description = "BI Developer" });

            
            
        }

        private void AddEmployee(RoleRatingContext context)
        {
            context.Employees.AddOrUpdate(a => a.IdNumber,
                new Employee { IdNumber = "8409295849082", Name = "Kgang", Surname = "Moloke"});
            context.SaveChanges();

        }
    }
}
