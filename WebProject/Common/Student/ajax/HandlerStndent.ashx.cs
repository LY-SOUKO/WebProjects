using EastSim.Utility.StringHelper;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebProject.Common.Student.ajax
{
    /// <summary>
    /// HandlerStndent 的摘要说明
    /// </summary>
    public class HandlerStndent : AjaxBaseEx
    {

        protected override Result SwitchCmd(HttpRequest Request)
        {
            string sCmd = GetPostBack.GetPostBackValue("cmd");
            Result result = new Result();
            switch (sCmd)
            {
                case "getStudentList":
                    result = GetStudentList();
                    break;
            }
            return result;
        }
        private Result GetStudentList() 
        {
            var aaaa = GetPostBack.GetPostBackValue("aaa");
            var dateList = BLL.Student.Student.BinddateList();
            return new Result() { state = state.success, data = new { DataList = dateList, TotalRowNum = dateList.Rows} };
        }
    }
}