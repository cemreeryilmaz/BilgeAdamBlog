using BlogProject.CORE.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.MODEL.Entities
{
    public class User : CoreEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public string LastIPAddress { get; set; }
        public bool IsAdmin { get; set; }

        // Navigation Properties
        // User'ın Post'ları
        public virtual List<Post> Posts { get; set; }
        // User'ın Comment'leri
        public virtual List<Comment> Comments { get; set; }
    }
}
