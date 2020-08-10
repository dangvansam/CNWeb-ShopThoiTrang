using ShopThoiTrang.Common;
using ShopThoiTrang.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class LoaiController : BaseController
    {
        // GET: Admin/Loai
        [HttpGet]
        public ActionResult Index()
        {
            var ss = (UserLogin)Session[CommomConstants.USER_SESSION];
            ViewBag.username = ss.UserName;
            ViewBag.fullname = ss.FullName;

            var fnLoai = new LoaiModel();
            var model = fnLoai.ListAll();
            return View(model);
        }

        // GET: Admin/Loai/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var fnLoai = new LoaiModel();
            var l = fnLoai.getByID(id);
            return View(l);
        }

        // GET: Admin/Loai/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Loai/Create
        [HttpPost]
        public ActionResult Create(Loai _loai)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fnLoai = new LoaiModel();
                    int id = fnLoai.Create(_loai);
                    if (id > 0)
                    {
                            return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create Error!");
                    }
                }
                return View(_loai);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Loai/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var fnLoai = new LoaiModel();
            var l = fnLoai.getByID(id);
            return View(l);
        }

        // POST: Admin/Loai/Edit/5
        [HttpPost]
        public ActionResult Edit(Loai _loai)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fnLoai = new LoaiModel();
                    int res = fnLoai.Update(_loai);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update Error!");
                    }
                }else
                {
                    return View(_loai);
                }

            }
            catch
            {
                return View();
            }
            return View();
        }

        // POST: Admin/Loai/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new LoaiModel().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
