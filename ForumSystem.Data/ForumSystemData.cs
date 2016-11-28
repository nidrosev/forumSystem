using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem.Data.Repositories;
using ForumSystem.Models;
using System.Data.Entity;

namespace ForumSystem.Data
{
    class ForumSystemData : IForumSystemData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public ForumSystemData()
            : this(new ForumSystemDbContext())
        {
        }

        public ForumSystemData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Theme> Theme
        {
            get
            {
                return this.GetRepository<Theme>();
            }
        }

        public IRepository<Category> Category
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Comment> Comment
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
