using EcomMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EcomMVC
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext():base("ConstrApplicationDB")
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Catgories { get; set; }
    }
}

