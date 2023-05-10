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
    public partial class 毕业申报系统 : Form
    {
        
        public 毕业申报系统()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            毕业申报表 gradurateTable = new 毕业申报表();
            StudentMainform.StudentPMF.OpenForm(gradurateTable);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            学生查看申报情况 frm = new 学生查看申报情况();
            StudentMainform.StudentPMF.OpenForm(frm);
        }

        private void 毕业申报系统_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
                    }
    }
}
