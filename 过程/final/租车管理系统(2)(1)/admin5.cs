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
    public partial class admin5 : Form
    {
        public admin5()
        {
            InitializeComponent();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select t_car_pla.carstoreid,t_store_info.storename,t_store_info.storepla,t_car_pla.carid,t_car_info.cartype,t_car_info.carlic,t_car_pla.carrent from t_car_pla,t_store_info,t_car_info where t_car_pla.carid=t_car_info.carid and t_car_pla.carstoreid=t_store_info.storeid";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void admin5_Load(object sender, EventArgs e)
        {

            string[] str2 = new string[] { "","天下租车", "神州租车", "哈哈租车", "完美租车" };
            comboBox2.DataSource = str2;
            comboBox2.SelectedIndex = 0;
            string[] str3 = new string[] {"", "北京市海淀区学院路号", "北京市朝阳区西大望路号", "浙江省杭州市上城区金福桥路号", "浙江省萧山区机场路号" };
            comboBox3.DataSource = str3;
            comboBox3.SelectedIndex = 0;
            Table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "select t_car_pla.carstoreid,t_store_info.storename,t_store_info.storepla,t_car_pla.carid,t_car_info.cartype,t_car_info.carlic,t_car_pla.carrent from t_car_pla,t_store_info,t_car_info where t_car_pla.carid=t_car_info.carid and t_car_pla.carstoreid=t_store_info.storeid";
            if (textBox1.Text != "")
            {
                sql = sql + " and t_car_pla.carstoreid=" + textBox1.Text;
            }
            if (comboBox2.Text != "")
            {
                sql = sql + " and t_store_info.storename like '%" + comboBox2.Text.ToString() + "%'";
            }
            if (comboBox3.Text != "")
            {
                sql = sql + " and t_store_info.storepla like '%" + comboBox3.Text.ToString() + "%'";
            }
            //MessageBox.Show(sql);
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            IDataReader dc = dao.read(sql);
            bool flag = true;
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString());
                flag = false;
            }
            if (flag) MessageBox.Show("无满足条件的门店，请更改条件");
            dc.Close();
            dao.DaoClose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
