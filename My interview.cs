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
    public partial class 我的面试 : Form
    {
        public 我的面试()
        {
            InitializeComponent();
            DataBind();
        }

        private void 我的面试_Load(object sender, EventArgs e)
        {
            DataBind();
        }
        void DataBind()
        {
            string sql = "select p_name,comp_name,i_position,i_time,i_state from interview i join company c on c.comp_no=i.comp_no join post p on p.p_no=i.p_no where s_no=" + LoginMainFrom.user.userID;
            DataTable dt = new DataTable();
            using (MySqlDataReader dr = MysqlWays.dataReader(sql))
                dt.Load(dr);
            dataGridView1.DataSource = dt;
            int i = 0;
            string state;
            while (i < dt.Rows.Count)
            {
                state = dt.Rows[i][4].ToString();
                if (state.Equals("待面试"))
                {
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.DodgerBlue;
                }
                else if (state.Equals("已通过"))
                {
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.Green;
                }
                else if (state.Equals("未通过"))
                {
                    dataGridView1.Rows[i].Cells[6].Style.ForeColor = Color.Brown;
                }
                i++;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < dataGridView1.Rows.Count - 1 && e.RowIndex >= 0)
            {
                if(e.ColumnIndex== 0)
                {
                    string sql;
                    //同初始化的sql语句相同，只有查询查询字段不同
                    sql = "select i.p_no,i.comp_no from interview i join company c on c.comp_no=i.comp_no join post p on p.p_no=i.p_no where s_no=" + LoginMainFrom.user.userID;
                    DataTable dt = new DataTable();
                    MySqlDataReader dr1 = MysqlWays.dataReader(sql);
                    dt.Load(dr1);

                    string p_no = dt.Rows[e.RowIndex][0].ToString();
                    string comp_no = dt.Rows[e.RowIndex][1].ToString();

                    面试详情 frm = new 面试详情(LoginMainFrom.user.userID.ToString(),comp_no,p_no);
                    sql = "select * from jobwanted  where s_no=" + LoginMainFrom.user.userID + " and p_no=" + p_no + " and comp_no=" + comp_no;
                    frm.ShowDialog();
                    //操作玩后刷新界面
                    我的面试_Load(new object(), new EventArgs());
                }
                else if(e.ColumnIndex == 1)
                {
                    new 你确定要这样做吗().ShowDialog();
                    if(你确定要这样做吗.bl==true)
                    {

                        string sql;
                        //同初始化的sql语句相同，只有查询查询字段不同
                        sql = "select i.p_no,i.comp_no from interview i join company c on c.comp_no=i.comp_no join post p on p.p_no=i.p_no where s_no=" + LoginMainFrom.user.userID;
                        DataTable dt = new DataTable();
                        using(MySqlDataReader dr2 = MysqlWays.dataReader(sql))
                        dt.Load(dr2);

                        string p_no = dt.Rows[e.RowIndex][0].ToString();
                        string comp_no = dt.Rows[e.RowIndex][1].ToString();

                        sql="delete from interview where p_no="+p_no+" and comp_no="+comp_no+" and s_no="+LoginMainFrom.user.userID;
                        if (MysqlWays.executeSql(sql))
                        {
                            MessageBox.Show("操作成功");
                            //操作玩后刷新界面
                            我的面试_Load(new object(), new EventArgs());
                        }
                        else
                        {
                            MessageBox.Show("删除失败");
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
