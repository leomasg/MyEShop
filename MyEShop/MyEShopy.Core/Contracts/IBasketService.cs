using MyEShop.Core.ViewModels;
using System.Collections.Generic;
using System.Web;

namespace MyEShop.Core.Contracts
{
    public interface IBasketService
    {
        void addToBasket(HttpContextBase httpContext, string productId);
        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
        void removeFromBasket(HttpContextBase httpContext, string itemId);
    }
}