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
    public partial class 我的简历 : Form
    {
        public 我的简历()
        {
            InitializeComponent();
            dataBind();     //1
        }
        string Sql;
        private void 我的简历_Load(object sender, EventArgs e)
        {
           dataBind();      //2 必须要有两个，不然没有状态颜色
        }
        public void dataBind()
        {
            Sql = "select p_name,comp_name,pc_position,pc_salary,j_time,j_state from jobwanted j join postcompany pc on pc.p_no=j.p_no and pc.comp_no=j.comp_no join company c on j.comp_no=c.comp_no  join post p on p.p_no=pc.p_no where j.s_no=" + LoginMainFrom.user.userID;
            //string sql = "select j_time,j_state from jobwanted where s_no="+LoginMainFrom.user.userID;
            DataTable dt = new DataTable();
            using(MySqlDataReader dr = MysqlWays.dataReader(Sql))
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            int i = 0;
            string state;
            while (i < dt.Rows.Count)
            {
                state = dt.Rows[i][5].ToString();
                if (state.Equals("待审核"))
                {
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.Blue;
                }
                else if (state.Equals("已通过"))
                {
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.Green;
                }else if (state.Equals("未通过"))
                {
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.Brown;
                }
                else if (state.Equals("待面试"))
                {
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.DodgerBlue;
                }
                else if (state.Equals("面试失败"))
                {
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.Brown;
                }
                else if (state.Equals("已就职"))
                {
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.Green;
                }
                else if (state.Equals("已辞退"))
                {
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.Brown;
                }
                i++;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < dataGridView1.Rows.Count-1 && e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                string sql;
                //同初始化的sql语句相同，只有查询查询字段不同
                sql = "select j.p_no,j.comp_no from jobwanted j join postcompany pc on pc.p_no=j.p_no and pc.comp_no=j.comp_no join company c on j.comp_no=c.comp_no  where j.s_no=" + LoginMainFrom.user.userID;
                DataTable dt = new DataTable();
                using (MySqlDataReader dr1 = MysqlWays.dataReader(sql))
                {
                    dt.Load(dr1);
                }

                string p_no =dt.Rows[e.RowIndex][0].ToString();
                string comp_no = dt.Rows[e.RowIndex][1].ToString();

                求职信息 frm =new 求职信息();
                frm.Comp_no = comp_no;
                frm.P_no = p_no;
                sql = "select * from jobwanted  where s_no=" + LoginMainFrom.user.userID +" and p_no="+p_no+" and comp_no="+comp_no;
                using(MySqlDataReader dr = MysqlWays.dataReader(sql))
                if (dr.Read())
                {
                    frm.dateTimePicker1.Text=dr.GetString("j_birth");
                    frm.tbDegree.Text = dr.GetString("j_degree");
                    frm.tbPhone.Text = dr.GetString("j_phone");
                    frm.headimagePosition = dr.GetString("j_head");
                    frm.resumeimagePosition = dr.GetString("j_resume");
                    frm.startposition = Application.StartupPath + "/images/" + dr.GetString("j_resume");
                }
                frm.power = 2;
                frm.ShowDialog();
                //操作玩后刷新界面
                我的简历_Load(new object(), new EventArgs());
            }
        }
    }
}
