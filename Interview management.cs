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
    public partial class 面试管理 : Form
    {
        public 面试管理()
        {
            InitializeComponent();
            面试管理_Load(new object(), new EventArgs());
        }

        private void 面试管理_Load(object sender, EventArgs e)
        {
            string sql = "select s_name,s_sex,s.s_no,p_name,i_time,i_position,i_state from interview i join student s on i.s_no=s.s_no join post p on p.p_no=i.p_no where comp_no=" + LoginMainFrom.user.userID;
            DataTable dt = new DataTable();
            using(MySqlDataReader dr = MysqlWays.dataReader(sql))
            dt.Load(dr);
            dataGridView1.DataSource= dt;
            for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                if (dataGridView1.Rows[i].Cells[7].Value.ToString().Equals("已通过"))
                {
                    dataGridView1.Rows[i].Cells[7].Style.ForeColor = Color.Green;
                }
                else if (dataGridView1.Rows[i].Cells[7].Value.ToString().Equals("未通过"))
                {
                    dataGridView1.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                }
                else if (dataGridView1.Rows[i].Cells[7].Value.ToString().Equals("待面试"))
                {
                    dataGridView1.Rows[i].Cells[7].Style.ForeColor = Color.Blue;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            面试管理_Load(new object(), new EventArgs());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex<dataGridView1.Rows.Count&&e.RowIndex>=0&&e.ColumnIndex==0)
            {
                string s_no = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string p_no="";
                string state=dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                string sql="select p_no from post where p_name= '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()+"'";
                using(MySqlDataReader dr = MysqlWays.dataReader(sql))
                if(dr.Read())
                {
                    p_no = dr.GetString(0);
                }
                面试详情 frm = new 面试详情(s_no,LoginMainFrom.user.userID.ToString(),p_no) ;
                if(state=="待面试")
                    frm.operate = 2;
                else frm.operate = 0;
                frm.ShowDialog();
                面试管理_Load(new object(), new EventArgs());
            }
        }
    }
}
