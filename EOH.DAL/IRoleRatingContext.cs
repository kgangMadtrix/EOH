using EOH.Domain.Model;
using System;
using System.Data.Entity;
namespace EOH.DAL
{
    public interface IRoleRatingContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<IndentificationType> IndentificationTypes { get; set; }
        DbSet<Role> Roles { get; set; }

        DbSet<Rate> Rates { get; set; }

        int SaveChanges();
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object obj);
        System.Data.Entity.Database Database { get; }
    }
}
