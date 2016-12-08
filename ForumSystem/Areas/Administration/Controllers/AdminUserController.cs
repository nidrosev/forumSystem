﻿using AutoMapper;
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

namespace ForumSystem.Areas.Administration.Controllers
{
 
    public class AdminUserController : Controller
    {
        private IUsersService uservice { get; set; }
        //private readonly UserManager<ApplicationUser> _userManager;
        public AdminUserController(IUsersService service, UserManager<ApplicationUser> userManager)
        {
  
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
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = this.uservice.Find(Id);

            if (user == null)
            {
                return HttpNotFound();
            }
            ApplicationUser userVM = Mapper.Map<ApplicationUser>(user);
            return View(userVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(RegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var dbuser = Mapper.Map<RegisterViewModel, ApplicationUser> (user);
            this.uservice.Update(dbuser);

            return RedirectToAction("Index");
        }
    }
}