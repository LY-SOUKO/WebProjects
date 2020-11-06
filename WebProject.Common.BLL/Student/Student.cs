using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Common.BLL.Student
{
    public class Student
    {
        /// <summary>
        /// 获取所有人员的信息
        /// </summary>
        /// <returns></returns>
        public static DataTable BinddateList()
        {
            return DAL.Student.StudentDAL.BinddateList();
        }
    }
}
