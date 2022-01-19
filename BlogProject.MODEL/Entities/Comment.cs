using BlogProject.CORE.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.MODEL.Entities
{
    public class Comment : CoreEntity
    {
        public string CommentText { get; set; }

        public Guid UserID { get; set; }
        public Guid PostID { get; set; }

        // Navigation Property
        // Comment'in User'ı
        public virtual User User { get; set; }
        // Comment'in Post'u
        public virtual Post Post { get; set; }

    }
}
