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
using System.Xml.Linq;

namespace 毕业生管理系统
{
    public partial class 岗位详情 : Form
    {
        public 岗位详情()
        {
            InitializeComponent();
        }
        public string p_no { get; set; }
        public string comp_no { get; set; }
        public string Sql { get; set; }
        private void 岗位详情_Load(object sender, EventArgs e)
        {
            //0是学生，1是辅导员，2是班导师，3就业科，4是企业，5是管理员
            //数据加载
            if (LoginMainFrom.user.userIdenty == 1 || LoginMainFrom.user.userIdenty == 2 || LoginMainFrom.user.userIdenty == 3)
                btnSendResume.Visible = false;
            Sql="select * from postcompany pc join post p on p.p_no=pc.p_no  where pc.p_no="+this.p_no+" and comp_no="+this.comp_no;
            using (MySqlDataReader dr = MysqlWays.dataReader(Sql))
            {
                dr.Read();
                lbName.Text = dr.GetString("p_name");
                lbSalary.Text = dr.GetString("pc_salary");
                lbCount.Text = dr.GetString("pc_count");
                lbPosition.Text = dr.GetString("pc_position");
                lbExperience.Text = dr.GetString("pc_experience");
                lbDegree.Text = dr.GetString("pc_degree");
                lbTechnology.Text = dr.GetString("pc_technology");
                tbRequrie.Text = dr.GetString("pc_requrie");
                tbResponsibility.Text = dr.GetString("pc_responsibility");
            }
            //加载操作控件
            if (LoginMainFrom.user.userIdenty!=4)
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
            }
            else
            {
                btnSearch.Visible = false;
                btnSendResume.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            企业详情 frm=new 企业详情();
            frm.comp_no=this.comp_no;
            frm.ShowDialog();
        }

        private void btnSendResume_Click(object sender, EventArgs e)
        {
            //判断以前是否投递过
            string sql = "select * from jobwanted where comp_no=" + comp_no + " and p_no=" + p_no + " and s_no=" + LoginMainFrom.user.userID;
            DataTable dt= new DataTable();
            using (MySqlDataReader dr= MysqlWays.dataReader(sql))
                dt.Load(dr);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("你已投递过，无需再投递，可在模块“我的简历”中查看");
                return;
            }
            //没有投递过就打开投递信息
            求职信息 frm = new 求职信息();
            frm.P_no=this.p_no;
            frm.Comp_no=this.comp_no; 
            frm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            岗位详情_企业 frm = new 岗位详情_企业();
            frm.operate = 1;
            frm.p_no=this.p_no;
            frm.ShowDialog();
            岗位详情_Load(new object(), new EventArgs());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            new 你确定要这样做吗().ShowDialog();
            if (你确定要这样做吗.bl)
            {
                string sql = "delete from postcompany where comp_no=" + comp_no + " and p_no=" + p_no;
                if (MysqlWays.executeSql(sql))
                {
                    MessageBox.Show("删除成功");
                    Close();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }
    }
}
