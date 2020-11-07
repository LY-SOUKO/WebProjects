using EastSim.Utility.StringHelper;
using SQLHelper;
using SQLHelper.Webs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebProject.Common.Login.ajax
{
    /// <summary>
    /// HandlerLogin 的摘要说明
    /// </summary>
    public class HandlerLogin : AjaxBaseEx
    {

        protected override Result SwitchCmd(HttpRequest Request)
        {
            string sCmd = GetPostBack.GetPostBackValue("cmd");
            Result result = new Result();
            switch (sCmd)
            {
                case "getLogin":
                    result = GetLogin();
                    break;
            }
            return result;
        }
        private Result GetLogin()
        {
            var userName = GetPostBack.GetPostBackValue("userName");
            var password = GetPostBack.GetPostBackValue("password");
            var dateList = BLL.People.People.Login(userName, password).AsEnumerable().Select(t => new
            {
                UserName = t.Field<string>("UserName"),
                Name = t.Field<string>("Name"),
                Password = t.Field<string>("Powd"),
                CompanyId = t.Field<string>("CompanyId"),
            }).ToList();
            if (dateList.Count > 0)
            {
                //CurUserInfo.Username = dateList[0].UserName;
                //CurUserInfo.CompanyID=
                return new Result() { state = state.success, msg = "登录成功！" };
            }
            else 
            {
                return new Result() { state = state.error, msg="账号或密码错误！"};
            }
            
        }
    }
}