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
using System.Net;
using ForumSystem.Data;

namespace ForumSystem.Areas.Administration.Controllers
{
 
    public class AdminUserController : Controller
    {
        private IUsersService uservice { get; set; }
        private ForumSystemDbContext context { get; set; }
        //private readonly UserManager<ApplicationUser> _userManager;
        public AdminUserController(IUsersService service, UserManager<ApplicationUser> userManager, ForumSystemDbContext data)
        {
            this.context = data;
            this.uservice = service;
        }
        // GET: Administration/AdminUser

        public ActionResult Index()
        {
            var usersQuarable = this.uservice.GetAll().ToList();
            var users = Mapper.Map<List<ApplicationUser>, List<UserModifyViewModel>>(usersQuarable);
            return View(users);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string UserId)
        {
            if (UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = this.uservice.Find(UserId);

            if (user == null)
            {
                return HttpNotFound();
            }
            ApplicationUser userVM = Mapper.Map<ApplicationUser>(user);
            ViewBag.UserRoles = context.Roles.ToList();
            return View(userVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(UserModifyViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var dbuser = Mapper.Map<UserModifyViewModel, ApplicationUser> (user);
            this.uservice.Update(dbuser);
            ViewBag.UserRoles = context.Roles.ToList();

            return RedirectToAction("Index");
        }
    }
}