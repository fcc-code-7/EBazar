using EBazarSols.Db;
using EBazarSols.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBazarSols.Services
{
    public class ProductServices
    {
        ESolDbContext context = new ESolDbContext();

        public List<Product> GetProducts()
        {
            using (context)
            {
                return context.Products.Include(x=>x.category).ToList();
            }
        }

        public void AddProducts(Product product)
        {
            using (context)
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void Update(Product product)
        {
            using (context)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Product FindProduct(int Id)
        {
           var id = context.Products.Find(Id);
            return id;

        }
        public void Delete(Product product)
        {
           
            using (context)
            {
                context.Entry(product).State= EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
