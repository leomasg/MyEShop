﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyEShop.Core.Models;

namespace MyEShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        //Substituido pela classe InMemoryRepository

        //ObjectCache cache = MemoryCache.Default;
        //List<Product> products;

        //public ProductRepository()
        //{
        //    products = cache["products"] as List<Product>;
        //    if (products == null)
        //    {
        //        products = new List<Product>();
        //    }
        //}

        //public void Comit()
        //{
        //    cache["products"] = products;
        //}

        //public void Insert(Product p)
        //{
        //    products.Add(p);
        //}

        //public void Update(Product p )
        //{
        //    Product productToUpdate = products.Find(x => x.Id == p.Id);
        //    if (productToUpdate != null)
        //    {
        //        productToUpdate = p;
        //    }
        //    else
        //    {
        //        throw new Exception("Product not found !");
        //    }
        //}

        //public Product Find(string Id)
        //{
        //    Product product = products.Find(x => x.Id == Id);
        //    if (product != null)
        //    {
        //        return product;
        //    }
        //    else
        //    {
        //        throw new Exception("Product not found !");
        //    }
        //}

        //public IQueryable<Product> Collection()
        //{
        //    return products.AsQueryable<Product>();
        //}

        //public void Delete(string Id)
        //{
        //    Product productToUpdate = products.Find(x => x.Id == Id);
        //    if (productToUpdate != null)
        //    {
        //        products.Remove(productToUpdate);
        //    }
        //    else
        //    {
        //        throw new Exception("Product not found, !");
        //    }
        //}


    }
}
