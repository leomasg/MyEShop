using MyEShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Core.Models
{
    public class Basket : BaseEntity
    {
        public virtual ICollection<BaseketItem> BasketItems { get; set; }
        public Basket()
        {
            this.BasketItems = new List<BaseketItem>();
        }
    }

}
