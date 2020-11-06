using SQLHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProject
{
    public partial class _default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentDefaultPage = WebSetting.DefaultPage;
            Response.Redirect(currentDefaultPage);
            //if (string.IsNullOrWhiteSpace(CurUserInfo.Username))
            //{
            //    string[] defaultPages = WebSetting.DefaultPage.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            //    string currentDefaultPage = WebSetting.DefaultPage;
            //    string requestHost = Request.Url.Host;
            //    foreach (var defaultPage in defaultPages)
            //    {
            //        Uri defaultUri = null;
            //        if (Uri.TryCreate(defaultPage, UriKind.Absolute, out defaultUri))
            //        {
            //            if (requestHost.ToLower() == defaultUri.Host.ToLower())
            //            {
            //                currentDefaultPage = defaultPage;
            //                break;
            //            }
            //        }
            //    }
            //    Response.Redirect(currentDefaultPage);
            //}
            //else
            //{
            //    var indexPage = Session["ThisUserDefaultLoginPage"] as string;//  
            //    if (string.IsNullOrEmpty(indexPage))
            //    {
            //        //获取可用的首页地址（默认首页不可用时有效）
            //        indexPage = WebSetting.MenuSetting[CurUserInfo.CustomerToken].DefaultLoginPage;
            //        if (!string.IsNullOrEmpty(indexPage))
            //        {
            //            Session["ThisUserDefaultLoginPage"] = indexPage;
            //        }
            //        else
            //        {
            //            //取系统全局配置首页地址
            //            indexPage = WebSetting.DefaultLoginPage;
            //        }
            //    }


            //    Response.Redirect(indexPage);
            //}
        }
    }
}