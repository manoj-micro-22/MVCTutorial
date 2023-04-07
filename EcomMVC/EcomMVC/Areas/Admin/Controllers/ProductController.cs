﻿using EcomMVC.Models;
using EcomMVC.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EcomMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDBContext dbContext = new ApplicationDBContext();

        // GET: Admin/Product
        public ActionResult Index()
        {
            
            //IEnumerable<Product> products = productRepository.GetAllProducts();
            IEnumerable<Product> products = dbContext.Products;

            return View(products);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var product = dbContext.Products.FirstOrDefault(e => e.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
            //return View();
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                
                dbContext.Products.Add(product);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View("index");
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            var product = dbContext.Products.FirstOrDefault(e => e.ProductId == id); 
            if(product == null)
            {
                return HttpNotFound();
            }   

            return View(product);
            //return View();
        }

        //[HttpPost]
        //public ActionResult Edit_save(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationDBContext dbContext = new ApplicationDBContext();
        //        dbContext.Entry(product).State = System.Data.Entity.EntityState.Modified;
        //        dbContext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                                
                Product product = dbContext.Products.FirstOrDefault(e => e.ProductId == id);
                UpdateModel(product);
                dbContext.SaveChanges();

                // TODO: Add update logic here                                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var product = dbContext.Products.FirstOrDefault(e => e.ProductId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            
            //dbContext.Products.Remove(product);

            //dbContext.SaveChanges();

            return View(product);

            //return RedirectToAction("Index");

            //return View();
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var product = dbContext.Products.SingleOrDefault(e => e.ProductId == id);

                dbContext.Products.Remove(product);

                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
