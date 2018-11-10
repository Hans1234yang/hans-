using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace IAsyncResult提高性能3_开回调函数
{
    class Program
    {
        //提高性能3 开回调函数 

        //1.定义委托类型
        public delegate string MyDelegate(string name);
        static void Main(string[] args)
        {
            //3.实例化委托
            MyDelegate m1 = new MyDelegate(MyFangfa);
            m1.BeginInvoke("hans",new AsyncCallback(MyCallBack),null);

            Console.ReadLine();
        }

        //2.定义方法
        public static string MyFangfa(string name)
        {
            return "Hello "+name;
        }

        public static void MyCallBack(IAsyncResult ar)
        {
            //获取当前的异步执行结果
            AsyncResult myResult = (AsyncResult)ar;

            //获取当前的委托对象 m1
            MyDelegate mmm1 = (MyDelegate)myResult.AsyncDelegate;

            string data = mmm1.EndInvoke(myResult);

            Console.WriteLine(data);

        }
    }
}
