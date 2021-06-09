using System;

namespace DelegateDemo
{
    class Program
    {
        //委托变量放不同的行为
        /// <summary>
        /// 委托 传递方法
        /// 委托是一个行为的载体
        /// 委托在定义的时候规范了 方法 返回类型 和参数列表
        /// 
        /// 泛型委托 区分函数就只能通过参数个数来区分了
        /// 
        /// 1.  定义一个委托
        /// 2. 实例化一个委托实列
        /// 3. 定义一个和委托匹配的函数
        /// 4. 将函数交给委托实列去使用
        /// 
        /// 
        /// 微软新增了两个默认的委托，一个是Action()  一个是Func
        /// Action 是没有返回值的， Func 是有返回值的
        /// 
        /// 在这基础上有引进了匿名函数 就是()
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //void GoStation(Help doSth)
            //{
            //    Console.WriteLine("go station");

            //    doSth();
            //    Console.WriteLine("end");
            //}

            //GoStation(SayHello);

            //Help h;

            //h = SayHello;
            //h();
            //h = SayGoodBye;
            //h();

            //void SayHello()
            //{
            //    Console.WriteLine("Hello");
            //}
            //void SayGoodBye()
            //{
            //    Console.WriteLine("GoodBye");
            //}


            void GoStation(Action doSth)
            {
                Console.WriteLine("go station");
                doSth();
                Console.WriteLine("end");
            }

            GoStation(()=>Console.WriteLine("匿名函数"));
            Console.WriteLine("Hello World!");
        }

      
    }

    delegate void Help();
    class Person { }
}
