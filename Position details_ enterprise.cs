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
    public partial class 岗位详情_企业 : Form
    {
        public 岗位详情_企业()
        {
            InitializeComponent();
        }
        public int operate = 0;        //表示要进行的操作，0表示添加，1表示修改
        public string p_no;             //用于更新操作
        private void 岗位详情_企业_Load(object sender, EventArgs e)
        {
            string sql = "select * from company where comp_no=" + LoginMainFrom.user.userID;
            using (MySqlDataReader dr = MysqlWays.dataReader(sql))
            {
                if (dr.Read())
                {
                    tbComp_name.Text = dr.GetString("comp_name");
                    tbPositon.Text = dr.GetString("comp_position");
                }
                if (operate == 0)
                    sql = "select * from post where p_no!=all(select p_no from postcompany where comp_no=" + LoginMainFrom.user.userID + ")";
                else sql = "select * from post";
                DataTable dt = new DataTable();
                dt.Load(MysqlWays.dataReader(sql));
                cbP_name.DataSource = dt;
                cbP_name.DisplayMember = "p_name";
                cbP_name.ValueMember = "p_no";
                //控件
                if (operate == 0)
                {
                    btnUpdate.Visible = false;
                }
                else
                {
                    btnAdd.Visible = false;//如果控件的值为1，则需要初始化所有的内容
                    sql = "select * from postcompany pc join post p on p.p_no=pc.p_no where p.p_no=" + p_no + " and comp_no=" + LoginMainFrom.user.userID;
                    using (MySqlDataReader dr1 = MysqlWays.dataReader(sql))
                    {
                        if (dr.Read())
                        {
                            cbP_name.Text = dr1.GetString("p_name");
                            tbDegree.Text = dr1.GetString("pc_degree");
                            tbExperience.Text = dr1.GetString("pc_experience");
                            tbSalary.Text = dr1.GetString("pc_salary");
                            tbTechnology.Text = dr1.GetString("pc_technology");
                            tbResponsibility.Text = dr1.GetString("pc_responsibility");
                            tbCount.Text = dr1.GetString("pc_count");
                            tbRequire.Text = dr1.GetString("pc_requrie");

                            cbP_name.Enabled = false;
                            //由于是更新操作，那么设置控件中的值可以被更改

                            tbDegree.ReadOnly = false;
                            tbExperience.ReadOnly = false;
                            tbSalary.ReadOnly = false;
                            tbTechnology.ReadOnly = false;
                            tbResponsibility.ReadOnly = false;
                            tbCount.ReadOnly = false;
                            tbRequire.ReadOnly = false;
                        }
                    }
                        
                }
            }
        
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = "insert into postcompany(p_no,comp_no,pc_salary,pc_position,pc_experience,pc_degree,pc_technology,pc_count,pc_responsibility,pc_requrie) ";
            sql += "value(" + cbP_name.SelectedValue + "," + LoginMainFrom.user.userID + ",'" + tbSalary.Text + "','" + tbPositon.Text + "','" + tbExperience.Text + "','" + tbDegree.Text + "','" + tbTechnology.Text + "',";
            sql += tbCount.Text + ",'" + tbResponsibility.Text + "','" + tbRequire.Text + "')";
            if (MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "update postcompany set pc_salary='"+tbSalary.Text+"',pc_experience='"+tbExperience.Text+"',pc_degree='"+tbDegree.Text+"',pc_technology='"+tbTechnology.Text+"',pc_count="+tbCount.Text+",pc_responsibility='"+tbResponsibility.Text+"',pc_requrie='"+tbRequire.Text+"'";
            sql += " where p_no=" + p_no + " and comp_no=" + LoginMainFrom.user.userID;
            if (MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }
    }
}
