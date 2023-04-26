using EcomMVC.Models;
using EcomMVC.Models.Dto;
using EcomMVC.Repository;
using EcomMVC.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EcomMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly AdminServices _adminServices;

        public ProductController()
        {
            _adminServices = new AdminServices();

        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            
            List<ProductDto> products = _adminServices.GetAllProducts().ToList();            
            return View(products);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _adminServices.GetProductsById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {                        
            ProductDto product = new ProductDto();
            product.CategoryListItems = _adminServices.GetCategotyDropDownList();
            return View(product);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                _adminServices.AddNewProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index", product);
            }            
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _adminServices.GetProductsById(id);
            product.CategoryListItems = _adminServices.GetCategotyDropDownList();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);            
        }
        
        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductDto productDto)
        {
            try
            {
                //Product product = dbContext.Products.FirstOrDefault(e => e.ProductId == id);
                //UpdateModel(product);
                //dbContext.SaveChanges();

                // TODO: Add update logic here                                
                ProductDto product = _adminServices.UpdateProduct(productDto);
                if (product != null)
                {
                    ViewBag.Message = "Product Updated Successfully.";
                }
                else
                {
                    ViewBag.Message = "Error in Updation.";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }            
        }

        // GET: Admin/Product/Delete/5        
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bool isDeleted = _adminServices.DeletProduct(id);            
            if (isDeleted)
            {
                ViewBag.Message = "Product Deleted Successfully.";
            }
            else
            {
                ViewBag.Message = "Error in Deletion.";
            }
            return RedirectToAction("Index");
        }        

    }
}
