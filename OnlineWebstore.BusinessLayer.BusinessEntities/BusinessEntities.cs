using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineWebstore.BusinessLayer.BusinessEntities
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
    public class Product 
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Range(1.0,double.MaxValue, ErrorMessage = "Value should be more than 1.0")]
        public double ProductPrice { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }

    }

}
