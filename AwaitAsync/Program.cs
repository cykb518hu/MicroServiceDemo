using System;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AwaitAsyncClass aw = new AwaitAsyncClass();
            aw.Show();

            Console.ReadLine();
        }
    }


    /// <summary>
    /// await/async 新语法 c#5.0 .Framework 4.5+ CLR 4.0   同步编程的思维实现了异步，多线程的的实际操作。 主要目的，最高效合理的使用线程，既使用了多线程，也满足了同步的需求，因为实际的多线程编程是很难控制顺序的。
    /// 本身不会产生一个新的线程，但是依托于Task 存在，所以程序执行时有多线程
    /// 主线程遇到await 关键字就会结束执行，回到主方法继续执行后续代码
    /// 
    /// 1. async 可以随意添加 但是只有await 不行。 await 只能出现在task 前面，方法必须声明async
    /// 2. 加了await/async 方法没有返回值，可以直接返回task，如果返回T类型的， 以Task<T>方式返回
    /// 3. await 关键字 后面的代码包装成了一个回调 等于task.ContinueWith
    /// </summary>
    public class AwaitAsyncClass
    {
        public void Show()
        {
            Console.WriteLine($"this Main start {Thread.CurrentThread.ManagedThreadId}");
            NoReturnTask();
            Console.WriteLine($"this Main end {Thread.CurrentThread.ManagedThreadId}");
        }

        public void NoReturn()
        {
            Console.WriteLine($"this NoRetrun start {Thread.CurrentThread.ManagedThreadId}");

            Task.Run(() =>
            {
                Console.WriteLine($"this NoRetrun Task start {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
                Console.WriteLine($"this NoRetrun Task end {Thread.CurrentThread.ManagedThreadId}");
            });

            Console.WriteLine($"this NoRetrun end {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task NoReturnTask()
        {
            Console.WriteLine($"this NoReturnTask start {Thread.CurrentThread.ManagedThreadId}");

            Task task = Task.Run(() =>
             {
                 Console.WriteLine($"this NoReturnTask Task start {Thread.CurrentThread.ManagedThreadId}");
                 Thread.Sleep(2000);
                 Console.WriteLine($"this NoReturnTask Task end {Thread.CurrentThread.ManagedThreadId}");
             });
            Console.WriteLine($"this NoReturnTask end {Thread.CurrentThread.ManagedThreadId}");
            await task;
           
        }

        public async Task<long> ReturnLongAsync()
        {
            Console.WriteLine($"this ReturnLong start {Thread.CurrentThread.ManagedThreadId}");
            long result = 0;
            await Task.Run(() =>
             {
                 Console.WriteLine($"this ReturnLong Task start {Thread.CurrentThread.ManagedThreadId}");

                 for (int i = 0; i < 1000000000; i++)
                 {
                     result += i;
                 }
                 Console.WriteLine($"this ReturnLong Task end {Thread.CurrentThread.ManagedThreadId}");
                 return result;
             });
            Console.WriteLine($"this ReturnLong end {Thread.CurrentThread.ManagedThreadId}");
            return result;
        }
        public async Task DoSomethins()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("**********");
            });
        }
    }
}
