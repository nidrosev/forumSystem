﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumSystem.Data;
using ForumSystem.Models;
using ForumSystem.ViewModels;
using ForumSystem.Services;
using ForumSystem.Services.Contracts;
using AutoMapper;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using ForumSystem.Areas.Administration.ViewModels;
using PagedList;
using ForumSystem.Common.Caching;

namespace ForumSystem.Controllers
{
    public class HomeController : Controller
    {
        private IThemeService themeService;
        //private IUsersService ThemeUser;
        private ICategoryService categoryService;
        private ICacheService cacheService;
        public HomeController(IThemeService tservice,ICategoryService cservice, ICacheService cache)
        {
            this.themeService = tservice;
            this.categoryService = cservice;
            this.cacheService = cache;
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var themes = this.cacheService.Get<List<Theme>>("allThemes", () =>
            {
                return themeService.GetAll().ToList();
            }, 60);
            var themesVM = Mapper.Map<List<Theme>, List<ThemeViewModel>>(themes);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
           
            return View(themesVM.ToPagedList(pageNumber, pageSize));
        }
       
        public ActionResult Details(string Id)
        {
            int ThemeId;
            int.TryParse(Id, out ThemeId);
            var themeObject = themeService.Find(ThemeId);
           // themeObject.Author = this.ThemeUser.Find(themeObject.AuthorId);
            //themeObject.Author = ForumSystemDbContext.Users.FirstOrDefault(x => x.Id == User.Identity.GetUserId());
            var post = Mapper.Map<Theme, ThemeViewModel>(themeObject);

            return View(post);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CategoryTheme(int Id)
        {
            var themesByCategory = this.themeService.FindByCategory(Id);

            return View(themesByCategory);
        }
        
        public PartialViewResult ShowCategories()
        {
            var categoriesQuarable = this.categoryService.GetAll().ToList();
            var categories = Mapper.Map<List<Category>, List<AdminCategoryViewModel>>(categoriesQuarable);
            return PartialView("_Categories", categories);
        }
        public PartialViewResult ShowFeaturedPost()
        {
            var featureThemesQuarable = this.themeService.GetAll().OrderBy(m=>m.CreatedOn).Take(5).ToList();
            var featureThemes = Mapper.Map<List<Theme>, List<AdminThemeViewModel>>(featureThemesQuarable);
            return PartialView("_FeaturedThemes", featureThemes);
        }
    }
}