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
    public partial class 就业管理 : Form
    {
        public 就业管理()
        {
            InitializeComponent();
        }
        private void OpenForm(Form frm)
        {
            //设置子窗口不显示为顶级窗口
            frm.TopLevel = false;
            //设置子窗口的样式，没有上面的标题与外框
            frm.FormBorderStyle = FormBorderStyle.None;
            //填充把frm窗体填充满
            frm.Dock = DockStyle.Fill;
            //将panel中的控件清除
            panel2.Controls.Clear();
            //在panel1中添加frm窗体
            panel2.Controls.Add(frm);
            frm.Show();
        }
        private void BtnColorChange(Button btn)
        {
            button1.BackColor=SystemColors.Control;
            button2.BackColor =SystemColors.Control;
            button3.BackColor = SystemColors.Control;
            button4.BackColor = SystemColors.Control;
            button5.BackColor = SystemColors.Control;

            btn.BackColor = Color.White;
        } 
        private void 就业管理_Load(object sender, EventArgs e)
        {
            BtnColorChange(button1);
            OpenForm(new 就业信息());
            //辅导员，就业科隐藏以下三个查询
            if(LoginMainFrom.user.userIdenty==1|| LoginMainFrom.user.userIdenty == 2)
            {
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnColorChange(button1);
            OpenForm(new 就业信息());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //班级就业统计
            BtnColorChange(button2);
            OpenForm(new 就业统计());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //专业就业统计
            BtnColorChange(button3);
            OpenForm(new 就业统计(1));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //学院就业统计
            BtnColorChange(button4);
            OpenForm(new 就业统计(2));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //全校就业统计
            BtnColorChange(button5);
            OpenForm(new 就业统计(3));
        }
    }
}
