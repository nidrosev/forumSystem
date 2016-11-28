using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Data
{
    using ForumSystem.Data.Repositories;
    using ForumSystem.Models;
    interface IForumSystemData
    {

        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Category> Category
        {
            get;
        }
        IRepository<Comment> Comment
        {
            get;
        }

        IRepository<T> GetRepository<T>() where T : class;
    }

}
