using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightControl.Model.Init
{

    /// <summary>
    /// 数据库配置信息
    /// </summary>
    public class DBConfig
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 是否创建数据库
        /// </summary>
        public bool CreateDb { get; set; }
    }
}
