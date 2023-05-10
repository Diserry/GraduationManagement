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
    public partial class 学生个人信息 : Form
    {
        public 学生个人信息()
        {
            InitializeComponent();
        }

        private void 个人信息_Load(object sender, EventArgs e)
        {
            //pictureShow为控件名字
            //将图像框改为圆形
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
            checkBox.Enabled = false;

            string sqlStr = "select s.s_no,s.s_name,cl.class_name,pro.pro_name from student s left join class cl on cl.class_no=s.s_class left join profession pro on pro.pro_no=s.s_pro where s.s_no=" + LoginMainFrom.user.userID;
            using (MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr))
            {
                if(dataReader.Read())
                {
                    label8.Text = dataReader.GetString("pro_name");
                    label2.Text = LoginMainFrom.user.userName;
                    label4.Text = LoginMainFrom.user.userID.ToString();
                    label6.Text = dataReader.GetString("class_name");
                }
                
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureShow_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewPassWord1_TextChanged(object sender, EventArgs e)
        {
            //当两次新密码相同时，在后面checkBox打勾
            if (NewPassWord1 != null)
                if (NewPassWord1.Text == NewPassWord2.Text)
                    this.checkBox.Checked = true;
                else this.checkBox.Checked = false;
        }

        private void NewPassWord2_TextChanged(object sender, EventArgs e)
        {
            //当两次新密码相同时，在后面checkBox打勾
            if (NewPassWord1 != null)
                if (NewPassWord1.Text == NewPassWord2.Text)
                    this.checkBox.Checked = true;
                else this.checkBox.Checked = false;
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
                if(NewPassWord1.Text.Length<1)
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
                        try
                        {
                            if (dataReader.Read())
                            {
                                if (dataReader.GetString("a_password") == OldPassWord.Text)
                                {
                                    string sqlStr = "update account set a_password='" + NewPassWord1.Text + "' where a_no=" + LoginMainFrom.user.userID;
                                    if (MysqlWays.executeSql(sqlStr))
                                        MessageBox.Show("密码修改成功！");
                                    else MessageBox.Show("密码修改失败！");
                                }
                                else MessageBox.Show("旧密码错误！");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("密码修改失败！");
                        }
                    }
                }
                else MessageBox.Show("两次密码不一致！");
            } while (false);
        }
    }
}
