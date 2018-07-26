using System.Collections.Generic;
using hzcl.OA.DALFactory;
using hzcl.OA.IBLL;
using hzcl.OA.IDAL;
using hzcl.OA.Model;

namespace hzcl.OA.BLL
{
    public class UserInfoService : BaseService<userinfo>, IUserInfoService
    {
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="list">要删除的ID列表</param>
        /// <returns>返回一个布尔值</returns>
        public bool DeleteTntities(List<int> list)
        {
            var userInfoList = this.CurrentDbSession.UserInfoDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var userInfo in userInfoList)
            {
                this.CurrentDbSession.UserInfoDal.DeleteEntity(userInfo);
            }

            return this.CurrentDbSession.SaveChanges();
        }

        public override void SetCurrentDal()
        {
            CurrentDal = this.CurrentDbSession.UserInfoDal;
        }
    }
}