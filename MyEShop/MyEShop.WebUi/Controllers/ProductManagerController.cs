using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEShop.Core.Models;
using MyEShop.DataAccess.InMemory;


namespace MyEShop.WebUi.Controllers
{
    public class ProductManagerController : Controller
    {
        ProductRepository context;

        public ProductManagerController()
        {
            this.context = new ProductRepository();
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList<Product>();
            return View(products);
        }

        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            else 
            {
                context.Insert(p);
                context.Comit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);

            if (product == null)
            {
                return HttpNotFound("Produto " + Id + " não encontrado!");
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product p , string Id)
        {
            Product productToEdit = context.Find(Id);

            if (productToEdit == null)
            {
                return HttpNotFound("Produto " + Id + " não encontrado!");
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return View(p);
                }
                productToEdit.Category = p.Category;
                productToEdit.description = p.description;
                productToEdit.Name = p.Name;
                productToEdit.Price = p.Price;

                context.Comit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound("Produto " + Id + " não encontrado!");
            }
            else
            {
                return View(productToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound("Produto " + Id + " não encontrado!");
            }
            else
            {
                context.Delete(Id);
                return RedirectToAction("Index");
            }
        }


    }
}