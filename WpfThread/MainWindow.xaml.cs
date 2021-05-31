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
            Debug.WriteLine("*********同步方法 start {0}*********", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 5; i++)
            {
                string name = $"btnSync_Click_{i}";

               // Action action = () => this.DoSomethinfLong(name);

                //多线程临时变量问题--解决申明变量
                Action action = () => this.DoSomethinfLong($"btnSync_Click_{i}");
                Task.Run(action);

            }

            Debug.WriteLine("*********同步方法 end {0}*********", Thread.CurrentThread.ManagedThreadId);
            MessageBox.Show("完成");

        }
    }
}
