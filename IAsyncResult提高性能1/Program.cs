using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAsyncResult提高性能1
{
    class Program   //提供性能方法   1.使用iscompleted属性
    {
        //1.创建委托类型
        public delegate string MyDelegate(string name);
        static void Main(string[] args)
        {
            //3实例化委托
            MyDelegate m1 = new MyDelegate(MyCallBack);

            //记录异步委托的执行结果
           IAsyncResult result= m1.BeginInvoke("hans",null,null);

            //多线程未执行线程的时候，执行里面的方法
            while(!result.IsCompleted)
            {
                Console.WriteLine("异步线程，未执行完毕，先执行这里");
            }

            string data = m1.EndInvoke(result);
            Console.WriteLine(data);
            Console.ReadLine();
        }


        //2.创建方法
        public static string MyCallBack(string name)
        {
            return "Hello " + name;
        }
    }
}
