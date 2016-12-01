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
            base.Add(entity);
            base.SaveChanges();
        }
        public override Theme Find(object Id)
        {
            return base.Find(Id);
        }
    }
}
