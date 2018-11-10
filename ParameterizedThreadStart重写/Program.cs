using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterizedThreadStart重写
{

    //parameterizeThreadStart重写   委托有参数
    class Program
    {
        static void Main(string[] args)
        {
            MyTHread m1 = new MyTHread(new MyParameterThreadStart(Add));
            m1.Start("你好");
            Console.ReadLine();

        }
        public static void Add(object o)
        {
            Console.WriteLine(o);
        }


    }

    public class MyTHread
    {
        MyParameterThreadStart m1;
        public MyTHread(MyParameterThreadStart _m1)
        {
            m1 = _m1;
        }

        public void Start(object o)
        {
            m1(o);
        }
    }



    public delegate void MyParameterThreadStart(object o);




}
