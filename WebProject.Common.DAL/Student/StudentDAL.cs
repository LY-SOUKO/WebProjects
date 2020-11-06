using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Common.DAL.Student
{
    public class StudentDAL
    {
        /// <summary>
        /// 获取所有人员的信息
        /// </summary>
        /// <returns></returns>
        public static DataTable BinddateList()
        {
            string sql = "select * from people ";
            return SQLHelper.DBHelper.GetTable(sql);
        }
    }
}
