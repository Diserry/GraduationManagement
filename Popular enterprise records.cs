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
    public partial class 热门企业记录 : Form
    {
        public 热门企业记录()
        {
            InitializeComponent();
        }
        public string comp_no;
        private void 热门企业记录_Load(object sender, EventArgs e)
        {
            string sql = "select * from company where comp_no=" + comp_no;
            using (MySqlDataReader dr = MysqlWays.dataReader(sql))
             if (dr.Read()){
                    lbName.Text = dr.GetString("comp_name");
                    lbPositon.Text = dr.GetString("comp_position");
                    pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + dr.GetString("comp_name") + ".jpg");
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            企业详情 frm=new 企业详情();
            frm.comp_no= this.comp_no;
            frm.ShowDialog();
        }
    }
}
