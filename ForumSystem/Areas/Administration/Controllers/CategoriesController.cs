using ForumSystem.Models;
using ForumSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var categories = this.cservice.GetAll();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}