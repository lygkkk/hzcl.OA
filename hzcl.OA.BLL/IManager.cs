 
using hzcl.OA.IBLL;
using hzcl.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hzcl.OA.BLL
{
	
	public partial class ActionInfoService :BaseService<ActionInfo>,IActionInfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDbSession.ActionInfoDal;
        }
    }   
	
	public partial class DepartMentService :BaseService<DepartMent>,IDepartMentService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDbSession.DepartMentDal;
        }
    }   
	
	public partial class R_UserInfo_ActionInfoService :BaseService<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDbSession.R_UserInfo_ActionInfoDal;
        }
    }   
	
	public partial class RoleInfoService :BaseService<RoleInfo>,IRoleInfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDbSession.RoleInfoDal;
        }
    }   
	
	public partial class UserInfoService :BaseService<userinfo>,IUserInfoService
    {
    

		 public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDbSession.UserInfoDal;
        }
    }   
	
}