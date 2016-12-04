using ForumSystem.Data;
using ForumSystem.Models;
using ForumSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ForumSystem.Services
{
    public class CommentService :BaseService<Comment>,ICommentService
    {

        public CommentService(IForumSystemData data)
            : base(data)
        {
            
        }
       
        public override IQueryable<Comment> GetAll()
        {
            return base.GetAll(); //.OrderByDescending(p => p.CreatedOn);
        }

        public void Add(Comment entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.UpdatedOn = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }

        public override void Update(Comment entity)
        {
            entity.UpdatedOn = DateTime.Now;
            base.Update(entity);
            base.SaveChanges();
        }
        public override void Delete(object Id)
        {
            base.Delete(Id);
            base.SaveChanges();
        }

        public override Comment Find(object Id)
        {
            return base.Find(Id);
        }


        public ICollection<Comment> FindAllCommentsForTheme(int Id)
        {
            var ThemeComments = new HashSet<Comment>();
            var comments = base.GetAll().ToList();
            foreach (var item in comments)
            {
                if (item.ThemeId == Id)
                {
                    ThemeComments.Add(item);
                }
            }

            return ThemeComments;
        }


    }
}
