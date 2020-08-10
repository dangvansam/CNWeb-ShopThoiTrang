using ShopThoiTrang.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ss = (UserLogin)Session[CommomConstants.USER_SESSION];
            if (ss == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "Index", area = "Admin" }));
                base.OnActionExecuting(filterContext);
            }
        }
    }
}