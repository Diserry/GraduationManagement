using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 毕业生管理系统
{
    public partial class 学生首页 : Form
    {
        public 学生首页()
        {
            InitializeComponent();
        }
        int i = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 0) i = 3;
            if (i == 5) i = 1;
            if (i == 1)
            {
                radioButton1.Checked = true;
            }
            else if (i == 2)
            {
                radioButton2.Checked = true;
            }
            else if (i == 3)
            {
                radioButton3.Checked = true;
            }
            else if (i == 4)
            {
                radioButton4.Checked = true;
            }
            //切换图片
            pictureBox1.Image = Image.FromFile(Application.StartupPath+"/images/img"+i+".jpg");
        }
        //点击<按钮，图片回到上一张
        private void button1_Click(object sender, EventArgs e)
        {
            i-=2;
            timer1_Tick(new object(), new EventArgs());
        }
        //点击>按钮，图片立即切换到下一站
        private void button2_Click(object sender, EventArgs e)
        {
            timer1_Tick(new object(), new EventArgs());
        }

        private void 学生首页_Load(object sender, EventArgs e)
        {
           
            string sql = "Select * from postcompany pc join company c on pc.comp_no=c.comp_no join post p on p.p_no=pc.p_no";
            using (MySqlDataReader reader = MysqlWays.dataReader(sql))
            {
                int n = 10;
                while (n-- > 0 && reader.Read())
                {
                    岗位记录 frm = new 岗位记录(reader.GetString("p_no"), reader.GetString("comp_no"));
                    //frm.p_no = reader.GetString("p_no");
                    //frm.comp_no = reader.GetString("comp_no");
                    //设置子窗口不显示为顶级窗口
                    frm.TopLevel = false;
                    //设置子窗口的样式，没有上面的标题与外框
                    frm.FormBorderStyle = FormBorderStyle.None;
                    //加入控件
                    flowLayoutPanel1.Controls.Add(frm);

                    frm.lbName1.Text = reader.GetString("p_name");
                    frm.lbCount.Text = reader.GetString("pc_count");
                    frm.lbPosition.Text = reader.GetString("pc_position");
                    frm.lbSalary.Text = reader.GetString("pc_salary");
                    frm.lbExperience.Text = reader.GetString("pc_experience");
                    frm.lbDegree.Text = reader.GetString("pc_degree");
                    frm.lbTechnology.Text = reader.GetString("pc_technology");
                    frm.lbName2.Text = reader.GetString("comp_name");
                    frm.pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + frm.lbName2.Text + ".jpg");
                    frm.Show();
                    frm.Show();
                }
                //热门企业初始化
                sql = "select * from jobwanted ";
                using (MySqlDataReader dr = MysqlWays.dataReader(sql))
                while (dr.Read())
                {
                    热门企业记录 frm = new 热门企业记录();
                    //设置子窗口不显示为顶级窗口
                    frm.TopLevel = false;
                    //设置子窗口的样式，没有上面的标题与外框
                    frm.FormBorderStyle = FormBorderStyle.None;
                    //加入控件
                    flowLayoutPanel2.Controls.Add(frm);

                    frm.comp_no = dr.GetString("comp_no");
                    frm.Show();

                }
                
            }

                //初始化热门校园招聘
             
            //初始化热门企业
           
        }
        private void ButtonColorChange(Button btn)
        {
            //按钮背景颜色改变
            button1.BackColor = Color.RoyalBlue;
            button2.BackColor = Color.RoyalBlue;
            button3.BackColor = Color.RoyalBlue;
            btn.BackColor = Color.CornflowerBlue;
            //按钮字体颜色改变
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            btn.ForeColor = Color.RoyalBlue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentMainform.StudentPMF.button3_Click(sender, e);
        }

        private void v76(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentMainform.StudentPMF.button1_Click(sender, e);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
