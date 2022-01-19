using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WEBUI.Controllers
{
    public class PostController : Controller
    {
        private readonly ICoreService<Post> _ps;
        private readonly ICoreService<Category> _cs;
        private readonly ICoreService<User> _us;
        private readonly ICoreService<Comment> _cms;

        public PostController(ICoreService<Post> ps, ICoreService<Category> cs, ICoreService<User> us, ICoreService<Comment> cms)
        {
            _ps = ps;
            _cs = cs;
            _cms = cms;
            _us = us;
        }
        public IActionResult Index()
        {
            ViewBag.SonYazilar = _ps.GetActive().OrderByDescending(x => x.CreatedDate).Take(3); // CreatedDate'e göre desc olarak sıralanıp ilk 3 tanesini almak için.
            ViewBag.Kategoriler = _cs.GetActive(); // Kategorileri almıp Index'te sağ alanda göstermek için.
            return View(_ps.GetActive());
        }

        [HttpGet]
        public IActionResult PostDetail(Guid id)
        {
            Post post = _ps.GetByID(id);
            //post.ViewCount++;
            //_ps.Update(post);

            User user = _us.GetByID(post.UserID);
            List<Comment> cmtList = _cms.GetDefault(x => x.Post.ID == post.ID).ToList();
            Category category = _cs.GetByID(post.CategoryID);

            return View(Tuple.Create<Post, User, List<Comment>, Category, Comment>(post, user, cmtList, category, new Comment()));
        }
        [HttpPost]
        public IActionResult AddComment(Comment cmt)
        {
            Comment comment = cmt;
            _cms.Add(comment);

            return RedirectToAction("PostDetail", cmt.PostID);
        }
    }
}
