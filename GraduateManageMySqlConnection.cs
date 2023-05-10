using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace 毕业生管理系统
{   
    
    public class GraduateManageMySqlConnection
    {

    public static MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
       public static MySqlConnection ConnectMySql()
        {
            //连接数据库需要用到的参数
            Builder.Database = "graduatemanagement";
            Builder.UserID = "root";
            Builder.Password = "mayu12345";
            Builder.Server = "localhost";
            //正式连接数据库
            MySqlConnection connection = new MySqlConnection(Builder.ConnectionString);
            //打开连接
            connection.Open();
            return connection;
        }
    }
}
