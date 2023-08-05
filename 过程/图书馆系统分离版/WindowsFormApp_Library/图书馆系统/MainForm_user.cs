using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace 图书馆系统
{
    public partial class MainForm_user : Form
    {
        public MainForm_user()
        {
            InitializeComponent();
        }
        int num1 = 0;

        private void MainForm_user_Load(object sender, EventArgs e)
        {
            timer2.Start();
            label6yonghu.Text = WindowsFormsApp2.Form1.msg;
            label1留言.Text = WindowsFormsApp2.Form1.msg;
            timerxiaoxi.Start();
            rereadtimer1.Start();
            Random rdq = new Random();
            int iq = rdq.Next();
            iq = iq % 10000;
            label3特征码.Text = Convert.ToString(iq);
            label1用户.Text = WindowsFormsApp2.Form1.msg;
            label22用户.Text = WindowsFormsApp2.Form1.msg;

            string str1515 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1515 = new SqlConnection(str1515);
            conn1515.Open();
            SqlDataAdapter sqlDap1515 = new SqlDataAdapter("Select * from book order by id", conn1515);
            DataSet dds1515 = new DataSet();
            sqlDap1515.Fill(dds1515);
            DataTable _table1515 = dds1515.Tables[0];
            int count1515 = _table1515.Rows.Count;
            dataGridView查看图书.DataSource = _table1515;
            conn1515.Close();

            tushuyilan.Visible = true;
            xinxigenggai.Visible = false;
            xiaoxitixing.Visible = false;
            yuyueyewu.Visible = false;
            jiehuanyewu.Visible = false;
            yijianfankui.Visible = false;

            string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn454 = new SqlConnection(str454);
            conn454.Open();
            string selectsql454 = "Select * from allmessageflag where username = '" + label6yonghu.Text + "'";
            SqlCommand cmd454 = new SqlCommand(selectsql454, conn454);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd454.CommandType = CommandType.Text;

            SqlDataReader sdr454;
            sdr454 = cmd454.ExecuteReader();
            if (sdr454.Read())
            {   //存在
            }
            else
            {//不存在 创建
                string str21 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn21 = new SqlConnection(str21);
                conn21.Open();
                string selectsql21 = "insert into allmessageflag values('" + label6yonghu.Text + "','否')";
                SqlCommand cmd21 = new SqlCommand(selectsql21, conn21);
                cmd21.CommandType = CommandType.Text;
                SqlDataReader sdr21;
                sdr21 = cmd21.ExecuteReader();
                conn21.Close();
            }
        }

        private void 图书一览_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = true;
            xinxigenggai.Visible = false;
            xiaoxitixing.Visible = false;
            yuyueyewu.Visible = false;
            jiehuanyewu.Visible = false;
            yijianfankui.Visible = false;

            //刷新图书信息
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book order by id", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
            dataGridView查看图书.DataSource = _table;
            conn.Close();




        }

        private void 借还业务_Click(object sender, EventArgs e)
        {
            jiehuanyewu.Visible = true;
            tushuyilan.Visible = false;
            xinxigenggai.Visible = false;
            xiaoxitixing.Visible = false;
            yuyueyewu.Visible = false;
            yijianfankui.Visible = false;

            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book where id like '%" + textBox8书号.Text + "%' and bname like '%" + textBox7书名.Text + "%'order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView1借书表.DataSource = _table1;
            conn1.Close();

            string str151 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn151 = new SqlConnection(str151);
            conn151.Open();

            SqlDataAdapter sqlDap31 = new SqlDataAdapter("Select * from js where username = '" + label1用户.Text + "' order by username", conn151);
            DataSet dds151 = new DataSet();
            sqlDap31.Fill(dds151);
            DataTable _table11 = dds151.Tables[0];
            int count11 = _table11.Rows.Count;
            dataGridView3借阅信息.DataSource = _table11;
            conn151.Close();

            string str1523 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1523 = new SqlConnection(str1523);
            conn1523.Open();

            SqlDataAdapter sqlDap323 = new SqlDataAdapter("Select * from hs where username = '" + label1用户.Text + "' order by username", conn1523);
            DataSet dds1523 = new DataSet();
            sqlDap323.Fill(dds1523);
            DataTable _table123 = dds1523.Tables[0];
            int count123 = _table123.Rows.Count;
            dataGridView2还书信息.DataSource = _table123;
            conn1523.Close();
        }

        private void 预约业务_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = false;
            xinxigenggai.Visible = false;
            xiaoxitixing.Visible = false;
            yuyueyewu.Visible = true;
            jiehuanyewu.Visible = false;
            yijianfankui.Visible = false;

            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book where id like '%" + textBox1预约书号.Text + "%' and bname like '%" + textBox4预约书名.Text + "%'order by id", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
            dataGridView1预约显示.DataSource = _table;
            conn.Close();

            string str15 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn15 = new SqlConnection(str15);
            conn15.Open();
            SqlDataAdapter sqlDap5 = new SqlDataAdapter("Select * from yy where username='" + label1用户.Text + "'", conn15);
            DataSet dds15 = new DataSet();
            sqlDap5.Fill(dds15);
            DataTable _table15 = dds15.Tables[0];
            int count15 = _table15.Rows.Count;
            dataGridView2预约表.DataSource = _table15;
            conn15.Close();
        }

        private void 信息修改_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = false;
            xinxigenggai.Visible = true;
            xiaoxitixing.Visible = false;
            yuyueyewu.Visible = false;
            jiehuanyewu.Visible = false;
            yijianfankui.Visible = false;
        }

        private void 意见反馈_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = false;
            xinxigenggai.Visible = false;
            xiaoxitixing.Visible = false;
            yuyueyewu.Visible = false;
            jiehuanyewu.Visible = false;
            yijianfankui.Visible = true;
        }

        private void 消息提醒_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = false;
            xinxigenggai.Visible = false;
            xiaoxitixing.Visible = true;
            yuyueyewu.Visible = false;
            jiehuanyewu.Visible = false;
            yijianfankui.Visible = false;
          
            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap1 = new SqlDataAdapter("Select * from allmessage order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap1.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView1qb.DataSource = _table1;
            conn1.Close();

            string str44 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn44 = new SqlConnection(str44);
            conn44.Open();
            string selectsql44 = "update usermessage set isread = '是' where username = '"+label1留言.Text+"'";
            SqlCommand cmd44 = new SqlCommand(selectsql44, conn44);
            cmd44.CommandType = CommandType.Text;
            SqlDataReader sdr44;
            sdr44 = cmd44.ExecuteReader();
            conn44.Close();

            string str4455 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn4455 = new SqlConnection(str4455);
            conn4455.Open();
            string selectsql4455 = "update allmessageflag set isread = '是' where username = '" + label1留言.Text + "'";
            SqlCommand cmd4455 = new SqlCommand(selectsql4455, conn4455);
            cmd4455.CommandType = CommandType.Text;
            SqlDataReader sdr4455;
            sdr4455 = cmd4455.ExecuteReader();
            conn4455.Close();
  string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from usermessage where username = '" + label1用户.Text + "' order by username", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
            dataGridView1siliao.DataSource = _table;
            conn.Close();

        }

        private void button1密码修改_Click(object sender, EventArgs e)
        {
            string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn454 = new SqlConnection(str454);
            conn454.Open();
            string selectsql454 = "Select * from login where username = '" + label6yonghu.Text + "'";
            SqlCommand cmd454 = new SqlCommand(selectsql454, conn454);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd454.CommandType = CommandType.Text;

            SqlDataReader sdr454;
            sdr454 = cmd454.ExecuteReader();
            if (sdr454.Read())
            {
                string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string selectsql = "update login set password = '" + textBoxmima.Text + "'  where username = '" + label6yonghu.Text + "'";
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                conn.Close();
                MessageBox.Show("修改密码成功", "修改密码", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            conn454.Close();
        }

        private void button2性别修改_Click(object sender, EventArgs e)
        {
            //查找读者
            string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn454 = new SqlConnection(str454);
            conn454.Open();
            string selectsql454 = "Select * from login where username = '" + label6yonghu.Text + "'";
            SqlCommand cmd454 = new SqlCommand(selectsql454, conn454);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd454.CommandType = CommandType.Text;

            SqlDataReader sdr454;
            sdr454 = cmd454.ExecuteReader();
            if (sdr454.Read())
            {   //开始修改

                string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string selectsql = "update login set sex = '" + textBox3xingbie.Text + "'  where username = '" + label6yonghu.Text + "'";
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                conn.Close();
                MessageBox.Show("修改性别成功", "修改性别", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            conn454.Close();
        }

        private void button3年龄修改_Click(object sender, EventArgs e)
        {
            //查找读者
            string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn454 = new SqlConnection(str454);
            conn454.Open();
            string selectsql454 = "Select * from login where username = '" + label6yonghu.Text + "'";
            SqlCommand cmd454 = new SqlCommand(selectsql454, conn454);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd454.CommandType = CommandType.Text;

            SqlDataReader sdr454;
            sdr454 = cmd454.ExecuteReader();
            if (sdr454.Read())
            {   //开始修改

                string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string selectsql = "update login set age = '" + textBox4nianling.Text + "'  where username = '" + label6yonghu.Text + "'";
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                conn.Close();
                MessageBox.Show("修改年龄成功", "修改年龄", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            conn454.Close();
        }

        private void button4qq修改_Click(object sender, EventArgs e)
        {
            //查找读者
            string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn454 = new SqlConnection(str454);
            conn454.Open();
            string selectsql454 = "Select * from login where username = '" + label6yonghu.Text + "'";
            SqlCommand cmd454 = new SqlCommand(selectsql454, conn454);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd454.CommandType = CommandType.Text;
            SqlDataReader sdr454;
            sdr454 = cmd454.ExecuteReader();
            if (sdr454.Read())
            {   //开始修改
                string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string selectsql = "update login set qq = '" + textBox5qq.Text + "'  where username = '" + label6yonghu.Text + "'";
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                conn.Close();
                MessageBox.Show("修改QQ成功", "修改QQ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conn454.Close();
        }

        private void button5查询_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book where id like '%" + textBox8书号.Text + "%' and bname like '%" + textBox7书名.Text + "%'order by id", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
            dataGridView1借书表.DataSource = _table;
            conn.Close();
        }

        private void button1借书按钮_Click(object sender, EventArgs e)
        {
            string str4 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn4 = new SqlConnection(str4);
            conn4.Open();
            if (dataGridView1借书表.SelectedRows.Count != 1) return;
            if (dataGridView1借书表.CurrentRow == null) return;
            // string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            DataRowView row1 = dataGridView1借书表.CurrentRow.DataBoundItem as DataRowView;
            if (row1["id"] == null) return;//可以进行快速监视
            string bd1 = Convert.ToString(row1["id"]);
            string selectsql4 = "Select * from js where username = '" + label22用户.Text + "' and id='" + bd1 + "'";
            SqlCommand cmd4 = new SqlCommand(selectsql4, conn4);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd4.CommandType = CommandType.Text;
            SqlDataReader sdr4;
            sdr4 = cmd4.ExecuteReader();
            if (sdr4.Read())//查询到借书信息
            {
                MessageBox.Show("你已经借阅了本书");
            }
            else
            {
                num1 = 0;
                string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                if (dataGridView1借书表.SelectedRows.Count != 1) return;
                if (dataGridView1借书表.CurrentRow == null) return;
                // string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                DataRowView row = dataGridView1借书表.CurrentRow.DataBoundItem as DataRowView;
                if (row["id"] == null) return;//可以进行快速监视
                string bd = Convert.ToString(row["id"]);
                string selectsql = "select bnum from book where id= " + bd + "";
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                object i = cmd.ExecuteScalar();
                textBox2辅助1.Text = i.ToString();

                num1 = int.Parse(textBox2辅助1.Text);
                int num2 = 0;
                num1 = num1 - 1;//借书后 减1数量
                num2 = num1 + 1;
                textBox3辅助.Text = Convert.ToString(num1);
                if (num2 > 0)
                {
                    conn.Close();
                    //查询数量完成 开始借书
                    string str21 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn21 = new SqlConnection(str21);
                    conn21.Open();
                    if (dataGridView1借书表.SelectedRows.Count != 1) return;
                    if (dataGridView1借书表.CurrentRow == null) return;
                    // string bd21 = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                    DataRowView row21 = dataGridView1借书表.CurrentRow.DataBoundItem as DataRowView;
                    if (row21["id"] == null) return;//可以进行快速监视
                    string bd21 = Convert.ToString(row21["id"]);
                    string selectsql21 = "update book set bnum = " + textBox3辅助.Text + " where id = '" + bd21 + "'";
                    SqlCommand cmd21 = new SqlCommand(selectsql21, conn21);
                    cmd21.CommandType = CommandType.Text;
                    SqlDataReader sdr21;
                    sdr21 = cmd21.ExecuteReader();
                    conn.Close();//完成book更新
                                 //写js表
                    string str12 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn12 = new SqlConnection(str12);
                    conn12.Open();
                    if (dataGridView1借书表.SelectedRows.Count != 1) return;
                    if (dataGridView1借书表.CurrentRow == null) return;
                    // string bd12 = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                    DataRowView row12 = dataGridView1借书表.CurrentRow.DataBoundItem as DataRowView;
                    if (row12["id"] == null) return;//可以进行快速监视
                    string bd12 = Convert.ToString(row12["id"]);
                    label1用户.Text = WindowsFormsApp2.Form1.msg;
                    string usetime = DateTime.Now.ToString();
                    string selectsql12 = "insert into js values('" + label1用户.Text + "','" + bd + "','" + usetime + "')";
                    SqlCommand cmd12 = new SqlCommand(selectsql12, conn12);
                    cmd12.CommandType = CommandType.Text;
                    SqlDataReader sdr12;
                    sdr12 = cmd12.ExecuteReader();
                    conn12.Close();
                    //yy表更新完成
                    MessageBox.Show("用户 " + label1用户.Text + " 借阅成功,书号：" + bd + " 剩余数量：" + textBox3辅助.Text, "预约图书", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //刷新图书目录
                    string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn1 = new SqlConnection(str1);
                    conn1.Open();

                    SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book where id like '%" + textBox8书号.Text + "%' and bname like '%" + textBox7书名.Text + "%'order by id", conn1);
                    DataSet dds1 = new DataSet();
                    sqlDap.Fill(dds1);
                    DataTable _table1 = dds1.Tables[0];
                    int count1 = _table1.Rows.Count;
                    dataGridView1借书表.DataSource = _table1;
                    conn1.Close();

                    string str151 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn151 = new SqlConnection(str151);
                    conn151.Open();

                    SqlDataAdapter sqlDap31 = new SqlDataAdapter("Select * from js where username = '" + label1用户.Text + "' order by username", conn151);
                    DataSet dds151 = new DataSet();
                    sqlDap31.Fill(dds151);
                    DataTable _table11 = dds151.Tables[0];
                    int count11 = _table11.Rows.Count;
                    dataGridView3借阅信息.DataSource = _table11;
                    conn151.Close();

                }
                else MessageBox.Show("查询完成，图书 " + bd + " 剩余数量：0 。请选择其他书籍借阅。");
            }
                
        }

        private void button2还书按钮_Click(object sender, EventArgs e)
        {
            //查询借书信息
            string str4 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn4 = new SqlConnection(str4);
            conn4.Open();
            string selectsql4 = "Select * from js where username = '" + label22用户.Text + "' and id='" + textBox1书号.Text + "'";
            SqlCommand cmd4 = new SqlCommand(selectsql4, conn4);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd4.CommandType = CommandType.Text;
            SqlDataReader sdr4;
            sdr4 = cmd4.ExecuteReader();
            if (sdr4.Read())//查询到借书信息
            {
                string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string selectsql = "update book set bnum = bnum+1 where id = '" + textBox1书号.Text + "'";
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                conn.Close();
                //删除借阅
                string str9 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn9 = new SqlConnection(str9);
                conn9.Open();
                string selectsql9 = "delete from js where id='" + textBox1书号.Text + "' and username='" + label22用户.Text + "'";
                SqlCommand cmd9 = new SqlCommand(selectsql9, conn9);
                cmd9.CommandType = CommandType.Text;
                SqlDataReader sdr9;
                sdr9 = cmd9.ExecuteReader();
                conn9.Close();

                //写还书记录
                string str7 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn7 = new SqlConnection(str7);
                conn7.Open();
                string usetime1 = DateTime.Now.ToString();
                string selectsql7 = "insert into hs values('" + label22用户.Text + "','" + textBox1书号.Text + "','" + usetime1 + "')";
                SqlCommand cmd7 = new SqlCommand(selectsql7, conn7);
                cmd7.CommandType = CommandType.Text;
                SqlDataReader sdr7;
                sdr7 = cmd7.ExecuteReader();
                conn7.Close();

                MessageBox.Show("用户：" + label22用户.Text + " 还书成功!书号： " + textBox1书号.Text, "还书信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //刷新图书表
                string str6 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn6 = new SqlConnection(str6);
                conn6.Open();
                SqlDataAdapter sqlDap6 = new SqlDataAdapter("Select * from book order by id", conn6);
                DataSet dds6 = new DataSet();
                sqlDap6.Fill(dds6);
                DataTable _table6 = dds6.Tables[0];
                int count6 = _table6.Rows.Count;
                dataGridView1借书表.DataSource = _table6;
                conn6.Close();

                //更新借阅表
                string str15 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn15 = new SqlConnection(str15);
                conn15.Open();

                SqlDataAdapter sqlDap3 = new SqlDataAdapter("Select * from js where username = '" + label1用户.Text + "' order by username", conn15);
                DataSet dds15 = new DataSet();
                sqlDap3.Fill(dds15);
                DataTable _table1 = dds15.Tables[0];
                int count1 = _table1.Rows.Count;
                dataGridView3借阅信息.DataSource = _table1;
                conn15.Close();
                //dataGridView1.DataBind();

                string str1523 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn1523 = new SqlConnection(str1523);
                conn1523.Open();

                SqlDataAdapter sqlDap323 = new SqlDataAdapter("Select * from hs where username = '" + label1用户.Text + "' order by username", conn1523);
                DataSet dds1523 = new DataSet();
                sqlDap323.Fill(dds1523);
                DataTable _table123 = dds1523.Tables[0];
                int count123 = _table123.Rows.Count;
                dataGridView2还书信息.DataSource = _table123;
                conn1523.Close();
                //dataGridView1.DataBind();
            }
            else
            {
                MessageBox.Show("还书失败，用户: " + label22用户.Text + " 无此项借书记录!", "还书信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conn4.Close();
        }

        private void button1预约查询_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book where id like '%" + textBox1预约书号.Text + "%' and bname like '%" + textBox4预约书名.Text + "%'order by id", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
            dataGridView1预约显示.DataSource = _table;
            conn.Close();
        }

        private void button4预约按钮_Click(object sender, EventArgs e)
        {
            num1 = 0;
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView1预约显示.SelectedRows.Count != 1) return;
            if (dataGridView1预约显示.CurrentRow == null) return;
            // string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            DataRowView row = dataGridView1预约显示.CurrentRow.DataBoundItem as DataRowView;
            if (row["id"] == null) return;//可以进行快速监视
            string bd = Convert.ToString(row["id"]);
            string selectsql = "select bnum from book where id= " + bd + "";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            object i = cmd.ExecuteScalar();
            textBox2预约辅助.Text = i.ToString();

            num1 = int.Parse(textBox2预约辅助.Text);
            int num2 = 0;
            num1 = num1 - 1;//预约后 减1数量
            num2 = num1 + 1;
            textBox3预约辅助.Text = Convert.ToString(num1);
            if (num2 > 0)
            {
                conn.Close();
                //查询数量完成 开始预约
                string str21 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn21 = new SqlConnection(str21);
                conn21.Open();
                if (dataGridView1预约显示.SelectedRows.Count != 1) return;
                if (dataGridView1预约显示.CurrentRow == null) return;
                // string bd21 = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                DataRowView row21 = dataGridView1预约显示.CurrentRow.DataBoundItem as DataRowView;
                if (row21["id"] == null) return;//可以进行快速监视
                string bd21 = Convert.ToString(row21["id"]);
                string selectsql21 = "update book set bnum = " + textBox3预约辅助.Text + " where id = '" + bd21 + "'";
                SqlCommand cmd21 = new SqlCommand(selectsql21, conn21);
                cmd21.CommandType = CommandType.Text;
                SqlDataReader sdr21;
                sdr21 = cmd21.ExecuteReader();
                conn21.Close();//完成book更新

                //写yy表
                string str12 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn12 = new SqlConnection(str12);
                conn12.Open();
                if (dataGridView1预约显示.SelectedRows.Count != 1) return;
                if (dataGridView1预约显示.CurrentRow == null) return;
                // string bd12 = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                DataRowView row12 = dataGridView1预约显示.CurrentRow.DataBoundItem as DataRowView;
                if (row12["id"] == null) return;//可以进行快速监视
                string bd12 = Convert.ToString(row12["id"]);
                label1预约用户.Text = WindowsFormsApp2.Form1.msg;
                string usetime = DateTime.Now.ToString();
                string selectsql12 = "insert into yy values('" + label1预约用户.Text + "','" + bd + "','" + usetime + "')";
                SqlCommand cmd12 = new SqlCommand(selectsql12, conn12);
                cmd12.CommandType = CommandType.Text;
                SqlDataReader sdr12;
                sdr12 = cmd12.ExecuteReader();
                conn12.Close();
                //yy表更新完成
                MessageBox.Show("用户 " + label1预约用户.Text + " 预约成功,书号：" + bd + " 剩余数量：" + textBox3预约辅助.Text, "预约图书", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //刷新图书目录
                string str19 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn19 = new SqlConnection(str19);
                conn19.Open();
                SqlDataAdapter sqlDap19 = new SqlDataAdapter("Select * from book where id like '%" + textBox1预约书号.Text + "%' and bname like '%" + textBox4预约书名.Text + "%'order by id", conn19);
                DataSet dds1 = new DataSet();
                sqlDap19.Fill(dds1);
                DataTable _table119 = dds1.Tables[0];
                int count19 = _table119.Rows.Count;
                dataGridView1预约显示.DataSource = _table119;
                conn19.Close();
                //dataGridView1.DataBind();
                //刷新预约表
                string str15 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn15 = new SqlConnection(str15);
                conn15.Open();
                SqlDataAdapter sqlDap5 = new SqlDataAdapter("Select * from yy where username='" + label1预约用户.Text + "'", conn15);
                DataSet dds15 = new DataSet();
                sqlDap5.Fill(dds15);
                DataTable _table15 = dds15.Tables[0];
                int count15 = _table15.Rows.Count;
                dataGridView2预约表.DataSource = _table15;
                conn15.Close();
                //dataGridView1.DataBind();
            }
            else
            {
                MessageBox.Show("查询完成，图书 " + bd + " 剩余数量：0 。请选择其他书籍预约。");
            }
        }

        private void button2精选留言_Click(object sender, EventArgs e)
        {
            string str191 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn191 = new SqlConnection(str191);
            conn191.Open();

            SqlDataAdapter sqlDap191 = new SqlDataAdapter("Select * from ly where jx = '是' order by time", conn191);
            DataSet dds11 = new DataSet();
            sqlDap191.Fill(dds11);
            DataTable _table1191 = dds11.Tables[0];
            int count191 = _table1191.Rows.Count;
            dataGridView2精选留言.DataSource = _table1191;
            conn191.Close();
            dataGridView2精选留言.Visible = true;
            button2精选留言.Enabled = false;
            返回留言.Visible = true;
            label1留言.Visible = false;
            label3特征码.Visible = false;
            label12.Visible = false;

            label10.Visible = false;
            textBox1留言.Visible = false;
            textBox2特征码.Visible = false;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1留言.Text == "请在此处留下您的宝贵意见。")
            {
                MessageBox.Show("留言失败！", "添加留言", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (textBox2特征码.Text == label3特征码.Text)
                {
                    string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string usetime = DateTime.Now.ToString();

                    string selectsql = "insert into ly values('" + textBox2特征码.Text + "','" + label1留言.Text + "','" + usetime + "','" + textBox1留言.Text + "','否')";
                    SqlCommand cmd = new SqlCommand(selectsql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    conn.Close();
                    
                    

                    MessageBox.Show("留言成功！", "添加留言", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
                else MessageBox.Show("特征码输入错误！", "添加留言");
            }
        }

        private void 返回留言_Click(object sender, EventArgs e)
        {
          
            dataGridView2精选留言.Visible = false;
            button2精选留言.Enabled = true;
            返回留言.Visible = false;

            label1留言.Visible = true;
            label3特征码.Visible = true;
            label12.Visible = true;
            label10.Visible = true;
            textBox1留言.Visible = true;
            textBox2特征码.Visible = true;
        }

        private void button6联系我们_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wpa.qq.com/msgrd?v=3&uin=1602112092&site=qq&menu=yes");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string usetime = DateTime.Now.ToString();
            string selectsql = "insert into usermessage values('" + textBox2id.Text + "','" +textBox1message.Text + "','" + usetime + "','" + label1用户.Text + "','否')";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            conn.Close();

            string str2 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn2 = new SqlConnection(str2);
            conn2.Open();

            SqlDataAdapter sqlDap2 = new SqlDataAdapter("Select * from usermessage where username = '" + label1用户.Text + "' order by username", conn2);
            DataSet dds2 = new DataSet();
            sqlDap2.Fill(dds2);
            DataTable _table2 = dds2.Tables[0];
            int count2 = _table2.Rows.Count;
            dataGridView1siliao.DataSource = _table2;
            conn2.Close();

            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap1 = new SqlDataAdapter("Select * from allmessage order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap1.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView1qb.DataSource = _table1;
            conn1.Close();
        }

       
        //读取 ’否 ’
        private void timerxiaoxi_Tick(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from usermessage where username = '" + label1用户.Text + "' and isread ='否' order by username", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
           

            conn.Close();
            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap1 = new SqlDataAdapter("Select * from allmessageflag where username = '"+label1用户.Text+"' and isread = '否'", conn1);
            DataSet dds1 = new DataSet();
            sqlDap1.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            if (count1 > 0 || count>0)
            {
                flaglabel1.Visible = true;
               
}
            else flaglabel1.Visible = false;
            conn1.Close();
        }
        //每10秒刷新消息
        private void rereadtimer1_Tick(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from usermessage where username = '" + label1用户.Text + "' order by username", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
            dataGridView1siliao.DataSource = _table;
            conn.Close();

            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap1 = new SqlDataAdapter("Select * from allmessage order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap1.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView1qb.DataSource = _table1;
            conn1.Close();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
                label1.Left -= 2;         //字幕滚动的数度

                if (label1.Right < 1)
                {
                    label1.Left = 735;     //滚动完的位置
                }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (flaglabel1.Enabled == true)
            {
                flaglabel1.Enabled = false;
            }
            else flaglabel1.Enabled = true;
        }
    }
}

