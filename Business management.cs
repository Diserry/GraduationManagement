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
    public partial class 企业管理 : Form
    {
        public 企业管理()
        {
            InitializeComponent();
        }
        string Sql;
        private void 企业管理_Load(object sender, EventArgs e)
        {
            Sql = "select * from company";
            DataBind(Sql);
        }
        void DataBind(string sql)
        {
            dataGridView1.Rows.Clear();
            using (MySqlDataReader dr = MysqlWays.dataReader(sql))
            {
                int i = 0;
                while (dr.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr.GetString("comp_no");
                    dataGridView1.Rows[i].Cells[1].Value = dr.GetString("comp_name");
                    dataGridView1.Rows[i].Cells[2].Value = dr.GetString("service");
                    dataGridView1.Rows[i].Cells[3].Value = dr.GetString("comp_position");
                    i++;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            new 你确定要这样做吗().ShowDialog();
            if (你确定要这样做吗.bl == false) return;
            string sql = "delete from company where comp_no=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
                DataBind(Sql);
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                Sql= "select * from company";
            }else
            {
                string str=textBox1.Text;
                Sql = "select * from company where comp_no='" + str + "' or comp_name like '%" + str + "%' or comp_position like '%" + str + "%'";
            }
            DataBind(Sql);
        }
    }
}
