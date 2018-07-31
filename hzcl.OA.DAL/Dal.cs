 

using hzcl.OA.IDAL;
using hzcl.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hzcl.OA.DAL
{
		
	public partial class ActionInfoDal :BaseDal<ActionInfo>,IActionInfoDal
    {

    }
		
	public partial class DepartMentDal :BaseDal<DepartMent>,IDepartMentDal
    {

    }
		
	public partial class RoleInfoDal :BaseDal<RoleInfo>,IRoleInfoDal
    {

    }
		
	public partial class R_UserInfo_ActionInfoDal :BaseDal<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoDal
    {

    }
		
	public partial class UserInfoDal :BaseDal<userinfo>,IUserInfoDal
    {

    }
	
}