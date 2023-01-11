﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyEShop.Core.Contracts;
using MyEShop.Core.Models;
using MyEShop.Core.ViewModels;
using MyEShop.Services;
using MyEShop.WebUi.Controllers;
using MyEShop.WebUi.Tests.Mocks;

namespace MyEShop.WebUi.Tests.Controllers
{
    [TestClass]
    public class BasketControllerTests
    {
        [TestMethod]
        public void CanAddBasketItem()
        {
            IRepository<Product> products = new MockContext<Product>();
            IRepository<Basket> baskets = new MockContext<Basket>();
            IRepository<Order> orders = new MockContext<Order>();

            var httpContext = new MockHttpContext();

            IBasketService basketService = new BasketService(products,baskets);
            IOrderService orderService = new OrderService(orders);
            var controller = new BasketController(basketService,orderService);
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext,new System.Web.Routing.RouteData(),controller);

            //basketService.addToBasket(httpContext, "1");
            controller.AddToBasket("1");

            Basket basket = baskets.Collection().FirstOrDefault();

            Assert.IsNotNull(basket);
            Assert.AreEqual(1, basket.BasketItems.Count());
            Assert.AreEqual("1", basket.BasketItems.ToList().FirstOrDefault().ProductId);
        }

        [TestMethod]
        public void CanGetSummaryViewModel()
        {
            IRepository<Product> products = new MockContext<Product>();
            IRepository<Basket> baskets = new MockContext<Basket>();
            IRepository<Order> orders = new MockContext<Order>();

            products.Insert(new Product() { Id = "1" ,Name = "Transformer", Price = 10.00m});
            products.Insert(new Product() { Id = "2", Name = "Livro", Price = 5.00m });

            Basket basket = new Basket();
            basket.BasketItems.Add(new BaseketItem() { ProductId = "1", Quantity = 2 });
            basket.BasketItems.Add(new BaseketItem() { ProductId = "2", Quantity = 1 });
            baskets.Insert(basket);

            IBasketService basketService = new BasketService(products, baskets);
            var httpContext = new MockHttpContext();
            httpContext.Request.Cookies.Add(new System.Web.HttpCookie("eCommerceBasket") { Value = basket.Id });

            IOrderService orderService = new OrderService(orders);

            var controller = new BasketController(basketService, orderService);
            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            var result = controller.BasketSummary() as PartialViewResult;
            var basketSummary = (BasketSummaryViewModel)result.ViewData.Model;

            Assert.AreEqual(3, basketSummary.BasketCount);
            Assert.AreEqual(25.00m, basketSummary.BasketTotal);
        }

        [TestMethod]
        public void CanCheckoutAndCreateOrder()
        {
            IRepository<Product> products = new MockContext<Product>();
            products.Insert(new Product() { Id = "1", Name = "Transformer", Price = 10.00m });
            products.Insert(new Product() { Id = "2", Name = "Livro", Price = 5.00m });

            IRepository<Basket> baskets = new MockContext<Basket>();
            Basket basket = new Basket();
            basket.BasketItems.Add(new BaseketItem() { ProductId = "1", Quantity = 2 , BasketId = basket.Id});
            basket.BasketItems.Add(new BaseketItem() { ProductId = "2", Quantity = 1 , BasketId = basket.Id });
            baskets.Insert(basket);

            IBasketService basketService = new BasketService(products, baskets);

            IRepository<Order> orders = new MockContext<Order>();

            IOrderService orderService = new OrderService(orders);

            var controller = new BasketController(basketService, orderService);
            var httpContext = new MockHttpContext();
            httpContext.Request.Cookies.Add(new System.Web.HttpCookie("eCommerceBasket") { Value = basket.Id });

            controller.ControllerContext = new System.Web.Mvc.ControllerContext(httpContext, new System.Web.Routing.RouteData(), controller);

            //Act
            Order order = new Order();
            controller.Checkout(order);

            //Assert
            Assert.AreEqual(2, order.OrderItems.Count);
            Assert.AreEqual(0, basket.BasketItems.Count);

            Order orderInRep = orders.Find(order.Id);
            Assert.AreEqual(2, orderInRep.OrderItems.Count);
        }

    }
}
