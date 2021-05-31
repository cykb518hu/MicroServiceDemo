using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muti_Threed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("*********同步方法 start {0}*********", Thread.CurrentThread.ManagedThreadId);


            for (int i = 0; i < 5; i++)
            {
                string name = $"btnSync_Click_{i}";
                DoSomethinfLong(name);

            }

            Console.WriteLine("*********同步方法 end {0}*********", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
        }


        private void DoSomethinfLong(string name)
        {
            Console.WriteLine();
            Console.WriteLine("*********DoSomethinfLong start {0} {1} {2} *********", name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"));

            long lResult = 0;
            for(int i=0;i<1000000000;i++)
            {
                lResult += i;
            }
            Console.WriteLine("*********DoSomethinfLong end {0} {1} {2} {3} *********", name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"), lResult);
            Console.WriteLine();
        }
    }
}
