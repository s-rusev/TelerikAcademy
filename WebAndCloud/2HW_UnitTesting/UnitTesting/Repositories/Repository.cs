using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private DbSet<T> set;

        public Repository(DbContext context)
        {
            this.context = context;
            set = context.Set<T>();
        }

        public T Add(T item)
        {
            set.Add(item);
            context.SaveChanges();
            return item;
        }

        public T Update(int id, T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var item = set.Find(id);
            set.Remove(item);
            context.SaveChanges();
        }

        public void Delete(T item)
        {
            set.Remove(item);
            context.SaveChanges();
        }

        public T Get(int id)
        {
            var item = set.Find(id);
            return item;
        }

        public IQueryable<T> All()
        {
            return set.AsQueryable();
        }
    }
}
