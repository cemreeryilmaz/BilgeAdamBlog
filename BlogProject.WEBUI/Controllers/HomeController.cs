using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using BlogProject.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WEBUI.Controllers
{
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
            ViewBag.SonYazilar = _ps.GetDefault(x => x.CreatedDate.Value.Year == DateTime.Now.Year).Take(2); // Geçerli tarihin yılı ile aynı yılda yazılmış Post'lardan ilk ikisini almak için
            ViewBag.Kategoriler = _cs.GetActive(); // Kategorileri almıp Index'te sağ alanda göstermek için.

            return View(Tuple.Create<List<Post>, List <User> , List<Category>, List<Comment>>(_ps.GetActive(), _us.GetActive(), _cs.GetActive(), _cms.GetActive()));
        }

        public PartialViewResult BannerPartial()
        {
            return PartialView("/PartialViews/_BannerPartial", _ps.GetActive().OrderByDescending(x => x.CreatedDate).Take(6));
        }


        






















        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
