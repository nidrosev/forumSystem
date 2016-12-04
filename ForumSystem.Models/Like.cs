using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Models
{
   public class Like:BaseModel
    {
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }
    }
}
