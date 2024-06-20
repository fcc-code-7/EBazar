using EBazarSols.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBazarSols.Db
{
    public class ESolDbContext : DbContext
    {
        public ESolDbContext() : base("EBazarDb")
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
