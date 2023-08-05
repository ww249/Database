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
    public partial class user3 : Form
    {
        private bool over_due;
        private bool is_rentintg;// 判断是否正在租车
        private DateTime rent_d;// 租车时间
        private DateTime return_d;// 预计还车时间
        private Double payment;
        private string ID;

        public user3()
        {
            InitializeComponent();
        }

        private int get_day_gap(DateTime d1,DateTime d2)
        {
            DateTime d3 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d1.Year, d1.Month, d1.Day));
            DateTime d4 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d2.Year, d2.Month, d2.Day));
            int days = (d4 - d3).Days;
            return days;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 进行订单查询
            // 判断是否逾期
            // 距离还车时间
            // 进行订单的查询
            ID = Data.UID;
            Dao da = new Dao();
            string sql = $"select rent.carid,car.cartype,rent.rentdate,res.returndate,s1.storepla,s2.storepla from t_car_res res,t_car_rent rent,t_store_info s1,t_store_info s2,t_car_info car where rent.uid = '{ID}' and rent.uid = res.uid and car.carid = rent.carid and s1.storeid = rent.rentstore and s2.storeid = res.returnstore and rent.carid = car.carid;";
            IDataReader dc = da.read(sql);
            if (dc.Read())
            {
                MessageBox.Show("查询成功");
                is_rentintg = true;
                string return_d_str = dc[3].ToString();
                return_d = Convert.ToDateTime(return_d_str);
                string rent_d_str = dc[2].ToString();
                rent_d = Convert.ToDateTime(rent_d_str);
                // 显示是否逾期
                // 显示离还车还有多久
                 if(return_d > DateTime.Now)
                {
                    over_due = false;
                    int gap = get_day_gap(DateTime.Now,return_d);
                    MessageBox.Show("距离您还车还有"+ gap.ToString() + "天");
                }
                else
                {
                    over_due = true;
                    MessageBox.Show("您已经逾期，请尽快还车，同时系统进制您进行续租");
                }
            }
            else
            {
                is_rentintg = false;
                MessageBox.Show("当前用户没有租车记录");
            }
            dc.Close();
            da.DaoClose();
        }

        private void user3_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            string sql = $"exec xu_yue @id = '{ID}',@t_date = '{Convert.ToDateTime(dateTimePicker2.Text)}';";
            int n = dao.Execute(sql);
            if (n > 0)
            {
                MessageBox.Show("续租成功");
            }
            else
            {
                MessageBox.Show("续租失败");
            }
            dateTimePicker2.Text = "";
            dao.DaoClose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请选择续租日期");
        }

        //还车按钮   点击显示需要支付金额
        private void button6_Click(object sender, EventArgs e)
        {
            int day_gap;
            Dao da = new Dao();
            string sql = $"select res.uid,rent.rentdate,res.returndate,car.cartype,type.rentprice from t_car_res res,t_car_rent rent,t_car_info car,t_type_info type where car.carid = rent.carid and res.uid = rent.uid and car.cartype = type.cartype and rent.uid = '{ID}';";
            IDataReader dc = da.read(sql);
            if (dc.Read())
            {
                string rent_pri = dc[4].ToString();
                Double pri = Convert.ToDouble(rent_pri);
                day_gap = get_day_gap(rent_d,DateTime.Now);
                payment = pri * day_gap;
                MessageBox.Show("您使用了" + day_gap.ToString() + "，需要支付" + payment.ToString() + "车辆" + pri.ToString() + "一天");
            }
            else
            {
                MessageBox.Show("当前没有该用户记录，无法还车");
            }
            da.DaoClose();
        }
        // 还车操作  使用存储过程
        private void button2_Click(object sender, EventArgs e)
        {
            // 存储过程还车
            Dao dao = new Dao();
            int over;
            if (over_due) over = 1;
            else over = 0;
            string sql = $"exec return_car @id = '{ID}',@r_date = '{DateTime.Now}',@payment = {payment},@over = {over};";
            int n = dao.Execute(sql);
            if (n > 0)
            {
                MessageBox.Show("还车成功");
            }
            else
            {
                MessageBox.Show("还车失败");
            }
            dao.DaoClose();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你已经缴费，请进行车辆归还");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
