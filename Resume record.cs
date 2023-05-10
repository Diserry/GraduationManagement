using MySql.Data.MySqlClient;
using MySql.Data.Types;
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
    public partial class 简历记录 : Form
    {
        public 简历记录(string s_no,string p_no,string comp_no)
        {
            InitializeComponent();
            S_no= s_no;
            P_no= p_no;
            Comp_no = comp_no;
        }
        public string S_no { get; set; }
        public string P_no { get; set; }
        public string Comp_no { get; set; } 
        public string Position { get; set; }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //打开指定目录下的文件
            System.Diagnostics.Process.Start(Application.StartupPath+"/images/"+Position);
        }

        private void 简历记录_Load(object sender, EventArgs e)
        {
            //初始化姓名，学号
            string pro_no, class_no;
            string sql = "select * from student where s_no=" + S_no;
            using (MySqlDataReader rd = MysqlWays.dataReader(sql))
            {
                pro_no = class_no = null;
                if (rd.Read())
                {
                    pro_no = rd.GetString("s_pro");
                    class_no = rd.GetString("s_class");

                    lbName.Text = rd.GetString("s_name");
                    lbS_no.Text = rd.GetString("s_no");
                }
                else
                {
                    return;
                }
            }
            
            //初始化专业
            
            sql = "select * from profession where pro_no=" + pro_no;
            using (MySqlDataReader rd = MysqlWays.dataReader(sql))
            {
                if (rd.Read())
                {
                    lbPro_name.Text = rd.GetString("pro_name");
                }
            }
            //初始化班级
            sql = "select * from class where class_no=" + class_no;
            using (MySqlDataReader rd = MysqlWays.dataReader(sql))
            {
                if (rd.Read())
                {
                    lbClass_name.Text = rd.GetString("class_name");
                }
            }
            //初始化岗位，单位
            sql = "select * from postcompany pc join company c on c.comp_no=pc.comp_no join post p on p.p_no=pc.p_no where pc.p_no=" + P_no+" and pc.comp_no="+Comp_no+"";
            using (MySqlDataReader rd = MysqlWays.dataReader(sql))
            {
                if (rd.Read())
                {
                    lbP_name.Text = rd.GetString("p_name");
                    lbComp_name.Text = rd.GetString("comp_name");
                }
            }
        }
    }
}
