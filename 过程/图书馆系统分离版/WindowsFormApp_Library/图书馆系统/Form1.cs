using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2

{

    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        public static string msg = "";//用户名msg
        public static int dlflag = 2;   //学生2  管理员1
        private void button1_Click(object sender, EventArgs e)
        {//登录
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                if (radioButton1.Checked) dlflag = 1;//管理员
                if (radioButton2.Checked) dlflag = 2;   //学生



                if (dlflag == 2)
                {
                    //数据库连接字符串
                    string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);//实例化sql连接对象
                    conn.Open();
                    //写sqlserver语句
                    string selectsql = "Select * from login where username = '" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                    SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                    cmd.CommandType = CommandType.Text;
                    //cmd执行的sql是你赋给CommandText的值里写出的sql语句，
                    //CommandType是SqlCommand对象的一个属性，CommandType是一个枚举类型，用于指定执行动作的形式，它告诉接下来执行的是一个文本(text)。
                    //有三个值：text、StoredProcedure、TableDirect，用于表示SqlCommand对象CommandType的执行形式。

                    SqlDataReader sdr;//声明对象 
                    sdr = cmd.ExecuteReader();  //读cmd取到的text文本
                    if (sdr.Read())//读到存在账号密码
                    {

                        label3.Text = "登陆学生成功!";
                        msg = textBox1.Text;  //跳转主界面
                        this.DialogResult = DialogResult.OK;//调用program中的函数方法 
                        this.Dispose(); //登陆成功显示主界面  
                        this.Close();   //关闭当前页面

                    }
                    else
                    {

                        label3.Text = "登陆学生失败!"; //label3在界面没有显示，因为我设置了显示为一个空格，label控件用以显示提示登录信息
                        button5.Visible = true;//忘记密码  
                        textBox2.Text = "";

                    }
                    conn.Close();//关闭对象
                }
                if (dlflag == 1)
                {
                    string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string selectsql = "Select * from loginad where username = '" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                    SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        label3.Text = "登陆管理员成功!";
                        msg = textBox1.Text;
                        this.DialogResult = DialogResult.Yes;
                        this.Dispose();
                        this.Close();
                    }
                    else
                    {
                        label3.Text = "登陆管理员失败!";
                        textBox2.Text = "";
                    }
                    conn.Close();
                }
            }
            else label3.Text = "用户名或密码为空!";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                //注册
                if (radioButton1.Checked) dlflag = 1;
                if (radioButton2.Checked) dlflag = 2;
                if (dlflag == 2)
                {
                    //查找读者 判断是否注册过   与登录代码基本一致
                    string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn454 = new SqlConnection(str454);//实例化cnn对象
                    conn454.Open();//打开
                    string selectsql454 = "Select * from login where username = '" + textBox1.Text + "'";
                    SqlCommand cmd454 = new SqlCommand(selectsql454, conn454);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                    cmd454.CommandType = CommandType.Text;
                    SqlDataReader sdr454;
                    sdr454 = cmd454.ExecuteReader();
                    if (sdr454.Read())
                    {
                        MessageBox.Show("用户已存在！请直接登录");
                    }
                    else
                    {//开始修改                      
                        string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();
                        string selectsql = "insert into login values('" + textBox1.Text + "','" + textBox2.Text + "',0,'null',0)";
                        SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader sdr;
                        sdr = cmd.ExecuteReader();
                        label3.Text = "注册学生成功!     ";
                        conn.Close();
                    }
                    conn454.Close();
                }
                if (dlflag == 1)
                {
                    //查找管理员
                    string str4543 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn4543 = new SqlConnection(str4543);
                    conn4543.Open();
                    string selectsql4543 = "Select * from loginad where username = '" + textBox1.Text + "'";
                    SqlCommand cmd4543 = new SqlCommand(selectsql4543, conn4543);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                    cmd4543.CommandType = CommandType.Text;
                    SqlDataReader sdr4543;
                    sdr4543 = cmd4543.ExecuteReader();
                    if (sdr4543.Read())
                    {
                        MessageBox.Show("管理员已存在！请直接登录  ");
                    }
                    else
                    {
                        string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                        SqlConnection conn = new SqlConnection(str);
                        conn.Open();
                        string selectsql = "insert into loginad values('" + textBox1.Text + "','" + textBox2.Text + "')";
                        SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader sdr;
                        sdr = cmd.ExecuteReader();
                        label3.Text = "注册管理员成功!";
                        conn.Close();
                    }
                    conn4543.Close();
                }
            }
            else label3.Text = "用户名或密码为空！";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*'; //设置文本框的PasswordChar属性为字符@
            textBox2.UseSystemPasswordChar = true;
            button3.BackColor = Color.LightSkyBlue;
            button4.BackColor = Color.White;
            this.timer2222.Enabled = true;
            this.timer2222.Interval = 1000;

            tabControl123.Visible = true;
            tabControl234.Visible = false;
            textBox1111.Text = Form1.msg;
            Random rd = new Random();
            int i = rd.Next();
            i = i % 10000;
            label10.Text = Convert.ToString(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {//切换登录状态
            button1.Visible = true;
            button2.Visible = false;
            label4.Text = "状态：登录";
            button3.BackColor = Color.LightSkyBlue;
            button4.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {//切换注册状态
            button2.Visible = true;
            button1.Visible = false;
            button7.Visible = false;
            button5.Visible = false;
            label4.Text = "状态：注册";
            button4.BackColor = Color.LightSkyBlue;
            button3.BackColor = Color.White;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            button7.Visible = true;
            label4.Text = "状态：忘记密码";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wpa.qq.com/msgrd?v=3&uin=1602112092&site=qq&menu=yes");
        }

      

        private void 验证身份_Click(object sender, EventArgs e)
        {
            label4.Text = "状态：验证身份";
            label8.Text = textBox1111.Text;
            if (textBox1111.Text != "" && textBox22222.Text != "" && textBox33333.Text != "" && textBox44444.Text != "")
            {

                //数据库连接字符串
                string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);//实例化sql连接对象
                conn.Open();
                //写sqlserver语句
                string selectsql = "Select * from login where username = '" + textBox1111.Text + "' and age='" + textBox22222.Text + "' and sex='" + textBox33333.Text + "' and qq=" + textBox44444.Text + "";
                SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                cmd.CommandType = CommandType.Text;
                //cmd执行的sql是你赋给CommandText的值里写出的sql语句，
                //CommandType是SqlCommand对象的一个属性，CommandType是一个枚举类型，用于指定执行动作的形式，它告诉接下来执行的是一个文本(text)。
                //有三个值：text、StoredProcedure、TableDirect，用于表示SqlCommand对象CommandType的执行形式。

                SqlDataReader sdr;//声明对象 
                sdr = cmd.ExecuteReader();  //读cmd取到的text文本
                if (sdr.Read())//读到存在账号 验证通过
                {
                    //成功
                    tabControl123.Visible = false;
                    tabControl234.Visible = true;
                }
                else
                {
                    MessageBox.Show("身份验证失败！");
                }


            }
            else
            {
                MessageBox.Show("身份验证失败！");
            }
        }

        private void 无法验证_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wpa.qq.com/msgrd?v=3&uin=1602112092&site=qq&menu=yes");

        }

        private void 账号申诉_Click(object sender, EventArgs e)
        {
            label4.Text = "状态：账号申诉";
            if (textBox7777.Text == label10.Text)
            {
                string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string usetime = DateTime.Now.ToString();
                string selectsql = "insert into ss values('" + textBox7777.Text + "','" + usetime + "','" + textBox1111.Text + "',0)";
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                conn.Close();
                //UpdataForm udform = new UpdataForm();
                
                等待管理员反馈.Visible = true;

                this.timer2222.Start();

            }
            else
            {
                MessageBox.Show("特征码输入错误！");
            }
        }

        private void 修改密码_Click(object sender, EventArgs e)
        {
            label4.Text = "状态：修改密码";
            if (textBox55555.Text != "" && textBox66666.Text != "" && textBox55555.Text == textBox66666.Text)
            {

                string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string selectsql = "update login set password = '" + textBox55555.Text + "'  where username = '" + label8.Text + "'";
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                //UpdataForm udform2 = new UpdataForm();
               
                conn.Close();
                MessageBox.Show("修改密码成功", "修改密码", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                groupBox2.Visible = false;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else MessageBox.Show("请输入正确的信息！");
        }

        private void timer2222_Tick(object sender, EventArgs e)
        {
            //数据库连接字符串
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);//实例化sql连接对象
            conn.Open();
            //写sqlserver语句
            string selectsql = "Select * from ss where id = '" + label10.Text + "' and flag='1'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd.CommandType = CommandType.Text;
            //cmd执行的sql是你赋给CommandText的值里写出的sql语句，
            //CommandType是SqlCommand对象的一个属性，CommandType是一个枚举类型，用于指定执行动作的形式，它告诉接下来执行的是一个文本(text)。
            //有三个值：text、StoredProcedure、TableDirect，用于表示SqlCommand对象CommandType的执行形式。

            SqlDataReader sdr;//声明对象 
            sdr = cmd.ExecuteReader();  //读cmd取到的text文本
            if (sdr.Read())//读到
            {
                等待管理员反馈.Text = "已接受数据，正在处理。。。";
                this.timer2222.Stop();
                this.timer2222.Enabled = false;

                string str8 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn8 = new SqlConnection(str8);
                conn8.Open();
                string selectsql8 = "update login set password = '123456'  where username = '" + textBox1111.Text + "'";
                SqlCommand cmd8 = new SqlCommand(selectsql8, conn8);
                cmd8.CommandType = CommandType.Text;
                SqlDataReader sdr8;
                sdr8 = cmd8.ExecuteReader();
                //UpdataForm udform2 = new UpdataForm();
                conn8.Close();

                MessageBox.Show("申诉成功!账号：" + textBox1111.Text + " 密码：123456");
                groupBox2.Visible = false;
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            button7.Visible = false;
            label4.Text = "状态：登录";
        }
    }
}
