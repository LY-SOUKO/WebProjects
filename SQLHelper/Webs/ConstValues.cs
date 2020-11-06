using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SQLHelper.Webs
{
    /// <summary>
    /// 网站常量及运行时常量
    /// </summary>
    public static class ConstValues
    {
        static ConstValues()
        {
            WebRootRealPath = HttpRuntime.AppDomainAppPath;
        }

        /// <summary>
        /// 网站物理路径
        /// </summary>
        public static readonly string WebRootRealPath;
        
    }
}
