using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool1
{                            //线程池的使用 
    class Program
    {
        static void Main(string[] args)
        {
            //设置最大线程数,第一个是工作者线程，第二个参数是IO线程      //没有实际参数的 回调函数
            ThreadPool.SetMaxThreads(1000,1000);
            ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncCallbcakSayHello));
            //int message = Thread.CurrentThread.ManagedThreadId;
            //Console.WriteLine("我是主线程，我的线程id是"+message);
            Console.ReadLine();
        }

        static void AsyncCallbcakSayHello(object o)
        {
           int message=  Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("我是回调函数,我的线程id是" + message);
        }
    }
}
