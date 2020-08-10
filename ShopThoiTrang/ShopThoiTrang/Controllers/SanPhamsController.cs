using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Framework;

namespace ShopThoiTrang.Controllers
{
    public class SanPhamsController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: SanPhams
        public ActionResult Index()
        {
            //var fnLoai = new LoaiModel();
            List<Loai> listl = db.Loais.ToList();
            ViewBag.listloai = listl;
            var fnSanPham = new SanPhamModel();
            var listsp = new List<SanPham>();
            
            listsp = fnSanPham.getAllSanPham();
            return View(listsp);
        }

        public ActionResult Loai(int maloai)
        {
            //var fnLoai = new LoaiModel();
            //List<Loai> listl = db.Loais.ToList();
            //ViewBag.listloai = listl;
            var fnSanPham = new SanPhamModel();
            List<SanPham> listsp = fnSanPham.getAllSanPhamByLoai(maloai);
            return View(listsp);
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int id)
        {
            var fnSanPham = new SanPhamModel();
            var sanPham = fnSanPham.getSanPhamByID(id);
            return View(sanPham);
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
