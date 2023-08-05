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
    public partial class admin31 : Form
    {
        public admin31()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label4.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Dao dao = new Dao();
                string sql = $"insert into t_store_info values('{label4.Text}','{textBox2.Text}','{textBox3.Text}','1');";
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("添加成功");
                    this.Close();
                    label4.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
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
            this.Close();
        }

        private void admin31_Load(object sender, EventArgs e)
        {
            // 生成默认的ID
            string num = "";
            Dao da = new Dao();
            string sql = $"select COUNT(*) from t_store_info;";
            IDataReader dc = da.read(sql);
            if (dc.Read())
            {
                num = (int.Parse(dc[0].ToString()) + 1).ToString();
            }
            dc.Close();
            da.DaoClose();
            string ID = "S" + num.PadLeft(5, '0');
            label4.Text = ID;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
