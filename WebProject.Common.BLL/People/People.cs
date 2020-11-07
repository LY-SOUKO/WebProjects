using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Common.BLL.People
{
    public class People
    {
        /// <summary>
        /// 人员登录
        /// </summary>
        /// <returns></returns>
        public static DataTable Login(string userName, string password)
        {
            return DAL.People.PeopleDAL.Login(userName, password);
        }
    }
}
