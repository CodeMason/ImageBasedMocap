using MoCapStudio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoCapStudio
{
    static class Program
    {
        static List<Thread> runningThreads_ = new List<Thread>();
        static List<System.Timers.Timer> timers_ = new List<System.Timers.Timer>();

        public static void AddThread(Thread th)
        {
            runningThreads_.Add(th);
        }

        public static void AddTimer(System.Timers.Timer t)
        {
            timers_.Add(t);
        }

        public static void RemoveThread(Thread th)
        {
            runningThreads_.Remove(th);
        }

        public static void RemoveTimer(System.Timers.Timer t)
        {
            timers_.Remove(t);
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static void Application_ApplicationExit(object sender, EventArgs e)
        {
            IProgramTerminated.Terminate();
            foreach (System.Timers.Timer ti in timers_)
                ti.Stop();
            foreach (Thread th in runningThreads_)
                th.Abort();
        }
    }
}
