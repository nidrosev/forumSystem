using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ForumSystem.Models
{
    public class Theme : BaseModel
    {
        public Theme()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }
       
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
