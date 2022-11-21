using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyEShop.Core.Contracts;
using MyEShop.Core.Models;
using MyEShop.Core.ViewModels;
using MyEShop.WebUi;
using MyEShop.WebUi.Controllers;

namespace MyEShop.WebUi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void indexPageDoesReturnProducts()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCategoryContext = new Mocks.MockContext<ProductCategory>();
            HomeController controller = new HomeController(productContext, productCategoryContext);

            productContext.Insert(new Product());

            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());
        }

    }


    //[TestClass]
    //public class HomeControllerTest
    //{
    //    [TestMethod]
    //    public void Index()
    //    {
    //        // Arrange
    //        HomeController controller = new HomeController();

    //        //// Act
    //        ViewResult result = controller.Index() as ViewResult;

    //        //// Assert
    //        Assert.IsNotNull(result);
    //    }

    //}
}
