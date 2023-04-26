using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EcomMVC.Models.Dto
{
    public class ProductDto
    {        
        public int ProductId { get; set; }

        [DisplayName("Producat Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name is Required!")]
        public string ProductName { get; set; }

        [DisplayName("Unit Price")]
        [Range(minimum: 10, maximum: 150000, ErrorMessage = "Unit Price is Required!")]
        public double UnitPrice { get; set; }

        public string Description { get; set; }

        //public int CategoryId { get; set; }

        [DisplayName("Product Category")]
        public string CategoryName { get; set; }

        [DisplayName("Category")]
        public List<SelectListItem> CategoryListItems { get; set; }
        public int SelectedCategoryId { get; set; }

    }
}
