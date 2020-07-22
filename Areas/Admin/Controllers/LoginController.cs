using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Areas.Admin.Models;
using Model.DAO;
using WebShop.Common;

namespace WebShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDao();
                var rs = dao.login(user.Username, Encryptor.MD5Hash(user.Password));
                if(rs == 1)
                {
                    var us = dao.GetByUserName(user.Username);
                    var userSession = new UserLogin();
                    userSession.UserName = us.Username;
                    userSession.IdUser = us.IdUser;
                    Session.Add(CommonConstants.USER_SESSION, userSession.UserName);
                    return RedirectToAction("Index", "Home");

                }
                else if(rs == 2)
                {
                    ModelState.AddModelError("", "Đăng nhập user");
                }
                else if(rs == -1)
                {
                    ModelState.AddModelError("", "Bạn nhập sai mật khẩu");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không tồn tại ");
                }
            }
        
            return View("Index");
        }
    }
}