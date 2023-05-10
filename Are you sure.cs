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
    public partial class 你确定要这样做吗 : Form
    {
        public 你确定要这样做吗()
        {
            InitializeComponent();
            bl = false;
        }
        public static bool bl=false;
        //确定
        private void btnTrue_Click(object sender, EventArgs e)
        {
            bl= true;
            this.Close();
        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            bl=false;
            this.Close();
        }

        private void 你确定要这样做吗_Load(object sender, EventArgs e)
        {

        }
    }
}
