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
        private string get_date(string d)
        {
            DateTime dt = Convert.ToDateTime(d);
            return string.Format("{0}-{1}-{2}", dt.Year, dt.Month, dt.Day);
        }
        private int get_day_gap(DateTime d1,DateTime d2)
        {
            DateTime d3 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d1.Year, d1.Month, d1.Day));
            DateTime d4 = Convert.ToDateTime(string.Format("{0}-{1}-{2}", d2.Year, d2.Month, d2.Day));
            int days = (d4 - d3).Days;
            days++;
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
            string sql = $"select rent.carid,car.cartype,rent.rentdate,res.returndate,s1.storepla,s2.storepla,uer.uname\r\nfrom t_car_res res,t_car_rent rent,t_store_info s1,t_store_info s2,t_car_info car, t_user uer\r\nwhere rent.uid = '{ID}' and rent.uid = res.uid and car.carid = rent.carid and s1.storeid = rent.rentstore and s2.storeid = res.returnstore and rent.carid = car.carid and uer.uid = rent.uid;";
            IDataReader dc = da.read(sql);
            if (dc.Read())
            {
                MessageBox.Show("查询成功");
                label3.Text = ID;
                label4.Text = dc[6].ToString();// 会员姓名
                label5.Text = dc[1].ToString();// 车型
                label6.Text = dc[0].ToString();// 车辆编号
                label7.Text = get_date(dc[2].ToString());// 租车日期
                label8.Text = get_date(dc[3].ToString());// 换车日期
                label9.Text = dc[4].ToString();// 提车门店
                label10.Text = dc[5].ToString();// 还车门店
                is_rentintg = true;
                string return_d_str = dc[3].ToString();
                return_d = Convert.ToDateTime(return_d_str);
                string rent_d_str = dc[2].ToString();
                rent_d = Convert.ToDateTime(rent_d_str);
                DateTime now = Convert.ToDateTime(string.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
                // 显示是否逾期
                // 显示离还车还有多久
                 if (return_d >= now)
                {
                    over_due = false;
                    int gap = get_day_gap(DateTime.Now,return_d);
                    MessageBox.Show("距离您还车还有"+ gap.ToString() + "天");
                    //续约界面
                    
                    button4.Show();
                    // 修改
                    button6.Show();

                    // 123
                    //label2.Show();
                    //dateTimePicker2.Show();
                }
                else
                {
                    over_due = true;
                    MessageBox.Show("您已经逾期，请尽快还车，同时系统禁止您进行续租");
                    //还车界面
                    
                    button6.Show();
                }


                // 修改
                //sql = $"select t_user.uid,uname,t_car_info.cartype,t_car_info.carlic,rentdate,returndate,s1.storename,s2.storename from t_store_info s1,t_store_info s2,t_user_order,t_user,t_car_info where t_user.uid=t_user_order.uid and t_car_info.carid=t_user_order.carid and s1.storeid=t_user_order.rentstore and s2.storeid=t_user_order.returnstore and t_user_order.uid={Data.UID}";

                //Dao dao = new Dao();
                //IDataReader d = dao.read(sql);
                //if (d.Read())
                //{
                //    label3.Text = d[0].ToString();
                //    label4.Text = d[1].ToString();
                //    label5.Text = d[2].ToString();
                //    label6.Text = d[3].ToString();
                //    label7.Text = get_date(d[4].ToString());
                //    label8.Text = get_date(d[5].ToString());
                //    label9.Text = d[6].ToString();
                //    label10.Text = d[7].ToString();
                //}
                //dc.Close();
                //dao.DaoClose();

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
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            //还车
            button2.Hide();
            button3.Hide();
            button6.Hide();
            pictureBox1.Hide();

            //续租
            button4.Hide();
            button5.Hide();
            label2.Hide();
            dateTimePicker2.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
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
                this.Close();
            }
            catch
            {
                MessageBox.Show("操作执行错误");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请选择续租日期");
            // 修改
            button5.Show();

            // 
            button6.Hide();
            label2.Show();
            dateTimePicker2.Show();
        }

        //还车按钮   点击显示需要支付金额
        private void button6_Click(object sender, EventArgs e)
        {
            button4.Hide();
            int day_gap;
            Dao da = new Dao();
            string sql = $"select res.uid,rent.rentdate,res.returndate,car.cartype,type.rentprice from t_car_res res,t_car_rent rent,t_car_info car,t_type_info type where car.carid = rent.carid and res.uid = rent.uid and car.cartype = type.cartype and rent.uid = '{ID}';";
            IDataReader dc = da.read(sql);
            if (dc.Read())
            {
                string rent_pri = dc[4].ToString();
                Double pri = Convert.ToDouble(rent_pri);
                if (over_due)
                {
                    pri *= 1.5;
                }
                day_gap = get_day_gap(rent_d,DateTime.Now);
                payment = pri * day_gap;
                MessageBox.Show("您使用了" + day_gap.ToString() + "天，需要支付" + payment.ToString() + "车辆" + pri.ToString() + "一天");
                
                button3.Show();
                pictureBox1.Show();
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
            try
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
            catch
            {

            }
            this.Close();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你已经缴费，请进行车辆归还");
            button2.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
