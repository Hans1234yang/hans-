using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace 异步IO_SqlCommand1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connstr = "Data Source=.;Initial Catalog=adoTest;Integrated Security=True;Asynchronous Processing=true";

            string sql1 = "insert into Student values('hansTest','666')";

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql1,conn);
            conn.Open();

            //启动异步Sqlcommand 不过以轮询方式检测
            IAsyncResult result = cmd.BeginExecuteNonQuery();

            //结束异步sqlcommand
            int count = cmd.EndExecuteNonQuery(result);
            Console.WriteLine("结束");
            Console.ReadLine();
        }
    }
}
