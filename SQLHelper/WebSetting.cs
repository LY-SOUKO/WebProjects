using EastSim.Utility.StringHelper;
using SQLHelper.Webs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHelper
{
    /// <summary>
    /// 配置文件系统设定
    /// </summary>
    public static partial class WebSetting
    {

        static WebSetting()
        {
            var basePath = ConstValues.WebRootRealPath;

            var RootConfigFilePath = Path.Combine(basePath, "Web.config");

            DefaultPage = ConfigHelper.GetConfigValue(RootConfigFilePath, "DefaultPage");
            
        }
        /// <summary>
        /// 默认首页地址
        /// </summary>
        public static string DefaultPage { get; }
    }
}
