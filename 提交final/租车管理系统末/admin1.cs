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
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
        }

        private void admin1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 车辆租赁管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin2 admin= new admin2();
            admin.ShowDialog();
        }

        private void 门店管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin3 admin = new admin3();
            admin.ShowDialog();
        }

        private void 订单查询ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            admin4订单查询 admin = new admin4订单查询();
            admin.ShowDialog();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 门店的车辆信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin5 admin = new admin5();
            admin.ShowDialog();
        }
    }
}
