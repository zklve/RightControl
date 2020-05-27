using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RightControl.Common
{
    /// <summary>
    /// 配置文件读取类
    /// </summary>
    public class ConfigHelper
    {
        private static ConfigHelper sington = null;
        private static readonly object obj = new object();

        private ConfigHelper()
        {

        }

        public ConfigHelper GetSingtonInstance()
        {
            if(sington == null)
            {
                lock (obj)
                {
                    if (sington == null)
                    {
                        sington = new ConfigHelper();
                    }
                }
            }
            return sington;
        }

        /// <summary>
        /// 读取配置文件信息 默认configs文件夹 下Json文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="envPath">所属文件夹</param>
        /// <param name="fileExtension">文件扩展名</param>
        /// <returns></returns>
        public static T Get<T>(string fileName,string envPath ="configs",string fileExtension = "json")
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, envPath);
            if (!Directory.Exists(filePath))
                return default(T);
            var builder = new ConfigurationBuilder()
                .SetBasePath(filePath)
                .AddJsonFile($" {filePath}.{fileExtension}");
            IConfiguration config = builder.Build();
            return config.Get<T>();
        }
    }
}
