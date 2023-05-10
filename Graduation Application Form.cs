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
    public partial class 毕业申报表 : Form
    {
        public int studentId=0;
        public 毕业申报表()
        {
            InitializeComponent();
        }
        public 毕业申报表(int stuId)
        {
            studentId = stuId;
            InitializeComponent();
        }

        private void 毕业申报表_Load(object sender, EventArgs e)
        {
            

            //学生打开是以下情况
            if(LoginMainFrom.user.userIdenty==0&&studentId==0)
            {
                //自动填写学生基本信息
                //\姓名，\学号，\班级，\辅导员，\学院，班导师，学历，专业
                textBox14.Text = LoginMainFrom.user.userName;
                textBox2.Text = LoginMainFrom.user.userID.ToString();
                MySqlConnection connection = MysqlWays.ConnectMySql();
                string sqlStr = "select cl.class_name 'class',ac.ac_name 'academy',t.t_name 'teacher',pr.pro_name'pro' from class cl left join student stu on stu.s_class=cl.class_no left join academy ac on ac.ac_no=cl.s_academy left join teacher t on cl.t_no=t.t_no left join profession pr on pr.pro_no=stu.s_pro where stu.s_no=" + LoginMainFrom.user.userID.ToString();
                MySqlCommand mySqlCommand = new MySqlCommand(sqlStr, connection);
                using (MySqlDataReader dataReader = mySqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        string _class = dataReader.GetString("class");
                        textBox13.Text = _class;
                        textBox1.Text = dataReader.GetString("teacher");
                        textBox3.Text = dataReader.GetString("academy");
                        textBox9.Text = dataReader.GetString("pro");
                        textBox4.Text = "本科";
                    }
                }
                    
                connection.Close();
                connection.Open();
                string sqlStr1 = "select t.t_name 't' from class cl left join student stu on stu.s_class=cl.class_no left join academy ac on ac.ac_no=cl.s_academy left join teacher t on cl.b_no=t.t_no left join profession pr on pr.pro_no=stu.s_pro where stu.s_no=" + LoginMainFrom.user.userID.ToString();
                MySqlCommand mySqlCommand1 = new MySqlCommand(sqlStr1, connection);
                using (MySqlDataReader dataReader1 = mySqlCommand1.ExecuteReader())
                {
                    if (dataReader1.Read())
                    {
                        textBox5.Text = dataReader1.GetString("t");
                    }
                    connection.Close();
                }
                    
            }
            //教师查看是以下情况
            if (studentId != 0)
            {


                // 需要隐藏的控件
                button2.Visible = false;
                button1.Visible = false;
                dateTimePicker1.Visible = false;

                //无法编辑的控件
                textBox11.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox10.ReadOnly = true;
                textBox16.ReadOnly = true;
                textBox12.ReadOnly = true;
                comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox6.Enabled = false;


                //查询显示对应数据
                textBox2.Text = studentId.ToString();
                MySqlConnection connection = MysqlWays.ConnectMySql();
                string sqlStr = "select * from graduationdeclaration where s_no=" + studentId.ToString();
                MySqlCommand mySqlCommand = new MySqlCommand(sqlStr, connection);
                using (MySqlDataReader dataReader = mySqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        textBox14.Text = dataReader.GetString("s_name");
                        textBox13.Text = dataReader.GetString("class_name");
                        textBox1.Text = dataReader.GetString("s_counsellor");
                        textBox9.Text = dataReader.GetString("pro_name");
                        textBox3.Text = dataReader.GetString("ac_name");
                        textBox5.Text = dataReader.GetString("s_ClassTutor");
                        textBox4.Text = dataReader.GetString("degree");
                        textBox6.Text = dataReader.GetString("s_phone");
                        textBox11.Text = dataReader.GetString("f_phone");
                        comboBox3.Text = dataReader.GetString("EmploymentStatus");
                        comboBox6.Text = dataReader.GetString("s_state");
                        comboBox4.Text = dataReader.GetString("go_way");
                        textBox10.Text = dataReader.GetString("Referrer");
                        textBox8.Text = dataReader.GetString("Jobs");
                        int m = dataReader.GetString("ArrivalTime").IndexOf(':');
                        textBox15.Text = dataReader.GetString("ArrivalTime").Substring(0, m - 1);
                        textBox16.Text = dataReader.GetString("Salary");
                        textBox7.Text = dataReader.GetString("EmploymentCompanies");
                        textBox12.Text = dataReader.GetString("s_Comment");
                    }
                }
                    
                connection.Close();


            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentMainform.StudentPMF.button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = MysqlWays.ConnectMySql();
            string sqlStr = "select check_state from student where s_no=" + LoginMainFrom.user.userID.ToString();
            MySqlCommand mySqlCommand = new MySqlCommand(sqlStr, connection);
            using (MySqlDataReader dataReader = mySqlCommand.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    if (dataReader.GetString("check_state") == "未提交")//判断是否未提交过
                    {
                        connection.Close();

                        int y = 0;
                        int m = 0;
                        connection.Open();
                        string sqlStr2 = "insert into graduationdeclaration values('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + comboBox3.Text + "','" + textBox10.Text + "','" + textBox8.Text + "','" + textBox16.Text + "','" + textBox15.Text + "','" + textBox11.Text + "','" + textBox7.Text + "','" + textBox12.Text + "','" + comboBox6.Text + "','" + textBox6.Text + "','" + textBox14.Text + "','" + textBox13.Text + "','" + textBox9.Text + "','" + textBox3.Text + "','" + comboBox4.Text + "')";

                        try
                        {
                            y = MySqlHelper.ExecuteNonQuery(connection, sqlStr2);//提交后，提交状态加一
                            connection.Close();

                            connection.Open();
                            string sqlStr1 = "Update student set check_state='班导师审核' where s_no=" + LoginMainFrom.user.userID;
                            m = MySqlHelper.ExecuteNonQuery(connection, sqlStr1);//提交后，提交状态加一
                            connection.Close();
                        }
                        catch
                        {
                            MessageBox.Show("请将信息输入完整后提交！");
                        }
                        if (m > 0)
                        {
                            if (y > 0)
                            {
                                StudentMainform.StudentPMF.button1_Click(sender, e);
                                MessageBox.Show("提交成功！");
                            }
                        }

                    }
                    else MessageBox.Show("还有申报正在审批中，请勿重复提交噢！");
                }
            }
                
            
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {

            //dateTimePicker1.ShowUpDown = true;
            //控制日期或时间的显示格式

            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            //使用自定义格式

            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;

            //时间控件的启用
            textBox15.Text = dateTimePicker1.Text;
        }
    }
}
