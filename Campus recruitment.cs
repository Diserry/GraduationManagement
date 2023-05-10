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
    public partial class SchoolEmployee : Form
    {
       public User user = new User();
        public SchoolEmployee(int identy)
        {
            InitializeComponent();
            user.userIdenty = identy;
        }

        private void 校园招聘_Load(object sender, EventArgs e)
        {
            string Sql = "Select * from postcompany pc join company c on pc.comp_no=c.comp_no join post p on p.p_no=pc.p_no";
            using(MySqlDataReader reader = MysqlWays.dataReader(Sql))
            while (reader.Read())
            {
                岗位记录 frm = new 岗位记录(reader.GetString("p_no"), reader.GetString("comp_no"));
                //设置子窗口不显示为顶级窗口
                frm.TopLevel = false;
                //设置子窗口的样式，没有上面的标题与外框
                frm.FormBorderStyle = FormBorderStyle.None;
                ////填充把frm窗体填充满
                flowLayoutPanel1.Controls.Add(frm);

                //frm.p_no = reader.GetString("p_no");
                //frm.comp_no = reader.GetString("comp_no");

                frm.lbName1.Text = reader.GetString("p_name");
                frm.lbCount.Text = reader.GetString("pc_count");
                frm.lbPosition.Text = reader.GetString("pc_position");
                frm.lbSalary.Text = reader.GetString("pc_salary");
                frm.lbExperience.Text = reader.GetString("pc_experience");
                frm.lbDegree.Text = reader.GetString("pc_degree");
                frm.lbTechnology.Text = reader.GetString("pc_technology");
                frm.lbName2.Text = reader.GetString("comp_name");
                frm.pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + frm.lbName2.Text + ".jpg");
                frm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
