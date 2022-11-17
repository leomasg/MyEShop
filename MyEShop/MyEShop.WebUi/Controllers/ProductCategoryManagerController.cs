using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEShop.DataAccess.InMemory;
using MyEShop.Core.Models;

namespace MyEShop.WebUi.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        //ProductCategoryRepository context;
        InMemoryRepository<ProductCategory> context;

        public ProductCategoryManagerController()
        {
            //this.context = new ProductCategoryRepository();
            this.context = new InMemoryRepository<ProductCategory>();
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory p)
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
            ProductCategory productCategory = context.Find(Id);

            if (productCategory == null)
            {
                return HttpNotFound("Produto Category " + Id + " não encontrado!");
            }
            else
            {
                return View(productCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory p, string Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound("Produto Category " + Id + " não encontrado!");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(p);
                }
                productCategoryToEdit.Category = p.Category;

                context.Comit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound("Produto Category " + Id + " não encontrado!");
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = context.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound("Produto Category " + Id + " não encontrado!");
            }
            else
            {
                context.Delete(Id);
                return RedirectToAction("Index");
            }
        }
    }
}