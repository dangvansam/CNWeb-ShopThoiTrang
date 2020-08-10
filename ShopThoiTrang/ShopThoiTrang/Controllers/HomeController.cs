using ShopThoiTrang.Common;
using ShopThoiTrang.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Controllers
{
    public class HomeController : Controller
    {
        private ShopDbContext db = new ShopDbContext();
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                ViewBag.username = Session["username"];
                ViewBag.fullname = Session["fullname"];
                ViewBag.id = Session["id"];
            }
            var fnSanPham = new SanPhamModel();
            List<SanPham> listsp = fnSanPham.getAllSanPham();
            return View(listsp);
        }

        public ActionResult Category()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(NguoiDung _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.NguoiDungs.FirstOrDefault(s => s.username == _user.username);
                if (check == null)
                {
                    //_user.password = GetMD5(_user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    _user.LoaiNguoiDung = 0;
                    db.NguoiDungs.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("","Username Already Exists!");
                    return View();
                }

            }
            return View();


        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var data = db.NguoiDungs.Where(s => s.username.Equals(username) && s.password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().TenNguoiDung;
                    Session["username"] = data.FirstOrDefault().username;
                    Session["id"] = data.FirstOrDefault().MaNguoiDung;
                    if(data.FirstOrDefault().LoaiNguoiDung == 0)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        var dao = new NguoiDungModel();
                        var user = dao.getByUsername(data.FirstOrDefault().username);
                        var user_session = new UserLogin();
                        user_session.UserName = data.FirstOrDefault().username;
                        user_session.UserID = data.FirstOrDefault().MaNguoiDung;
                        user_session.FullName = data.FirstOrDefault().TenNguoiDung;
                        Session.Add(CommomConstants.USER_SESSION, user_session);
                        return RedirectToAction("Index", "Home","Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Incorrect!");
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

    }
}