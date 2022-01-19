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
    public class CategoryController : Controller
    {
        private readonly ICoreService<Category> _cs;
        public CategoryController(ICoreService<Category> cs)
        {
            _cs = cs;
        }
        public IActionResult Index()
        {
            return View(_cs.GetAll());
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Category item)
        {
            if (ModelState.IsValid)
            {
                bool result = _cs.Add(item);

                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Kayıt işlemi sırasında bir hata meydana geldi. Lütfen tüm alanları kontrol edip tekrar deneyin!";
                }
            }
            else
            {
                TempData["Message"] = "İşlem başarısız oldu!. Lütfen tüm alanları kontrol edin ve tekrar deneyin!";
            }
            return View(item);
        }

        public IActionResult Activate(Guid id)
        {
            _cs.Activate(id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            Category silinecek = _cs.GetByID(id);
            _cs.Remove(silinecek);

            //_cs.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            return View(_cs.GetByID(id));
        }

        [HttpPost]
        public IActionResult Update(Category item)
        {
            if (ModelState.IsValid)
            {
                Category updatedCategory = _cs.GetByID(item.ID);
                updatedCategory.CategoryName = item.CategoryName;
                updatedCategory.Description = item.Description;

                bool result = _cs.Update(updatedCategory);

                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Message"] = "Güncelleme işlemi sırasında bir hata meydana geldi. Lütfen tüm alanları kontrol edip tekrar deneyin!";
                }
            }
            else
            {
                TempData["Message"] = "İşlem başarısız oldu! Lütfen tüm alanları kontrol edin ve tekrar deneyin!";
            }
            return View(item);
        }
    }
}
