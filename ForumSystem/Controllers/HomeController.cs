using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumSystem.Data;
using ForumSystem.Models;
using ForumSystem.ViewModels;

namespace ForumSystem.Controllers
{
    public class HomeController : BaseController
    {
        private IForumSystemData Data;
        public HomeController(IForumSystemData data)
        {
            this.Data = data;
        }
        public ActionResult Index()
        {
            var themes = this.Data.Themes.All().ToList();
            // var postVM = Mapper.Map<ThemeViewModel>(themes);  
            ICollection<ThemeViewModel> themesVM = themes.Select(p => new ThemeViewModel()
            {
                Content = p.Content,
                Title = p.Title,
                //CreatedOn = p.CreatedOn,
                Author = p.AuthorId,
                Id = p.Id,
                Comments = p.Comments
            }).ToList();
            return View(themesVM);
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