using EcomMVC.Models;
using System.Data.Entity;

namespace EcomMVC
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext() : base("ConstrApplicationDB")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Catgories { get; set; }
    }
}

