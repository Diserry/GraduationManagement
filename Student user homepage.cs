using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 毕业生管理系统
{
    public partial class StudentMainform : Form
    {
        public User user = new User();
        public StudentMainform(int identy)
        {
            InitializeComponent();
            StudentPMF = this;
            user.userIdenty = identy;
        }

        public static StudentMainform StudentPMF = null;

        

        private void 用户主界面_Load(object sender, EventArgs e)
        {
            //起始页面为学生首页
            button2_Click(new object(),new EventArgs());
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
            ToolStripMenuItem1.Text = LoginMainFrom.user.userName;
        }
        private void ButtonColorChange(Button btn)
        {
            //按钮背景颜色改变
            button1.BackColor = Color.PowderBlue;
            button2.BackColor = Color.PowderBlue;
            button3.BackColor = Color.PowderBlue;
            button4.BackColor = Color.PowderBlue;
            button5.BackColor = Color.PowderBlue;
            btn.BackColor = Color.CornflowerBlue;
            //按钮字体颜色改变
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            button4.ForeColor = Color.White;
            button5.ForeColor = Color.White;
            btn.ForeColor = Color.RoyalBlue;
        }
        public void OpenForm(Form frm)
        {
            //设置子窗口不显示为顶级窗口
            frm.TopLevel = false;
            //设置子窗口的样式，没有上面的标题与外框
            frm.FormBorderStyle = FormBorderStyle.None;
            //填充把frm窗体填充满
            frm.Dock = DockStyle.Fill;
            //清空容器里面的控件
            splitContainer1.Panel2.Controls.Clear();
            //加入控件
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        private void pictureShow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            学生个人信息 PersonImformation = new 学生个人信息();
            PersonImformation.Show();
            this.Hide();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            //点击打开校园招聘岗位
            ButtonColorChange(button3);
            Form frm = new SchoolEmployee(user.userIdenty);
            OpenForm(frm);
        }

       
        public void button1_Click(object sender, EventArgs e)
        {
            
            ButtonColorChange(button1);
            Form frm = new 毕业申报系统();
             OpenForm(frm);
        }

        public void button2_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button2);
            Form frm = new 学生首页();
            OpenForm(frm);
        }

        private void pictureShow_Click(object sender, EventArgs e)
        {
            Form frm = new 学生个人信息();
            OpenForm(frm);
        }

        public  void button4_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button2);
            Form frm = new 毕业申报管理();
            OpenForm(frm);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 张三ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new LoginMainFrom();
            frm.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ButtonColorChange(button4);
            Form frm = new 我的简历();
            OpenForm(frm);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button5);
            Form frm = new 我的面试();
            OpenForm(frm);
        }

        private void 个人中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            学生个人信息 frm = new 学生个人信息();
            frm.Show();
        }
    }
}
