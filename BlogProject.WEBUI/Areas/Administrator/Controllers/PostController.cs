using BlogProject.CORE.Service;
using BlogProject.MODEL.Entities;
using BlogProject.WEBUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WEBUI.Areas.Administrator.Controllers
{
    [Area("Administrator"), Authorize]
    public class PostController : Controller
    {
        private IHostingEnvironment _hostingEnv;
        private readonly ICoreService<Post> _ps;
        private readonly ICoreService<Category> _cs;

        public PostController(ICoreService<Post> ps, IHostingEnvironment hostingEnv, ICoreService<Category> cs)
        {
            _cs = cs;
            _hostingEnv = hostingEnv;
            this._ps = ps;
        }

        public IActionResult Index()
        {
            return View(_ps.GetAll());
        }

        public IActionResult Insert()
        {
            ViewBag.Categories = new SelectList(_cs.GetActive(), "ID", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Post item, List<IFormFile> files)
        {
            ViewBag.Categories = new SelectList(_cs.GetActive(), "ID", "CategoryName");

            item.UserID = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "ID").Value);
            item.ViewCount = 0;

            string imgPath = Upload.ImageUpload(files, _hostingEnv, out bool imgResult);
            if (imgResult)
                item.ImagePath = imgPath;
            else
            {
                ViewBag.Message = "Resim yükleme sırasında bir hata oluştu!";
                return View(item);
            }

            if (ModelState.IsValid)
            {
                bool addingResult = _ps.Add(item);

                if (addingResult)
                    return RedirectToAction("Index");
                else
                    ViewBag.Message = "Kayıt işlemi sırasında bir hata oluştu! Lütfen tüm alanları kontrol edip tekrar deneyin!";
            }
            else
                ViewBag.Message = "İşlem başarısız oldu! Lütfen tüm alanları kontrol edin!";
            
            return View(item);
        }

        public IActionResult Activate(Guid id)
        {
            _ps.Activate(id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            Post silinecek = _ps.GetByID(id);
            _ps.Remove(silinecek);

            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            ViewBag.Categories = new SelectList(_cs.GetActive(), "ID", "CategoryName");

            return View(_ps.GetByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Post item, List<IFormFile> files)
        {
            ViewBag.Categories = new SelectList(_cs.GetActive(), "ID", "CategoryName");

            //item.UserID = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "ID").Value);
            Post updated = _ps.GetByID(item.ID);
            updated.Title = item.Title;
            updated.PostDetail = item.PostDetail;
            updated.Tags = item.Tags;

            string imgPath = Upload.ImageUpload(files, _hostingEnv, out bool imgResult);
            if (imgResult)
                updated.ImagePath = imgPath;
            else
            {
                ViewBag.Message = "Resim yükleme sırasında bir hata oluştu!";
                return View(updated);
            }

            if (ModelState.IsValid)
            {
                bool addingResult = _ps.Update(updated);

                if (addingResult)
                    return RedirectToAction("Index");
                else
                    ViewBag.Message = "Kayıt işlemi sırasında bir hata oluştu! Lütfen tüm alanları kontrol edip tekrar deneyin!";
            }
            else
                ViewBag.Message = "İşlem başarısız oldu! Lütfen tüm alanları kontrol edin!";

            return View(updated);
        }
    }
}
