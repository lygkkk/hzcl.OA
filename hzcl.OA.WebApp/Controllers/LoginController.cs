using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CZBK.ItcastOA.Common;
using hzcl.OA.BLL;

namespace hzcl.OA.WebApp.Controllers
{
    public class LoginController :  Controller
    {
        private IBLL.IUserInfoService userInfoService { get; set; }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        #region 验证码显示
        public ActionResult ShowValiDateCode()
        {
            //Random rd = new Random();
            //int[] k = new int[]{};
            //for (int i = 0; i < 4; i++)
            //{
            //    k[i] = rd.Next(1, 10);
            //}
            ValidateCode vdc = new ValidateCode();
            string code = vdc.CreateValidateCode(4);
            Session["ValiDateCode"] = code;
            byte[] buff = vdc.CreateValidateGraphic(code);

            return File(buff, "image/jpeg");
        }
        #endregion

        #region 完成用户登录

        public ActionResult UserLogin()
        {
            string valiDateCode = Session["ValiDateCode"] != null ? Session["ValiDateCode"].ToString() : String.Empty;
            if (string.IsNullOrEmpty(valiDateCode))
            {
                return Content("no:验证码错误");
            }
            Session["ValiDateCode"] = null;
            string txtCode = Request["vCode"];
            if (!valiDateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误");
            }

            string userName = Request["UserName"];
            string userPass = Request["UserPass"];
            var userInfo = userInfoService.LoadEntities(u =>

                u.UserName == userName && u.UserPass == userPass
            ).FirstOrDefault();
            if (userInfo != null)
            {
                Session["userInfo"] = userInfo;
                return Content("ok:登录成功");
            }
            else
            {
                return Content("no:登录失败");
            }
        }

        #endregion
    }
}