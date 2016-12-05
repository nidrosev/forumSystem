using System;
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

namespace ForumSystem.Controllers
{
    public class HomeController : Controller
    {
        private IThemeService themeService;
        private IUsersService ThemeUser;
        //private ICommentService commentService;
        public HomeController(IThemeService tservice/*,IUsersService user*/)
        {
            this.themeService = tservice;
            //this.ThemeUser = user;
        }
        public ActionResult Index()
        {
            var themes = themeService.GetAll().ToList();
            

            var themesVM = AutoMapper.Mapper.Map<List<Theme>, List<ThemeViewModel>>(themes);
            return View(themesVM);
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
    }
}