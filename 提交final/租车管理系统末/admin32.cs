using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace 租车管理系统
{
    public partial class admin32 : Form
    {
        string ID = "";
        public admin32(string storeid, string storename, string storepla)
        {
            InitializeComponent();
            ID = label4.Text = storeid;
            textBox2.Text = storename;
            textBox3.Text = storepla;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_store_info set storename='{textBox2.Text}',storepla='{textBox3.Text}' where storeid='{ID}'";//carid不改
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

        private void admin32_Load(object sender, EventArgs e)
        {

        }
    }
}
