 

using hzcl.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hzcl.OA.DALFactory
{
    public partial class AbstractFactory
    {
      
   
		
	    public static IActionInfoDal CreateActionInfoDal()
        {

		 string fullClassName = NameSpace + ".ActionInfoDal";
          return CreateInstance(fullClassName) as IActionInfoDal;

        }
		
	    public static IDepartMentDal CreateDepartMentDal()
        {

		 string fullClassName = NameSpace + ".DepartMentDal";
          return CreateInstance(fullClassName) as IDepartMentDal;

        }
		
	    public static IR_UserInfo_ActionInfoDal CreateR_UserInfo_ActionInfoDal()
        {

		 string fullClassName = NameSpace + ".R_UserInfo_ActionInfoDal";
          return CreateInstance(fullClassName) as IR_UserInfo_ActionInfoDal;

        }
		
	    public static IRoleInfoDal CreateRoleInfoDal()
        {

		 string fullClassName = NameSpace + ".RoleInfoDal";
          return CreateInstance(fullClassName) as IRoleInfoDal;

        }
		
	    public static IUserInfoDal CreateuserinfoDal()
        {

		 string fullClassName = NameSpace + ".UserInfoDal";
          return CreateInstance(fullClassName) as IUserInfoDal;

        }
	}
	
}