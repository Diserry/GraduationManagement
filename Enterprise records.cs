using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 毕业生管理系统
{
    public partial class 企业记录 : Form
    {
        public 企业记录()
        {
            InitializeComponent();
        }
        public string Comp_no;
        private void button1_Click(object sender, EventArgs e)
        {
            企业详情 frm = new 企业详情();
            frm.comp_no = Comp_no;
            frm.Show();

        }

        private void 企业记录_Load(object sender, EventArgs e)
        {
            //在招职位个数
            string sql = "select count(*) from postcompany where comp_no=" + Comp_no;
            using (MySqlDataReader dr = MysqlWays.dataReader(sql))
            {
                if (dr.Read())
                {
                    lbCount.Text = dr.GetString("count(*)")+"个";
                }
            }
            //热门岗位

            string sql2 = "select count(*),p.p_name from jobwanted j join post p on p.p_no=j.p_no where comp_no=" + Comp_no + " group by j.p_no";
            using (MySqlDataReader dr = MysqlWays.dataReader(sql2))
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                if(dt.Rows.Count > 0)
                {
                    int max=0;
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (max < int.Parse(dt.Rows[i][0].ToString()))
                        {
                            max = int.Parse(dt.Rows[i][0].ToString());
                            lbHot.Text = dt.Rows[i][1].ToString();
                        }
                    }
                }
                else
                {
                    lbHot.Text = "无";
                }
            }
        }
    }
}
