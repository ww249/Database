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
    public partial class admin22 : Form
    {
        string ID="";
        public admin22()
        {
            InitializeComponent();
        }
        public admin22(string carid,string cartype,string carlic)
        {
            InitializeComponent();
            ID=label4.Text = carid;
            label5.Text = cartype;
            textBox3.Text = carlic;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_car_info set carlic='{textBox3.Text}' where carid='{ID}'";//carid不改
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void admin22_Load(object sender, EventArgs e)
        {

        }
    }
}
