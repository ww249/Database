﻿using System;
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
        public admin4订单查询()
        {
            InitializeComponent();
        }
        public void Table()
        {
            string[] str1 = new string[] { "", "比亚迪汉", "比亚迪秦", "比亚迪宋", "特斯拉MODEL3", "特斯拉MODELY", "长安1", "保时捷", "福特" };
            comboBox3.DataSource = str1;
            comboBox3.SelectedIndex = 0;
            string[] str2 = new string[] { "", "天下租车", "神州租车", "哈哈租车", "完美租车" };
            comboBox1.DataSource = str2;
            comboBox1.SelectedIndex = 0;
            string[] str3 = new string[] { "", "天下租车", "神州租车", "哈哈租车", "完美租车" };
            comboBox2.DataSource = str3;
            comboBox2.SelectedIndex = 0;

            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = $"select uor.uid,t_user.uname,uor.rentdate,uor.returndate,st1.storename,st2.storename,t_car_info.cartype,uor.payment from t_user_order uor,t_user,t_store_info st1,t_store_info st2,t_car_info where t_user.uid=uor.uid and st1.storeid=uor.rentstore and st2.storeid=uor.returnstore and t_car_info.carid=uor.carid ";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(),dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString());
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
                sql = sql + "and t_user.name like '%" + textBox2.Text + "%'";
            }
            if (dateTimePicker1.Text != "")
            {
                sql = sql + "and uor.rentdate=" + dateTimePicker1.Text;
            }
            if (dateTimePicker2.Text != "")
            {
                sql = sql + "and uor.returndate=" + dateTimePicker2.Text;
            }
            if (comboBox1.Text != "")
            {
                sql = sql + "and st1.storename like '%" + comboBox1.Text + "%'";
            }
            if (comboBox2.Text != "")
            {
                sql = sql + "and st2.storename like '%" + comboBox2.Text + "%'";
            }
            if (comboBox3.Text != "")
            {
                sql = sql + "and t_car_info.cartype like '%" + comboBox3.Text + "%'";
            }
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString(), dc[6].ToString(), dc[7].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void admin4订单查询_Load(object sender, EventArgs e)
        {
            Table();
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
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
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
    }
}
