using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hzcl.OA.BLL;
using hzcl.OA.Model;
using hzcl.OA.Model.EnumType;
using Newtonsoft.Json;

namespace hzcl.OA.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        IBLL.IUserInfoService userInfoService = new UserInfoService();
        public ActionResult Index()
        {
            //bll.LoadEntities(c => c.)
            return View();
        }

        #region 获取用户列表信息

        public ActionResult GetUserInfoList()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int pageCount;
            short DelFlag = (short)DeleteEnumType.Normarl;
            var userInfoList =  userInfoService.LoadPageEntities<int>(pageIndex, pageSize, out pageCount, c => c.DelFlag == DelFlag,
                c => c.ID, true);
            var temp = from u in userInfoList
                select new
                {
                    ID = u.ID,
                    UserName = u.UserName,
                    UserPass = u.UserPass,
                    Remark = u.Remark,
                    RegTime = u.RegTime
                };
            return Json(new {rows = temp, total = pageCount});
        }

        #endregion

        #region 删除用户书记录

        public ActionResult DeleteUserInfo()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (string s in strIds)
            {
                list.Add(Convert.ToInt32(s));
            }

            if (userInfoService.DeleteTntities(list))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }

        }

        #endregion

        #region 添加用户信息

        public ActionResult AddUserInfo(userinfo userinfo)
        {
            userinfo.DelFlag = 0;
            userinfo.RegTime = DateTime.Now;
            userinfo.Modified = DateTime.Now;
            userInfoService.AddEntity(userinfo);
            return Content("ok");
        }

        #endregion

        #region 显示要修改的用户信息

        public ActionResult ShowEditInfo()
        {
            int id = int.Parse(Request["id"]);
            var userInfo =  userInfoService.LoadEntities(u => u.ID == id).FirstOrDefault();
            return Json(userInfo, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}