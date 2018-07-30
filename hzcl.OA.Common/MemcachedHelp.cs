using System;
using System.ComponentModel;
using Memcached.ClientLibrary;

namespace hzcl.OA.Common
{
    public class MemcachedHelp
    {
        public static readonly MemcachedClient mc = null;
        static MemcachedHelp()
        {
            string[] serverList = { "127.0.0.1:11211"};

            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverList);
            pool.InitConnections = 3;
            pool.MaxConnections = 5;
            pool.MinConnections = 3;

            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;

            pool.MaintenanceSleep = 30;
            pool.Failover = true;

            pool.Nagle = false;
            pool.Initialize();

            mc = new MemcachedClient();
            mc.EnableCompression = false;
        }

        public static bool Set(string key, object val)
        {
            return mc.Set(key, val);
        }

        public static bool Set(string key, object val, DateTime dateTime)
        {
            return mc.Set(key, val, dateTime);
        }


        public static object Get(string key)
        {
            return mc.Get(key);
        }

        public static bool Delete(string key)
        {
            if (mc.KeyExists(key))
            {
                return mc.Delete(key);
            }

            return false;
        }
    }
}