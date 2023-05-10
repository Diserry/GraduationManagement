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
    public partial class 岗位记录 : Form
    {
        public 岗位记录(string P_no,string Comp_no)
        {
            InitializeComponent();
            p_no= P_no;
            comp_no= Comp_no;
        }
        public string p_no { get;set; }
        public string comp_no { get;set; }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            岗位详情 frm = new 岗位详情();
            frm.p_no = this.p_no;
            frm.comp_no = this.comp_no;
            frm.ShowDialog();
        }

        private void 岗位记录_Load(object sender, EventArgs e)
        {
            string sql = "select count(*) from jobwanted where comp_no=" + comp_no + " and p_no=" + p_no;
            DataTable dt = new DataTable();
            using (MySqlDataReader Reader= MysqlWays.dataReader(sql))
            {
                dt.Load(Reader);
            }
            lbCount.Text = dt.Rows[0][0].ToString() +"/"+lbCount.Text+"人";
        }
    }
}
