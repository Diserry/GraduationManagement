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
    public partial class 简历管理 : Form
    {
        public 简历管理()
        {
            InitializeComponent();
        }
        public string Sql { get; set; }
        private void 简历管理_Load(object sender, EventArgs e)
        {
            string Sql = "select * from jobwanted";
            DataBind(Sql);
            //初始化专业框
            cbProfession.Items.Add("全部");
            string sql = "select pro_name from profession";
            using (MySqlDataReader dr = MysqlWays.dataReader(sql))
            {
                while (dr.Read())
                {
                    cbProfession.Items.Add(dr.GetString("pro_name"));
                }
            }
            cbProfession.Text = "全部";
        }
        void DataBind(string sql)
        {
            flowLayoutPanel1.Controls.Clear();
            using(MySqlDataReader rd = MysqlWays.dataReader(sql))
            while (rd.Read())
            {
                简历记录 frm = new 简历记录(rd.GetString("s_no"), rd.GetString("p_no"), rd.GetString("comp_no"));
                //设置子窗口不显示为顶级窗口
                frm.TopLevel = false;
                //设置子窗口的样式，没有上面的标题与外框
                frm.FormBorderStyle = FormBorderStyle.None;
                //加入控件
                flowLayoutPanel1.Controls.Add(frm);

                frm.pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + rd.GetString("j_head"));
                frm.Position = rd.GetString("j_resume");
                frm.Show();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select * from jobwanted j join student s on j.s_no=s.S_no where s_name like '%" + textBox1.Text + "%' or j.s_no='" + textBox1.Text + "'";
            DataBind(sql);
        }

        private void cbProfession_SelectedIndexChanged(object sender, EventArgs e)
        {
            //班级控件根据专业得来
            cbClass.Items.Clear();
            cbClass.Items.Add("全部");
            string sql;
            if (cbProfession.Text.Equals("全部"))
            {
                sql = "select * from class";
            }
            else
            {
                sql = "select * from class c join profession p on c.pro_no=p.pro_no where pro_name='" + cbProfession.Text+"'";
            }
            
            using(MySqlDataReader dr = MysqlWays.dataReader(sql))
            {
                while (dr.Read())
                {
                    cbClass.Items.Add(dr.GetString("class_name"));
                }
               
            }
            cbClass.Text = "全部";
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string class_name = cbClass.Text;
            string pro_name = cbProfession.Text;
            if (class_name.Equals("全部"))
            {
                class_name = "";
            }
            if (pro_name.Equals("全部"))
            {
                pro_name = "";
            }
            string sql = "select * from jobwanted j join student s on j.s_no=s.s_no join class c on c.class_no=s.s_class join profession p on p.pro_no=s.s_pro ";
            sql += " where pro_name like '%" + pro_name + "%' and class_name like '%" + class_name + "%'";
            DataBind(sql);
        }
    }
}
