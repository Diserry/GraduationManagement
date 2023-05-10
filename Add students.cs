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
    public partial class 添加学生 : Form
    {
        int sno=-1;
        public 添加学生()
        {
         
            InitializeComponent();
        }
        public 添加学生(int sno_)
        {
            sno = sno_;
            InitializeComponent();
        }

        private void 添加学生_Load(object sender, EventArgs e)
        {
            if (sno != -1)
            {
                button1.Visible = false;
                textBox2.ReadOnly = true;
                textBox2.Text = sno.ToString();
            }
            else button2.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)//添加学生
        {
            string sqlStr = "insert into student values('" + textBox2.Text + "','" + textBox1.Text + "',(select class_no from class where class_name='" + textBox3.Text + "'),(select pro_no from profession where pro_name='" + textBox4.Text + "'),'未提交','')";
            if (MysqlWays.executeSql(sqlStr))
            {
                string sql = "insert into account values('"+textBox2.Text+"','"+123456+"','"+textBox1.Text+"','"+0+"')";
                if(MysqlWays.executeSql(sql))
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)//更改
        {
            string sqlStr = "update student set s_name='" + textBox1.Text + "', s_class=(select class_no from class where class_name='" + textBox3.Text + "') , s_pro=(select pro_no from profession where pro_name='" + textBox4.Text + "') where s_no= '"+textBox2.Text+"'";
            if (MysqlWays.executeSql(sqlStr))
            {
                MessageBox.Show("更改成功");
            }
            else
            {
                MessageBox.Show("更改失败");
            }
        }
    }
}
