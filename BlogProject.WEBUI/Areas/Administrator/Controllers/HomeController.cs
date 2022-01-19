using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WEBUI.Areas.Administrator.Controllers
{
    [Area("Administrator"), Authorize]
    public class HomeController : Controller
    {
        private readonly ICoreService<Post> _ps;
        private readonly ICoreService<Category> _cs;
        private readonly ICoreService<User> _us;
        private readonly ICoreService<Comment> _cms;

        public HomeController(ICoreService<Post> ps, ICoreService<Category> cs, ICoreService<User> us, ICoreService<Comment> cms)
        {
            _ps = ps;
            _cs = cs;
            _cms = cms;
            _us = us;
        }
        public IActionResult Index()
        {
            return View(Tuple.Create<List<Post>, List<User>, List<Category>, List<Comment>>(_ps.GetActive(), _us.GetActive(), _cs.GetActive(), _cms.GetActive()));
        }
    }
}
