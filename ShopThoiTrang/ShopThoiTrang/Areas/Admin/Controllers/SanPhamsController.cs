using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Common;
using ShopThoiTrang.Framework;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class SanPhamsController : BaseController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/SanPhams
        
        //public ActionResult Index(string searchstring, string field)
        //{
        //    var ss = (UserLogin)Session[CommomConstants.USER_SESSION];
        //    ViewBag.username = ss.UserName;
        //    ViewBag.fullname = ss.FullName;

        //    ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai");

        //    var sanPhams = db.SanPhams.Include(s => s.Loai);
        //    return View(sanPhams.ToList());
        //}

        public ActionResult Index()
        {
            //var ss = (UserLogin)Session[CommomConstants.USER_SESSION];
            //ViewBag.username = ss.UserName;
            //ViewBag.fullname = ss.FullName;

            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai");

            var sanPhams = db.SanPhams.Include(s => s.Loai);
            return View(sanPhams.ToList());
        }
        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.img = sanPham.Anh;
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai");
            return View();
        }

        // POST: Admin/SanPhams/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,MaLoai,TenSanPham,Gia,SoLuong,Anh,ThongTin")] SanPham sanPham, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    //file.SaveAs(HttpContext.Server.MapPath("~/Content/ProductImages/") + file.FileName);
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/ProductImages/"), filename);
                    // file is uploaded
                   file.SaveAs(path);
                    sanPham.Anh = filename;
                }
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Create Product Error!");
            }
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,MaLoai,TenSanPham,Gia,SoLuong,ThongTin,Anh")] SanPham sanPham, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                if (file != null)
                {
                    //file.SaveAs(HttpContext.Server.MapPath("~/Content/ProductImages/") + file.FileName);
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/ProductImages/"), filename);
                    // file is uploaded
                    file.SaveAs(path);
                    sanPham.Anh = filename;
                }
                //db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.Loais, "MaLoai", "TenLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
