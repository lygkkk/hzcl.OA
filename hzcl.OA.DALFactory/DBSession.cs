using System.Data.Entity;
using hzcl.OA.DAL;
using hzcl.OA.IDAL;
using hzcl.OA.Model;

namespace hzcl.OA.DALFactory
{
    /// <summary>
    /// 数据会话层 就是一个工厂类
    /// </summary>
    public partial class DBSession : IDBSession
    {

        //hzclEntities db = new hzclEntities();
        //private IUserInfoDal _userInfoDal;

        public DbContext DbContext
        {
            get
            {
                return DAL.DBContextFactory.CreateDbContext();
            } 
        }

        //public IUserInfoDal UserInfoDal
        //{
        //    get
        //    {
        //        if (_userInfoDal == null)
        //        {
        //            //_userInfoDal = new UserInfoDal();
        //            _userInfoDal = AbstractFactory.CreateUserInfoDal();

        //        }

        //        return _userInfoDal;
        //    }

        //    set { _userInfoDal = value; }
        //}

        public bool SaveChanges()
        {
            return DbContext.SaveChanges() > 0;
        }
    }
}