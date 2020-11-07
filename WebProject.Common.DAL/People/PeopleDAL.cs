using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Common.DAL.People
{
    public class PeopleDAL
    {
        /// <summary>
        /// 人员登录
        /// </summary>
        /// <returns></returns>
        public static DataTable Login(string userName, string password)
        {
            string sql = "select * from people where UserName='"+ userName + "' and Powd='"+ password + "' AND DeleteSign=0";
            return SQLHelper.DBHelper.GetTable(sql);
        }
    }
}
