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
        string  cartype, rentdate, returndate, rentstore, returnstore,carid;
        bool paydepo;
        public user2()
        {
            InitializeComponent();
        }

        public user2(bool pay)
        {
            InitializeComponent();
            paydepo = pay;
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select car.carid,car.cartype,car.carlic,store.storepla from t_car_info car,t_car_pla pla,t_store_info store where car.carid = pla.carid and store.storeid = pla.carstoreid and pla.carrent = 0;";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
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
                string sql = $"exec res @id = '{Data.UID}',@type = '{cartype}',@rent_d = '{Convert.ToDateTime(dateTimePicker2.Text)}',@return_d = '{Convert.ToDateTime(dateTimePicker1.Text)}',@rent_s = '{rentstore}',@return_s = '{returnstore}';";//需要改
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
                dao.DaoClose();
                dateTimePicker1.Text = "";
                dateTimePicker2.Text = "";
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
            Table();


            string[] str1 = new string[] { "比亚迪汉", "比亚迪秦", "比亚迪宋", "特斯拉MODEL3", "特斯拉MODELY", "长安1", "保时捷", "福特" };
            comboBox1.DataSource = str1;
            comboBox1.SelectedIndex = 0;
            string[] str2 = new string[] { "北京市海淀区学院路号", "北京市朝阳区西大望路号", "浙江省杭州市上城区金福桥路号", "浙江省萧山区机场路号" };
            comboBox2.DataSource = str2;
            comboBox2.SelectedIndex = 0;
            string[] str3 = new string[] { "北京市海淀区学院路号", "北京市朝阳区西大望路号", "浙江省杭州市上城区金福桥路号", "浙江省萧山区机场路号" };
            comboBox3.DataSource = str3;
            comboBox3.SelectedIndex = 0;
            pictureBox1.Hide();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            cartype= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

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
