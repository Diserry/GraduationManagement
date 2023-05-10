using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 毕业生管理系统
{
    public partial class 面试详情 : Form
    {
        public 面试详情(string S_no,string Comp_no,string P_no)
        {
            InitializeComponent();
            s_no= S_no;
            comp_no= Comp_no;
            p_no= P_no;
        }
        public string s_no;
        public string comp_no;
        public string p_no;
        public int operate;         //表示要进行的操作0表示查看 1表示增加 2表示公司操作
        private void 面试详情_Load(object sender, EventArgs e)
        {
            if(operate==0)          //查询操作初始化所有信息
            {
                //隐藏控件
                tbDate.Visible= false;
                tbHour.Visible= false;
                tbMinute.Visible= false;
                lbHour.Visible= false;
                lbMinute.Visible= false;
                btnBack.Visible= false;
                btnBack2.Visible= false;
                btnTrue.Visible= false;
                btnRefuse.Visible= false;
                btnPass.Visible= false;
                label4.Visible= false;

                string sql = "select * from interview i join company c on i.comp_no=c.comp_no join post p on p.p_no=i.p_no join student s on s.s_no=i.s_no";
                sql += " where i.s_no=" + s_no + " and i.comp_no=" + comp_no + " and i.p_no=" + p_no;
                MySqlDataReader dr=MysqlWays.dataReader(sql);
                if(dr.Read())
                {
                    tbName.Text=dr.GetString("s_name");
                    tbS_no.Text = dr.GetString("s_no");
                    tbCompany.Text = dr.GetString("comp_name");
                    tbPost.Text = dr.GetString("p_name");
                    tbDateTime.Text = Convert.ToDateTime(dr.GetString("i_time")).ToString("yyyy年MM月dd日 HH时mm分");
                    tbPosition.Text = dr.GetString("i_position");
                    tbState.Text = dr.GetString("i_state");
                    if (tbState.Text.Equals("待面试"))
                    {
                        tbState.ForeColor = Color.Blue;
                    }
                    else if (tbState.Text.Equals("未通过"))
                    {
                        tbState.ForeColor = Color.Red;
                    }
                    else if (tbState.Text.Equals("已通过"))
                    {
                        tbState.ForeColor = Color.Green;
                    }
                    tbContent.Text = dr.GetString("i_content");
                }
            }
            else if (operate == 1)
            {
                //隐藏状态控件
                lbState.Visible = false;
                tbState.Visible = false;  
                tbDateTime.Visible = false;
                btnBack2.Visible = false;
                btnRefuse.Visible = false;
                btnPass.Visible = false;

                //开启控件，能够输入
                tbDate.Enabled = true;         
                tbPosition.ReadOnly = false;
                tbContent.ReadOnly = false;
                string sql = "select * from jobwanted j join company c on j.comp_no=c.comp_no join student s on s.s_no=j.s_no join post p on p.p_no=j.p_no";
                sql += " where j.s_no=" + this.s_no + " and j.comp_no=" + this.comp_no + " and j.p_no=" + this.p_no;
                using(MySqlDataReader dr = MysqlWays.dataReader(sql))
                if (dr.Read())
                {
                    tbName.Text = dr.GetString("s_name");
                    tbS_no.Text = dr.GetString("s_no");
                    tbCompany.Text = dr.GetString("comp_name");
                    tbPost.Text = dr.GetString("p_name");
                }

            }else if (operate == 2)
            {   
                btnBack.Visible = false;
                btnTrue.Visible = false;
                tbDate.Visible = false;
                tbHour.Visible = false;
                tbMinute.Visible = false;
                lbHour.Visible = false;
                lbMinute.Visible = false;
                //同第一个查看一样
                string sql = "select * from interview i join company c on i.comp_no=c.comp_no join post p on p.p_no=i.p_no join student s on s.s_no=i.s_no";
                sql += " where i.s_no=" + s_no + " and i.comp_no=" + comp_no + " and i.p_no=" + p_no;
                using(MySqlDataReader dr = MysqlWays.dataReader(sql))
                if (dr.Read())
                {
                    tbName.Text = dr.GetString("s_name");
                    tbS_no.Text = dr.GetString("s_no");
                    tbCompany.Text = dr.GetString("comp_name");
                    tbPost.Text = dr.GetString("p_name");
                    tbDateTime.Text = Convert.ToDateTime(dr.GetString("i_time")).ToString("yyyy年MM月dd日 HH时mm分");
                    tbPosition.Text = dr.GetString("i_position");
                    tbState.Text = dr.GetString("i_state");
                    tbContent.Text = dr.GetString("i_content");
                }
            }
            
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTrue_Click(object sender, EventArgs e)
        {
            if (tbPosition.Text.Equals(""))
            {
                MessageBox.Show("请输入面试地点");
                return;
            }
            string sql="insert into interview(comp_no,p_no,s_no,i_time,i_position,i_state,i_content)";
            sql += " value(" + comp_no + "," + p_no + "," + s_no + ",'" + tbDate.Text + " " + tbHour.Value +":"+tbMinute.Value+ ":00','" + tbPosition.Text + "','待面试','" + tbContent.Text + "')";
            if (MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
                sql = "update jobwanted set j_state='待面试' where s_no=" + s_no + " and comp_no=" + comp_no + " and p_no=" + p_no;
                MysqlWays.executeSql(sql);
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            string sql = "update interview set i_state='已通过' where comp_no=" + comp_no + " and s_no=" + s_no + " and p_no=" + p_no;
            if (MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
                sql = "update jobwanted set j_state='已就职' where comp_no=" + comp_no + " and s_no=" + s_no + " and p_no=" + p_no;
                MysqlWays.executeSql(sql);
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }

        private void btnRefuse_Click(object sender, EventArgs e)
        {
            string sql = "update interview set i_state='未通过' where comp_no=" + comp_no + " and s_no=" + s_no + " and p_no=" + p_no;
            if (MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
                sql= "update jobwanted set j_state='面试失败' where comp_no=" + comp_no + " and s_no=" + s_no + " and p_no=" + p_no;
                MysqlWays.executeSql(sql);
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }
    }
}
