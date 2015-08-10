using EOH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOH.DAL.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T>, IDisposable where T : class
    {
        internal IRoleRatingContext Context { get; private set; }
        internal abstract DbSet<T> Table { get; }

        public RepositoryBase()
        {
            if(this.Context == null)
                this.Context = new RoleRatingContext();
        }

        public virtual IEnumerable<T> SelectAll()
        {
            return Table;
        }

        public virtual T SelectByID(int id)
        {
            return Table.Find(id);
        }

        public virtual void Insert(T obj)
        {
            Table.Add(obj);
        }

        public virtual void Update(T obj)
        {
            Table.Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            T existing = Table.Find(id);
            Table.Remove(existing);
        }

        public virtual void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Dispose()
        {

        }
    }
}
