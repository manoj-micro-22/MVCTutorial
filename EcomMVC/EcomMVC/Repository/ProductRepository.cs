using EcomMVC.Models;
using EcomMVC.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace EcomMVC.Repository
{
    public class ProductRepository
    {
        private readonly ApplicationDBContext dbContext;
        
        public ProductRepository(ApplicationDBContext dBContext)
        {
            dbContext = dBContext;
        }

        //ApplicationDBContext dbContext = new ApplicationDBContext();
        public List<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return null;
        }

        public Product AddProduct(Product product)
        {                        
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            dbContext.Products.AddOrUpdate(product);
            dbContext.SaveChanges();
            return product;
        }

        public bool DeletProduct(int id)
        {
            try
            {
                var product = dbContext.Products.FirstOrDefault(p => p.ProductId == id);
                dbContext.Products.Remove(product);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;                              
            }
           
        }
    }
}
