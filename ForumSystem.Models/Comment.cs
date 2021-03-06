﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Models
{
    public class Comment:BaseModel
    {
        public Comment()
        {
            this.Likes = new HashSet<Like>();
        }

        [Required]
        public string CommentContent { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }
        public int ThemeId { get; set; }
        public virtual Theme Theme { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
