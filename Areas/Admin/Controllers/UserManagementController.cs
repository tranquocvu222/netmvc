using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Common;
using PagedList;

namespace WebShop.Areas.Admin.Controllers
{
    public class UserManagementController : BaseController
    {
        // GET: Admin/UserManagement
        public ActionResult Index(string search, int page =1, int pageSize =8)
        {
            var dao = new UserDao();
            var model = dao.GetAllUser(search, page, pageSize);
            ViewBag.SearchString = search;
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new UserDao();
            var user = dao.GetById(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                bool rs = dao.Update(user);
                if (rs)
                {
                    return RedirectToAction("Index", "UserManagement");
                }
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
               
                var dao = new UserDao();
                user.Role = 2;
                var passMD5 = Encryptor.MD5Hash(user.Password);
                user.Password = passMD5;
                int id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "UserManagement");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm User thất bại");
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new UserDao();
            bool rs = dao.Delete(id);
            if (rs)
            {
                return RedirectToAction("Index", "UserManagement");
            }
            else
            {
                ModelState.AddModelError("", "Xóa User thất bại");
            }
            return View("Index");
        }
     

    }
}