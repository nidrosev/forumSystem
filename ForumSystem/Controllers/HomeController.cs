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

namespace ForumSystem.Controllers
{
    public class HomeController : BaseController
    {
        private IThemeService themeService;
        public HomeController(IThemeService service)
        {
            this.themeService = service;
        }
        public ActionResult Index()
        {
            var themes = themeService.GetAll().ToList();
            /*var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Theme, ThemeViewModel>();
            });
            var mapper = config.CreateMapper();
            var themesVM = mapper.Map<ThemeViewModel>(themes);  */

            var themesVM = AutoMapper.Mapper.Map<List<Theme>, List<ThemeViewModel>>(themes);
           /* ICollection<ThemeViewModel> themesVM = themes.Select(p => new ThemeViewModel()
            {
                Content = p.Content,
                Title = p.Title,
                CreatedOn = p.CreatedOn,
                Author = p.AuthorId,
                Id = p.Id,
                Comments = p.Comments
            }).ToList();*/
            return View(themesVM);
        }
        public ActionResult Details(string Id)
        {
            int ThemeId;
            int.TryParse(Id, out ThemeId);
            var themeObject = themeService.Find(ThemeId);
           // var post = Mapper.Map<Theme, ThemeViewModel>(themeObject);
            var post = new ThemeViewModel()
            {
                Content = themeObject.Content,
                Title = themeObject.Title,
                CreatedOn = themeObject.CreatedOn,
                Author = themeObject.AuthorId,
                Id = themeObject.Id,
                //Comments = themeObject.Comments
            };


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