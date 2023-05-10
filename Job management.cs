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
using static System.Windows.Forms.AxHost;

namespace 毕业生管理系统
{
    public partial class 求职管理 : Form
    {
        public 求职管理()
        {
            InitializeComponent();
        }

        private void 求职管理_Load(object sender, EventArgs e)
        {
            string sql;
            if (LoginMainFrom.user.userIdenty == 4)
                sql = "select * from jobwanted j join student s on j.s_no=s.s_no join company c on j.comp_no=c.comp_no join profession pf on pf.pro_no=s.s_pro join post p on p.p_no=j.p_no where j.comp_no=" + LoginMainFrom.user.userID;
            else sql = "select * from jobwanted j join student s on j.s_no=s.s_no join company c on j.comp_no=c.comp_no join profession pf on pf.pro_no=s.s_pro join post p on p.p_no=j.p_no";
 
            using(MySqlDataReader dr = MysqlWays.dataReader(sql))
            while(dr.Read()) { 
                求职记录 frm=new 求职记录();
                frm.TopLevel = false;
                flowLayoutPanel1.Controls.Add(frm);
                frm.Show();

                frm.pbHead.BackgroundImage = Image.FromFile(Application.StartupPath+"/images/"+dr.GetString("j_head"));
                frm.lbName.Text = dr.GetString("s_name");
                frm.lbSex.Text = dr.GetString("s_sex");
                frm.lbProfession.Text = dr.GetString("pro_name");
                frm.lbPost.Text = dr.GetString("p_name");
                frm.lbCompany.Text = dr.GetString("comp_name");
                frm.lbState.Text=dr.GetString("j_state");
                if (frm.lbState.Text.Equals("待审核"))
                {
                    frm.lbState.ForeColor = Color.Blue;
                    frm.btnElimilate.Visible = true;
                    frm.btnInterview.Visible = true;
                    frm.btnSearch.Visible = true;
                }
                else if (frm.lbState.Text.Equals("待面试"))
                {
                    frm.lbState.ForeColor = Color.DodgerBlue;
                    frm.btnSeach2.Visible= true;
                }
                else if (frm.lbState.Text.Equals("未通过"))
                {
                    frm.lbState.ForeColor = Color.Red;
                    frm.btnSeach2.Visible = true;
                }
                else if (frm.lbState.Text.Equals("已就职"))
                {
                    frm.lbState.ForeColor = Color.Green;
                    frm.btnSearch.Visible = true;
                    frm.btnDismiss.Visible = true;
                }
                else if (frm.lbState.Text.Equals("已辞退"))
                {
                    frm.lbState.ForeColor = Color.Red;
                    frm.btnSeach2.Visible=true;
                }
                else if (frm.lbState.Text.Equals("面试失败"))
                {
                    frm.lbState.ForeColor = Color.Red;
                    frm.btnSeach2.Visible = true;
                }
                    frm.pbResume.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + dr.GetString("j_resume"));
                frm.resumePosition = Application.StartupPath + "/images/" + dr.GetString("j_resume");

                frm.Comp_no = dr.GetString("comp_no");
                frm.S_no = dr.GetString("s_no");
                frm.P_no = dr.GetString("p_no");
            }
        }

        private void lbRefresh_Click(object sender, EventArgs e)
        {
            for(int i=flowLayoutPanel1.Controls.Count-1; i>=1;i--)
            {
                flowLayoutPanel1.Controls.RemoveAt(i);
            }
            求职管理_Load(new object(), new EventArgs());
        }
    }
}
