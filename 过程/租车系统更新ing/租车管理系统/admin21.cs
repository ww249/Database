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
    public partial class admin21 : Form
    {
        public admin21()
        {
            InitializeComponent();
            label4.Hide();
            textBox4.Hide();
            button3.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void admin21_Load(object sender, EventArgs e)
        {
            string num = "";
            Dao da = new Dao();
            string sql = $"select COUNT(*) from t_car_info;";
            IDataReader dc = da.read(sql);
            if (dc.Read())
            {
                num = (int.Parse(dc[0].ToString()) + 1).ToString();
            }
            dc.Close();
            da.DaoClose();
            string ID = "C" + num.PadLeft(5, '0');
            label5.Text = ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(label5.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Dao dao= new Dao();
                //string sql = $"insert into t_car_info values('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}');";

                    //MessageBox.Show("添加成功");
                    string sql= $"select * from t_type_info where cartype='{textBox2.Text}';";

                IDataReader dc = dao.read(sql);
                if (dc.Read())//说明有该车型，则直接插入
                {
                    sql = $"insert into t_car_info values('{label5.Text}','{textBox2.Text}','{textBox3.Text}');update t_type_info set type_num=type_num+1 where t_type_info.cartype='{textBox2.Text}';";
                    dao.Execute(sql);
                    
                    MessageBox.Show("添加车型成功");
                }
                 else//无该车型，则先插入车型，置其数量为1
                    {
                        sql = $"insert into t_car_info values('{label5.Text}','{textBox2.Text}','{textBox3.Text}');";
                    dao.Execute(sql);
                        MessageBox.Show("该车型为新车型，请设置价格");
                        label4.Show();
                        textBox4.Show();
                        button3.Show();

                }
                dao.DaoClose();


            }

            else
            {
                MessageBox.Show("输入不允许有空");
            }
            /*             else
                 {
                     MessageBox.Show("添加失败");
                 }
                 textBox1.Text = "";
                 textBox2.Text = "";
                 textBox3.Text = "";*/


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql = $"insert into t_type_info values('{textBox2.Text}',{textBox4.Text},1);";
            try
            {
                int t = dao.Execute(sql);
                if (t > 0)
                {
                    MessageBox.Show("新车型设置成功");
                }
            }
            catch
            {
                MessageBox.Show("新车型设置异常");
            }
            label4.Hide();
            textBox4.Hide();
            button3.Hide();
            dao.DaoClose();
        }
    }
}
