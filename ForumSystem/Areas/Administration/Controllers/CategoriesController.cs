using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Areas.Administration.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Administration/Categories
        public ActionResult Index()
        {
            return View();
        }
    }
}