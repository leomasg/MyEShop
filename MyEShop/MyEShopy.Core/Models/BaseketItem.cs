using MyEShop.Core.Models;

namespace MyEShop.Core.Models
{
    public class BaseketItem : BaseEntity
    {
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}