using EBazarSols.Entities;
using EBazarSols.Services;
using EBazarSols.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBazarSols.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductServices services=new ProductServices();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductTable()
        {
            var product = services.GetProducts();
            return PartialView(product);
        }
        public ActionResult Create()
        {
            CategoryServices categoryServ = new CategoryServices();
            var category = categoryServ.GetCategories();
            return PartialView(category);
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            CategoryServices categoryServices = new CategoryServices();
            var newProduct = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId
            };
            if(ModelState.IsValid ) { 
             services.AddProducts(newProduct);
                return RedirectToAction("ProductTable");
            }
            return View(newProduct);
        }

        public ActionResult Edit(int id)
        {
            //CategoryServices categoryServ = new CategoryServices();
            //var category = categoryServ.GetCategories();
            var products=services.FindProduct(id);
            return PartialView(products);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            CategoryServices categoryServices = new CategoryServices();
            var newProduct = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                CategoryId = model.CategoryId
            };
            if (ModelState.IsValid)
            {
                services.AddProducts(newProduct);
                return RedirectToAction("ProductTable");
            }
            return View(newProduct);
        }
    }
}