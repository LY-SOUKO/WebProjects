using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.UI;

namespace SQLHelper
{
    public class BasePage : Page
    {
        /// <summary>
        /// 跳转到网站首页
        /// </summary>
        protected void RedirectToDefault()
        {
            Response.Redirect("~/");
            Response.End();
        }
        /// <summary>
        /// 跳转到未找到
        /// </summary>
        protected void RedirectToNotFound()
        {
            Response.Clear();
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            Response.End();
        }
        /// <summary>
        /// 跳转到错误页
        /// </summary>
        protected void RedirectToError()
        {
            Response.Clear();
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            Response.End();
        }

        /// <summary>
        /// 跳转到无权限页面
        /// </summary>
        protected void RedirectToUnAuthorized()
        {
            Response.Clear();
            Response.StatusCode = (int)HttpStatusCode.Forbidden;
            Response.End();
        }

        /// <summary>
        /// 在网页上执行指定的JS代码
        /// </summary>
        /// <param name="strScript"></param>
        public void ExeScript(string strScript)
        {
            ClientScript.RegisterStartupScript(GetType(), "ExeScript" + Guid.NewGuid().ToString(), strScript, true);
        }

        /// <summary>
        /// 向客户端发送消息
        /// </summary>
        /// <param name="strMsg"></param>
        public void Alert(string strMsg)
        {
            string strScript = string.Format("alert(\"{0}\");", HttpUtility.JavaScriptStringEncode(strMsg));
            ExeScript(strScript);
        }
    }
}
