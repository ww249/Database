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

namespace 租车管理系统
{
    public partial class admin4订单查询 : Form
    {
        private string get(string t)
        {
            string ans="";
            for (int i= 0; i < t.Length - 8; i++){
                ans += t[i];
            }
            return ans;
        }
        public admin4订单查询()
        {
            InitializeComponent();
        }
        public void Table()
        {
            monthCalendar1.Hide();
            monthCalendar2.Hide();
            //string[] str1 = new string[] { "", "比亚迪汉", "比亚迪秦", "比亚迪宋", "特斯拉MODEL3", "特斯拉MODELY", "长安1", "保时捷", "福特" };
            //comboBox3.DataSource = str1;
            //comboBox3.SelectedIndex = 0;
            //string[] str2 = new string[] { "", "天下租车", "神州租车", "哈哈租车", "完美租车" };
            //comboBox1.DataSource = str2;
            //comboBox1.SelectedIndex = 0;
            //string[] str3 = new string[] { "", "天下租车", "神州租车", "哈哈租车", "完美租车" };
            //comboBox2.DataSource = str3;
            //comboBox2.SelectedIndex = 0;



            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select uor.uid,t_user.uname,uor.rentdate,uor.returndate,st1.storename,st2.storename,t_car_info.cartype,uor.payment from t_user_order uor,t_user,t_store_info st1,t_store_info st2,t_car_info where t_user.uid=uor.uid and st1.storeid=uor.rentstore and st2.storeid=uor.returnstore and t_car_info.carid=uor.carid ";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), get(dc[2].ToString()),get(dc[3].ToString()), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select uor.uid,t_user.uname,uor.rentdate,uor.returndate,st1.storename,st2.storename,t_car_info.cartype,uor.payment from t_user_order uor,t_user,t_store_info st1,t_store_info st2,t_car_info where t_user.uid=uor.uid and st1.storeid=uor.rentstore and st2.storeid=uor.returnstore and t_car_info.carid=uor.carid ";
            if (textBox1.Text != "")
            {
                sql=sql+ "and uor.uid=" + textBox1.Text;
            }
            if(textBox2.Text != "")
            {
                sql = sql + " and t_user.name like '%" + textBox2.Text + "%'";
            }
            if (textBox3.Text != "")
            {
                sql = sql + " and uor.rentdate='" + Convert.ToDateTime(textBox3.Text) + "'";
            }
            if (textBox4.Text != "")
            {
                sql = sql + " and uor.returndate='" + Convert.ToDateTime(textBox4.Text) + "'";
            }
            if (comboBox1.Text != "")
            {
                sql = sql + " and st1.storename like '%" + comboBox1.Text + "%'";
            }
            if (comboBox2.Text != "")
            {
                sql = sql + " and st2.storename like '%" + comboBox2.Text + "%'";
            }
            if (comboBox3.Text != "")
            {
                sql = sql + " and t_car_info.cartype like '%" + comboBox3.Text + "%'";
            }
            try
            {
                IDataReader dc = dao.read(sql);
                bool flag = true;
                while (dc.Read())
                {
                    flag= false;
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString());
                }
                if(flag)
                {
                    MessageBox.Show("无满足条件的记录");
                }
                dc.Close();
                dao.DaoClose();
            }
            catch
            {
                MessageBox.Show(sql);
            }
        }

       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void admin4订单查询_Load_1(object sender, EventArgs e)
        {
            //// TODO: 这行代码将数据加载到表“car_rentDataSet.t_type_info”中。您可以根据需要移动或移除它。
            //this.t_type_infoTableAdapter.Fill(this.car_rentDataSet.t_type_info);
            //// TODO: 这行代码将数据加载到表“car_rentDataSet1.t_store_info”中。您可以根据需要移动或移除它。
            //this.t_store_infoTableAdapter1.Fill(this.car_rentDataSet1.t_store_info);
            //// TODO: 这行代码将数据加载到表“car_rentDataSet.t_store_info”中。您可以根据需要移动或移除它。
            //this.t_store_infoTableAdapter.Fill(this.car_rentDataSet.t_store_info);
            try
            {
                this.t_store_infoTableAdapter.Fill(this.car_rentDataSet.t_store_info);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            comboBox1.DataSource = this.car_rentDataSet.t_store_info;
            this.comboBox1.SelectedIndex = -1;

            try
            {
                this.t_store_infoTableAdapter1.Fill(this.car_rentDataSet1.t_store_info);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            comboBox2.DataSource = this.car_rentDataSet1.t_store_info;
            this.comboBox2.SelectedIndex = -1;
            try
            {
                this.t_type_infoTableAdapter.Fill(this.car_rentDataSet.t_type_info);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            comboBox3.DataSource = this.car_rentDataSet.t_type_info;
            this.comboBox3.SelectedIndex = -1;
            Table();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            monthCalendar1.Show();
            monthCalendar1.BringToFront();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            monthCalendar2.Show();
            monthCalendar2.BringToFront();
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            
            
        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox4.Text = monthCalendar2.SelectionStart.ToShortDateString();
            //隐藏日历控件
            monthCalendar2.Hide();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox3.Text = monthCalendar1.SelectionStart.ToShortDateString();
            //隐藏日历控件
            monthCalendar1.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
