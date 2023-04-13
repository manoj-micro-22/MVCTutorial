using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomMVC.Models.Dto
{
    public class ProductDto
    {        
        public int ProductId { get; set; }

        [DisplayName("Producat Name")]
        public string ProductName { get; set; }

        [DisplayName("Unit Price")]
        public double UnitPrice { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        [DisplayName("Product Category")]
        public string CategoryName { get; set; }
    }
}
