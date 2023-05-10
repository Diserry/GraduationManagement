using Org.BouncyCastle.Crypto.Engines;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace 毕业生管理系统
{
    public partial class 教职工用户主界面 : Form
    {
       public User user = new User();
        
        public 教职工用户主界面(int identy)
        {
            InitializeComponent();
            user.userIdenty = identy;
            
        }
        //在本窗体上嵌套打开frm窗体
        private void OpenForm(Form frm)
        {
            //不同身份需要隐藏部分功能
            //if(user.userIdenty==1)
            //{
            //    //辅导员关闭简历管理
            //    this.button9.Visible = false;
            //}


            //设置子窗口不显示为顶级窗口
            frm.TopLevel = false;
            //设置子窗口的样式，没有上面的标题与外框
            frm.FormBorderStyle = FormBorderStyle.None;
            //填充把frm窗体填充满
            frm.Dock = DockStyle.Fill;
            //清空容器里面的控件
            tabControl1.TabPages[tabControl1.TabCount-1].Controls.Clear();
            //加入控件
            tabControl1.TabPages[tabControl1.TabCount-1].Controls.Add(frm);
            frm.Show();
            //切换到当前点击的选项卡
            tabControl1.SelectedTab=tabControl1.TabPages[tabControl1.TabCount-1];
        }
        //改变点击按钮的背景颜色与字体颜色
        private void ButtonColorChange(Button btn)
        {
            //按钮背景颜色改变
            button1.BackColor = Color.LightBlue;
            button2.BackColor = Color.LightBlue;
            button3.BackColor = Color.LightBlue;
            button5.BackColor = Color.LightBlue;
            button4.BackColor = Color.LightBlue;
            button7.BackColor = Color.LightBlue;
            button8.BackColor = Color.LightBlue;
            button9.BackColor = Color.LightBlue;
            button6.BackColor = Color.LightBlue;
            button10.BackColor = Color.LightBlue;
            button11.BackColor = Color.LightBlue;
            button12.BackColor = Color.LightBlue;
            btn.BackColor = Color.DarkGray;
            //按钮字体颜色改变
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            button5.ForeColor = Color.White;
            button6.ForeColor = Color.White;
            button4.ForeColor = Color.White;
            button7.ForeColor = Color.White;
            button8.ForeColor = Color.White;
            button9.ForeColor = Color.White;
            button11.ForeColor = Color.White;
            button10.ForeColor = Color.White;
            button12.ForeColor = Color.White;
            btn.ForeColor = Color.Black;
        }
        //点击按钮后添加按钮导航选项卡
        private bool BtnTabPageAdd(object s)
        {
            Button btn = s as Button;
            if (tabControl1.TabPages[btn.Text] == null)   //如果当前窗体选项卡不存在
            {
                //添加导航选项卡，文本内容为按钮文本
                tabControl1.TabPages.Add(btn.Text,btn.Text);
                return true;
            }
            else return false;
        }
        private void pictureShow_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            //双击头像显示信息界面
           // OpenForm(new 教职工个人信息界面());
        }

        private void 教职工用户主界面_Load(object sender, EventArgs e)
        {
            

            //上方名字显示当前用户
            toolStripMenuItem1.Text = LoginMainFrom.user.userName;

            //初始化时，默认按了系统首页按钮
            if(user.userIdenty==4)
            {
                Button btn = new Button();
                btn.Text = " 校园招聘";
                button3_Click(btn, new EventArgs());
            }
            else if(user.userIdenty == 5)
            {
                Button btn = new Button();
                btn.Text = " 教师管理";
                button10_Click(btn, new EventArgs());
            }
            else
            {
                Button btn = new Button();
                btn.Text = " 系统首页";
                button7_Click(btn, new EventArgs());
            }

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

            //不同身份需要隐藏部分功能
            //0是学生，1是辅导员，2是班导师，3就业科，4是企业，5是管理员
            if(user.userIdenty!=5)
            {
                this.button10.Visible = false;
                this.button11.Visible = false;
                this.button12.Visible = false;
            }
            if (user.userIdenty == 1)
            {
                //辅导员关闭简历管理
                this.button9.Visible = false;
                this.button4.Visible = false;
                this.button6.Visible = false;
            }
            if (user.userIdenty == 2)
            {
                //班导师关闭简历管理
                this.button9.Visible = false;
                this.button4.Visible = false;
                this.button6.Visible = false;
            }
            if (user.userIdenty == 3)
            {
                //就业科关闭简历管理
                this.button9.Visible = false;
                this.button4.Visible = false;
                this.button6.Visible = false;
            }
            if (user.userIdenty == 4)
            {
                //企业关闭
                this.button1.Visible = false;
                this.button2.Visible = false;
                this.button7.Visible = false;
            }
            if(user.userIdenty==5)
            {
                this.button1.Visible = false;
                this.button2.Visible = false;
                this.button3.Visible = false;
                this.button4.Visible = false;
                this.button5.Visible = false;
                this.button6.Visible = false;
                this.button7.Visible = false;
                this.button8.Visible = false;
                this.button9.Visible = false;
                
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button3);
            if (BtnTabPageAdd(sender))      //如果添加选项卡成功，该选项卡不存在就添加
                OpenForm(new SchoolEmployee(user.userIdenty));
            else
            {                               //如果失败（已经存在）就跳到指定选项卡
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button2);
            if (BtnTabPageAdd(sender))      //如果添加选项卡成功，该选项卡不存在就添加
                OpenForm(new 毕业申报管理());
            else
            {                               //如果失败（已经存在）就跳到指定选项卡
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }

        public void button5_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button5);
            if (BtnTabPageAdd(sender))
                OpenForm(new 企业信息());
            else
            {
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }



        public void button1_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button1);
            if (BtnTabPageAdd(sender))
                OpenForm(new 就业管理());
            else
            {
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }


        public void button7_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button7);
            if (BtnTabPageAdd(sender))
                OpenForm(new 教职工首页());
            else
            {
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }
        private void pictureShow_Click(object sender, EventArgs e)
        {
          
        }

        public void button8_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button8);
            if (BtnTabPageAdd(sender))
                OpenForm(new 岗位管理(user.userIdenty));
            else
            {
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }

        public void button9_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button9);
            if (BtnTabPageAdd(sender))
                OpenForm(new 简历管理());
            else
            {
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new LoginMainFrom();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button4);
            if (BtnTabPageAdd(sender))
                OpenForm(new 求职管理());
            else
            {
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button6);
            if (BtnTabPageAdd(sender))
                OpenForm(new 面试管理());
            else
            {
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button10);
            if (BtnTabPageAdd(sender))
                OpenForm(new TeacherManage());
            else
            {
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {   
  
             ButtonColorChange(button11);
            if (BtnTabPageAdd(sender))
                OpenForm(new 学生管理());
            else
            {
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button12);
            if (BtnTabPageAdd(sender))      //如果添加选项卡成功，该选项卡不存在就添加
                OpenForm(new 企业管理());
            else
            {                               //如果失败（已经存在）就跳到指定选项卡
                Button btn = sender as Button;
                tabControl1.SelectedTab = tabControl1.TabPages[btn.Text];
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            教职工个人信息界面 frm = new 教职工个人信息界面();
            frm.Show();
            
        }
    }
}
