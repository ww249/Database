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
        private string ID;
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

        // 有用
        private void 归还车辆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //当现在没有租车 
            //不能进入界面
            ID = Data.UID;
            Dao da = new Dao();
            string sql = $"select * from t_car_rent\r\nwhere uid = '{ID}';";
            IDataReader dc = da.read(sql);
            if (dc.Read())
            {
                dc.Close();
                da.DaoClose();
                user3 user = new user3();
                user.ShowDialog();
            }
            else
            {
                dc.Close();
                da.DaoClose();
                MessageBox.Show("当前没有租车，不能进行还车");
            }
        }

        // 没用
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

        private void 到店取车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 如果当前正在租车
            // 直接显示不能进入当前界面
            ID = Data.UID;
            Dao da = new Dao();
            string sql = $"select * from t_car_rent\r\nwhere uid = '{ID}';";
            IDataReader dc = da.read(sql);
            if (dc.Read())
            {
                dc.Close();
                da.DaoClose();
                MessageBox.Show("当前正在租车，不能进行取车");
            }
            else
            {
                dc.Close();
                da.DaoClose();
                user4 user = new user4();
                user.ShowDialog();
            }
        }
    }
}
