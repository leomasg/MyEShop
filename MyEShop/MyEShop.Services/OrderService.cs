using MyEShop.Core.Contracts;
using MyEShop.Core.Models;
using MyEShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> orderContext;
        public OrderService(IRepository<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItems)
        {
            foreach (var item in basketItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                });
            }

            orderContext.Insert(baseOrder);
            orderContext.Comit();
        }

        public List<Order> GetOrderList ()
        {
            return orderContext.Collection().ToList();
        }
        public Order GetOrder( string id )
        {
            return orderContext.Find(id);
        }
        public void UpdatetOrder(Order updatedOrder)
        {
            orderContext.Update(updatedOrder);
            orderContext.Comit();
        }



    }
}
