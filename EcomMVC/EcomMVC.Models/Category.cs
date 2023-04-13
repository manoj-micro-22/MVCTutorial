using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcomMVC.Models
{
    /// <summary>
    /// Category Model 
    /// </summary>
    public class Category
    {
        /// <summary>
        /// CategoryId
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        [DisplayName("Category Name")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Category Name is required!")]
        public string CategoryName { get; set; }
    }
}
