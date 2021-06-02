using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfThread
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        /// <summary>
        /// 单线程VS 多线程
        /// 
        /// 1. 单线程要阻塞，多线程开启其他线程去处理任务，主线程可以空闲， 场景： 一个任务需要执行蛮长时间，用子线程去完成，主线程先返回结果。
        /// 2. 单线程慢，多线程快，多线程多个人同时做事情。 英国项目，多个线程取不同api结果，然后整合所有结果。 压榨CPU，资源换性能
        ///    但是多线程效率并不会成倍增加， a cpu 不够， b 调度机制 上下文切换有消耗  task 是基于线程池的，不会出现太多情况， cpu核数*3
        /// 
        /// 3. 多线程是无序的 线程是计算机资源，不受代码控制
        /// 4. 多线程要考虑均匀的分配任务
        /// 
        /// 5. 多线程循环临时变量问题
        /// 
        /// 6. 线程安全问题： 一段代码，单线程执行和多线程执行结果不一致，就表明有线程安全问题。  多线程去访问同一个集合 一般没问题，线程安全问题都是处在修改一个对象
        /// 
        /// 7. 多线程异常会被线程消化，有可能看不到异常抛出。
        /// 
        /// 
        /// Framework 1.0 1.1  
        /// 直接使用thread 
        /// ThreadStart threadStart = () => { };
        /// Thread thread = new Thread(threadStart);
        /// thread.start()  join() abort()...
        /// 优点： api 丰富，自由度很高， 
        /// 缺点： 线程是系统资源，不会如预期那样相应，不好控制，而且线程没有控制，容易死机。 例如一个小孩拿一把AK
        /// 
        /// 
        /// Framework 2.0 新增threadPool
        /// 池化资源管理设计思想， 原始使用方法，每次使用要申请，然后释放。 线程池就是一个容器，提前申请部分线程，可以重复利用不用每次
        /// 去申请新的
        /// 优点： 线程复用， 限制最大线程数量
        /// 缺点： api 太少，线程等待 顺序 控制特别不方便。
        /// 
        /// Framework 3.0 
        /// 出现Task 后续一直在更新，多线程最佳实践
        /// 
        /// Task 基于线程池线程
        /// 提供了丰富的API
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("*********同步方法 start {0}*********", Thread.CurrentThread.ManagedThreadId);

            ThreadStart threadStart = () => { };

            Thread thread = new Thread(threadStart);

         

            for (int i = 0; i < 5; i++)
            {
                string name = $"btnSync_Click_{i}";
                DoSomethinfLong(name);

            }

            Debug.WriteLine("*********同步方法 end {0}*********", Thread.CurrentThread.ManagedThreadId);
            MessageBox.Show("完成");
        }


        private void DoSomethinfLong(string name)
        {
            Debug.WriteLine("*********DoSomethinfLong start {0} {1} {2} *********", name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"));

            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }
            Debug.WriteLine("*********DoSomethinfLong end {0} {1} {2} {3} *********", name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"), lResult);
            Debug.WriteLine("");
        }

        private void buAsync_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("*********异步方法 start {0}*********", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 5; i++)
            {
                string name = $"btnSync_Click_{i}";

               // Action action = () => this.DoSomethinfLong(name);

                //多线程临时变量问题--解决申明变量
                Action action = () => this.DoSomethinfLong($"btnSync_Click_{i}");

                Task.Run(action);

            }

            Debug.WriteLine("*********异步方法 end {0}*********", Thread.CurrentThread.ManagedThreadId);
            MessageBox.Show("完成");

        }

        private void buThreadAdvanced_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("*********buThreadAdvanced_Click start {0}*********", Thread.CurrentThread.ManagedThreadId);

            Debug.WriteLine("step 1");
            Debug.WriteLine("step 2");
            Debug.WriteLine("step 3");
            Debug.WriteLine("step 4");
            Debug.WriteLine("step 5");
            Debug.WriteLine("step 6");

            List<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => this.Coding("xiaowu", "infrastructure")));
            taskList.Add(Task.Run(() => this.Coding("rojak", "mvc")));
            taskList.Add(Task.Run(() => this.Coding("ivan", "sql")));
            taskList.Add(Task.Run(() => this.Coding("steven", "qa")));


            //Task.Run(() => {

            //    //Task.WaitAny(taskList.ToArray());
            //    //Debug.WriteLine("milestone complite");

            //    ////全部完成
            //    //Task.WaitAll(taskList.ToArray());
            //    //Debug.WriteLine("finish all");

            //}); // 可以开启另外一个线程去执行下面操作，主线程就不用阻塞。 但是最好不好包三层
            //任意一个完成

            //回调

            taskList.Add(taskList[0].ContinueWith(t => Debug.WriteLine($"this thread callback{Thread.CurrentThread.ManagedThreadId}")));

            taskList.Add(Task.Factory.ContinueWhenAll(taskList.ToArray(), t => { Debug.WriteLine($"this thread callback{Thread.CurrentThread.ManagedThreadId}"); }));

            //Task.WaitAny(taskList.ToArray());
           // Debug.WriteLine("milestone complite");

            //全部完成
            Task.WaitAll(taskList.ToArray());
            Debug.WriteLine("finish all");

            Debug.WriteLine("*********buThreadAdvanced_Click end {0}*********", Thread.CurrentThread.ManagedThreadId);
            MessageBox.Show("完成");

        }

        private void Coding(string name,string job)
        {
            Debug.WriteLine("*********Coding start {0} {1} {2} {3}*********", name, job, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"));

            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }
            Debug.WriteLine("*********Coding end {0} {1} {2} {3} {4}*********", name, job, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"), lResult);
            Debug.WriteLine("");
        }


        /// <summary>
        /// 多线程任务分配，均匀分配
        /// 任务管理器，或者waitany
        /// </summary>
        private void Random()
        {
            Debug.WriteLine("*********Random start {0} {1}*********", Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"));

            int[][] typeArry = new int[100][];
            for (int i = 0; i < 100; i++)
            {
                int[] innerArry = new int[i];
                for (int j = 0; j < i; j++)
                {
                    innerArry[j] = j;

                }
                typeArry[i] = innerArry;
            }

            List<Task> taskList = new List<Task>();
            int threadNum = 27;

            ParallelOptions parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = threadNum
            };

            Parallel.ForEach(typeArry, parallelOptions, currentTypeArray =>
            {
                Debug.WriteLine($"CurrentThreadId={Thread.CurrentThread.ManagedThreadId},excute{string.Join(',', currentTypeArray)}");
                foreach (var num in currentTypeArray)
                {
                    Thread.Sleep(num);
                }
            });

            Task.WaitAll(taskList.ToArray());
            Debug.WriteLine("finish all");
            //List<List<int[]>> dList = new List<List<int[]>>();
            //for(int i = 0; i < threadNum; i++)
            //{
            //    dList.Add(new List<int[]>() { });
            //}
            //for(int i = 0; i < 100; i++)
            //{
            //    dList[i % threadNum].Add(typeArry[i]);
            //}

            //for (int i = 0; i < threadNum; i++)
            //{
            //    var currentyArray = dList[i];
            //    taskList.Add( Task.Run(()=>{ 

            //        foreach(var arry in currentyArray)
            //        {
            //            Debug.WriteLine($"CurrentThreadId={Thread.CurrentThread.ManagedThreadId},excute{string.Join(',', arry)}");
            //            foreach(var num in arry)
            //            {
            //                Thread.Sleep(num);
            //            }
            //        }
            //        Debug.WriteLine($"CurrentThreadId={Thread.CurrentThread.ManagedThreadId},finished");
            //    }));
            //}


            Debug.WriteLine("*********Coding end {0} {1} *********", Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"));
            Debug.WriteLine("");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Random();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Action action =()=> this.SpendTime("interface");

            Task.Run(action);
 

            Debug.WriteLine("*********button4_Click end{0} {1} *********",Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"));
        }

        private void SpendTime(string name)
        {
            Debug.WriteLine("*********SpendTime start {0} {1} {2} *********", name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"));

            Thread.Sleep(2000);
            Debug.WriteLine("*********SpendTime end {0} {1} {2} *********", name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"));
            Debug.WriteLine("");
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("*********button5_Click start {0} {1}  *********",Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"));

            //线程安全问题
            //List<int> intList = new List<int>();
            //for(int i = 0; i < 1000; i++)
            //{
            //    Task.Run(() => {
            //        intList.Add(i);
            //    });

            //}
            //Thread.Sleep(5000);
            //Debug.WriteLine(intList.Count);

            //解决 线程安全问题 加lock  就是单线程化， Lock 就是保证方法块里面任意时刻只有一个线程进去执行，其他线程就排队
            //lock 原理： 语法糖 等价Monitor-- 锁定一个内存引用地址--所以不能是值类型
            //  不同并发公用一个锁变量，会出现相互阻塞， 锁不同变量，才能并发。
            List<int> intList = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                Task.Run(() =>
                {
                    lock (LOCK)
                    {
                        intList.Add(i);
                    }
                    
                });

            }
            Thread.Sleep(5000);
            Debug.WriteLine(intList.Count);


            Debug.WriteLine("*********button5_Click end {0} {1} *********",Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HH:mm:ss:fff"));
            Debug.WriteLine("");
        }

        private static readonly object LOCK = new object();
    }
}
