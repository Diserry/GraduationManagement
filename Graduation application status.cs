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
    public partial class 毕业申报管理 : Form
    {
        public 毕业申报管理()
        {
            InitializeComponent();

        }

        private void 毕业申报状况_Load(object sender, EventArgs e)
        {
            button1_Click_1(new object(), new EventArgs());
        }
        private void ButtonColorChange(Button btn)
        {
            //按钮背景颜色改变
            button1.BackColor = SystemColors.InactiveBorder;
            button2.BackColor = SystemColors.InactiveBorder;
            button3.BackColor = SystemColors.InactiveBorder;
            btn.BackColor = Color.White;
            //按钮字体颜色改变
            button1.ForeColor = Color.RoyalBlue;
            button2.ForeColor = Color.RoyalBlue;
            button3.ForeColor = Color.RoyalBlue;
            btn.ForeColor = Color.DodgerBlue;
        }
        private void OpenForm(Form frm)
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            //加入控件
            panel2.Controls.Add(frm);
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ButtonColorChange(button1);
            Form frm = new 毕业申报待审查();
            OpenForm(frm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button2);
            Form frm = new 毕业申报通过情况();
            OpenForm(frm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonColorChange(button3);
            Form frm = new 毕业申报未交();
            OpenForm(frm);
        }
    }
}
