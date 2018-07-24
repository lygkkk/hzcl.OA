using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using hzcl.OA.Model;

namespace hzcl.OA.DAL
{
    /// <summary>
    /// 负责创建EF数据操作上下文实例，必须保证线程内唯一
    /// </summary>
    public class DBContextFactory
    {
        public static DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext) CallContext.GetData("DbContext");
            if (dbContext == null)
            {
                dbContext = new hzclEntities();
                CallContext.SetData("DbContext", dbContext);
            }

            return dbContext;
        }
    }
}