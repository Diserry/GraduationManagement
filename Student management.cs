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
    public partial class 学生管理 : Form
    {
        public 学生管理()
        {
            InitializeComponent();
        }

        private void 学生管理_Load(object sender, EventArgs e)
        {
            string sqlStr = "select s.s_no,s.s_name,cl.class_name,pro.pro_name from student s left join class cl on cl.class_no=s.s_class left join profession pro on pro.pro_no=s.s_pro";
            dataGridView1.DataSource = MysqlWays.checkData(sqlStr).Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlStr = "select s.s_no,s.s_name,cl.class_name,pro.pro_name from student s left join class cl on cl.class_no=s.s_class left join profession pro on pro.pro_no=s.s_pro where s_no= '" + textBox1.Text + "'and s.s_name='" + textBox2.Text + "'";
            if (MysqlWays.checkData(sqlStr).Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr).Tables[0];
            }
            else MessageBox.Show("学生不存在！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlStr = "delete from student where s_no='" + int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'";
            if (MysqlWays.executeSql(sqlStr))
            {
                MessageBox.Show("删除成功");
                string sqlStr1 = "select s.s_no,s.s_name,cl.class_name,pro.pro_name from student s left join class cl on cl.class_no=s.s_class left join profession pro on pro.pro_no=s.s_pro";
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr1).Tables[0];
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            添加学生 addStudent = new 添加学生();
            addStudent.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            添加学生 addStudent = new 添加学生(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            addStudent.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sqlStr = "select s.s_no,s.s_name,cl.class_name,pro.pro_name from student s left join class cl on cl.class_no=s.s_class left join profession pro on pro.pro_no=s.s_pro";
            dataGridView1.DataSource = MysqlWays.checkData(sqlStr).Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            学生批量导入 frm = new 学生批量导入();
            frm.ShowDialog();
        }
    }
}
