using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyEShop.Core.Models; 

namespace MyEShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Comit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory p)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(x => x.Id == p.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = p;
            }
            else
            {
                throw new Exception("Product Category not found !");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productCategories.Find(x => x.Id == Id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product Category not found !");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable<ProductCategory>();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(x => x.Id == Id);
            if (productCategoryToUpdate != null)
            {
                productCategories.Remove(productCategoryToUpdate);
            }
            else
            {
                throw new Exception("Product Category not found, !");
            }
        }


    }
}
