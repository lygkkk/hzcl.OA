 
using hzcl.OA.DAL;
using hzcl.OA.IDAL;
using hzcl.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hzcl.OA.DALFactory
{
	public partial class DBSession : IDBSession
    {
	
		private IActionInfoDal _ActionInfoDal;
        public IActionInfoDal ActionInfoDal
        {
            get
            {
                if(_ActionInfoDal == null)
                {
                    _ActionInfoDal = AbstractFactory.CreateActionInfoDal();
                }
                return _ActionInfoDal;
            }
            set { _ActionInfoDal = value; }
        }
	
		private IDepartMentDal _DepartMentDal;
        public IDepartMentDal DepartMentDal
        {
            get
            {
                if(_DepartMentDal == null)
                {
                    _DepartMentDal = AbstractFactory.CreateDepartMentDal();
                }
                return _DepartMentDal;
            }
            set { _DepartMentDal = value; }
        }
	
		private IR_UserInfo_ActionInfoDal _R_UserInfo_ActionInfoDal;
        public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal
        {
            get
            {
                if(_R_UserInfo_ActionInfoDal == null)
                {
                    _R_UserInfo_ActionInfoDal = AbstractFactory.CreateR_UserInfo_ActionInfoDal();
                }
                return _R_UserInfo_ActionInfoDal;
            }
            set { _R_UserInfo_ActionInfoDal = value; }
        }
	
		private IRoleInfoDal _RoleInfoDal;
        public IRoleInfoDal RoleInfoDal
        {
            get
            {
                if(_RoleInfoDal == null)
                {
                    _RoleInfoDal = AbstractFactory.CreateRoleInfoDal();
                }
                return _RoleInfoDal;
            }
            set { _RoleInfoDal = value; }
        }
	
		private IUserInfoDal _userinfoDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if(_userinfoDal == null)
                {
                    _userinfoDal = AbstractFactory.CreateuserinfoDal();
                }
                return _userinfoDal;
            }
            set { _userinfoDal = value; }
        }
	}	
}