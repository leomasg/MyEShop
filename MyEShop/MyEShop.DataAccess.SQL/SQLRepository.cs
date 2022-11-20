using MyEShop.Core.Contracts;
using MyEShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;
        string className;

        public SQLRepository(DataContext context)
        {
            className = typeof(T).Name;
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Comit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            var p = Find(Id);
            if (p != null)
            {
                if (context.Entry(p).State == EntityState.Detached)
                {
                    dbSet.Attach(p);
                }
                dbSet.Remove(p);
            }
            else
            {
                throw new Exception(className + " not found !");
            }
        }

        public T Find(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T p)
        {
            dbSet.Add(p);
        }

        public void Update(T p)
        {
            dbSet.Attach(p);
            context.Entry(p).State = EntityState.Modified;
        }
    }
}
