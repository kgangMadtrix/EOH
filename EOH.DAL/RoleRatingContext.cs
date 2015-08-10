using EOH.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOH.DAL
{
    public class RoleRatingContext:DbContext, EOH.DAL.IRoleRatingContext
    {
        static RoleRatingContext()
        {
            //stop Ef from creating the database by default
            Database.SetInitializer<RoleRatingContext>(null);
        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<IndentificationType> IndentificationTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Rate> Rates { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                   .HasMany<Employee>(s => s.Employees)
                   .WithMany(c => c.Roles)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("RoleId");
                       cs.MapRightKey("EmployeeId");
                       cs.ToTable("EmployeeRoles");
                   });

            base.OnModelCreating(modelBuilder);
        }
    }
}
