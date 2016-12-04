using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Services.Contracts
{
    public interface ICommentService
    {
        IQueryable<Comment> GetAll();
        void Add(Comment entity);
        void Update(Comment entity);
        void Delete(object id);
        Comment Find(object Id);
        ICollection<Comment> FindAllCommentsForTheme(int Id);
    }
}
