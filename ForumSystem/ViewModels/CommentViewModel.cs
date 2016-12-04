using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ForumSystem.ViewModels
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {
            this.Likes = new HashSet<Like>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string  CommentContent { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public int AuthorId { get; set; }
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}

