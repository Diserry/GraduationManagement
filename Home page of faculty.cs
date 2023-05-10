using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 毕业生管理系统
{
    public partial class 教职工首页 : Form
    {
        public 教职工首页()
        {
            InitializeComponent();
        }

        private void 教职工首页_Load(object sender, EventArgs e)
        {
            //班导师
            if(LoginMainFrom.user.userIdenty==2)
            {
                //为第一个表注入数据
                string sqlStr2 = "select COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'employCount' ,COUNT(case when gr.EmploymentStatus = '未实习' THEN 1 ELSE NUll end)'noJob' from graduationdeclaration gr left join student stu on gr.s_no=stu.s_no left join class cl on stu.s_class=cl.class_no left join teacher t on t.t_no=cl.b_no where t.t_no=" + LoginMainFrom.user.userID;
                using (MySqlDataReader dataReader2 = MysqlWays.dataReader(sqlStr2))
                {
                    if (dataReader2.Read())
                    {
                        chart1.Series[0].Points.Add(double.Parse(dataReader2.GetString("employCount")));
                        label6.Text = dataReader2.GetString("employCount") + " 人";
                        chart1.Series[0].Points.Add(double.Parse(dataReader2.GetString("noJob")));
                        label7.Text = dataReader2.GetString("noJob") + " 人";
                        chart1.Series[0].Points[0].Color = Color.Blue;//蓝色是已实习人数
                        chart1.Series[0].Points[1].Color = Color.Red;

                    }
                }
                    
                
                //为第二个表注入数据
                string sqlStr3 = "select COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)-COUNT(CASE WHEN gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END) 'unSign' ,COUNT(CASE WHEN gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'Sign' from graduationdeclaration gr left join student stu on gr.s_no=stu.s_no left join class cl on stu.s_class=cl.class_no left join teacher t on t.t_no=cl.b_no where t.t_no=" + LoginMainFrom.user.userID;
                using(MySqlDataReader dataReader3 = MysqlWays.dataReader(sqlStr3))
                {
                    if (dataReader3.Read())
                    {
                        chart3.Series[0].Points.Add(double.Parse(dataReader3.GetString("unSign")));
                        label9.Text = dataReader3.GetString("unSign") + " 人";
                        chart3.Series[0].Points.Add(double.Parse(dataReader3.GetString("Sign")));
                        label8.Text = dataReader3.GetString("Sign") + " 人";
                        chart3.Series[0].Points[1].Color = Color.Yellow;//黄色是已实习人数
                        chart3.Series[0].Points[0].Color = Color.White;

                    }
                }
                //为第三个表注入数据
                string sqlStr = "select gr.Salary FROM graduationdeclaration gr left join student stu on stu.s_no=gr.s_no left join class cl on cl.class_no=stu.s_class left join teacher t on t.t_no =cl.b_no where cl.b_no="+LoginMainFrom.user.userID+ " and gr.EmploymentStatus!='未实习'";
                using (MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr))
                {
                    while (dataReader.Read())
                    {
                        chart2.Series[0].Points.AddY(dataReader[0]);
                    }
                }

                string sqlStr1 = "select MAX(Salary)'max',MIN(Salary)'min' FROM graduationdeclaration where EmploymentStatus!='未实习'";

                using (MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr1))
                {
                    if (dataReader1.Read())
                    {
                        label10.Text = dataReader1.GetString("max") + "元/每月";
                        label1.Text = dataReader1.GetString("min") + "元/每月";
                    }
                }
            }
            //辅导员
            if (LoginMainFrom.user.userIdenty == 1)
            {
                //为第一个表注入数据
                string sqlStr2 = "select COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'employCount' ,COUNT(case when gr.EmploymentStatus = '未实习' THEN 1 ELSE NUll end)'noJob' from graduationdeclaration gr left join student stu on gr.s_no=stu.s_no left join class cl on stu.s_class=cl.class_no left join teacher t on t.t_no=cl.t_no where t.t_no=" + LoginMainFrom.user.userID;
                using (MySqlDataReader dataReader2 = MysqlWays.dataReader(sqlStr2))
                {
                    if (dataReader2.Read())
                    {
                        chart1.Series[0].Points.Add(double.Parse(dataReader2.GetString("employCount")));
                        label6.Text = dataReader2.GetString("employCount") + " 人";
                        chart1.Series[0].Points.Add(double.Parse(dataReader2.GetString("noJob")));
                        label7.Text = dataReader2.GetString("noJob") + " 人";
                        chart1.Series[0].Points[0].Color = Color.Blue;//蓝色是已实习人数
                        chart1.Series[0].Points[1].Color = Color.Red;
                    }
                }
                //为第二个表注入数据
                string sqlStr3 = "select COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)-COUNT(CASE WHEN gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END) 'unSign' ,COUNT(CASE WHEN gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'Sign' from graduationdeclaration gr left join student stu on gr.s_no=stu.s_no left join class cl on stu.s_class=cl.class_no left join teacher t on t.t_no=cl.t_no where t.t_no=" + LoginMainFrom.user.userID;
                using (MySqlDataReader dataReader3 = MysqlWays.dataReader(sqlStr3))
                {
                    if (dataReader3.Read())
                    {
                        chart3.Series[0].Points.Add(double.Parse(dataReader3.GetString("unSign")));
                        label9.Text = dataReader3.GetString("unSign") + " 人";
                        chart3.Series[0].Points.Add(double.Parse(dataReader3.GetString("Sign")));
                        label8.Text = dataReader3.GetString("Sign") + " 人";
                        chart3.Series[0].Points[1].Color = Color.Yellow;//黄色是已实习人数
                        chart3.Series[0].Points[0].Color = Color.White;
                    }
                }
                    
                //为第三个表注入数据
                string sqlStr = "select gr.Salary FROM graduationdeclaration gr left join student stu on stu.s_no=gr.s_no left join class cl on cl.class_no=stu.s_class left join teacher t on t.t_no =cl.t_no where cl.t_no=" + LoginMainFrom.user.userID;
                using(MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr))
                {
                    while (dataReader.Read())
                    {
                        chart2.Series[0].Points.AddY(dataReader[0]);
                    }
                }
                string sqlStr1 = "select MAX(Salary)'max',MIN(Salary)'min' FROM graduationdeclaration gr left join student stu on stu.s_no=gr.s_no left join class cl on cl.class_no=stu.s_class left join teacher t on t.t_no =cl.t_no where cl.t_no=" + LoginMainFrom.user.userID + " and gr.EmploymentStatus!='未实习'";
                using (MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr1))
                {
                    if (dataReader1.Read())
                    {
                        label10.Text = dataReader1.GetString("max") + "元/每月";
                        label1.Text = dataReader1.GetString("min") + "元/每月";
                    }
                }
            }
            //就业科
            if (LoginMainFrom.user.userIdenty == 3)
            {
                //为第一个表注入数据
                string sqlStr2 = "select COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'employCount' ,COUNT(case when gr.EmploymentStatus = '未实习' THEN 1 ELSE NUll end)'noJob' from graduationdeclaration gr";
                using(MySqlDataReader dataReader2 = MysqlWays.dataReader(sqlStr2))
                {
                    if (dataReader2.Read())
                    {
                        chart1.Series[0].Points.Add(double.Parse(dataReader2.GetString("employCount")));
                        label6.Text = dataReader2.GetString("employCount") + " 人";
                        chart1.Series[0].Points.Add(double.Parse(dataReader2.GetString("noJob")));
                        label7.Text = dataReader2.GetString("noJob") + " 人";
                        chart1.Series[0].Points[0].Color = Color.Blue;//蓝色是已实习人数
                        chart1.Series[0].Points[1].Color = Color.Red;
                    }
                }
                //为第二个表注入数据
                string sqlStr3 = "select COUNT(CASE WHEN gr.EmploymentStatus = '实习' or gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)-COUNT(CASE WHEN gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END) 'unSign' ,COUNT(CASE WHEN gr.EmploymentStatus = '已签约' THEN 1 ELSE NUll END)'Sign' from graduationdeclaration gr";
                using(MySqlDataReader dataReader3 = MysqlWays.dataReader(sqlStr3))
                if (dataReader3.Read())
                {
                    chart3.Series[0].Points.Add(double.Parse(dataReader3.GetString("unSign")));
                    label9.Text = dataReader3.GetString("unSign") + " 人";
                    chart3.Series[0].Points.Add(double.Parse(dataReader3.GetString("Sign")));
                    label8.Text = dataReader3.GetString("Sign") + " 人";
                    chart3.Series[0].Points[1].Color = Color.Yellow;//黄色是已实习人数
                    chart3.Series[0].Points[0].Color = Color.White;
                }
                //为第三个表注入数据
                string sqlStr = "select Salary FROM graduationdeclaration;";
                using(MySqlDataReader dataReader = MysqlWays.dataReader(sqlStr))
                while (dataReader.Read())
                {
                    chart2.Series[0].Points.AddY(dataReader[0]);
                }
                string sqlStr1 = "select MAX(Salary)'max',MIN(Salary)'min' FROM graduationdeclaration where EmploymentStatus!='未实习'";
                
                using (MySqlDataReader dataReader1 = MysqlWays.dataReader(sqlStr1))
                if (dataReader1.Read())
                {
                    label10.Text = dataReader1.GetString("max") + "元/每月";
                    label1.Text = dataReader1.GetString("min") + "元/每月";
                }
            }
        }

        private void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            //图一提示
            HitTestResult myTestResult = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);//获取命中测试的结果
            if (myTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = myTestResult.PointIndex;
                DataPoint dp = myTestResult.Series.Points[i];
                string XValue = dp.XValue.ToString();//获取数据点的X值
                string YValue = dp.YValues[0].ToString();//获取数据点的Y值
                if(myTestResult.Series.Points[i].Color==Color.Blue)
                e.Text = "已实习人数:" + YValue;
                else
                {
                    e.Text = "未实习人数:" + YValue;
                }
            }
        }

        private void chart3_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            //图二提示
            HitTestResult myTestResult = chart3.HitTest(e.X, e.Y, ChartElementType.DataPoint);//获取命中测试的结果
            if (myTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = myTestResult.PointIndex;
                DataPoint dp = myTestResult.Series.Points[i];
                string XValue = dp.XValue.ToString();//获取数据点的X值
                string YValue = dp.YValues[0].ToString();//获取数据点的Y值
                if (myTestResult.Series.Points[i].Color == Color.White)
                    e.Text = "未签约人数:" + YValue;
                else
                {
                    e.Text = "已签约人数:" + YValue;
                }
            }
        }

        private void chart2_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            HitTestResult myTestResult = chart2.HitTest(e.X, e.Y, ChartElementType.DataPoint);//获取命中测试的结果
            if (myTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = myTestResult.PointIndex;
                DataPoint dp = myTestResult.Series.Points[i];
                string XValue = dp.XValue.ToString();//获取数据点的X值
                string YValue = dp.YValues[0].ToString();//获取数据点的Y值
                    e.Text = "薪资:" + YValue;
            }
        }
    }
}
