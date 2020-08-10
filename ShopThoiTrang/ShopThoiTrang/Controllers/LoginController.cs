using ShopThoiTrang.Areas.Admin.Models;
using ShopThoiTrang.Common;
using ShopThoiTrang.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NguoiDungModel();
                var result = dao.Login(model.username, model.password);
                if (result)
                {
                    //var user = dao.getByUsername(model.username);
                    //var user_session = new UserLogin();
                    //user_session.UserName = user.username;
                    //user_session.UserID = user.MaNguoiDung;
                    //user_session.FullName = user.TenNguoiDung;
                    //Session.Add(CommomConstants.USER_SESSION, user_session);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Incorrect!");
                }
            }
            return View("Index","Home");
        }
    }
}