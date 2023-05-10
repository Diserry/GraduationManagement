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
    public partial class 求职信息 : Form
    {
        public 求职信息()
        {
            InitializeComponent();
        }
        public string P_no { get; set; }  
        public string Comp_no { get; set; }
        public string S_no { get; set; }

        public int power = 1;      //用来限制操作权限（删除，提交，更新...）,控制这些按钮是否显示
        public Image headimage { get; set; }
        public Image resumeimage { get; set; }
        public string headimagePosition=null;            //头像名/地址
        int headFlag = 0;                                //标记上传头像，如果有上传头像值就为1
        public string resumeimagePosition=null;          //简历名/地址
        int resumeFlag = 0;                              //标记上传简历
        private void 求职信息_Load(object sender, EventArgs e)
        {
            
            if(LoginMainFrom.user.userIdenty==0)
            {
                S_no=LoginMainFrom.user.userID.ToString();
            }
            tbS_no.Text = S_no;
            //初始化就业信息
            string sql = "select * from postcompany pc join post p on p.p_no=pc.p_no where pc.p_no=" + P_no + " and comp_no=" + Comp_no;
            using(MySqlDataReader reader = MysqlWays.dataReader(sql))
            if(reader.Read())
            {
                tbP_name.Text = reader.GetString("p_name");
                tbP_Position.Text = reader.GetString("pc_position");
                tbP_salary.Text = reader.GetString("pc_salary");

                string sql2 = "select comp_name from company where comp_no=" + Comp_no;
                MySqlDataReader rd = MysqlWays.dataReader(sql2);
                if(rd.Read()) {
                    tbComp_name.Text = rd.GetString("comp_name");
                }
            }
            //初始化个人信息
            sql = "select * from student where s_no=" + S_no;
            MySqlDataReader reader1 = MysqlWays.dataReader(sql);
            if(reader1.Read()) { 
                tbName.Text=reader1.GetString("s_name");
                tbSex.Text = reader1.GetString("s_sex");

                string pro_no = reader1.GetString("s_pro");
                string sql2="select * from profession where pro_no="+pro_no;
                using(MySqlDataReader rd = MysqlWays.dataReader(sql2))
                if (rd.Read())
                {
                    tbProfession.Text = rd.GetString("pro_name");
                }
            }
            //隐藏控件
            if (power == 1)     //学生查看
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnBack2.Visible = false;
            }
            else if(power==2)   //填写信息
            {
                btnTrue.Visible = false;
                btnBack.Visible = false;
            }
            else if (power == 3)//企业查看
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnBack2.Visible = false;
                btnTrue.Visible = false;
                btnBack.Visible = false;

                dateTimePicker1.Enabled= false;
                tbDegree.Enabled= false;
                tbPhone.Enabled= false;
                btnUpPicture.Visible= false;
                btnSendResume.Visible= false;
                label2.Visible=false;
                label5.Visible=false;
                label13.Visible=false;
            }
            //初始化图片
            if (headimagePosition!=null)
            {
                pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + headimagePosition);
               
            }
            if (resumeimagePosition!=null)
            {
                pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/" + resumeimagePosition);
            }
        }
        //上传头像
        private void btnUpPicture_Click(object sender, EventArgs e)
        {
            //过滤文件类型
            openFileDialog1.Filter = "图片文件(*.jpg)|*.jpg";
            //显示文件对话框
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                //获取文件路径
                string position=openFileDialog1.FileName;
                //获得图片
                headimage =Image.FromFile(position);
                //添加头像
                pictureBox1.BackgroundImage= headimage;
                MessageBox.Show("头像上传成功");
                headFlag = 1;
            }
        }

        private void btnTrue_Click(object sender, EventArgs e)
        {
            if (WriteAll() == false)
            {
                MessageBox.Show("信息不完整,操作失败");
                return;
            }
            //保存头像图片名字（当前项目目录）时间用作图片名，因为时间不会重复
            headimagePosition = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            //保持简历图片名字（当前项目目录）
            resumeimagePosition = DateTime.Now.ToString("yyyyMMddHHmmss") + 1 + ".jpg";
            //插入语句
            string sql = "insert into jobwanted(s_no,p_no,comp_no,j_birth,j_degree,j_phone,j_head,j_resume,j_state,j_time) ";
            sql += "value(" + S_no + "," + this.P_no + ","+this.Comp_no+",'" + dateTimePicker1.Text + "','" + tbDegree.Text + "','" + tbPhone.Text + "','" + headimagePosition + "','" + resumeimagePosition + "',"+"'待审核','"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +"')";
            if (MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
                //保存图片到当前项目文件夹
                headimage.Save(Application.StartupPath+"/images/"+headimagePosition);
                resumeimage.Save(Application.StartupPath + "/images/"+resumeimagePosition);

                this.Close();
            }
            else 
            {
                MessageBox.Show("操作失败");
            }
        }
        //上传简历
        public string startposition;           //保存简历的初始文件位置，用于后面的单击查看
        private void btnSendResume_Click(object sender, EventArgs e)
        {
            //过滤文件类型
            openFileDialog1.Filter = "图片文件(*.jpg)|*.jpg|图片文件(*.png)|*.png";
            //显示文件对话框
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //获取文件路径
                startposition = openFileDialog1.FileName;
                
                //获得图片
                resumeimage = Image.FromFile(startposition);
                //添加头像
                pictureBox2.BackgroundImage = resumeimage;
                MessageBox.Show("简历上传成功");
                resumeFlag = 1;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.BackgroundImage != null)
            {
                System.Diagnostics.Process.Start(startposition);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //强调该操作无法撤回
            new 你确定要这样做吗().ShowDialog();
            if (你确定要这样做吗.bl==false)
            {
                return;
            }
            //删除操作
            string sql = "delete from jobwanted where s_no=" + S_no + " and p_no=" + P_no + " and comp_no=" + Comp_no;
            if(MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (WriteAll() == false)
            {
                MessageBox.Show("信息不完整,操作失败");
                return;
            }
            ////从项目文件中删除原图片，加入新图片
            //if(resumeimagePosition!= null)
            //{
            //    //删除原图片
            //    //System.IO.File.Delete(Application.StartupPath+"/images/"+ resumeimagePosition);
            //    //设置简历图片名字（当前项目目录）
            //    resumeimagePosition = DateTime.Now.ToString("yyyyMMddHHmmss") + 1 + ".jpg";
            //    //保存新图片
            //    pictureBox2.BackgroundImage.Save(Application.StartupPath + "/images/" + resumeimagePosition);
            //}
            //if(headimagePosition!= null)
            //{
            //    //System.IO.File.Delete(Application.StartupPath + "/images/" + headimagePosition);
            //    headimagePosition = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            //    pictureBox1.BackgroundImage.Save(Application.StartupPath + "/images/" +headimagePosition);
            //}

            //判断是否有上传头像
            //如果没上传headFlag值为0，headimagePosition保存还是原理的文件名，更新之后不变
            if (headFlag == 1)
            {
                //设置头像文件名称为时间    时间不会重复
                headimagePosition = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                //保存图片到项目中
                pictureBox1.BackgroundImage.Save(Application.StartupPath + "/images/" +headimagePosition);
            }
            //判断是否有上传简历
            if (resumeFlag==1)
            {
                //设置简历图片名字（当前项目目录）
                resumeimagePosition = DateTime.Now.ToString("yyyyMMddHHmmss") + 1 + ".jpg";
                //保存新图片
                pictureBox2.BackgroundImage.Save(Application.StartupPath + "/images/" + resumeimagePosition);
            }

            //更新操作
            string sql = "update jobwanted set j_birth='"+dateTimePicker1.Text+"',j_degree='"+tbDegree.Text+"',j_phone='"+tbPhone.Text+"',j_head='"+headimagePosition+"',j_resume='"+resumeimagePosition+"',j_time='"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"'";
            sql += " where s_no=" + S_no + " and p_no=" + P_no + " and comp_no=" + Comp_no;
            if (MysqlWays.executeSql(sql))
            {
                MessageBox.Show("操作成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }
        //判断信息是否输入完整
        public bool WriteAll()
        {
            bool bl = false;
            if (pictureBox1.BackgroundImage != null && pictureBox2.BackgroundImage != null && dateTimePicker1.Text != null && tbDegree.Text != "" && tbPhone.Text != "")
            {
                bl = true;
            }
            return bl;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
