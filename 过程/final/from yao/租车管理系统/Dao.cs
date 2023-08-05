using System.Data.SqlClient;

namespace 租车管理系统
{
    class Dao
    {
        SqlConnection sc=new SqlConnection();
        public SqlConnection connection()
        {
            string str = @"Data Source=LAPTOP-740QUQ02;Initial Catalog=car_rent;Integrated Security=True";//数据库连接字符
            sc = new SqlConnection(str);//创建数据库连接对象
            sc.Open();//打开数据库
            return sc;//返回数据库连接对象
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd=new SqlCommand(sql,connection());
            return cmd;
        }
        public int Execute(string sql)//更新操作
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql)//读取操作
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sc.Close();//关闭数据库连接
        }
    }
}
