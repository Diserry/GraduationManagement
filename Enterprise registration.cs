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
    public partial class 注册企业 : Form
    {
        public 注册企业()
        {
            InitializeComponent();
        }
        int i = 1;
        int comp_no;
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbPassword1.Text.Equals("") || tbPassword2.Text.Equals(""))
            {
                MessageBox.Show("密码不能为空");
                return;
            }else if (!tbPassword1.Text.Equals(tbPassword2.Text))
            {
                MessageBox.Show("两次密码输入不一致");
                return;
            }
            //获取待遇字符串
            string streat = "";
            if (cb1.Checked) streat += 1;
            else streat += 0;
            if (cb2.Checked) streat += 1;
            else streat += 0;
            if (cb3.Checked) streat += 1;
            else streat += 0;
            if (cb4.Checked) streat += 1;
            else streat += 0;
            if (cb5.Checked) streat += 1;
            else streat += 0;
            if (cb6.Checked) streat += 1;
            else streat += 0;
            string sql = "insert into company(comp_no,comp_name,profile,service,comp_position,treatment,imagecount) ";
            sql += "value(" + tbAcount.Text + ",'" + tbName.Text + "','" + tbProfile.Text + "','" + tbSevice.Text + "','" + tbPosition.Text + "','" + streat+"',"+imageList1.Images.Count+ ")";
            if (MysqlWays.executeSql(sql))
            {
                MessageBox.Show("注册成功");
                pictureBox1.BackgroundImage.Save(Application.StartupPath + "/images/" + tbName.Text + ".jpg");
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    imageList1.Images[i].Save(Application.StartupPath + "/images/" + tbName.Text + (i+1)+".jpg");
                }
                sql = "insert into account(a_no,a_password,a_name,a_identy) value("+tbAcount.Text+",'"+tbPassword1.Text+"','"+tbName.Text+"',4)";
                MysqlWays.executeSql(sql);
                this.Close();
            }
            else
            {
                MessageBox.Show("操作失败");
            }
        }

        private void btnUpPicture1_Click(object sender, EventArgs e)
        {
            //过滤文件类型
            openFileDialog1.Filter = "图片文件(*.jpg)|*.jpg";
            //显示文件对话框
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                string position= openFileDialog1.FileName;
                //获得图片
                pictureBox1.BackgroundImage = Image.FromFile(position);;
                MessageBox.Show("图片上传成功");
            }
        }

        private void btnUpPicture2_Click(object sender, EventArgs e)
        {
            //过滤文件类型
            openFileDialog1.Filter = "图片文件(*.jpg)|*.jpg";
            //显示文件对话框
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string position=openFileDialog1.FileName;
                Image img= Image.FromFile(position);
                imageList1.Images.Add(img);
                //向listview中加入图片 i为名称，后面一个参数为图片索引，图片来自与imagelist控件
                listView1.Items.Add(i++.ToString(),imageList1.Images.Count-1);
                MessageBox.Show("图片上传成功");
            }
        }
        int index=-1;
        //选择某张图片时
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                //获取选择图片的索引
                index = listView1.SelectedIndices[0];
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(index==-1)
            {
                MessageBox.Show("请先选择图片");
            }
            else
            {
                listView1.Items.RemoveAt(index);
                imageList1.Images.RemoveAt(index);
                index = -1;
            }
        }

        private void 注册企业_Load(object sender, EventArgs e)
        {
            string sql = "select max(comp_no) from company";
            using(MySqlDataReader dr = MysqlWays.dataReader(sql))
            if(dr.Read())
            {
                comp_no = int.Parse(dr.GetString("max(comp_no)"))+1;
                tbAcount.Text = comp_no + "";
            }
        }
    }
}
