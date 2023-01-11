using MyEShop.Core.Contracts;
using MyEShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEShop.WebUi.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;
        IOrderService orderService;

        public BasketController(IBasketService basketService , IOrderService OrderService)
        {
            this.basketService = basketService;
            this.orderService = OrderService;
        }

        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(string Id)
        {
            basketService.addToBasket(this.HttpContext, Id);
            return RedirectToAction("index");
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.removeFromBasket(this.HttpContext, Id);
            return RedirectToAction("index");
        }

        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);
            return PartialView(basketSummary);
        }

        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(Order order )
        {
            var basketItems = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";

            //Process payment

            order.OrderStatus = "Order Processed";

            orderService.CreateOrder(order, basketItems);
            basketService.ClearBasket(this.HttpContext);

            return RedirectToAction("ThankYou" , new { orderId = order.Id });
        }

        public ActionResult ThankYou(String orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }
    }
}