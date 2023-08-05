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
    public partial class user4 : Form
    {
        private bool store_exist;
        private string selectedcarid;
        private string rent_s;
        private string return_s;
        public user4()
        {
            InitializeComponent();
        }

        private string get_date(string d)
        {
            DateTime dt = Convert.ToDateTime(d);
            return string.Format("{0}-{1}-{2}", dt.Year, dt.Month, dt.Day);
        }

        private void res_t()
        {
            // 首先删除上次的预约记录
            string ID = Data.UID;
            Dao dao = new Dao();
            string sql = $"delete from\r\nt_car_res\r\nwhere uid = '{ID}';";
            int n = dao.Execute(sql);
            if (n > 0)
            {
                //MessageBox.Show("预约记录删除成功");
            }
            else
            {
                //MessageBox.Show("预约记录删除失败");
            }
            dao.DaoClose();

            user2 user22 = new user2(true);
            user22.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void user4_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            // 进行用户订单的查询
            // 查询结果显示在textbox上
            string ID = Data.UID;
            Dao dao = new Dao();
            string sql = $"select cartype,rentdate,returndate,rentstore,returnstore,paydepo from t_car_res where uid = '{ID}';";
            IDataReader dc = dao.read(sql);
            if (dc.Read())
            {
                label11.Text = dc[0].ToString();
                label12.Text = get_date(dc[1].ToString());
                label13.Text = get_date(dc[2].ToString());
                label14.Text = dc[3].ToString();
                rent_s = label14.Text;
                label15.Text = dc[4].ToString();
                return_s = label15.Text;
                if (dc[5].ToString() == "1") label16.Text = "800";// 押金默认800
                else label16.Text = "0";
                // 查询当前门店是否存在
                string sql1 = $"select store.if_exist from t_car_res res,t_store_info store where uid = '{ID}' and store.storeid = res.rentstore;";
                dc = dao.read(sql1);
                if (dc.Read())
                {
                    if (dc[0].ToString() == "0")
                    {
                        store_exist = false;
                        MessageBox.Show("当前门店不存在");
                        dc.Close();
                        dao.DaoClose();
                        res_t();// 重新进行预约
                    }
                    else// 当前门店存在
                    {
                        MessageBox.Show(label14.Text + "存在");
                        // 显示门店满足要求的车辆
                        string sql2 = $"select pla.carid,res.cartype,pla.carrent,res.rentstore,res.returnstore,car.carlic from t_car_res res,t_car_pla pla,t_car_info car where uid = '{ID}' and pla.carstoreid = res.rentstore and res.cartype = car.cartype and car.carid = pla.carid and pla.carrent != 1;";
                        dc = dao.read(sql2);
                        // 有满足要求的车辆 显示信息
                        dataGridView1.Rows.Clear();
                        while (dc.Read())
                        {
                            dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[5].ToString());
                        }
                        if (dataGridView1.Rows.Count == 0)
                        {
                            // 没有满足条件的车辆
                            // 查询当前门店所有的车辆，并显示
                            MessageBox.Show("当前门店没有满足你需求的车辆，请重新挑选车辆并进行提车");
                            string sql3 = $"select\r\ncar.carid,car.cartype,car.carlic\r\nfrom\r\nt_car_pla pla,t_car_info car,t_car_res res\r\nwhere pla.carstoreid = res.rentstore and pla.carid = car.carid and pla.carrent != 1 and res.uid = '{ID}';\r\n";
                            dc = dao.read(sql3);
                            dataGridView1.Rows.Clear();
                            while (dc.Read())
                            {
                                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
                            }
                            if(dataGridView1.Rows.Count == 0)
                            {
                                MessageBox.Show("当前门店没有车辆，请预约其他门店车辆，完成租车操作");
                                dc.Close();
                                dao.DaoClose();
                                res_t();// 重新进行预约
                            }
                        }
                        else
                        {
                            // 有该车辆，点击进行预约
                            MessageBox.Show("请点击车辆提车");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("门店查询失败");
                }
                dc.Close();
                dao.DaoClose();
            }
            else
            {
                MessageBox.Show("您当前没有订单");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 选中车辆进行提车
            string ID = Data.UID;
            Dao dao = new Dao();
            string sql = $"insert into t_car_rent(uid,carid,rentdate,rentstore,returnstore) values('{ID}','{selectedcarid}','{DateTime.Now}','{rent_s}','{return_s}');";
            int n = dao.Execute(sql);
            if (n > 0)
            {
                MessageBox.Show("取车成功");
            }
            else
            {
                MessageBox.Show("取车失败");
            }
            dao.DaoClose();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            selectedcarid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //MessageBox.Show(selectedcarid);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
