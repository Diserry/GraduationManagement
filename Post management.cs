using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 毕业生管理系统
{
    public partial class 岗位管理 : Form
    { 
        public User user = new User();
        public 岗位管理(int identy)
        {
            
            InitializeComponent();
            user.userIdenty = identy;
        }
        public String Sql { get; set; }
        private void 岗位管理_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            Sql = "Select * from postcompany pc join company c on pc.comp_no=c.comp_no join post p on pc.p_no=p.p_no";
            if (user.userIdenty == 4)
            {
                Sql += " where c.comp_no=" + LoginMainFrom.user.userID;
                //隐藏公司搜索框
                label2.Visible = false;
                cbCompany.Visible = false;
            }
            else
            {
                btnAdd.Visible = false;
            }

            DataBind(Sql);
            //初始化岗位列表
            cbPost.Items.Add("全部");
            string sql = "select p_name from post";
            using (MySqlDataReader dr = MysqlWays.dataReader(sql))
            {
                while (dr.Read())
                {
                    cbPost.Items.Add(dr.GetString("p_name"));
                }
            }
            cbPost.Text = "全部";
            //初始化企业列表
            cbCompany.Items.Add("全部");
            sql = "select comp_name from company";
            using (MySqlDataReader dr = MysqlWays.dataReader(sql))
            {
                while (dr.Read())
                {
                    cbCompany.Items.Add(dr.GetString("comp_name"));
                }
            }
            cbCompany.Text = "全部";
            //初始化位置列表
            cbPosition.Items.Add("全部");
            sql = "select pc_position from postcompany group by pc_position";
            using (MySqlDataReader dr = MysqlWays.dataReader(sql))
            {
                while (dr.Read())
                {
                    cbPosition.Items.Add(dr.GetString("pc_position"));
                }
            }
            cbPosition.Text = "全部";
            //初始化学历
            cbDegree.Text = "全部";
        }
        void DataBind(string sql)
        {
            flowLayoutPanel1.Controls.Clear();
            using (MySqlDataReader reader = MysqlWays.dataReader(sql))
                while (reader.Read())
                {
                    岗位记录 frm = new 岗位记录(reader.GetString("p_no"), reader.GetString("comp_no"));
                    //设置子窗口不显示为顶级窗口
                    frm.TopLevel = false;
                    //设置子窗口的样式，没有上面的标题与外框
                    frm.FormBorderStyle = FormBorderStyle.None;
                    ////填充把frm窗体填充满
                    flowLayoutPanel1.Controls.Add(frm);

                    //frm.p_no = reader.GetString("p_no");
                    //frm.comp_no = reader.GetString("comp_no");

                    frm.lbName1.Text = reader.GetString("p_name");
                    frm.lbCount.Text = reader.GetString("pc_count");
                    frm.lbPosition.Text = reader.GetString("pc_position");
                    frm.lbSalary.Text = reader.GetString("pc_salary");
                    frm.lbExperience.Text = reader.GetString("pc_experience");
                    frm.lbDegree.Text = reader.GetString("pc_degree");
                    frm.lbTechnology.Text = reader.GetString("pc_technology");
                    frm.lbName2.Text = reader.GetString("comp_name");
                    frm.pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + frm.lbName2.Text + ".jpg");
                    frm.Show();
                }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            DataBind(Sql);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            岗位详情_企业 frm = new 岗位详情_企业();
            frm.ShowDialog();
            DataBind(Sql);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataBind(Sql);
        }

        private void cbPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            string comp_name=cbCompany.Text;
            string p_name=cbPost.Text;
            string pc_position=cbPosition.Text;
            string pc_degree=cbDegree.Text;
            if (cbPost.Text.Equals("全部"))
            {
               p_name = "";
            }
            if (cbCompany.Text.Equals("全部"))
            {
                comp_name = "";
            }
            if (cbPosition.Text.Equals("全部"))
            {
                pc_position = "";
            }
            if (cbDegree.Text.Equals("全部"))
            {
                pc_degree = "";
            }
            sql = Sql + " where comp_name like '%" + comp_name + "%' and p_name like '%" + p_name + "%' and pc_position like '%"+pc_position+"%' and pc_degree like '%"+pc_degree+"%'";
            if (LoginMainFrom.user.userIdenty == 4)
            {
                sql = Sql+ " and p_name like '%" + p_name + "%' and pc_position like '%" + pc_position + "%' and pc_degree like '%" + pc_degree + "%'";
            }
            DataBind(sql);
        }

    }
}
