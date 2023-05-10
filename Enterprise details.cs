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
    public partial class 企业详情 : Form
    {
        public 企业详情()
        {
            InitializeComponent();
        }
        public string comp_no { get; set; }
        private void 企业详情_Load(object sender, EventArgs e)
        {
            string sql = "select * from company where "+"comp_no='"+this.comp_no+"'";
            using(MySqlDataReader reader = MysqlWays.dataReader(sql))
            //处理基本信息
            {
                reader.Read();
                lbName.Text = reader.GetString("comp_name") + " 技术有限公司";
                lbPosition.Text = reader.GetString("comp_position");
                lbService.Text = reader.GetString("Service");
                pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + reader.GetString("comp_name") + ".jpg");
                tbProfile.Text = reader.GetString("Profile");
                int imagecount = int.Parse(reader.GetString("imagecount"));
                //处理图片
                string name = reader.GetString("comp_name");
                for (int i = 1; i <= imagecount; i++)
                {
                    企业相册 frm = new 企业相册();
                    frm.pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + name + i + ".jpg");
                    frm.TopLevel = false;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Show();
                    flowLayoutPanel2.Controls.Add(frm);
                }

                //处理待遇
                string str = reader.GetString("treatment");
                if (str[0] == '1') cb1.Checked = true;
                if (str[1] == '1') cb2.Checked = true;
                if (str[2] == '1') cb3.Checked = true;
                if (str[3] == '1') cb4.Checked = true;
                if (str[4] == '1') cb5.Checked = true;
                if (str[5] == '1') cb6.Checked = true;

            }
            //处理在招职位
            string sql2 = "select * from postcompany pc join company c on c.comp_no=pc.comp_no join post p on pc.p_no=p.p_no where " + "pc.comp_no='" + this.comp_no + "'";
            using(MySqlDataReader reader2 = MysqlWays.dataReader(sql2))
            {
                int count = 0;
                while (reader2.Read())
                {
                    count++;
                    岗位记录 frm = new 岗位记录(reader2.GetString("p_no"), this.comp_no);
                    //frm.p_no = reader2.GetString("p_no");
                    //frm.comp_no=this.comp_no;
                    //设置子窗口不显示为顶级窗口
                    frm.TopLevel = false;
                    //设置子窗口的样式，没有上面的标题与外框
                    frm.FormBorderStyle = FormBorderStyle.None;
                    ////填充把frm窗体填充满
                    flowLayoutPanel1.Controls.Add(frm);

                    frm.lbName1.Text = reader2.GetString("p_name");
                    frm.lbCount.Text = reader2.GetString("pc_count");
                    frm.lbPosition.Text = reader2.GetString("pc_position");
                    frm.lbSalary.Text = reader2.GetString("pc_salary");
                    frm.lbExperience.Text = reader2.GetString("pc_experience");
                    frm.lbDegree.Text = reader2.GetString("pc_degree");
                    frm.lbTechnology.Text = reader2.GetString("pc_technology");
                    frm.lbName2.Text = reader2.GetString("comp_name");
                    frm.pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + frm.lbName2.Text + ".jpg");
                    frm.Show();
                }
                lbCount.Text = count.ToString()+"个";
            }
            
        }
    }
}
