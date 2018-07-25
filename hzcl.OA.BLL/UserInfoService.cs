using hzcl.OA.DALFactory;
using hzcl.OA.IBLL;
using hzcl.OA.IDAL;
using hzcl.OA.Model;

namespace hzcl.OA.BLL
{
    public class UserInfoService : BaseService<userinfo>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDbSession.UserInfoDal;
        }
    }
}