using AutoMapper;
using ForumSystem.Areas.Administration.ViewModels;
using ForumSystem.Models;
using ForumSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Areas.Administration.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService cservice { get; set; }
        public CategoriesController(ICategoryService service)
        {
            this.cservice = service;
        }
        // GET: Administration/Categories
        public ActionResult Index()
        {
            var categories = this.cservice.GetAll().ToList();
            return View(categories);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(AdminCategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var dbcategory = Mapper.Map<AdminCategoryViewModel, Category>(category);
            this.cservice.Add(dbcategory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.cservice.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            AdminCategoryViewModel categoryVM = Mapper.Map<AdminCategoryViewModel>(category);
            return View(categoryVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(AdminCategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var dbcategory = Mapper.Map<AdminCategoryViewModel, Category>(category);
            this.cservice.Update(dbcategory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.cservice.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Themes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.cservice.Delete(id);
            return RedirectToAction("Index");
        }

    }
}