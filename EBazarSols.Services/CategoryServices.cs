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
    public class CategoryServices
    {
        ESolDbContext context = new ESolDbContext();

        public List<Category> GetCategories()
        {
            using (context)
            {
                return context.Categories.ToList();
            }
        }

        public void AddCategories(Category category)
        {
            using (context)
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public void Update(Category category)
        {
            using (context)
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Category FindCategory(int Id)
        {
            using (context)
            {
                return  context.Categories.Find(Id);
               
            }

        }
        public void Delete(Category category)
        {
           
            using (context)
            {
                context.Entry(category).State= EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
