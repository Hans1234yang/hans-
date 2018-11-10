using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 异步委托1
{
    class Program
    {
        // 有参数，有返回值 的委托，就要用到 回调函数

            //1.定义一个委托类型
        delegate string Mydelegate(string name);

        static void Main(string[] args)
        {
            //实例化一个委托

            Mydelegate m1 = new Mydelegate(MyFangfa);

            //异步调用两个方法
            //方法一：
            //string result=  m1("hans");
            // Console.WriteLine(result);

            //方法二：
            //
           IAsyncResult result = m1.BeginInvoke("hans",null,null);  //第一个null 是回调函数名称，第二个null 是回调函数的 object参数


            string data = m1.EndInvoke(result);       //endinvoke是会线程阻塞的，保证其他线程执行完，才会执行后面
            Console.WriteLine(data);
            Console.ReadLine();
        }

        //2.创建一个方法
        public static string MyFangfa(string name)
        {
            return "Hello " + name;
        }
    }
}
