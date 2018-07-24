using System.Data.Entity;
using hzcl.OA.Model;

namespace hzcl.OA.IDAL
{
    public interface IDBSession
    {
        DbContext DbContext { get; }
        IUserInfoDal UserInfoDal { get; set; }
        bool SaveChanges();
    }
}