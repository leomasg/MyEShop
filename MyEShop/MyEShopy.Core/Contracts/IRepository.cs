using MyEShop.Core.Models;
using System.Linq;

namespace MyEShop.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Comit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T p);
        void Update(T p);
    }
}