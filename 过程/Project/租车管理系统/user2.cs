using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace 租车管理系统
{
    public partial class user2 : Form
    {
        string  cartype, rentdate, returndate, rentstore, returnstore;
        bool paydepo;
        public user2()
        {
            InitializeComponent();
        }
        public void Table()
        {
            button4.BringToFront();
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from ";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rentstore = comboBox2.Text.ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnstore=comboBox3.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cartype!= "" && rentdate != "" && returndate != "" && rentstore != "" && returnstore != ""&&paydepo==true)
            {
                Dao dao = new Dao();
                string sql = $"insert into t_car_res values('{Data.UID}','{cartype}','{rentdate}','{rentdate}','{rentstore}','{returnstore}',1)";//需要改
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("添加成功");
                    paydepo = false;
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                MessageBox.Show("输入不允许有空");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paydepo = true;
        }

        private void user11_Load(object sender, EventArgs e)
        {
            label8.Text = "若您无法在预定时间归还车辆，\r\n请及时续租，否则会有相应费用扣除";

            string[] str1 = new string[] { "比亚迪汉", "比亚迪秦", "比亚迪宋", "特斯拉MODEL3", "特斯拉MODELY", "长安1", "保时捷", "福特" };
            comboBox1.DataSource = str1;
            comboBox1.SelectedIndex = 0;
            string[] str2 = new string[] { "北京市海淀区学院路号", "北京市朝阳区西大望路号", "浙江省杭州市上城区金福桥路号", "浙江省萧山区机场路号" };
            comboBox2.DataSource = str2;
            comboBox2.SelectedIndex = 0;
            string[] str3 = new string[] { "北京市海淀区学院路号", "北京市朝阳区西大望路号", "浙江省杭州市上城区金福桥路号", "浙江省萧山区机场路号" };
            comboBox3.DataSource = str3;
            comboBox3.SelectedIndex = 0;
                //隐藏日历控件
            monthCalendar1.Hide();
            monthCalendar2.Hide();
            pictureBox1.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            monthCalendar2.Show();
            monthCalendar2.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            monthCalendar1.Show();
            monthCalendar1.BringToFront();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //将选择的日期显示在文本框中
            textBox1.Text = monthCalendar1.SelectionStart.ToShortDateString();
            //隐藏日历控件
            monthCalendar1.Hide();
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            //将选择的日期显示在文本框中
            textBox2.Text = monthCalendar2.SelectionStart.ToShortDateString();
            //隐藏日历控件
            monthCalendar2.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Show(); pictureBox1.BringToFront();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cartype=comboBox1.Text.ToString();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
