using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 毕业生管理系统
{
    public partial class 教职工个人信息界面 : Form
    {
        public 教职工个人信息界面()
        {
            InitializeComponent();
        }

        private void NewPassWord1_TextChanged(object sender, EventArgs e)
        {
            //当两次新密码相同时，在后面checkBox打勾
            if (NewPassWord1 != null)
                if (NewPassWord1.Text == NewPassWord2.Text)
                    this.checkBox.Checked = true;
            else this.checkBox.Checked = false;
        }

        private void 教职工个人信息界面_Load(object sender, EventArgs e)
        {
            checkBox.Enabled = false;
            string sql = "Select t.t_no,t.t_name,t.t_phone,a.ac_no,a.ac_name from teacher t left join academy a on t.t_academyno=a.ac_no where t.t_no="+LoginMainFrom.user.userID;
            using(MySqlDataReader dataReader = MysqlWays.dataReader(sql))
            if(dataReader.Read())
            {
                label2.Text = dataReader.GetString("t_name");
                label4.Text = LoginMainFrom.user.userID.ToString();
                label6.Text = dataReader.GetString("ac_name");
                label8.Text = dataReader.GetString("t_phone");

            }
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pictureShow.ClientRectangle);
            Region region = new Region(gp);
            pictureShow.Region = region;
            gp.Dispose();
            region.Dispose();

            pictureShow.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureShow.BackgroundImageLayout = ImageLayout.Stretch;

            //指定图像
            pictureShow.Image = imageList.Images[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {

            do
            {
                if (OldPassWord.Text.Length < 1)
                {
                    MessageBox.Show("请输入密码");
                    break;
                }
                if (NewPassWord1.Text.Length < 1)
                {
                    MessageBox.Show("请输入新密码");
                    break;
                }
                if (NewPassWord2.Text.Length < 1)
                {
                    MessageBox.Show("请再次输入新密码");
                    break;
                }
                if (checkBox.Checked == true)
                {
                    string sql = "select a_password from account where a_no=" + LoginMainFrom.user.userID;
                    using (MySqlDataReader dataReader = MysqlWays.dataReader(sql))
                    {


                        if (dataReader.Read())
                        {
                            if (dataReader.GetString("a_password") == OldPassWord.Text)
                            {
                                string sqlStr = "update account set a_password='" + NewPassWord1.Text + "' where a_no=" + LoginMainFrom.user.userID;
                                if (MysqlWays.executeSql(sqlStr) == true)
                                    MessageBox.Show("密码修改成功！");
                                else MessageBox.Show("密码修改失败！");
                            }
                            else MessageBox.Show("旧密码错误！");
                        }


                    }
                }
                else MessageBox.Show("两次密码不一致！");
            } while (false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewPassWord2_TextChanged(object sender, EventArgs e)
        {
            //当两次新密码相同时，在后面checkBox打勾
            if (NewPassWord1 != null)
                if (NewPassWord1.Text == NewPassWord2.Text)
                    this.checkBox.Checked = true;
                else this.checkBox.Checked = false;
        }
    }
}
