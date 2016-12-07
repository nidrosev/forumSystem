using AutoMapper;
using ForumSystem.Models;
using ForumSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumSystem.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumSystem.Areas.Administration.Controllers
{
 
    public class AdminUserController : Controller
    {
        private IUsersService uservice { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminUserController(IUsersService service, UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
            this.uservice = service;
        }
        // GET: Administration/AdminUser
        public ActionResult Index()
        {
            var usersQuarable = this.uservice.GetAll().ToList();
            var users = Mapper.Map<List<ApplicationUser>, List<RegisterViewModel>>(usersQuarable);
            return View(users);
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            var model = UserManager().FindById(Id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ApplicationUser user)
        {
            _userManager.FindById
            return
        }
    }
}