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
    public partial class 企业信息 : Form
    {
        public 企业信息()
        {
            InitializeComponent();
        }
        public String Sql { get; set; }
        private void 企业信息_Load(object sender, EventArgs e)
        {
            cbName.Items.Add("全部");
            Sql = "select * from company";
            MySqlDataReader reader = MysqlWays.dataReader(Sql);
            while (reader.Read())
            {
                企业记录 frm = new 企业记录();
                //设置子窗口不显示为顶级窗口
                frm.TopLevel = false;
                //设置子窗口的样式，没有上面的标题与外框
                frm.FormBorderStyle = FormBorderStyle.None;
                //填入数据
                frm.Comp_no = reader.GetString("comp_no");
                frm.lbName.Text = reader.GetString("comp_name") + " 技术有限公司";
                frm.lbPosition.Text = reader.GetString("comp_position");
                frm.lbService.Text = reader.GetString("Service");
                frm.pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + reader.GetString("comp_name") + ".jpg");
                //添加记录
                flowLayoutPanel1.Controls.Add(frm);
                frm.Show();

                cbName.Items.Add(reader.GetString("comp_name"));
            }
            cbName.Text = "全部";
            cbPosition.Items.Add("全部");
            string sql = "select comp_position from company group by comp_position ";
            MySqlDataReader dr = MysqlWays.dataReader(sql);
            while (dr.Read())
            {
                cbPosition.Items.Add(dr.GetString("comp_position"));
            }
            cbPosition.Text = "全部";
        }
        void DataBind(string sql)
        {
            flowLayoutPanel1.Controls.Clear();
            MySqlDataReader reader = MysqlWays.dataReader(sql);
            while (reader.Read())
            {
                企业记录 frm = new 企业记录();
                //设置子窗口不显示为顶级窗口
                frm.TopLevel = false;
                //设置子窗口的样式，没有上面的标题与外框
                frm.FormBorderStyle = FormBorderStyle.None;
                //填入数据
                frm.Comp_no = reader.GetString("comp_no");
                frm.lbName.Text = reader.GetString("comp_name") + " 公司";
                frm.lbPosition.Text = reader.GetString("comp_position");
                frm.lbService.Text = reader.GetString("Service");
                frm.pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + reader.GetString("comp_name") + ".jpg");
                //添加记录
                flowLayoutPanel1.Controls.Add(frm);
                frm.Show();
            }
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPosition.SelectedIndexChanged -= cbPosition_SelectedIndexChanged;
            cbPosition.Text = "全部";
            flowLayoutPanel1.Controls.Clear();
            string sql;
            if (cbName.Text.Equals("全部")) sql = Sql;
            else
                sql = Sql + " where comp_name='" + cbName.Text + "'";
            DataBind(sql);
            cbPosition.SelectedIndexChanged += cbPosition_SelectedIndexChanged;
        }

        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbName.SelectedIndexChanged -= cbName_SelectedIndexChanged;
            cbName.Text = "全部";
            flowLayoutPanel1.Controls.Clear();
            string sql;
            if (cbPosition.Text.Equals("全部")) sql = Sql;
            else
                sql = Sql + " where comp_position='" + cbPosition.Text + "'";
            DataBind(sql);
            cbName.SelectedIndexChanged += cbName_SelectedIndexChanged;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql;
            if (textBox1.Text.Equals(""))
            {
                sql = "select * from company";
            }
            else
            {
                string str = textBox1.Text;
                sql = "select * from company where comp_name like '%" + str + "%' or comp_position like '%" + str + "%'";
            }
            DataBind(sql);
        }
    }
}
