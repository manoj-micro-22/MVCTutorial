using EcomMVC.Repository;
using System.Web.Mvc;

namespace EcomMVC.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        
        private readonly CatrgoryRepository category;

        private readonly ApplicationDBContext dBContext;

        public CategoryController()
        {
            dBContext = new ApplicationDBContext();
            category  = new CatrgoryRepository(dBContext);
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            var categorylist= category.GetCategories();
            return View(categorylist);
        }

        


       
    }
}