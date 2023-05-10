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
    public partial class 就业信息 : Form
    {
        public 就业信息()
        {
            InitializeComponent();
        }

        private void 就业信息_Load(object sender, EventArgs e)
        {
            if(LoginMainFrom.user.userIdenty==1)//辅导员
            {
                label4.Visible = false;
                comboBox1.Visible = false;
                //添加班级列表
                string sqlStr2 = "select class_name from class where b_no=" + LoginMainFrom.user.userID + " or t_no=" + LoginMainFrom.user.userID + " order by class_no";
                using(MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr2))
                while (dataReader1.Read())
                {
                    comboBox2.Items.Add(dataReader1[0]);
                }

                string sqlStr = "select gr.s_no,gr.s_name,gr.class_name,gr.pro_name,gr.ac_name,gr.EmploymentCompanies,gr.EmploymentStatus,gr.Jobs,gr.ArrivalTime,gr.Salary from graduationdeclaration gr left join student stu on stu.s_no=gr.s_no left join class cl on stu.s_class=cl.class_no left join teacher t on cl.t_no=t.t_no where t.t_no=" + LoginMainFrom.user.userID;
                dataGridView1.DataSource= MysqlWays.checkData(sqlStr).Tables[0];
            }
            if (LoginMainFrom.user.userIdenty == 2)//班导师
            {
                label4.Visible = false;
                comboBox1.Visible = false;
                //添加班级列表
                string sqlStr2 = "select class_name from class where b_no=" + LoginMainFrom.user.userID + " or t_no=" + LoginMainFrom.user.userID + " order by class_no";
                using(MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr2))
                while (dataReader1.Read())
                {
                    comboBox2.Items.Add(dataReader1[0]);
                }

                string sqlStr = "select gr.s_no,gr.s_name,gr.class_name,gr.pro_name,gr.ac_name,gr.EmploymentCompanies,gr.EmploymentStatus,gr.Jobs,gr.ArrivalTime,gr.Salary from graduationdeclaration gr left join student stu on stu.s_no=gr.s_no left join class cl on stu.s_class=cl.class_no left join teacher t on cl.b_no=t.t_no where t.t_no=" + LoginMainFrom.user.userID;
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr).Tables[0];
            }
            if (LoginMainFrom.user.userIdenty == 3)//就业科
            {
                //学院列表添加成员
                string sqlStr1 = "select ac_name from academy";
                using(MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr1))
                while (dataReader.Read())
                {
                    comboBox1.Items.Add(dataReader[0]);
                }

                //班级列表添加成员
                string sqlStr2 = "select class_name from class order by class_no";
                using(MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr2))
                while (dataReader1.Read())
                {
                    comboBox2.Items.Add(dataReader1[0]);
                }

                string sqlStr = "select gr.s_no,gr.s_name,gr.class_name,gr.pro_name,gr.ac_name,gr.EmploymentCompanies,gr.EmploymentStatus,gr.Jobs,gr.ArrivalTime,gr.Salary from graduationdeclaration gr";
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr).Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = null;
            try
            {
                for (int i = 0; i <= 0; i++)
                {
                    if (comboBox2.Text != "" && comboBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column1"].Value.ToString().Equals(textBox2.Text) && r.Cells["Column2"].Value.ToString().Contains(textBox1.Text) && r.Cells["Column3"].Value.ToString().Equals(comboBox2.Text) && r.Cells["Column5"].Value.ToString().Equals(comboBox1.Text)).First();
                        break;
                    }
                    if (comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column1"].Value.ToString().Equals(textBox2.Text) && r.Cells["Column2"].Value.ToString().Contains(textBox1.Text) && r.Cells["Column3"].Value.ToString().Equals(comboBox2.Text)).First();
                        break;
                    }
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column1"].Value.ToString().Equals(textBox2.Text) || r.Cells["Column2"].Value.ToString().Contains(textBox1.Text)).First();
                    }
                    if (textBox2.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column1"].Value.ToString().Equals(textBox2.Text)).First();
                        break;
                    }
                    if (textBox1.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column2"].Value.ToString().Contains(textBox1.Text)).First();
                    }
                }
            }
            catch
            {
                MessageBox.Show("查找的学生不存在");
            }
            finally
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                if (row != null)
                    dataGridView1.Rows[row.Index].DefaultCellStyle.BackColor = Color.Red;
            }
        }
    }
}
