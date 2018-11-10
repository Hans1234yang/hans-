using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IO线程_异步写入
{
    class Program
    {
        //io线程异步写入
        static void Main(string[] args)
        {
            //设立线程池中 工作者线程1000，io线程1000
            ThreadPool.SetMaxThreads(1000, 1000);

            //建立文件 Hello.txt
            FileStream stream = new FileStream
                ("Hello.txt",       //文件路径
                FileMode.OpenOrCreate,     //创建文件
                FileAccess.ReadWrite,    //文件访问方式
                FileShare.ReadWrite,     //是否进程共享
                1024,               ///缓冲区大小
                true               // 是否启用异步io线程
                );

            byte[] bytes = new byte[16384];

            string message = "你好，我是杨澹，我是.net开发程序员,喜欢下象棋";

            bytes = Encoding.UTF8.GetBytes(message);  //将要写入的信息转化为字节码

            //启动异步写入
            stream.BeginWrite(bytes, 0, (int)bytes.Length, new AsyncCallback(MyCallBack), stream);
            Console.WriteLine("结束");
            Console.ReadLine();
            
        }

        public static void MyCallBack(IAsyncResult result)
        {
           //传过来的获取文件流 对象
            FileStream stream1=(FileStream)result.AsyncState;    //io线程 这里比较方便直接获取 文件流对象就可以了 

            stream1.EndWrite(result);
            stream1.Close();
        }
    }
}
