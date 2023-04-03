using EcomMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcomMVC
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("ConstrApplicationDB")
        {

        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> catgories { get; set; }
    }
}