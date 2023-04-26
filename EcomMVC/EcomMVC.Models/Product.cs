using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomMVC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage ="Product Name is Required!")] 
        public string ProductName { get; set; }

        [Range(minimum: 10, maximum: 150000,ErrorMessage ="Unit Price is Required!")]
        public double UnitPrice { get; set; }

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage ="Please select Product Category!")]
        public int CategoryId { get; set; }
    }
}
