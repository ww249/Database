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
    public partial class user1 : Form
    {
        string ID;
        public user1()
        {
            InitializeComponent();
        }
        public user1(string id)
        {
            InitializeComponent();
            ID = id;
        }
        private void user1_Load(object sender, EventArgs e)
        {

        }

        private void 预约车辆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user2 user = new user2();
            user.ShowDialog();
        }

        private void 归还车辆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user3 user = new user3();
            user.ShowDialog();
        }

        private void 续约车辆ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 查询订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin4订单查询 admin = new admin4订单查询();
            admin.ShowDialog();
        }
    }
}
