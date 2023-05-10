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
    public partial class 教师批量导入 : Form
    {
        public 教师批量导入()
        {
            InitializeComponent();
        }

        private void 教师批量导入_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog tagetFile = new OpenFileDialog();//选择需要打印的文件
            if (tagetFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox1.Text = tagetFile.FileName;
            }
            int lastIndex = textBox1.Text.LastIndexOf("\\");
            string fileName = textBox1.Text.Substring(lastIndex + 1);
            int houzhuiIndex = fileName.LastIndexOf(".");
            try
            {
                string fileExt = fileName.Substring(houzhuiIndex);
                if (fileExt == ".xls")
                {
                    DataSet ds = MysqlWays.ExcelToDS(textBox1.Text);
                    dataGridView1.DataSource = ds.Tables[0];
                    data = ds.Tables[0];
                    //MessageBox.Show(dataGridView1.Rows[0].Cells[0].Value.ToString());
                    
                }
            }
            catch { MessageBox.Show("文件类型不正确！"); }
            
        }
        public DataTable data;
        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
           
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[1].Value.ToString() == "")
                    break;
               
                sb.Append("insert into teacher values(");
                sb.Append("('" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "')," + "('" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "')," + "('" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "')," + "('" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "')");
                sb.Append(")");
                
                try
                {
                    using (MysqlWays.dataReader(sb.ToString()))
                    { 
                    }
                }
                catch
                {
                    MessageBox.Show("重复文件！");
                }
                sb.Clear();
                sb1.Clear();
                
            }
            MessageBox.Show("导入完成");
        }
    }
}
