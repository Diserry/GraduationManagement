using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 毕业生管理系统
{

    public class MysqlWays
    {
        public static MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
        public static MySqlConnection ConnectMySql()            //连接数据库需要用到的参数
        {
            Builder.Database = "graduatemanagement";
            Builder.UserID = "root";
            Builder.Password = "zjk520";
            Builder.Server = "localhost";
            Builder.CharacterSet = "utf8";
            MySqlConnection connection = new MySqlConnection(Builder.ConnectionString);
            connection.Open();
            return connection;
        }
        public static DataSet checkData(string sqlStr)
        {
            MySqlConnection connection = MysqlWays.ConnectMySql();
            MySqlCommand sqlCommand = new MySqlCommand(sqlStr, connection);
            DataSet ds = new DataSet();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand);
            dataAdapter.Fill(ds);
            connection.Close();
            return ds;
        }
        //public static void 
        public static MySqlDataReader dataReader(string sqlStr)
        {
            MySqlDataReader Reader;
            MySqlConnection connection = MysqlWays.ConnectMySql();
            MySqlCommand mySqlCommand = new MySqlCommand(sqlStr,connection);
            
            Reader = mySqlCommand.ExecuteReader();
            return Reader;
        }
        public static bool executeSql(string sql)   //增，删，改
        {
            bool rtn = true;
            MySqlConnection connection = ConnectMySql();
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                int iRtn = mySqlCommand.ExecuteNonQuery();
                if (iRtn <= 0)
                    rtn = false;
            }
            catch
            {
                rtn = false;
            }
            finally
            {
                connection.Close();
            }
            return rtn;
        }
        public static DataSet ExcelToDS(string Path)//excel数据使用
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            if(ds==null)
            {
                MessageBox.Show("未导入成功！");
            }
            return ds;
        }
    }
}
