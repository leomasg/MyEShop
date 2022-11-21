using MyEShop.Core.Contracts;
using MyEShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.WebUi.Tests.Mocks
{
    class MockContext<T> : IRepository<T> where T : BaseEntity
    {
        List<T> itens;
        string className;

        public MockContext()
        {
            itens = new List<T>();
        }

        public void Comit()
        {
            return;
        }

        public void Insert(T p)
        {
            itens.Add(p);
        }

        public void Update(T p)
        {
            T tToUpdate = itens.Find(x => x.Id == p.Id);
            if (tToUpdate != null)
            {
                tToUpdate = p;
            }
            else
            {
                throw new Exception(className + " not found !");
            }
        }

        public T Find(string Id)
        {
            T obj = itens.Find(x => x.Id == Id);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                throw new Exception(className + " not found !");
            }
        }

        public IQueryable<T> Collection()
        {
            return itens.AsQueryable<T>();
        }

        public void Delete(string Id)
        {
            T tToDelete = itens.Find(x => x.Id == Id);
            if (tToDelete != null)
            {
                itens.Remove(tToDelete);
            }
            else
            {
                throw new Exception(className + " not found !");
            }
        }

    }
}
