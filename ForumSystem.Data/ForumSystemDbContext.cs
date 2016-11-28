using ForumSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Data
{
    public class ForumSystemDbContext : IdentityDbContext
    {

        public ForumSystemDbContext() : base("ForumSytemDbConnection")
        {

        }

        public IDbSet<ApplicationUser> Users
        {
            get;
            set;
        }

        public IDbSet<Theme> Theme
        {
            get;
            set;
        }

        public static ForumSystemDbContext Create()
        {
            return new ForumSystemDbContext();
        }
    }
}
