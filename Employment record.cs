using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 毕业生管理系统
{
    public partial class 求职记录 : Form
    {
        public 求职记录()
        {
            InitializeComponent();
        }
        public string S_no;
        public string Comp_no;
        public string P_no;
        public string resumePosition;

        private void 求职记录_Load(object sender, EventArgs e)
        {
        }

        private void pbResume_Click(object sender, EventArgs e)
        {
            if (pbResume.BackgroundImage != null)
            {
                System.Diagnostics.Process.Start(resumePosition);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            求职信息 frm =new 求职信息();
            frm.S_no= this.S_no;
            frm.P_no= this.P_no;
            frm.Comp_no= this.Comp_no;
            frm.power = 3;
            string sql = "select * from jobwanted  where s_no=" +this.S_no + " and p_no=" + this.P_no + " and comp_no=" + this.Comp_no;
            using(MySqlDataReader dr = MysqlWays.dataReader(sql))
            if (dr.Read())
            {
                frm.dateTimePicker1.Text = dr.GetString("j_birth");
                frm.tbDegree.Text = dr.GetString("j_degree");
                frm.tbPhone.Text = dr.GetString("j_phone");
                frm.headimagePosition = dr.GetString("j_head");
                frm.resumeimagePosition = dr.GetString("j_resume");
                frm.startposition = Application.StartupPath + "/images/" + dr.GetString("j_resume");             
            }
            frm.ShowDialog();
        }

        private void btnInterview_Click(object sender, EventArgs e)
        {
            面试详情 frm = new 面试详情(S_no,Comp_no,P_no);
            frm.operate = 1;   //表示要进行的操作为增加
            frm.Show();
        }

        private void btnElimilate_Click(object sender, EventArgs e)
        {
            new 你确定要这样做吗().ShowDialog();
            if (你确定要这样做吗.bl == false) return;
            string sql = "update jobwanted set j_state='未通过' where s_no=" + S_no + " and comp_no=" + Comp_no + " and p_no=" + P_no;
            if(MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            new 你确定要这样做吗().ShowDialog();
            if (你确定要这样做吗.bl == false) return;
            string sql= "update jobwanted set j_state='已辞退' where  s_no=" + S_no + " and comp_no=" + Comp_no + " and p_no=" + P_no;
            if (MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }
    }
}
