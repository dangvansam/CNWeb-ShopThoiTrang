using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Framework
{
    public class SanPhamModel
    {
        private ShopDbContext context = null;
        public SanPhamModel()
        {
            context = new ShopDbContext();
        }
        public List<SanPham> getAllSanPhamByLoai(int? maloai)
        {
            List<SanPham> products = context.SanPhams.Where(x => x.MaLoai == maloai).ToList();
            return products;
        }
        public List<SanPham> getAllSanPham()
        {
            var sanPhams = context.SanPhams.ToList();
            return sanPhams;
        }
        public SanPham getSanPhamByID(int masp)
        {
            var sanPham = context.SanPhams.Where(x => x.MaSanPham == masp).FirstOrDefault();
            return sanPham;
        }
    }
}