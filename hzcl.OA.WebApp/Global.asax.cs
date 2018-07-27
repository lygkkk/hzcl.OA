using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using hzcl.OA.WebApp.Models;
using log4net;
using Spring.Web.Mvc;

namespace hzcl.OA.WebApp
{
    public class MvcApplication : SpringMvcApplication  //System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();//读取了配置文件中关于Log4Net配置信息.
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //开启一个线程 用于扫描错误信息 并记录
            string filePath = Server.MapPath("/Log/");
            ThreadPool.QueueUserWorkItem((a) =>
            {
                //线程不能结束 首页这里要设置一个死循环 一旦终止线程 后面的错误就不能被写入到日志了
                while (true)
                {
                    //判断队列中是否有数据
                    if (MyExceptionAttribute.ExceptionQueue.Count() > 0)
                    {
                        Exception ex = MyExceptionAttribute.ExceptionQueue.Dequeue();
                        if (ex != null)
                        {
                            //string fileName = DateTime.Now.ToString("yyyy-MM-dd");
                            //File.AppendAllText(filePath + fileName + ".txt", ex.ToString(), Encoding.UTF8);
                            ILog logger = LogManager.GetLogger("errorMsg");
                            logger.Error(ex.ToString());
                        }
                        else
                        {
                            //很关键 因为队列中没有数据 就让线程休息3秒 免得浪费CPU执行这个线程 因为有可能10分钟也不会有错误
                            Thread.Sleep(3000);
                        }
                    }
                    else
                    {
                        //很关键 因为队列中没有数据 就让线程休息3秒 免得浪费CPU执行这个线程 因为有可能10分钟也不会有错误
                        Thread.Sleep(3000);
                    }
                }
            }, filePath);
        }
    }
}
