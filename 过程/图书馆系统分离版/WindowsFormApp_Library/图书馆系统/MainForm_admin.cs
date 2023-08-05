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
    public partial class MainForm_admin : Form
    {
        public MainForm_admin()
        {
            InitializeComponent();
        }
        int flag11 = 1;
        string adminnn = WindowsFormsApp2.Form1.msg;

        private void button1tianjiatushu_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "insert into book values('" + textBox1shuhao.Text + "','" + textBox2shuming.Text + "','" + textBox3shuliang.Text + "')";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            conn.Close();


            MessageBox.Show("添加成功！", "添加图书", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //刷新
            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView1shanchutushuxianshi.DataSource = _table1;
            conn1.Close();

        }

        private void button2shumingxiugai_Click(object sender, EventArgs e)
        {

            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "update book set bname = '" + textBox6shuming.Text + "' where id = '" + textBox5shuhao.Text + "'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();

            conn.Close();
            MessageBox.Show("修改书名成功", "修改书名", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //刷新删除中的图书信息
            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView1shanchutushuxianshi.DataSource = _table1;
            conn.Close();

        }

        private void button3shuliangxiugai_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "update book set bnum = " + textBox4shuliang.Text + " where id = '" + textBox5shuhao.Text + "'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            conn.Close();
            MessageBox.Show("修改数量成功", "修改数量", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //刷新删除中的图书信息
            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView1shanchutushuxianshi.DataSource = _table1;
            conn.Close();

        }

        private void MainForm_admin_Load(object sender, EventArgs e)
        {
            timer2radiocheck.Start();
            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView111222.DataSource = _table1;
            conn1.Close();

            tushuyilan.Visible = true;
            tushuguanli.Visible = false;
            jieyueguanli.Visible = false;
            xiaoxiguanli.Visible = false;
            liuyanguanli.Visible = false;
            duzheguanli.Visible = false;
            

        }

        private void button4shanchuanniu_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView1shanchutushuxianshi.SelectedRows.Count != 1) return;
            if (dataGridView1shanchutushuxianshi.CurrentRow == null) return;
            // string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            DataRowView row = dataGridView1shanchutushuxianshi.CurrentRow.DataBoundItem as DataRowView;
            if (row["id"] == null) return;//可以进行快速监视
            string bd = Convert.ToString(row["id"]);
            string selectsql = "delete from book where id = " + bd + "";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            //SqlDataReader sdr;
            //sdr = cmd.ExecuteReader();
            int ret = cmd.ExecuteNonQuery();//受影响的行数（总数）
            if (ret == -1)
            {
                MessageBox.Show("删除失败！");
                return;
            }
            else
            {
                MessageBox.Show("删除成功！");
            }
            conn.Close();
            //重新加载图书信息
            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView1shanchutushuxianshi.DataSource = _table1;

            //dataGridView1.DataBind();
            conn1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = true;
            tushuguanli.Visible = false;
            jieyueguanli.Visible = false;
            xiaoxiguanli.Visible = false;
            liuyanguanli.Visible = false;
            duzheguanli.Visible = false;

            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from book order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView111222.DataSource = _table1;
            conn1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = false;
            tushuguanli.Visible = false;
            jieyueguanli.Visible = false;
            xiaoxiguanli.Visible = false;
            liuyanguanli.Visible = true;
            duzheguanli.Visible = false;
            //加载留言表数据
            string str19 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn19 = new SqlConnection(str19);
            conn19.Open();

            SqlDataAdapter sqlDap19 = new SqlDataAdapter("Select * from ly order by time", conn19);
            DataSet dds1 = new DataSet();
            sqlDap19.Fill(dds1);
            DataTable _table119 = dds1.Tables[0];
            int count19 = _table119.Rows.Count;
            dataGridView1chakanliuyan.DataSource = _table119;
            conn19.Close();


            string str191 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn191 = new SqlConnection(str191);
            conn191.Open();

            SqlDataAdapter sqlDap191 = new SqlDataAdapter("Select * from ly where jx = '是' order by time", conn191);
            DataSet dds11 = new DataSet();
            sqlDap191.Fill(dds11);
            DataTable _table1191 = dds11.Tables[0];
            int count191 = _table1191.Rows.Count;
            dataGridView2jingxuanliuyan.DataSource = _table1191;
            conn191.Close();
        }

        private void button1shanchuliuyan_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView1chakanliuyan.SelectedRows.Count != 1) return;
            if (dataGridView1chakanliuyan.CurrentRow == null) return;
            // string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            DataRowView row = dataGridView1chakanliuyan.CurrentRow.DataBoundItem as DataRowView;
            if (row["id"] == null) return;//可以进行快速监视
            string bd = Convert.ToString(row["id"]);
            string selectsql = "delete from ly where id = " + bd + "";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            //SqlDataReader sdr;
            //sdr = cmd.ExecuteReader();
            int ret = cmd.ExecuteNonQuery();//受影响的行数（总数）
            if (ret == -1)
            {
                MessageBox.Show("删除失败！");
                return;
            }
            else
            {
                MessageBox.Show("删除成功！");
                //加载留言表数据
                string str19 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn19 = new SqlConnection(str19);
                conn19.Open();

                SqlDataAdapter sqlDap19 = new SqlDataAdapter("Select * from ly order by time", conn19);
                DataSet dds1 = new DataSet();
                sqlDap19.Fill(dds1);
                DataTable _table119 = dds1.Tables[0];
                int count19 = _table119.Rows.Count;
                dataGridView1chakanliuyan.DataSource = _table119;
                conn19.Close();
            }
            conn.Close();
        }

        private void button2jingxuanliuyan_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView1chakanliuyan.SelectedRows.Count != 1) return;
            if (dataGridView1chakanliuyan.CurrentRow == null) return;
            // string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            DataRowView row = dataGridView1chakanliuyan.CurrentRow.DataBoundItem as DataRowView;
            if (row["id"] == null) return;//可以进行快速监视
            string bd = Convert.ToString(row["id"]);
            string selectsql = "update ly set jx = '是' where id = '" + bd + "'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            //SqlDataReader sdr;
            //sdr = cmd.ExecuteReader();
            int ret = cmd.ExecuteNonQuery();//受影响的行数（总数）
            if (ret == -1)
            {
                MessageBox.Show("精选留言失败！");
                return;
            }
            else
            {
                MessageBox.Show("精选留言成功！");
                //加载留言表数据
                string str19 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn19 = new SqlConnection(str19);
                conn19.Open();

                SqlDataAdapter sqlDap19 = new SqlDataAdapter("Select * from ly order by time", conn19);
                DataSet dds1 = new DataSet();
                sqlDap19.Fill(dds1);
                DataTable _table119 = dds1.Tables[0];
                int count19 = _table119.Rows.Count;
                dataGridView1chakanliuyan.DataSource = _table119;
                conn19.Close();
            }
            conn.Close();
            string str191 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn191 = new SqlConnection(str191);
            conn191.Open();

            SqlDataAdapter sqlDap191 = new SqlDataAdapter("Select * from ly where jx = '是' order by time", conn191);
            DataSet dds11 = new DataSet();
            sqlDap191.Fill(dds11);
            DataTable _table1191 = dds11.Tables[0];
            int count191 = _table1191.Rows.Count;
            dataGridView2jingxuanliuyan.DataSource = _table1191;
            conn191.Close();
        }

        private void button3qvxiaojingxuan_Click(object sender, EventArgs e)
        {

            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView2jingxuanliuyan.SelectedRows.Count != 1) return;
            if (dataGridView2jingxuanliuyan.CurrentRow == null) return;
            // string bd = dataGridView2.CurrentRow.Cells[2].Value.ToString();

            DataRowView row = dataGridView2jingxuanliuyan.CurrentRow.DataBoundItem as DataRowView;
            if (row["id"] == null) return;//可以进行快速监视
            string bd = Convert.ToString(row["id"]);
            string selectsql = "update ly set jx = '否' where id = '" + bd + "'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            //SqlDataReader sdr;
            //sdr = cmd.ExecuteReader();
            int ret = cmd.ExecuteNonQuery();//受影响的行数（总数）
            if (ret == -1)
            {
                MessageBox.Show("取消精选留言失败！");
                return;
            }
            else
            {
                MessageBox.Show("取消精选留言成功！");
            }
            conn.Close();

            string str191 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn191 = new SqlConnection(str191);
            conn191.Open();

            SqlDataAdapter sqlDap191 = new SqlDataAdapter("Select * from ly where jx = '是' order by time", conn191);
            DataSet dds11 = new DataSet();
            sqlDap191.Fill(dds11);
            DataTable _table1191 = dds11.Tables[0];
            int count191 = _table1191.Rows.Count;
            dataGridView2jingxuanliuyan.DataSource = _table1191;
            conn191.Close();

            //加载留言表数据
            string str19 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn19 = new SqlConnection(str19);
            conn19.Open();

            SqlDataAdapter sqlDap19 = new SqlDataAdapter("Select * from ly order by time", conn19);
            DataSet dds1 = new DataSet();
            sqlDap19.Fill(dds1);
            DataTable _table119 = dds1.Tables[0];
            int count19 = _table119.Rows.Count;
            dataGridView1chakanliuyan.DataSource = _table119;
            conn19.Close();
        }

        private void button5chaxun_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from login where age like '%" + textBox10duzhenianling.Text + "%' and username like '%" + textBox11duzheming.Text + "%' order by username", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
            dataGridView1.DataSource = _table;
            conn.Close();
            //dataGridView1.DataBind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = false;
            tushuguanli.Visible = false;
            jieyueguanli.Visible = false;
            xiaoxiguanli.Visible = false;
            liuyanguanli.Visible = false;
            duzheguanli.Visible = true;
            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from login order by username", conn1);
            DataSet dds1 = new DataSet();
            sqlDap.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView1.DataSource = _table1;

            conn1.Close();
            //dataGridView1.DataBind();

            string str2 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn2 = new SqlConnection(str2);
            conn2.Open();
            SqlDataAdapter sqlDap2 = new SqlDataAdapter("Select * from ss order by id", conn2);
            DataSet dds2 = new DataSet();
            sqlDap2.Fill(dds2);
            DataTable _table2 = dds2.Tables[0];
            int count2 = _table2.Rows.Count;
            dataGridView2zhanghaoshensu.DataSource = _table2;
            conn2.Close();
            //dataGridView1.DataBind();
        }

        private void button1duzhemi_Click(object sender, EventArgs e)
        {
            string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn454 = new SqlConnection(str454);
            conn454.Open();
            string selectsql454 = "Select * from login where username = '" + textBox1duzheming.Text + "'";
            SqlCommand cmd454 = new SqlCommand(selectsql454, conn454);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd454.CommandType = CommandType.Text;

            SqlDataReader sdr454;
            sdr454 = cmd454.ExecuteReader();
            if (sdr454.Read())
            {
                if (textBox1duzheming.Text != "")
                {
                    string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string selectsql = "update login set password = '" + textBox2duzhemi.Text + "'  where username = '" + textBox1duzheming.Text + "'";
                    SqlCommand cmd = new SqlCommand(selectsql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    //UpdataForm udform2 = new UpdataForm();
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    conn.Close();
                    MessageBox.Show("修改密码成功", "修改密码", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //刷新读者信息
                    string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn1 = new SqlConnection(str1);
                    conn1.Open();

                    SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from login order by username", conn1);
                    DataSet dds1 = new DataSet();
                    sqlDap.Fill(dds1);
                    DataTable _table1 = dds1.Tables[0];
                    int count1 = _table1.Rows.Count;
                    dataGridView1.DataSource = _table1;

                    //dataGridView1.DataBind();
                    conn1.Close();
                }
                else MessageBox.Show("请输入用户名！");
            }
            else MessageBox.Show("用户名不存在！");
            conn454.Close();
        }

        private void button2duzhexing_Click(object sender, EventArgs e)
        {
            string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn454 = new SqlConnection(str454);
            conn454.Open();
            string selectsql454 = "Select * from login where username = '" + textBox1duzheming.Text + "'";
            SqlCommand cmd454 = new SqlCommand(selectsql454, conn454);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd454.CommandType = CommandType.Text;

            SqlDataReader sdr454;
            sdr454 = cmd454.ExecuteReader();
            if (sdr454.Read())
            {   //开始修改
                if (textBox1duzheming.Text != "")
                {
                    string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string selectsql = "update login set sex = '" + textBox3duzhexing.Text + "'  where username = '" + textBox1duzheming.Text + "'";
                    SqlCommand cmd = new SqlCommand(selectsql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    //UpdataForm udform2 = new UpdataForm();
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    conn.Close();
                    MessageBox.Show("修改性别成功", "修改性别", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //刷新读者信息
                    string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn1 = new SqlConnection(str1);
                    conn1.Open();

                    SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from login order by username", conn1);
                    DataSet dds1 = new DataSet();
                    sqlDap.Fill(dds1);
                    DataTable _table1 = dds1.Tables[0];
                    int count1 = _table1.Rows.Count;
                    dataGridView1.DataSource = _table1;

                    //dataGridView1.DataBind();
                    conn1.Close();
                }
                else MessageBox.Show("请输入用户名！");
            }
            else MessageBox.Show("用户不存在！");
            conn454.Close();
        }

        private void button3duzhemnian_Click(object sender, EventArgs e)
        {
            //查找读者
            string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn454 = new SqlConnection(str454);
            conn454.Open();
            string selectsql454 = "Select * from login where username = '" + textBox1duzheming.Text + "'";
            SqlCommand cmd454 = new SqlCommand(selectsql454, conn454);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd454.CommandType = CommandType.Text;

            SqlDataReader sdr454;
            sdr454 = cmd454.ExecuteReader();
            if (sdr454.Read())
            {   //开始修改
                if (textBox1duzheming.Text != "")
                {
                    string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string selectsql = "update login set age = '" + textBox4duzhenian.Text + "'  where username = '" + textBox1duzheming.Text + "'";
                    SqlCommand cmd = new SqlCommand(selectsql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    //UpdataForm udform2 = new UpdataForm();
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    conn.Close();
                    MessageBox.Show("修改年龄成功", "修改年龄", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //刷新读者信息
                    string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn1 = new SqlConnection(str1);
                    conn1.Open();

                    SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from login order by username", conn1);
                    DataSet dds1 = new DataSet();
                    sqlDap.Fill(dds1);
                    DataTable _table1 = dds1.Tables[0];
                    int count1 = _table1.Rows.Count;
                    dataGridView1.DataSource = _table1;

                    //dataGridView1.DataBind();
                    conn1.Close();
                }
                else MessageBox.Show("请输入用户名！");
            }
            else MessageBox.Show("用户不存在！");
            conn454.Close();
        }

        private void button4duzheqq_Click(object sender, EventArgs e)
        {
            //查找读者
            string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn454 = new SqlConnection(str454);
            conn454.Open();
            string selectsql454 = "Select * from login where username = '" + textBox1duzheming.Text + "'";
            SqlCommand cmd454 = new SqlCommand(selectsql454, conn454);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
            cmd454.CommandType = CommandType.Text;

            SqlDataReader sdr454;
            sdr454 = cmd454.ExecuteReader();
            if (sdr454.Read())
            {   //开始修改
                if (textBox1duzheming.Text != "")
                {
                    string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string selectsql = "update login set qq = '" + textBox5duzheqq.Text + "'  where username = '" + textBox1duzheming.Text + "'";
                    SqlCommand cmd = new SqlCommand(selectsql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
            
                    conn.Close();
                    MessageBox.Show("修改QQ成功", "修改QQ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //刷新读者信息
                    string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn1 = new SqlConnection(str1);
                    conn1.Open();

                    SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from login order by username", conn1);
                    DataSet dds1 = new DataSet();
                    sqlDap.Fill(dds1);
                    DataTable _table1 = dds1.Tables[0];
                    int count1 = _table1.Rows.Count;
                    dataGridView1.DataSource = _table1;
                    conn1.Close();
                    //dataGridView1.DataBind();

                }
                else MessageBox.Show("请输入用户名！");
            }
            else MessageBox.Show("用户不存在！");
            conn454.Close();
        }

        private void button6shensutongyi_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView2zhanghaoshensu.SelectedRows.Count != 1) return;
            if (dataGridView2zhanghaoshensu.CurrentRow == null) return;
            // string bd = dataGridView2.CurrentRow.Cells[2].Value.ToString();

            DataRowView row = dataGridView2zhanghaoshensu.CurrentRow.DataBoundItem as DataRowView;
            if (row["id"] == null) return;//可以进行快速监视
            string bd = Convert.ToString(row["id"]);
            string selectsql = "update ss set flag = 1  where id= '" + bd + "'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            //SqlDataReader sdr;
            //sdr = cmd.ExecuteReader();
            int ret = cmd.ExecuteNonQuery();//受影响的行数（总数）
            if (ret == -1)
            {
                MessageBox.Show("操作失败！");
                return;
            }
            else
            {
                MessageBox.Show("操作成功！");
            }
            conn.Close();
            //重新加载信息
            string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn1 = new SqlConnection(str1);
            conn1.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from ss  order by id", conn1);
            DataSet dds1 = new DataSet();
            sqlDap.Fill(dds1);
            DataTable _table1 = dds1.Tables[0];
            int count1 = _table1.Rows.Count;
            dataGridView2zhanghaoshensu.DataSource = _table1;

            //dataGridView2.DataBind();
            conn1.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            label1.Left -= 2;         //字幕滚动的数度

            if (label1.Right < 1)
            {
                label1.Left = 735;     //滚动完的位置
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from js where id like'%" + textBox5.Text + "%' and username like '%" + textBox6.Text + "%' and time like '%" + textBox4.Text + "%' order by username", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
            dataGridView3.DataSource = _table;
            conn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from hs where id like'%" + textBox5.Text + "%' and username like '%" + textBox6.Text + "%' and time like '%" + textBox4.Text + "%' order by username", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
            dataGridView3.DataSource = _table;
            conn.Close();
        }

        private void timer2radiocheck_Tick(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox2id.Text = "all";
                textBox2id.Enabled = false;
                flag11 = 2;
                textBox1.Enabled = true;
            }
            if (radioButton1.Checked)
            {
                flag11 = 1;
                textBox1.Enabled = false;
                textBox2id.Enabled = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (flag11 == 1)//user
            {
                string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string usetime = DateTime.Now.ToString();
                string selectsql = "insert into usermessage values('" + textBox2id.Text + "','" + textBox1message.Text + "','" + usetime + "','" + adminnn + "','否')";
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                conn.Close();


                
                MessageBox.Show("发送给 " + textBox2id.Text + " 成功！");


                string str2 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn2 = new SqlConnection(str2);
                conn2.Open();
                SqlDataAdapter sqlDap2 = new SqlDataAdapter("Select * from usermessage order by username", conn2);
                DataSet dds2 = new DataSet();
                sqlDap2.Fill(dds2);
                DataTable _table2 = dds2.Tables[0];
                int count2 = _table2.Rows.Count;
                dataGridView2.DataSource = _table2;
                conn2.Close();

            }
            else                            //all
            {
                //查找id
                string str4543 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn4543 = new SqlConnection(str4543);
                conn4543.Open();
                string selectsql4543 = "Select * from allmessage where id = '" + textBox1.Text + "'";
                SqlCommand cmd4543 = new SqlCommand(selectsql4543, conn4543);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                cmd4543.CommandType = CommandType.Text;
                SqlDataReader sdr4543;
                sdr4543 = cmd4543.ExecuteReader();
                if (sdr4543.Read())
                {
                    MessageBox.Show("该消息id已存在！请更换消息id  ");
                }
                else
                {
                    string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string usetime = DateTime.Now.ToString();
                    string selectsql = "insert into allmessage values('" + textBox1.Text + "','" + usetime + "','" + textBox1message.Text + "','" + adminnn + "')";
                    SqlCommand cmd = new SqlCommand(selectsql, conn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader sdr;
                    sdr = cmd.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("发送成功！");

                    string str77 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn77 = new SqlConnection(str77);
                    conn77.Open();
                    string selectsql77 = "update allmessageflag set isread = '否'";
                    SqlCommand cmd77 = new SqlCommand(selectsql77, conn77);
                    cmd77.CommandType = CommandType.Text;
                    SqlDataReader sdr77;
                    sdr77 = cmd77.ExecuteReader();
                    conn77.Close();

                    string str26 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                    SqlConnection conn26 = new SqlConnection(str26);
                    conn26.Open();
                    SqlDataAdapter sqlDap26 = new SqlDataAdapter("Select * from allmessage order by id", conn26);
                    DataSet dds26 = new DataSet();
                    sqlDap26.Fill(dds26);
                    DataTable _table26 = dds26.Tables[0];
                    int count26 = _table26.Rows.Count;
                    dataGridView4.DataSource = _table26;
                    conn26.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = false;
            tushuguanli.Visible = false;
            jieyueguanli.Visible = false;
            xiaoxiguanli.Visible = true;
            liuyanguanli.Visible = false;
            duzheguanli.Visible = false;
            string str2 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn2 = new SqlConnection(str2);
            conn2.Open();
            SqlDataAdapter sqlDap2 = new SqlDataAdapter("Select * from usermessage order by username", conn2);
            DataSet dds2 = new DataSet();
            sqlDap2.Fill(dds2);
            DataTable _table2 = dds2.Tables[0];
            int count2 = _table2.Rows.Count;
            dataGridView2.DataSource = _table2;
            conn2.Close();
            string str26 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn26 = new SqlConnection(str26);
            conn26.Open();
            SqlDataAdapter sqlDap26 = new SqlDataAdapter("Select * from allmessage order by id", conn26);
            DataSet dds26 = new DataSet();
            sqlDap26.Fill(dds26);
            DataTable _table26 = dds26.Tables[0];
            int count26 = _table26.Rows.Count;
            dataGridView4.DataSource = _table26;
            conn26.Close();
        }



        private void button8_Click_1(object sender, EventArgs e)
        {
            string str = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView4.SelectedRows.Count != 1) return;
            if (dataGridView4.CurrentRow == null) return;
            // string bd = dataGridView4.CurrentRow.Cells[2].Value.ToString();

            DataRowView row = dataGridView4.CurrentRow.DataBoundItem as DataRowView;
            if (row["id"] == null) return;//可以进行快速监视
            string bd = Convert.ToString(row["id"]);
            string selectsql = "delete from allmessage where id = " + bd + "";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            //SqlDataReader sdr;
            //sdr = cmd.ExecuteReader();
            int ret = cmd.ExecuteNonQuery();//受影响的行数（总数）
            if (ret == -1)
            {
                MessageBox.Show("删除失败！");
                return;
            }
            else
            {
                MessageBox.Show("删除成功！");

                string str26 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn26 = new SqlConnection(str26);
                conn26.Open();
                SqlDataAdapter sqlDap26 = new SqlDataAdapter("Select * from allmessage order by id", conn26);
                DataSet dds26 = new DataSet();
                sqlDap26.Fill(dds26);
                DataTable _table26 = dds26.Tables[0];
                int count26 = _table26.Rows.Count;
                dataGridView4.DataSource = _table26;
                conn26.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = false;
            tushuguanli.Visible = false;
            jieyueguanli.Visible = true;
            xiaoxiguanli.Visible = false;
            liuyanguanli.Visible = false;
            duzheguanli.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tushuyilan.Visible = false;
            tushuguanli.Visible = true;
            jieyueguanli.Visible = false;
            xiaoxiguanli.Visible = false;
            liuyanguanli.Visible = false;
            duzheguanli.Visible = false;
        }

        

        private void button13_Click(object sender, EventArgs e)
        {
            string str454 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
            SqlConnection conn454 = new SqlConnection(str454);//实例化cnn对象
            conn454.Open();//打开
            string selectsql454 = "Select * from login where username = '" + textBox11.Text + "'";
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
                string selectsql = "insert into login values('" + textBox11.Text + "','" + textBox22.Text + "',0,'null',0)";
                SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                MessageBox.Show("添加用户成功!");
                conn.Close();

                string str1 = @"Data Source=DESKTOP-72DLVN4;Initial catalog=LoginTable;integrated Security=True";
                SqlConnection conn1 = new SqlConnection(str1);
                conn1.Open();

                SqlDataAdapter sqlDap = new SqlDataAdapter("Select * from login order by username", conn1);
                DataSet dds1 = new DataSet();
                sqlDap.Fill(dds1);
                DataTable _table1 = dds1.Tables[0];
                int count1 = _table1.Rows.Count;
                dataGridView1.DataSource = _table1;
                groupBox1.Visible = false;
                conn1.Close();
            }
            conn454.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }
    }
}
