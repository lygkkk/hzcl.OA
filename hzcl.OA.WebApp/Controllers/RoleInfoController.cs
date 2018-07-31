using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hzcl.OA.Model.EnumType;

namespace hzcl.OA.WebApp.Controllers
{
    public class RoleInfoController : Controller
    {
        private IBLL.IRoleInfoService RoleInfoService { get; set; }
        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }


        #region 获取角色列表
        public ActionResult GetRoleInfoList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int pageCount;

            short delFlag = (short) DeleteEnumType.Normarl;
            var roleInfo = RoleInfoService.LoadPageEntities(pageIndex, pageSize, out pageCount,
                u => u.DelFlag == delFlag, u => u.ID, true);
            var temp = from u in roleInfo
                select new
                {
                    ID = u.ID,
                    RoleName = u.RoleName,
                    Sort = u.sort,
                    RegTime = u.RegTime,
                    Remark =u.Remark
                };
            return Json(new {rows = temp, total = pageCount}, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}