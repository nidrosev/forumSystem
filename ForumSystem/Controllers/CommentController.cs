using AutoMapper;
using ForumSystem.Data;
using ForumSystem.Models;
using ForumSystem.Services;
using ForumSystem.Services.Contracts;
using ForumSystem.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Controllers
{
    public class CommentController : Controller
    {
        private ICommentService commentService;
        private object data;

        public CommentController(ICommentService cservice)
        {
            this.commentService = cservice;

        }
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ShowComment(int id)
        {
             System.Threading.Thread.Sleep(300);
            var commentsQuarable = commentService.FindAllCommentsForTheme(id).ToList();
            var comments = Mapper.Map<List<Comment>, List<CommentViewModel>>(commentsQuarable);
            return PartialView("_ShowComments", comments);
        }

        [HttpGet]
        public ActionResult Create(int Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentViewModel themeVM = new CommentViewModel();
            themeVM.ThemeId = Id;
            // commentVM.Author = new SelectList(this.usersService.GetAll(), "Id", "UserName");
            return View(themeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CommentViewModel comment)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details/" + comment.ThemeId, "Home");
            }
            //  comment.AuthorId = User.Identity.GetUserId();
            comment.AuthorId = User.Identity.GetUserId();
            var dbcomment = Mapper.Map<CommentViewModel, Comment>(comment);

            this.commentService.Add(dbcomment);
     
            return RedirectToAction("Details/"+comment.ThemeId, "Home");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.commentService.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            CommentViewModel commentVM = Mapper.Map<CommentViewModel>(comment);
            return View(commentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var dbcomment = Mapper.Map<CommentViewModel, Comment>(comment);
                this.commentService.Update(dbcomment);
                return RedirectToAction("Details/" + comment.ThemeId, "Home");
            }

            //  post.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", post.AuthorId);
            return View(comment);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var comment = this.commentService.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Administration/Themes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.commentService.Delete(id);
            return RedirectToAction("Index", "Home");
        }

    }
}