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
    public partial class TeacherManage : Form
    {
        public TeacherManage()
        {
            InitializeComponent();
        }

        private void TeacherManage_Load(object sender, EventArgs e)
        {
            string sql = "Select t.t_no,t.t_name,t.t_phone,a.ac_no,a.ac_name from teacher t left join academy a on t.t_academyno=a.ac_no";
            dataGridView1.DataSource= MysqlWays.checkData(sql).Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string sqlStr = "Select t.t_no,t.t_name,t.t_phone,a.ac_no,a.ac_name from teacher t left join academy a on t.t_academyno=a.ac_no where t.t_no='"+ textBox1.Text+"' and t.t_name='"+textBox2.Text+"'";
            //MySqlConnection connection = MysqlWays.ConnectMySql();
            //MySqlCommand mySqlCommand = new MySqlCommand(sqlStr, connection);
            //using (MySqlDataReader dataReader = mySqlCommand.ExecuteReader())
            //{
            //    if(dataReader.Read())
            //    {
            //        dataGridView1= dataReader[0];
            //    }
            //}
            //connection.Close();
            string sqlStr = "Select t.t_no,t.t_name,t.t_phone,a.ac_no,a.ac_name from teacher t left join academy a on t.t_academyno=a.ac_no where t.t_no='" + textBox1.Text + "' and t.t_name='" + textBox2.Text + "'";
            if (MysqlWays.checkData(sqlStr).Tables[0].Rows.Count!=0)
            {
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr).Tables[0];
            }
            else MessageBox.Show("教师不存在！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            添加教师 addTeacher = new 添加教师();
            addTeacher.ShowDialog();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "Select t.t_no,t.t_name,t.t_phone,a.ac_no,a.ac_name from teacher t left join academy a on t.t_academyno=a.ac_no";
            dataGridView1.DataSource = MysqlWays.checkData(sql).Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int tno = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string tname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string sqlStr = "Delete from teacher where t_no="+tno;
            if(MysqlWays.executeSql(sqlStr))
            {
                MessageBox.Show("删除成功！");
                string sql = "Select t.t_no,t.t_name,t.t_phone,a.ac_no,a.ac_name from teacher t left join academy a on t.t_academyno=a.ac_no";
                dataGridView1.DataSource = MysqlWays.checkData(sql).Tables[0];
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            更改教师信息 changeTeacher = new 更改教师信息(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            changeTeacher.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            教师批量导入 frm = new 教师批量导入();
            frm.ShowDialog();
        }
    }
}
