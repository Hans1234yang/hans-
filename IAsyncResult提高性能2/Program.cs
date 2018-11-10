using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAsyncResult提高性能2
{
    class Program
    {
        //提高性能方法2 : 用到 WaitHandle

        //1.创建委托类型
        public delegate string Mydelegate(string name);
        static void Main(string[] args)
        {
            //3.实例化委托
            Mydelegate m1 = new Mydelegate(MyFangFa);

            //异步执行结果
           IAsyncResult result= m1.BeginInvoke("Hans ",null,null);

            while(!result.AsyncWaitHandle.WaitOne(2000))
            {
                Console.WriteLine("异步线程未完成，先执行这里");

            }
            string data = m1.EndInvoke(result);
            Console.WriteLine(data);
            Console.ReadLine();
        }
        //2.创建方法
        static string MyFangFa(string name)
        {
            return "Hello " + name;
        }
    }
}
