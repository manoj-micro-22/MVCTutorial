using EcomMVC.Models;
using EcomMVC.Models.Dto;
using EcomMVC.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcomMVC.Services
{
    public class AdminServices
    {
        private readonly ProductRepository _productRepository;
        private readonly CatrgoryRepository _catrgoryRepository;        
        private readonly ApplicationDBContext _dbContext;

        public AdminServices() 
        {
            _dbContext = new ApplicationDBContext();
            _productRepository = new ProductRepository(_dbContext);
            _catrgoryRepository = new CatrgoryRepository(_dbContext);
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var product = from p in _productRepository.GetProducts()
                          join c in _catrgoryRepository.GetCategories() on p.CategoryId equals c.CategoryId
                          select new ProductDto()
                          {
                              ProductId = p.ProductId,
                              ProductName = p.ProductName,
                              UnitPrice = p.UnitPrice,
                              Description = p.Description,                              
                              SelectedCategoryId = c.CategoryId,
                              CategoryName = c.CategoryName,
                              CategoryListItems = _catrgoryRepository.GetCategotyDropDownList(),                              
                          };
            
            return product.ToList();
        }

        public ProductDto GetProductsById(int id)
        {
            var product = from p in _productRepository.GetProducts()
                          join c in _catrgoryRepository.GetCategories() on p.CategoryId equals c.CategoryId
                          where p.ProductId == id
                          select new ProductDto()
                          {
                              ProductId = p.ProductId,
                              ProductName = p.ProductName,
                              UnitPrice = p.UnitPrice,
                              Description = p.Description,
                              SelectedCategoryId = c.CategoryId,
                              CategoryName = c.CategoryName,
                              CategoryListItems = _catrgoryRepository.GetCategotyDropDownList(),
                          };

            return product.FirstOrDefault();
        }

        public List<SelectListItem> GetCategotyDropDownList()
        {
            return _catrgoryRepository.GetCategotyDropDownList();
        }
        public Product AddNewProduct(ProductDto productdto)
        {
            Product product = new Product();
            product.ProductName = productdto.ProductName;
            product.UnitPrice = productdto.UnitPrice;
            product.Description = productdto.Description;
            product.CategoryId = productdto.SelectedCategoryId;

            _productRepository.AddProduct(product);
            return product;
        }
        public bool DeletProduct(int id)
        {
            return _productRepository.DeletProduct(id);
        }

        public ProductDto UpdateProduct(ProductDto productDto)
        {
            Product product = new Product();
            product.ProductId = productDto.ProductId;
            product.ProductName = productDto.ProductName;
            product.Description= productDto.Description;
            product.UnitPrice= productDto.UnitPrice;
            product.CategoryId= productDto.SelectedCategoryId;

            _productRepository.UpdateProduct(product);
            return productDto;
        }

    }
}