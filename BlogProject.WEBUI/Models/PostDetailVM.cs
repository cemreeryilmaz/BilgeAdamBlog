using BlogProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WEBUI.Models
{
    public class PostDetailVM
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment NewComment { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }

    }
}
