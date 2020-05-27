using RightControl.Common;
using RightControl.Model.Init;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RightControl.Repository.DBHeper
{
    public class Application
    {

        private static ConcurrentDictionary<int, DbConnection> dicConfig = new ConcurrentDictionary<int, DbConnection>();
        private static object obj = new object();
        private static SemaphoreSlim slim = new SemaphoreSlim(1);

        private static DBConfig DbConfig
        {
            get
            {
                return ConfigHelper.Get<DBConfig>("dbConfig");
            }
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetDbConnection()
        {
            if (dicConfig.ContainsKey(DbConfig.Type))
            {
                return dicConfig[DbConfig.Type];
            }

            slim.Wait();
            DbConnection connection = null;
            if (connection == null)
            {
                switch (DbConfig.Type)
                {
                    case 1:
                        connection = MySqlHelper.GetConnection();
                        break;
                    case 2:
                        connection = SqlHelper.GetConnection();
                        break;
                }
            }

            if (!dicConfig.ContainsKey(DbConfig.Type))
            {
                dicConfig.TryAdd(DbConfig.Type, connection);
            }
            slim.Release();

            return connection;
        }
    }
}
