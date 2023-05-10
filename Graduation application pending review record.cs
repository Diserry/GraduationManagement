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
    public partial class 毕业申报待审查 : Form
    {
        public 毕业申报待审查()
        {
            InitializeComponent();
        }

        private void 毕业申报待审查_Load(object sender, EventArgs e)
        {
            if(LoginMainFrom.user.userIdenty==1)//辅导员查看待审
            {
                label4.Visible = false;
                comboBox1.Visible = false;
                //添加班级列表
                string sqlStr2 = "select class_name from class where b_no=" + LoginMainFrom.user.userID + " or t_no=" + LoginMainFrom.user.userID + " order by class_no";
                using (MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr2))
                {
                    while (dataReader1.Read())
                    {
                        comboBox2.Items.Add(dataReader1[0]);
                    }
                }
                    
                string sqlStr = "select stu.s_no,stu.s_name,cl.class_name,pro.pro_name,ac.ac_name,t.t_name from student stu left join class cl on stu.s_class=cl.class_no left join profession pro on stu.s_pro=pro.pro_no left join academy ac on cl.s_academy=ac.ac_no left join teacher t on cl.t_no=t.t_no where stu.check_state='辅导员审核' and cl.t_no="+LoginMainFrom.user.userID;
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr).Tables[0];

            }
            if (LoginMainFrom.user.userIdenty == 2)//班导师查看待审
            {
                label4.Visible = false;
                comboBox1.Visible = false;
                //添加班级列表
                string sqlStr2 = "select class_name from class where b_no=" + LoginMainFrom.user.userID + " or t_no=" + LoginMainFrom.user.userID + " order by class_no";
                using (MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr2))
                {
                    while (dataReader1.Read())
                    {
                        comboBox2.Items.Add(dataReader1[0]);
                    }
                }
                    
                string sqlStr = "select stu.s_no,stu.s_name,cl.class_name,pro.pro_name,ac.ac_name,t.t_name from student stu left join class cl on stu.s_class=cl.class_no left join profession pro on stu.s_pro=pro.pro_no left join academy ac on cl.s_academy=ac.ac_no left join teacher t on cl.t_no=t.t_no where stu.check_state='班导师审核' and cl.b_no=" + LoginMainFrom.user.userID;
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr).Tables[0];
            }
            if (LoginMainFrom.user.userIdenty == 3)//就业科查看待审
            {
                //学院列表添加成员
                string sqlStr1 = "select ac_name from academy";
                using (MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr1))
                {
                    while (dataReader.Read())
                    {
                        comboBox1.Items.Add(dataReader[0]);
                    }
                }
                    

                //班级列表添加成员
                string sqlStr2 = "select class_name from class order by class_no";
                using (MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr2))
                {
                    while (dataReader1.Read())
                    {
                        comboBox2.Items.Add(dataReader1[0]);
                    }
                }
                    
                string sqlStr = "select stu.s_no,stu.s_name,cl.class_name,pro.pro_name,ac.ac_name,t.t_name from student stu left join class cl on stu.s_class=cl.class_no left join profession pro on stu.s_pro=pro.pro_no left join academy ac on cl.s_academy=ac.ac_no left join teacher t on cl.t_no=t.t_no where stu.check_state='就业科审核'";
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr).Tables[0];
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //查看
            if (dataGridView1.Columns[e.ColumnIndex].Name == "check" && e.RowIndex >= 0)
            {
                毕业申报表 frm = new 毕业申报表(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString()));
                frm.ShowDialog();
            }
            //通过
            if (dataGridView1.Columns[e.ColumnIndex].Name == "pass" && e.RowIndex >= 0)
            {
                if(LoginMainFrom.user.userIdenty==2)//班导师通过
                {
                    MySqlConnection connection= MysqlWays.ConnectMySql();
                    string sqlStr = "update student set check_state='辅导员审核' where s_no="+ dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    int m = MySqlHelper.ExecuteNonQuery(connection, sqlStr);//提交后，提交状态加一
                    connection.Close();
                    if(m>0)
                    MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString() + "已通过！");
                    string sqlStr1 = "select stu.s_no,stu.s_name,cl.class_name,pro.pro_name,ac.ac_name,t.t_name from student stu left join class cl on stu.s_class=cl.class_no left join profession pro on stu.s_pro=pro.pro_no left join academy ac on cl.s_academy=ac.ac_no left join teacher t on cl.t_no=t.t_no where stu.check_state='班导师审核' and cl.b_no=" + LoginMainFrom.user.userID;
                    dataGridView1.DataSource = MysqlWays.checkData(sqlStr1).Tables[0];
                }
                if (LoginMainFrom.user.userIdenty == 1)//辅导员通过
                {
                    MySqlConnection connection = MysqlWays.ConnectMySql();
                    string sqlStr = "update student set check_state='就业科审核' where s_no=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    int m = MySqlHelper.ExecuteNonQuery(connection, sqlStr);//提交后，提交状态加一
                    connection.Close();
                    if (m > 0)
                        MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString() + "已通过！");
                    string sqlStr1 = "select stu.s_no,stu.s_name,cl.class_name,pro.pro_name,ac.ac_name,t.t_name from student stu left join class cl on stu.s_class=cl.class_no left join profession pro on stu.s_pro=pro.pro_no left join academy ac on cl.s_academy=ac.ac_no left join teacher t on cl.t_no=t.t_no where stu.check_state='辅导员审核' and cl.t_no=" + LoginMainFrom.user.userID;
                    dataGridView1.DataSource = MysqlWays.checkData(sqlStr1).Tables[0];
                }
                if (LoginMainFrom.user.userIdenty == 3)//就业科通过
                {
                    MySqlConnection connection = MysqlWays.ConnectMySql();
                    string sqlStr = "update student set check_state='已通过审核' where s_no=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    int m = MySqlHelper.ExecuteNonQuery(connection, sqlStr);//提交后，提交状态加一
                    connection.Close();
                    if (m > 0)
                        MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString() + "已通过！");
                    string sqlStr1 = "select stu.s_no,stu.s_name,cl.class_name,pro.pro_name,ac.ac_name,t.t_name from student stu left join class cl on stu.s_class=cl.class_no left join profession pro on stu.s_pro=pro.pro_no left join academy ac on cl.s_academy=ac.ac_no left join teacher t on cl.t_no=t.t_no where stu.check_state='就业科审核'";
                    dataGridView1.DataSource = MysqlWays.checkData(sqlStr1).Tables[0];
                }
            }
            //打回
            if (dataGridView1.Columns[e.ColumnIndex].Name == "unpass" && e.RowIndex >= 0)
            {
                if (LoginMainFrom.user.userIdenty == 2)//班导师
                {
                    MySqlConnection connection = MysqlWays.ConnectMySql();
                    string sqlStr = "update student set check_state='未提交' where s_no=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString()+ ";delete from graduationdeclaration where s_no=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    int m = MySqlHelper.ExecuteNonQuery(connection, sqlStr);//提交后，提交状态加一
                    connection.Close();
                    if (m > 0)
                        MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString() + "已打回！");
                    string sqlStr1 = "select stu.s_no,stu.s_name,cl.class_name,pro.pro_name,ac.ac_name,t.t_name from student stu left join class cl on stu.s_class=cl.class_no left join profession pro on stu.s_pro=pro.pro_no left join academy ac on cl.s_academy=ac.ac_no left join teacher t on cl.t_no=t.t_no where stu.check_state='班导师审核' and cl.b_no=" + LoginMainFrom.user.userID;
                    dataGridView1.DataSource = MysqlWays.checkData(sqlStr1).Tables[0];
                }
                if (LoginMainFrom.user.userIdenty == 1)//辅导员
                {
                    MySqlConnection connection = MysqlWays.ConnectMySql();
                    string sqlStr = "update student set check_state='未提交' where s_no=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString() + ";delete from graduationdeclaration where s_no=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    int m = MySqlHelper.ExecuteNonQuery(connection, sqlStr);//提交后，提交状态加一
                    connection.Close();
                    if (m > 0)
                        MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString() + "已打回！");
                    string sqlStr1 = "select stu.s_no,stu.s_name,cl.class_name,pro.pro_name,ac.ac_name,t.t_name from student stu left join class cl on stu.s_class=cl.class_no left join profession pro on stu.s_pro=pro.pro_no left join academy ac on cl.s_academy=ac.ac_no left join teacher t on cl.t_no=t.t_no where stu.check_state='辅导员审核' and cl.t_no=" + LoginMainFrom.user.userID;
                    dataGridView1.DataSource = MysqlWays.checkData(sqlStr1).Tables[0];
                }
                if (LoginMainFrom.user.userIdenty == 3)//就业科
                {
                    MySqlConnection connection = MysqlWays.ConnectMySql();
                    string sqlStr = "update student set check_state='未提交' where s_no=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString() + ";delete from graduationdeclaration where s_no=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    int m = MySqlHelper.ExecuteNonQuery(connection, sqlStr);//提交后，提交状态加一
                    connection.Close();
                    if (m > 0)
                        MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString() + "已打回！");
                    string sqlStr1 = "select stu.s_no,stu.s_name,cl.class_name,pro.pro_name,ac.ac_name,t.t_name from student stu left join class cl on stu.s_class=cl.class_no left join profession pro on stu.s_pro=pro.pro_no left join academy ac on cl.s_academy=ac.ac_no left join teacher t on cl.t_no=t.t_no where stu.check_state='就业科审核' and cl.b_no=" + LoginMainFrom.user.userID;
                    dataGridView1.DataSource = MysqlWays.checkData(sqlStr1).Tables[0];
                }
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
                        break;
                    }
                    if(textBox2.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column1"].Value.ToString().Equals(textBox2.Text)).First();
                        break;
                    }
                    if(textBox1.Text!="")
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
