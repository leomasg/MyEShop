using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEShop.Core.Models;
using MyEShop.DataAccess.InMemory;
using MyEShop.Core.ViewModels;
using MyEShop.Core.Contracts;
using System.IO;

namespace MyEShop.WebUi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductManagerController : Controller
    {
        //ProductRepository context;
        //ProductCategoryRepository productCategories;

        //InMemoryRepository<Product> context;
        //InMemoryRepository<ProductCategory> productCategories;

        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        //public ProductManagerController()
        public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoriesContext)
        {
            //this.context = new ProductRepository();
            //this.productCategories = new ProductCategoryRepository();

            //this.context = new InMemoryRepository<Product>();
            //this.productCategories = new InMemoryRepository<ProductCategory>();

            this.context = productContext;
            this.productCategories = productCategoriesContext;

        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList<Product>();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();

            return View(viewModel);

            //Product product = new Product();
            //return View(product);
        }
        [HttpPost]
        //public ActionResult Create(Product p)
        public ActionResult Create(ProductManagerViewModel p,HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            else 
            {
                if (file != null)
                {
                    p.Product.Image = p.Product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + p.Product.Image);
                }
                //context.Insert(p);
                context.Insert(p.Product);
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
                //return View(product);
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();

                return View(viewModel);

            }
        }
        [HttpPost]
        //public ActionResult Edit(Product p , string Id)
        public ActionResult Edit(ProductManagerViewModel p, string Id, HttpPostedFileBase file)
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
                if (file != null)
                {
                    productToEdit.Image = p.Product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
                }
                //productToEdit.Category = p.Category;
                //productToEdit.description = p.description;
                //productToEdit.Name = p.Name;
                //productToEdit.Price = p.Price;

                productToEdit.Category = p.Product.Category;
                productToEdit.description = p.Product.description;
                productToEdit.Name = p.Product.Name;
                productToEdit.Price = p.Product.Price;

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
                context.Comit();
                return RedirectToAction("Index");
            }
        }


    }
}