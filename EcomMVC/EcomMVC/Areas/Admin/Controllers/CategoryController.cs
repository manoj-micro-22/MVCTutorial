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
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<Category> categoryList = new List<Category>();
            categoryList.Add(new Category() { CategoryId = 1, CategoryName = "Electronics" });
            categoryList.Add(new Category() { CategoryId = 2, CategoryName = "Home" });

            return View(categoryList);
        }
    }
}