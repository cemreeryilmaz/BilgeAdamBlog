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
    public class UserController : Controller
    {
        private readonly ICoreService<User> _us;
        public UserController(ICoreService<User> us)
        {
            _us = us;
        }
        public IActionResult Index()
        {
            return View(_us.GetAll());
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(User item)
        {
            if (ModelState.IsValid)
            {
                bool result = _us.Add(item);

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
            _us.Activate(id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            User silinecek = _us.GetByID(id);
            _us.Remove(silinecek);

            //_us.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(Guid id)
        {
            return View(_us.GetByID(id));
        }

        [HttpPost]
        public IActionResult Update(User item)
        {
            if (ModelState.IsValid)
            {
                User updatedUser = _us.GetByID(item.ID);
                updatedUser.FirstName = item.FirstName;
                updatedUser.LastName = item.LastName;
                updatedUser.Title = item.Title;
                updatedUser.EmailAddress = item.EmailAddress;
                updatedUser.Password = item.Password;
                updatedUser.ImageURL = item.ImageURL;
                updatedUser.IsAdmin = item.IsAdmin;

                bool result = _us.Update(updatedUser);

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
