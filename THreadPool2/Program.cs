using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THreadPool2
{                         //尝试重写一下 THreadpool 线程池的方法
    class Program
    {
        static void Main(string[] args)
        {
            MyThreadPool.SetMaxThreads(1000, 10000);

            MyThreadPool.MyQueueUserWorkItem(new MyWaitCallback(CallBackAdd));
            Console.ReadLine();
        }

        public static void CallBackAdd(object o)
        {
            Console.WriteLine("你好"+o);
        }
    }

    public class MyThreadPool      //线程池的写法 和线程 的写法 不一样 。线程是 先1.创建线程的时候,在构造函数中  实例化一个委托
                                                                         //2. 用thread类的start 方法 调用委托
                                     // 线程池是 在QueueUserWorkItem 里面 实例化一个委托 。
    {
        static MyWaitCallback m1;
        public MyThreadPool()
        {
           
        }

        //设置工作者线程 ，io线程最大值
        public static void SetMaxThreads(int workersThread, int ioThread)
        {

        }

        public static void MyQueueUserWorkItem(MyWaitCallback _m1)
        {
            m1 = _m1;
            m1("Hans 同学");
        }
    }

    //定义一个委托  有参数的
    public delegate void MyWaitCallback(object o);
}
