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
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersService(IForumSystemData data, UserManager<ApplicationUser> userManager) : base(data)
        {
            this._userManager = userManager;
            
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return base.GetAll();            
        }
        async void Update(ApplicationUser entity)
        {         
            await _userManager.UpdateAsync(entity);
        }
        async void Delete(ApplicationUser entity)
        {
            await _userManager.DeleteAsync(entity);
        }
        ApplicationUser Find(string Id)
        {
            
            return _userManager.FindById(Id);
        }
       /* public List<string> GetRoles()
        {
            var roles = System.Web.Security.Roles.GetAllRoles().ToList();
            return roles;
        }*/
 

    }
}
