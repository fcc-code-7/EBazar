using EBazarSols.Entities;
using EBazarSols.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EBazarSols.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryServices services = new CategoryServices();
        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult CategoryTable()
        {
            var category = services.GetCategories();
            return PartialView(category);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                services.AddCategories(category);
                return RedirectToAction("CategoryTable");
           
                }
            return View(category);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = services.FindCategory(id);
            return PartialView(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                services.Update(category);
                return RedirectToAction("CategoryTable");

            }
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var category = services.FindCategory(id);
            try
            {
                if (ModelState.IsValid)
                {
                    services.Delete(category);
                    // Assuming services.Delete(id) handles database deletion and context.SaveChanges()
                    return RedirectToAction("CategoryTable");
                }
                return View(id); // This might need to be revised based on your application flow
            }
            catch (Exception ex)
            {
                // Log the exception to troubleshoot
                // Example:
                // Logger.LogError($"Error deleting category with id {id}: {ex.Message}");
                
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

    }
}