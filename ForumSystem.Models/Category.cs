using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Models
{
    public class Category : BaseModel
    {

        public Category()
        {
            this.CategoryThemes = new HashSet<Theme>();
        }

        public string Name { get; set; }
        public string ShortDescription { get; set; }

        public virtual ICollection<Theme> CategoryThemes { get; set; }
    }
}
