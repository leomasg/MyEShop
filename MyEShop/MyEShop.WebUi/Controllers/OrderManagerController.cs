﻿using MyEShop.Core.Contracts;
using MyEShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEShop.WebUi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManagerController : Controller
    {
        IOrderService orderService;

        public OrderManagerController(IOrderService OrderService)
        {
            this.orderService = OrderService;
        }

        //Get OrderManager
        public ActionResult Index()
        {
            List<Order> orders = orderService.GetOrderList();

            return View(orders);
        }

        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order Created",
                "Payment Processed",
                "Order Shipped",
                "Order Complete"
            };

            Order order = orderService.GetOrder(Id);

            return View(order);
        }
        [HttpPost]
        public ActionResult UpdateOrder(Order updatedOrder , string Id)
        {   
                
            Order order = orderService.GetOrder(Id);

            order.OrderStatus = updatedOrder.OrderStatus;

            orderService.UpdatetOrder(order);

            return RedirectToAction("Index");
        }



    }
}