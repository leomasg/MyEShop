using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Core.Models
{
    public class Product
    {
        public string Id { get; set; }
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string description { get; set; }
        [Range(0,1000)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public Product(string name, string description, decimal price, string category, string image)
        {
            this.Id = this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.description = description;
            this.Price = price;
            this.Category = category;
            this.Image = image;
        }
    }
}
