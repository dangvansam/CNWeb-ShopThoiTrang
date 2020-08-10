using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Areas.Admin.Code
{
    public class SessionHelper
    {
        public static void SetSession(UserSession ss)
        {
            HttpContext.Current.Session["loginSession"] = ss;
        }
        public static UserSession GetSession()
        {
            var ss = HttpContext.Current.Session["loginSession"];
            if (ss == null)
            {
                return null;
            }
            else
            {
                return ss as UserSession;
            }
        }
        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();

        }
    }
}