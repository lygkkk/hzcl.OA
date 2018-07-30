using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hzcl.OA.WebApp.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 先执行与 控制器之前
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["userInfo"] == null)
            {
                //filterContext.HttpContext.Response.Redirect("/Login/Index");
                filterContext.Result  = Redirect("/Login/Index");
            }
        }
    }
}