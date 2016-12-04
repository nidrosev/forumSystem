using ForumSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem.Models;
using ForumSystem.Data;
using ForumSystem.Services;

namespace ForumSystem.Services
{
    public class ThemeService : BaseService<Theme>, IThemeService
    {
        public ThemeService(IForumSystemData data)
            : base(data)
        {
        }

        public override IQueryable<Theme> GetAll()
        {
            return base.GetAll(); //.OrderByDescending(p => p.CreatedOn);
        }

        public override void Add(Theme entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.UpdatedOn = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }

        public override void Update(Theme entity)
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

        public override Theme Find(object Id)
        {
            return base.Find(Id);
        }
    }
}
