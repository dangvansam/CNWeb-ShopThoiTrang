using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Framework
{
    public class NguoiDungModel
    {
        private ShopDbContext context = null;
        public NguoiDungModel()
        {
            context = new ShopDbContext();
        }
         
        public bool Login(string username, string password)
        {
            var result = context.NguoiDungs.Count(x => x.username == username && x.password == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public NguoiDung getByUsername(string username)
        {
            return context.NguoiDungs.SingleOrDefault(x => x.username == username);
        }
        //public int Login(string username, string password)
        //{
        //    object[] sqlParams ={
        //        new SqlParameter("@username", username),
        //        new SqlParameter("password", password),};
        //    var res = context.Database.SqlQuery<int>("Sp_Login @username, @password", sqlParams).SingleOrDefault();
        //    return res;
        //}
        public NguoiDung getNguoiDung(string username)
        {
            object[] sqlParams ={
                new SqlParameter("@username", username)};
            var res = context.Database.SqlQuery<NguoiDung>("select * from NguoiDung where username=@username", sqlParams).SingleOrDefault();
            return res;

        }
    }
}