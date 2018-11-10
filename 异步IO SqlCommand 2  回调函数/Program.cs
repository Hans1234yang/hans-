using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace 异步IO_SqlCommand_2__回调函数
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = "Data Source=.;Initial Catalog=adoTest;Integrated Security=True;Asynchronous Processing=true";

            string sql = "insert into Student values('hansTestt','888')";

            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sql,conn);
            //打开数据库
            conn.Open();

            //启动 cmd的异步操作，  将cmd对象 以object形式传到 回调函数
            cmd.BeginExecuteNonQuery(new AsyncCallback(MyCallBack),cmd);
            Console.ReadLine();
        }

        public static void MyCallBack(IAsyncResult ar)
        {
            SqlCommand cmddd = (SqlCommand)ar.AsyncState;

            //结束异步惭怍
            int count = cmddd.EndExecuteNonQuery(ar);
            Console.WriteLine("影响行数"+count);
            Console.WriteLine("结束");
            //关闭数据库连接
            cmddd.Connection.Close();
        }


    }
}
