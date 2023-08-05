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
    public partial class admin3 : Form
    {
        public admin3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void admin3_Load(object sender, EventArgs e)
        {
            Table();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao= new Dao();
            string sql = $"select *from t_store_info";
            IDataReader dc=dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin31 admin = new admin31();
            admin.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string storeid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string storename = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string storepla = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                admin32 admin32 = new admin32(storeid,storename,storepla);
                admin32.ShowDialog();
                Table();//刷新数据
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string sq = $"select carid from t_car_rent,t_store_info where returnstore= '{id}' and t_store_info.if_exist=1 and returnstore=t_store_info.storeid;";
            Dao da = new Dao();
            IDataReader dc = da.read(sq);
            if (dc.Read())
            {
                //说明有车在门店
                MessageBox.Show("该门店有车需要还，无法删除");
            }
            else
            {
                try
                {

                    label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        string sql = $"delete from t_store_info where storeid='{id}'";//sql语句出错啦,可能是外键
                        Dao dao = new Dao();
                        if (dao.Execute(sql) > 0)
                        {
                            MessageBox.Show("删除成功");
                            Table();
                        }
                        else
                        {
                            MessageBox.Show("删除失败" + sql);
                        }
                        dao.DaoClose();
                    }
                }
                catch
                {
                    MessageBox.Show("请先在表格选中要删除的图书记录！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            da.DaoClose();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
        //根据门店地址显示数据，模糊查询
       /* private void Table_storepla()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from t_store_info where storepla like '%{textBox3.Text}%'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
       */


        private void button4_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string sql = "select * from t_store_info where 1=1 ";
            if (textBox1.Text != "")
            {
                sql = sql + " and storeid=" + textBox1.Text;
            }
            if (textBox2.Text != "")
            {
                sql = sql + " and storename like '%" + textBox2.Text + "%'";
            }
            if (textBox3.Text != "")
            {
                sql = sql + " and storepla like '%" + textBox3.Text + "%'";
            }
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            IDataReader dc = dao.read(sql);
            bool flag = true;
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
                flag = false;
            }
            if (flag) MessageBox.Show("无满足条件的门店，请更改条件");
            dc.Close();
            dao.DaoClose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
