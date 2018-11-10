using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool3
{
    class Program
    {
        static void Main(string[] args)
        {
            //前面是工作者线程，后者是io线程
            ThreadPool.SetMaxThreads(1000,1000);

            ThreadPool.QueueUserWorkItem(new WaitCallback(MyCallBack), "hello world");  //hello world 传到回调函数的 object 函数
            Console.ReadLine();
        }

        static void MyCallBack(object o)
        {
            Console.WriteLine(o);
        }
        
    }
}
