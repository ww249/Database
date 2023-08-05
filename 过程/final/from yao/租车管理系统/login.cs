using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 租车管理系统
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        //登陆方法，验证是否允许登陆，允许返回值
        public void Login(string id)
        {
            //用户
            if (radioButtonUser.Checked == true)
            {
                Dao dao= new Dao();
                string sql = $"select * from t_user where uid='{textBox1.Text}'and upsw='{textBox2.Text}'";
               // MessageBox.Show(sql);
                IDataReader dc=dao.read(sql);
                if (dc.Read())//读到信息了
                {
                    Data.UID = dc["uid"].ToString();
                    Data.UName = dc["uname"].ToString();
                    MessageBox.Show("登陆成功");
                    MessageBox.Show(dc["uid"].ToString() + dc["uname"].ToString());//需要填写！！！！！！！！！！！！！！！！！！！！
                    user1 user = new user1(id);
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登陆失败");
                }
                dao.DaoClose();
            }
            //管理员
            if(radioButtonAdmin.Checked == true)
            {
                Dao dao = new Dao();

                string sql = $"select * from t_admin where adminid='{textBox1.Text}'and adminpsw='{textBox2.Text}'";
                // MessageBox.Show(sql);
                IDataReader dc = dao.read(sql);
                if (dc.Read())//读到信息了
                {
                    MessageBox.Show("登陆成功");
                    MessageBox.Show(dc[0].ToString() + dc[1].ToString());//需要填写！！！！！！！！！！！！！！！！！！！！
                    admin1 a=new admin1();
                    this.Hide();
                    a.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登陆失败");
                }
                dao.DaoClose();
            }
            MessageBox.Show("请选中单选框，单选框失效");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string id=textBox1.Text;
                Login(id);
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
