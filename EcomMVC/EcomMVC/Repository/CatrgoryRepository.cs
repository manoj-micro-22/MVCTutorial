using EcomMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcomMVC.Repository
{
    /// <summary>
    /// Category Repository
    /// </summary>
    public class CatrgoryRepository
    {
       private readonly ApplicationDBContext dbContext;
       
        public CatrgoryRepository(ApplicationDBContext dBContext)
        { 
           dbContext= dBContext;           
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetCategories()
        {
            IEnumerable<Category> categoryList = dbContext.Catgories.ToList();
            
            return categoryList;
        }

        /// <summary>
        /// Get Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetCategory(int id)
        {
            var category = dbContext.Catgories.FirstOrDefault(c => c.CategoryId == id);
            return category;
        }

        /// <summary>
        /// TODO: Add insert logic here
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Category CreateCategory(Category category)
        {
            try
            {   
                dbContext.Catgories.Add(category);
                dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return category;
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Category UpdateCategory(Category category)
        {
            try
            {
                var cat = dbContext.Catgories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
                cat.CategoryName = category.CategoryName;               
                dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return category;
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public bool DeleteCategory(int CategoryId)
        {
            try
            {
                var cat = dbContext.Catgories.FirstOrDefault(c => c.CategoryId == CategoryId);
                dbContext.Catgories.Remove(cat);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
