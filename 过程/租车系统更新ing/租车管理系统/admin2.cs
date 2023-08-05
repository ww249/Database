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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
        }
        private void admin2_Load(object sender, EventArgs e)
        {
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
            Table();
        }
        //从数据库读取数据显示在表格控件中
        public void Table()
        {
            //string[] str1 = new string[] { "比亚迪汉", "比亚迪秦", "比亚迪宋", "特斯拉MODEL3", "特斯拉MODELY", "长安1", "保时捷", "福特" };
            //comboBox1.DataSource = str1;
            //comboBox1.SelectedIndex = 0;
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from t_car_info";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin21 admin = new admin21();
            admin.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string sq = $"select * from t_car_pla where carid='{id}' and carrent=0;";
            Dao da = new Dao();
            IDataReader dc = da.read(sq);
            if (dc.Read())
            {
                MessageBox.Show("该车在门店（t_car_pla=0）,执行删除");
                try
                {

                    label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        string sql = $"delete from t_car_info where carid='{id}';update t_type_info set type_num=type_num-1 from t_car_info,t_type_info  where type_num>0 and t_car_info.carid='{id}' and t_car_info.cartype=t_type_info.cartype;";//sql语句出错啦
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
                    MessageBox.Show("请先在表格选中要删除的车辆记录！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("该车不在门店（t_car_pla=1）,不执行删除" + sq);
            }
            da.DaoClose();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string sq = $"select carid from t_car_pla where carid='{id}' and carrent=0;";
            Dao da = new Dao();


            IDataReader dc = da.read(sq);
            if (dc.Read())
            {
                try
                {
                    string carid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    string cartype = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string carlic = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    admin22 admin22 = new admin22(carid, cartype, carlic);
                    admin22.ShowDialog();
                    Table();//刷新数据
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
            }
            else
            {
                MessageBox.Show("该车不在门店（t_car_pla=1）,不执行删除" + sq);
            }
            da.DaoClose();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "select * from t_car_info where 1=1 ";
            if (textBox1.Text != "")
            {
                sql = sql + "and carid=" + textBox1.Text;
            }
            if (comboBox1.Text != "")
            {
                sql = sql + "and cartype like '%"+comboBox1.Text+"%'";
            }
            if (textBox3.Text != "")
            {
                sql = sql + "and carlic like '%" + textBox3.Text + "%'";
            }
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            IDataReader dc = dao.read(sql);
            bool flag = true;
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
                flag= false;
            }
            if (flag) MessageBox.Show("无满足条件的车辆，请更改条件");
            dc.Close();
            dao.DaoClose();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Table();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
