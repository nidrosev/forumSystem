using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ForumSystem.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  CommentContent { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserName { get; set; }
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
    }
}