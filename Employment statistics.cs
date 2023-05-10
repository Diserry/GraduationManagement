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
    public partial class 就业统计 : Form
    {
        //提出定义，0是班级，1是专业，2是学院，3是全校
        int CheckWay = 0;
        public 就业统计(int checkWay)
        {
            InitializeComponent();
            CheckWay = checkWay;
        }
        public 就业统计()
        {
            InitializeComponent();
        }
        private void 就业统计_Load(object sender, EventArgs e)
        {
            //班级统计
            if(CheckWay==0)
            {
               if(LoginMainFrom.user.userIdenty==2)//班导师
                {
                    //添加班级列表
                    string sqlStr2 = "select class_name from class where b_no=" + LoginMainFrom.user.userID + " or t_no=" + LoginMainFrom.user.userID + " order by class_no";
                    using(MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr2))
                    while (dataReader1.Read())
                    {
                        comboBox1.Items.Add(dataReader1[0]);
                    }
                    //添加专业列表
                    string sqlStr3 = "select pro.pro_name from profession pro left join class cl on pro.pro_no=cl.pro_no where cl.b_no=" + LoginMainFrom.user.userID + " or cl.t_no=" + LoginMainFrom.user.userID + " order by class_no";
                    using(MySqlDataReader dataReader2 = MysqlWays.dataReader(sqlStr3))
                    while (dataReader2.Read())
                    {
                        comboBox2.Items.Add(dataReader2[0]);
                    }
                    //添加学院列表
                    string sqlStr = "select ac.ac_name from academy ac left join class cl on ac.ac_no=cl.s_academy where cl.b_no=" + LoginMainFrom.user.userID + " or cl.t_no=" + LoginMainFrom.user.userID + " order by class_no";
                    using(MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr))
                    while (dataReader.Read())
                    {
                        comboBox3.Items.Add(dataReader[0]);
                    }
                    string sqlStr5 = "select gr.ac_name,gr.pro_name,gr.class_name,COUNT(*) 'personCount',COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'employCount' ,COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)'jobCount',concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'employPro' ,concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'SignPro' ,truncate(AVG(IF(gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约',Salary,NULL)),2)'AvgSalary'from graduationdeclaration gr left join student stu on gr.s_no=stu.s_no left join class cl on stu.s_class=cl.class_no left join teacher t on t.t_no=cl.b_no where t.t_no=" + LoginMainFrom.user.userID+" GROUP BY cl.class_no;";
                    dataGridView1.DataSource = MysqlWays.checkData(sqlStr5).Tables[0];
                }
               if (LoginMainFrom.user.userIdenty == 1)//辅导员
                {
                    //添加班级列表
                    string sqlStr2 = "select class_name from class where b_no=" + LoginMainFrom.user.userID + " or t_no=" + LoginMainFrom.user.userID + " order by class_no";
                    using(MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr2))
                    while (dataReader1.Read())
                    {
                        comboBox1.Items.Add(dataReader1[0]);
                    }
                    //添加专业列表
                    string sqlStr3 = "select pro.pro_name from profession pro left join class cl on pro.pro_no=cl.pro_no where cl.b_no=" + LoginMainFrom.user.userID + " or cl.t_no=" + LoginMainFrom.user.userID + " order by class_no";
                    using(MySqlDataReader dataReader2 = MysqlWays.dataReader(sqlStr3))
                    while (dataReader2.Read())
                    {
                        comboBox2.Items.Add(dataReader2[0]);
                    }
                    //添加学院列表
                    string sqlStr = "select ac.ac_name from academy ac left join class cl on ac.ac_no=cl.s_academy where cl.b_no=" + LoginMainFrom.user.userID + " or cl.t_no=" + LoginMainFrom.user.userID + " order by class_no";
                    using(MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr))
                    while (dataReader.Read())
                    {
                        comboBox3.Items.Add(dataReader[0]);
                    }
                    string sqlStr5 = "select gr.ac_name,gr.pro_name,gr.class_name,COUNT(*) 'personCount',COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'employCount' ,COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)'jobCount',concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'employPro' ,concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'SignPro' ,truncate(AVG(IF(gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约',Salary,NULL)),2)'AvgSalary'from graduationdeclaration gr left join student stu on gr.s_no=stu.s_no left join class cl on stu.s_class=cl.class_no left join teacher t on t.t_no=cl.t_no where t.t_no=" + LoginMainFrom.user.userID + " GROUP BY cl.class_no;";
                    dataGridView1.DataSource = MysqlWays.checkData(sqlStr5).Tables[0];
                }
               if (LoginMainFrom.user.userIdenty == 3)//就业科
                {
                    //添加班级列表
                    string sqlStr2 = "select class_name from class order by class_no";
                    using(MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr2))
                    while (dataReader1.Read())
                    {
                        comboBox1.Items.Add(dataReader1[0]);
                    }
                    //添加专业列表
                    string sqlStr3 = "select pro_name from profession";
                    using(MySqlDataReader dataReader2 = MysqlWays.dataReader(sqlStr3))
                    while (dataReader2.Read())
                    {
                        comboBox2.Items.Add(dataReader2[0]);
                    }
                    //添加学院列表
                    string sqlStr = "select ac_name from academy";
                    using(MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr))
                    while (dataReader.Read())
                    {
                        comboBox3.Items.Add(dataReader[0]);
                    }
                    string sqlStr5 = "select gr.ac_name,gr.pro_name,gr.class_name,COUNT(*) 'personCount',COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'employCount' ,COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)'jobCount',concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'employPro' ,concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'SignPro' ,truncate(AVG(IF(gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约',Salary,NULL)),2)'AvgSalary'from graduationdeclaration gr left join student stu on gr.s_no=stu.s_no left join class cl on stu.s_class=cl.class_no left join teacher t on t.t_no=cl.t_no GROUP BY cl.class_no;";
                    dataGridView1.DataSource = MysqlWays.checkData(sqlStr5).Tables[0];
                }
            }
            //专业统计
            if(CheckWay == 1)
            {
                label7.Text = "专业就业统计";
                comboBox1.Visible = false;
                label1.Visible = false;
                //添加专业列表
                string sqlStr3 = "select pro_name from profession";
                using(MySqlDataReader dataReader2 = MysqlWays.dataReader(sqlStr3))
                while (dataReader2.Read())
                {
                    comboBox2.Items.Add(dataReader2[0]);
                }
                //添加学院列表
                string sqlStr = "select ac_name from academy";
                using(MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr))
                while (dataReader.Read())
                {
                    comboBox3.Items.Add(dataReader[0]);
                }
                dataGridView1.Columns["Column3"].Visible = false;
                string sqlStr5 = "select gr.ac_name,gr.pro_name,COUNT(*) 'personCount',COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'employCount' ,COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)'jobCount',concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'employPro' ,concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'SignPro' ,truncate(AVG(IF(gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约',Salary,NULL)),2)'AvgSalary'from graduationdeclaration gr left join student stu on gr.s_no=stu.s_no left join class cl on stu.s_class=cl.class_no left join profession pro on cl.pro_no=pro.pro_no GROUP BY cl.pro_no;";
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr5).Tables[0];

            }
            //学院统计
            if (CheckWay == 2)
            {
                label7.Text = "学院就业统计";
                comboBox2.Visible = false;
                comboBox1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                //添加学院列表
                string sqlStr = "select ac_name from academy";
                using(MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr))
                while (dataReader.Read())
                {
                    comboBox3.Items.Add(dataReader[0]);
                }
                dataGridView1.Columns["Column3"].Visible = false;
                dataGridView1.Columns["Column2"].Visible = false;
                string sqlStr5 = "select gr.ac_name,COUNT(*) 'personCount',COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'employCount' ,COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)'jobCount',concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'employPro' ,concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'SignPro' ,truncate(AVG(IF(gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约',Salary,NULL)),2)'AvgSalary'from graduationdeclaration gr left join student stu on gr.s_no=stu.s_no left join class cl on stu.s_class=cl.class_no left join academy ac on ac.ac_no=cl.s_academy GROUP BY ac.ac_no;";
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr5).Tables[0];
            }
            //全校统计
            if (CheckWay == 3)
            {
                panel1.Visible = false;
                label6.Text = "以下为全校就业统计信息：";
                label7.Text = "全校就业统计";
                dataGridView1.Columns["Column3"].Visible = false;
                dataGridView1.Columns["Column2"].Visible = false;
                dataGridView1.Columns["Column1"].Visible = false;
                string sqlStr5 = "select COUNT(*) 'personCount',COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'employCount' ,COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)'jobCount',concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'employPro' ,concat(TRUNCATE(COUNT(case when gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll end)*100/COUNT(*),2),'%') as'SignPro' ,truncate(AVG(IF(gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约',Salary,NULL)),2)'AvgSalary'from graduationdeclaration gr;"; 
                dataGridView1.DataSource = MysqlWays.checkData(sqlStr5).Tables[0];
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = null;
            try
            {
                for (int i = 0; i <= 0; i++)
                {
                    if (comboBox3.Text != "" && comboBox2.Text != "" && comboBox1.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column1"].Value.ToString().Contains(comboBox3.Text) && r.Cells["Column2"].Value.ToString().Contains(comboBox2.Text) && r.Cells["Column3"].Value.ToString().Contains(comboBox1.Text)).First();

                        break;
                    }
                    if(comboBox2.Text != "" && comboBox3.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column2"].Value.ToString().Contains(comboBox2.Text) && r.Cells["Column1"].Value.ToString().Equals(comboBox3.Text)).First();
                        break;
                    }
                    if (comboBox2.Text != "" && comboBox1.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column2"].Value.ToString().Contains(comboBox2.Text) && r.Cells["Column3"].Value.ToString().Equals(comboBox1.Text)).First();
                        break;
                    }
                    if (comboBox1.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column3"].Value.ToString().Equals(comboBox1.Text)).First();
                        break;
                    }
                    if (comboBox2.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column2"].Value.ToString().Equals(comboBox2.Text)).First();
                        break;
                    }
                    if (comboBox3.Text != "")
                    {
                        row = dataGridView1.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Column1"].Value.ToString().Equals(comboBox3.Text)).First();
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("不存在该班级");
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
