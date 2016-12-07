using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem.Data;
using ForumSystem.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ForumSystem.Services.Contracts
{
    public class UsersService : BaseService<ApplicationUser>,IUsersService
    {
        public UsersService(IForumSystemData data) : base(data)
        {
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return base.GetAll();            
        }

       
    }
}
