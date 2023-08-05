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
            string sql = $"select car.carid,car.cartype,car.carlic,store.storepla from t_car_info car,t_car_pla pla,t_store_info store where car.carid = pla.carid and store.storeid = pla.carstoreid and pla.carrent = 0 ";
            if (comboBox1.Text != "")
            {
                sql = sql + " and car.cartype='" + comboBox1.Text.ToString() + "'";
            }
            if (comboBox2.Text != "")
            {
                sql = sql + " and store.storepla='" + comboBox2.Text.ToString() + "'";
            }
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();

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
            Table();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            returnstore=comboBox3.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cartype!= "" && rentdate != "" && returndate != "" && rentstore != "" && returnstore != ""&&paydepo==true)
            {
                try
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
                }
                catch
                {

                }
                this.Close();
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
            //// TODO: 这行代码将数据加载到表“car_rentDataSet1.t_store_info”中。您可以根据需要移动或移除它。
            //this.t_store_infoTableAdapter1.Fill(this.car_rentDataSet1.t_store_info);
            //// TODO: 这行代码将数据加载到表“car_rentDataSet.t_store_info”中。您可以根据需要移动或移除它。
            //this.t_store_infoTableAdapter.Fill(this.car_rentDataSet.t_store_info);
            //// TODO: 这行代码将数据加载到表“car_rentDataSet.t_type_info”中。您可以根据需要移动或移除它。
            //this.t_type_infoTableAdapter.Fill(this.car_rentDataSet.t_type_info);

            try
            {
                this.t_type_infoTableAdapter.Fill(this.car_rentDataSet.t_type_info);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            comboBox1.DataSource = this.car_rentDataSet.t_type_info;
            this.comboBox1.SelectedIndex = -1;
            try
            {
                this.t_store_infoTableAdapter.Fill(this.car_rentDataSet.t_store_info);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            comboBox2.DataSource = this.car_rentDataSet.t_store_info;
            this.comboBox2.SelectedIndex = -1;


            // 当第一个门店地点变化时，第二个会跟着变化
            // 分开创建数据源就行、
            // 同时要注意adapter以及dataset名称的变化
            try
            {
                this.t_store_infoTableAdapter1.Fill(this.car_rentDataSet1.t_store_info);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            comboBox3.DataSource = this.car_rentDataSet1.t_store_info;
            this.comboBox3.SelectedIndex = -1;
            Table();
            //Table();


            //string[] str1 = new string[] { "比亚迪汉", "比亚迪秦", "比亚迪宋", "特斯拉MODEL3", "特斯拉MODELY", "长安1", "保时捷", "福特" };
            //comboBox1.DataSource = str1;
            //comboBox1.SelectedIndex = 0;
            //string[] str2 = new string[] { "北京市海淀区学院路号", "北京市朝阳区西大望路号", "浙江省杭州市上城区金福桥路号", "浙江省萧山区机场路号" };
            //comboBox2.DataSource = str2;
            //comboBox2.SelectedIndex = 0;
            //string[] str3 = new string[] { "北京市海淀区学院路号", "北京市朝阳区西大望路号", "浙江省杭州市上城区金福桥路号", "浙江省萧山区机场路号" };
            //comboBox3.DataSource = str3;
            //comboBox3.SelectedIndex = 0;

            // 已将缴纳押金的话 不显示缴纳押金界面
            if (paydepo)
            {
                button5.Hide();
                button2.Hide();
            }
            pictureBox1.Hide();
            label6.Hide();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Show(); pictureBox1.BringToFront();
            label6.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = -1;
            this.comboBox2.SelectedIndex = -1;
            this.comboBox3.SelectedIndex = -1;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            cartype= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.comboBox1.Text =  cartype;
            this.comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
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
            Table();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
