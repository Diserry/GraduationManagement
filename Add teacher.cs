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
    public partial class 添加教师 : Form
    {
        public 添加教师()
        {
            InitializeComponent();
        }

        private void 添加教师_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlStr = "insert into teacher values('"+textBox2.Text+ "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            if(MysqlWays.executeSql(sqlStr))
            {
                MessageBox.Show("添加成功！");
            }
            else MessageBox.Show("添加失败！");
        }

        private void 添加教师_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
