using EcomMVC.Models;
using EcomMVC.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
        public IEnumerable<ProductDto> GetAllProducts()
        {
            var product = from p in dbContext.Products
                          join c in dbContext.Catgories on p.CategoryId equals c.CategoryId
                          select new ProductDto()
                          {
                              ProductId = p.ProductId,
                              ProductName = p.ProductName,
                              UnitPrice = p.UnitPrice,
                              Description = p.Description,
                              CategoryId = c.CategoryId,
                              CategoryName = c.CategoryName
                          };

            //return (IEnumerable<ProductDto>)product;
            return product;
            
        }

        public Product GetProductById(int id)
        {
            return null;
        }

        public Product AddProduct(Product product)
        {
            return null;
        }

        public Product UpdateProduct(Product product)
        {
            return null;
        }

        public Product DeletProduct(int id)
        {
            return null;
        }
    }
}
