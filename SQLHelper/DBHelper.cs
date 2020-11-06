using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHelper
{
    public class DBHelper
    {
        public static readonly string conString = ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString;

        //增删改
        public static bool ExeNonQuery(string sql, CommandType type, params SqlParameter[] lists)
        {
            bool bFlag = false;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.CommandType = type;
                if (lists != null)
                {
                    foreach (SqlParameter p in lists)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        bFlag = true;
                    }

                }
                catch {; }
            }
            return bFlag;
        }

        //查．读
        public static SqlDataReader ExeDataReader(string sql, CommandType type, params SqlParameter[] lists)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.CommandType = type;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (lists != null)
            {
                foreach (SqlParameter p in lists)
                {
                    cmd.Parameters.Add(p);
                }
            }

            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        //返回单个值
        public static object GetScalar(string sql, CommandType type, params SqlParameter[] lists)
        {
            object returnValue = null;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.CommandType = type;
                if (lists != null)
                {
                    foreach (SqlParameter p in lists)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    returnValue = cmd.ExecuteScalar();

                }
                catch {; }
            }
            return returnValue;
        }

        //事务
        public static bool ExeNonQueryTran(List<SqlCommand> list)
        {
            bool flag = true;
            SqlTransaction tran = null;
            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        tran = con.BeginTransaction();
                        foreach (SqlCommand com in list)
                        {
                            com.Connection = con;
                            com.Transaction = tran;
                            com.ExecuteNonQuery();
                        }
                        tran.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    tran.Rollback();
                    flag = false;
                }
            }
            return flag;
        }
        //返回DataTable
        public static DataTable GetTable(string sql)
        {
            SqlConnection conn = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

    }
}
