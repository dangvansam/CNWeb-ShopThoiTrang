using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Framework
{
    public class LoaiModel
    {
        private ShopDbContext context = null;
        public LoaiModel()
        {
            context = new ShopDbContext();
        }
        
        public List<Loai> ListAll()
        {
            var list = context.Database.SqlQuery<Loai>("Sp_Loai_ListAll").ToList();
            return list;
        }

        public Loai getByID(int maloai)
        {
            var loai = context.Loais.Where(l => l.MaLoai == maloai).FirstOrDefault();
            return loai;
        }
        public int Create(Loai loai)
        {
            context.Loais.Add(loai);
            context.SaveChanges();
            return loai.MaLoai;
        }
        public int Update(Loai loai)
        {
            context.Entry(loai).State = EntityState.Modified;
            int res = context.SaveChanges();
            return res;
        }
        public bool Delete(int maloai)
        {
            try
            {
                Loai l = context.Loais.Find(maloai);
                context.Loais.Remove(l);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}