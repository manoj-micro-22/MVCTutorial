using EcomMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomMVC.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDBContext dbContext = new ApplicationDBContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            IEnumerable<Category> categoryList = dbContext.Catgories;

            return View(categoryList);
        }
    }
}