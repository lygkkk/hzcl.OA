using System.Configuration;
using System.Reflection;
using hzcl.OA.IDAL;

namespace hzcl.OA.DALFactory
{
    /// <summary>
    /// 通过反射创建类的实例
    /// </summary>
    public class AbstractFactory
    {
        private static readonly string Assemblypath = ConfigurationManager.AppSettings["Assemblypath"];
        private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];

        public static IUserInfoDal CreateUserInfoDal()
        {
            string fullClassName = NameSpace + ".UserInfoDal";
            return CreateInstance(fullClassName) as IUserInfoDal;
        }

        private static object CreateInstance(string classNmae)
        {
            var assembly = Assembly.Load(Assemblypath);
            return assembly.CreateInstance(classNmae);
        }
    }
}