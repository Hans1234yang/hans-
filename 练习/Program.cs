using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 练习
{
    class Program     ///threadStart 委托的重写    委托无参数
    {
        static void Main(string[] args)
        {
            Thread t2 = new Thread(new ThreadStart(SayHello));
            


            MyThread m1 = new MyThread(new MythreadThart(SayHello));
            m1.Start();
            

            Console.ReadLine();
        }

        public static void SayHello()
        {
            Console.WriteLine("您好世界");
        }
    }

    class MyThread
    {
        MythreadThart m1;


        public MyThread(MythreadThart _m1)
        {
            m1 = _m1;   //实例化一个委托
        }

        public void Start()
        {
            m1();  //调用委托
        }
    }

    //1.定义一个没有返回类型 没有参数的委托
    public delegate void MythreadThart();

}
