using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Data
{
    using ForumSystem.Data.Repositories;
    using Models;

    public interface IForumSystemData
    {

        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Theme> Themes
        {
            get;
        }

        IRepository<Comment> Comments
        {
            get;
        }
        IRepository<Category> Categories
        {
            get;
        }


        IRepository<T> GetRepository<T>() where T : class;
    }

}
