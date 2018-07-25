using System.Runtime.Remoting.Messaging;
using hzcl.OA.IDAL;

namespace hzcl.OA.DALFactory
{
    public class DBSessionFactory
    {
        public static IDBSession CreateDbSession()
        {
            IDBSession dbSession = (IDBSession) CallContext.GetData("dbsession");

            if (dbSession == null)
            {
                dbSession = new DALFactory.DBSession();
                CallContext.SetData("dbsession", dbSession);
            }

            return dbSession;
        }
    }
}