using ForumSystem.Models;
using ForumSystem.Services;
using ForumSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem.Data;

namespace ForumSystem.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IForumSystemData data) : base(data)
        {
        }

        public void Add(Category entity)
        {

            base.Add(entity);
            base.SaveChanges();
        }

        public Category Find(object Id)
        {
            return base.Find(Id);
        }

        public IQueryable<Category> GetAll()
        {
            return base.GetAll().OrderBy(x => x.Name);
        }

        public void Update(Category entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
        public void Delete(object id)
        {
            base.Delete(id);
            base.SaveChanges();
        }
    }
}
