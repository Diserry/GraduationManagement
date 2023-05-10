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
    public partial class 学生查看申报情况 : Form
    {
        public 学生查看申报情况()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentMainform.StudentPMF.button1_Click(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 学生查看申报情况_Load(object sender, EventArgs e)
        {
            string sqlStr = "select gr.s_no,gr.s_name,gr.class_name,gr.pro_name,gr.ac_name,gr.s_counsellor,stu.check_state from graduationdeclaration gr left join student stu on stu.s_no=gr.s_no where stu.s_no=" + LoginMainFrom.user.userID;
            dataGridView1.DataSource= MysqlWays.checkData(sqlStr).Tables[0];
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "check" && e.RowIndex >= 0)
            {
                毕业申报表 frm = new 毕业申报表(LoginMainFrom.user.userID);
                frm.ShowDialog();
            }
        }
    }
}
