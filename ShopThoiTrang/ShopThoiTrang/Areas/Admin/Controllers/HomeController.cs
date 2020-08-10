using ShopThoiTrang.Areas.Admin.Code;
using ShopThoiTrang.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var ss = (UserLogin)Session[CommomConstants.USER_SESSION];
            ViewBag.username = ss.UserName;
            ViewBag.fullname = ss.FullName;
            return View();
        }
        public ActionResult Logout()
        {
            SessionHelper.ClearSession();
            return RedirectToAction("Index", "Login");
        }
    }
}