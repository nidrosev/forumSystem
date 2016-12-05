using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.ViewModels
{
    public class ThemeViewModel
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public string  Content { get; set; }
        public DateTime? CreatedOn { get; set; }
      //  public string SubHeader { get; set; }
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}