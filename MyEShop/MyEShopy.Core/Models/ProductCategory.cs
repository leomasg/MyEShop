using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        //public string Id { get; set; }

        [StringLength(20)]
        [DisplayName("Product Category Name")]
        public string Category { get; set; }

        //public ProductCategory()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}

    }
}
