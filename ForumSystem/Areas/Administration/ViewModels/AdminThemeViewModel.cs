using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.Areas.Administration.ViewModels
{
    public class AdminThemeViewModel
    {
        public AdminThemeViewModel()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Content { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}