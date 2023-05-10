using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 毕业生管理系统
{
    
    public partial class LoginMainFrom : Form
    {
        
        public LoginMainFrom()
        {
            InitializeComponent();
        }

        public static User user = new User();
        

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void Login_Click(object sender, EventArgs e)//点击login登录
        {
            do { 
                //获取输入的用户名，密码
                string usename = textBox1.Text;
                string passwrod = textBox2.Text;
               if (textBox1.Text.Length < 1)                                                                                                             //判断账户密码角色是否输入为空
               {
                  MessageBox.Show("请输入账户");
                  break;
                }
               if (textBox2.Text.Length < 1)
               {
                  MessageBox.Show("请输入密码");
                  break;
                }
               try
               {
                  //数据库中账号密码
                  string sqlStr = "select*from account where a_no=" + usename + " and a_password=" + passwrod;
                  MySqlCommand mySqlCommand = new MySqlCommand(sqlStr, MysqlWays.ConnectMySql());
                  MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                    
                  if (dataReader.Read())
                  {

                    user.userID = int.Parse(dataReader.GetString("a_no"));
                    user.userIdenty = int.Parse(dataReader.GetString("a_identy"));
                    user.userName = dataReader.GetString("a_name");
                    //以下用于判断
                    //0是学生，1是辅导员，2是班导师，3就业科，4是企业，5是管理员

                    if (dataReader.GetString("a_identy") == "1")
                    {
                        //辅导员登录
                        Form UserMainForm = new 教职工用户主界面(1);
                        this.Hide();

                        UserMainForm.ShowDialog();

                        this.Close();

                    }
                    else if (dataReader.GetString("a_identy") == "2")
                    {
                        //班导师登录
                        Form UserMainForm = new 教职工用户主界面(2);
                        this.Hide();

                        UserMainForm.ShowDialog();

                        this.Close();

                    }
                    else if (dataReader.GetString("a_identy") == "3")
                    {
                        //就业科登录
                        Form UserMainForm = new 教职工用户主界面(3);
                        this.Hide();

                        UserMainForm.ShowDialog();

                        this.Close();

                    }
                    else if (dataReader.GetString("a_identy") == "4")
                    {
                        //企业登录
                        Form UserMainForm = new 教职工用户主界面(4);
                        this.Hide();

                        UserMainForm.ShowDialog();

                        this.Close();

                    }
                    else if (dataReader.GetString("a_identy") == "5")
                    {
                        //管理员登录
                        Form UserMainForm = new 教职工用户主界面(5);
                        this.Hide();

                        UserMainForm.ShowDialog();

                        this.Close();

                    }
                    else if (dataReader.GetString("a_identy") == "0")
                    {
                        Form UserMainForm = new StudentMainform(0);
                        this.Hide();
                        UserMainForm.ShowDialog();
                        this.Close();

                    }

                  }
                  else MessageBox.Show("账号或密码不正确");
               }
               catch
               {
                  MessageBox.Show("账号或密码不正确");
               }
              
        } while (false);

        }


        private void button1_Click(object sender, EventArgs e)//退出程序
        {
            this.Close();
        }

        private void lbRegister_Click(object sender, EventArgs e)
        {
            new 注册企业().ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
