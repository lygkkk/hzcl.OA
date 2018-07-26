using System.Collections.Generic;
using hzcl.OA.Model;

namespace hzcl.OA.IBLL
{
    public interface IUserInfoService :IBaseService<userinfo>
    {
        //删除多条记录 当作特有的方法 所以写在了 这个接口里 否则就要写到 IBaseService 基类接口
        bool DeleteTntities(List<int> list);
    }
}