using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 租车管理系统
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        private string get(string t)
        {
            string ans = "";
            for (int i = 0; i < t.Length - 8; i++)
            {
                ans += t[i];
            }
            return ans;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" )
            {
                if(textBox2.Text == textBox3.Text)
                {
                    string sql = $"insert into t_user(uid,uname,udate,upsw) values('{label4.Text}','{textBox1.Text}','{DateTime.Now}','{textBox2.Text}');";//carid不改
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("注册成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("该用户编号已存在，注册失败，请您修改您的用户编号");
                    }
                }
                else
                {
                    MessageBox.Show("确认密码与输入密码不一致，请重新输入");
                }
            }
            else
            {
                MessageBox.Show("输入不能有空");
            }
        }

        private void register_Load(object sender, EventArgs e)
        {

            label6.Text = get(DateTime.Now.ToString());
            // 生成默认的ID
            string num = "";
            Dao da = new Dao();
            string sql = $"select COUNT(*) from t_user;";
            IDataReader dc = da.read(sql);
            if (dc.Read())
            {
                num = (int.Parse(dc[0].ToString()) + 1).ToString();
            }
            dc.Close();
            da.DaoClose();
            string time = DateTime.Now.ToString("yyyyMM");
            string ID = "U" + time + num.PadLeft(3, '0');
            label4.Text = ID;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
