using ForumSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumSystem.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using ForumSystem.Models;
using System.Data.Entity;

namespace ForumSystem.Areas.Administration.Controllers
{
    public class RoleController : Controller
    {
        private ForumSystemDbContext Context { get; set; }

        public RoleController(ForumSystemDbContext data)
        {
            this.Context = data;
        }


        // GET: Administration/Role
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var Roles = Context.Roles.ToList();
 
            return View(Roles);
        }

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IdentityRole Role)
        {
            Context.Roles.Add(Role);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

       /* public void RemoveFromRole(string userId, string roleName)
        {
            Context.RemoveFromRole(userId, roleName);
        }
        public void DeleteRole(string roleId)
        {
            var roleUsers = Context.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId));
            var role = Context.Roles.Find(roleId);

            foreach (var user in roleUsers)
            {
                this.RemoveFromRole(user.Id, role.Name);
            }
            Context.Roles.Remove(role);
            Context.SaveChanges();
        }*/
    }
}