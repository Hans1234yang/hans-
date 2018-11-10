using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace IAsyncResult提高性能_回调函数
{
    class Program      //在回调函数中 有类型传递
    {
        //1.定义一个委托类型  有参数，有返回值
        delegate string myDelegate(string name);
        static void Main(string[] args)
        {
            Person p1 = new Person("杨先生", "下中国象棋");

            //3.实例化一个委托
            myDelegate m1 = new myDelegate(Fangfa);

            m1.BeginInvoke("hans",new AsyncCallback(MyCallBack),p1);

            Console.ReadLine();
        }

        //2.定义一个方法 
        public static string Fangfa(string name)
        {
            return "Hello " + name;
        }

        //回调函数
        public static void MyCallBack(IAsyncResult ar)
        {
            //获取异步执行的结果
            AsyncResult myresult=(AsyncResult)ar;
            //获取委托对象
            myDelegate m1 = (myDelegate)myresult.AsyncDelegate;

            //获取方法的返回值
            string data = m1.EndInvoke(myresult);

            Person p = (Person)ar.AsyncState;
            Console.WriteLine(data);
            Console.WriteLine(p.name +"  "+ p.hobby);

        }
    }

    public class Person
    {
        public string name;
        public string hobby;

        public Person(string _name,string _hobby )
        {
            name = _name;
            hobby = _hobby;
        }
    }
}
