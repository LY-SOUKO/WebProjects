using EastSim.Utility.StringHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SQLHelper.Webs
{
    /// <summary>
    /// 获得当前用户信息
    /// </summary>
    public static partial class CurUserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public static string Username
        {
            get { return HttpContext.Current.Session["Username"] as string; }
            internal set { HttpContext.Current.Session["Username"] = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public static string Realname
        {
            get { return HttpContext.Current.Session["Realname"] as string; }
            internal set { HttpContext.Current.Session["Realname"] = value; }
        }

        /// <summary>
        /// 单位ID
        /// </summary>
        public static string CompanyID
        {
            get { return HttpContext.Current.Session["CompanyID"] as string; }
            internal set { HttpContext.Current.Session["CompanyID"] = value; }
        }

        /// <summary>
        /// 单位名称
        /// </summary>
        public static string CompanyName
        {
            get { return HttpContext.Current.Session["CompanyName"] as string; }
            internal set { HttpContext.Current.Session["CompanyName"] = value; }
        }

        /// <summary>
        /// 客户ID
        /// </summary>
        public static int? CustomerId
        {
            get { return HttpContext.Current.Session["CustomerId"] as int?; }
            internal set { HttpContext.Current.Session["CustomerId"] = value; }
        }

        public static string CustomerToken
        {
            get { return HttpContext.Current.Session["CustomerToken"] as string; }
            internal set { HttpContext.Current.Session["CustomerToken"] = value; }
        }

        public static string RootCompany
        {
            get { return HttpContext.Current.Session["RootCompany"] as string; }
            internal set { HttpContext.Current.Session["RootCompany"] = value; }
        }

        /// <summary>
        /// 以GB2312编码转换成的16进制表示的密码
        /// </summary>
        public static string Hid_Password
        {
            get { return HttpContext.Current.Session["Hid_Password"] as string; }
            internal set { HttpContext.Current.Session["Hid_Password"] = value; }
        }


        /// <summary>
        /// 用户是否是Administrator
        /// </summary>
        public static bool IsAdmin
        {
            get { return string.Equals(Username, "Admin", StringComparison.OrdinalIgnoreCase); }
        }

        /// <summary>
        /// 用户的管辖范围
        /// </summary>
        public static string PeopleRange
        {
            get { return HttpContext.Current.Session["PeopleRange"] as string; }
            internal set { HttpContext.Current.Session["PeopleRange"] = value; }
        }

        /// <summary>
        /// 用户的应用范围
        /// </summary>
        public static string ApplyRange
        {
            get { return HttpContext.Current.Session["ApplyRange"] as string ?? PeopleRange; }
            internal set { HttpContext.Current.Session["ApplyRange"] = value; }
        }

        /// <summary>
        /// 在线日志ID，不可用于仿真软件启动
        /// </summary>
        public static Guid? LoginId
        {
            get { return HttpContext.Current.Session["LoginId"] as Guid?; }
            internal set { HttpContext.Current.Session["LoginId"] = value; }
        }
        /// <summary>
        /// Online表中的ID，用于仿真软件启动
        /// </summary>
        public static string CurUser_SessionID
        {
            get { return HttpContext.Current.Session["OnLineCacheID"] as string; }
            internal set { HttpContext.Current.Session["OnLineCacheID"] = value; }
        }

        /// <summary>
        /// 用户IP
        /// </summary>
        public static string IP
        {
            get { return HttpContext.Current.Request.UserHostAddress; }
        }

        /// <summary>
        /// 由主机字节序表示的uint型IP地址
        /// </summary>
        public static uint uintIP
        {
            get { return IPChange.ToUint32(IP); }
        }

        /// <summary>
        /// 获得用户登录时间
        /// </summary>
        public static DateTime? LoginTime
        {
            get { return HttpContext.Current.Session["LoginTime"] as DateTime?; }
            internal set { HttpContext.Current.Session["LoginTime"] = value; }
        }


        /// <summary>
        /// <para>权限字符串</para>
        /// </summary>
        [Obsolete("PermissionsInts替代")]
        public static string Permissions
        {
            get { return HttpContext.Current.Session["Permissions"] as string; }
            internal set { HttpContext.Current.Session["Permissions"] = value; }
        }

        /// <summary>
        /// 转换成int型的权限组
        /// </summary>
        public static IList<int> PermissionsInts
        {
            get { return HttpContext.Current.Session["PermissionsInts"] as IList<int>; }
            internal set { HttpContext.Current.Session["PermissionsInts"] = value; }
        }
    }
}
