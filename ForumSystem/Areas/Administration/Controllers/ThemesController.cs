using ForumSystem.Models;
using ForumSystem.Services.Contracts;
using ForumSystem.Areas.Administration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Net;

namespace ForumSystem.Areas.Administration.Controllers
{
    public class ThemesController : Controller
    {
        private IThemeService themeService;

        public ThemesController(IThemeService service)
        {
            this.themeService = service;
        }
        // GET: Administration/Posts
        public ActionResult Index()
        {
            var themesQuarable = this.themeService.GetAll().ToList();
            var themes = Mapper.Map<List<Theme>, List<AdminThemeViewModel>>(themesQuarable);
            return View(themes);
        }

        /*public ActionResult Create()
        {
            ThemeViewModel themeVM = new ThemeViewModel();
            themeVM.Users = new SelectList(this.usersService.GetAll(), "Id", "UserName");

            return View(postVM);
        }*/

        [HttpGet]
        public ActionResult Create()
        {
            AdminThemeViewModel themeVM = new AdminThemeViewModel();
            // commentVM.Author = new SelectList(this.usersService.GetAll(), "Id", "UserName");
            return View(themeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(AdminThemeViewModel theme)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
             
             var dbtheme = Mapper.Map<AdminThemeViewModel,Theme>(theme);
            this.themeService.Add(dbtheme);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = this.themeService.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }

            AdminThemeViewModel themeVM = Mapper.Map<AdminThemeViewModel>(theme);
            return View(themeVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(AdminThemeViewModel theme)
        {
            if (ModelState.IsValid)
            {
                var dbTheme = Mapper.Map<AdminThemeViewModel,Theme>(theme);
                this.themeService.Update(dbTheme);
                return RedirectToAction("Index");
            }

          //  post.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", post.AuthorId);
            return View(theme);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theme theme = this.themeService.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        // POST: Administration/Themes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.themeService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}