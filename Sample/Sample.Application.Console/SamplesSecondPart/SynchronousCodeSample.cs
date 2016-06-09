using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Sample.Application.Console.SamplesSecondPart
{
    public class SynchronousCodeSample
    {
        public void Run()
        {
            RunFirstSample();
        }

        public void RunFirstSample()
        {
            Process currentProcess = Process.GetCurrentProcess();

            Thread firstThread = new Thread(new ThreadStart(FirstThread));
            Thread seconThread = new Thread(new ThreadStart(SecondThread));
            firstThread.Start();
            seconThread.Start();
        }

        public void FirstThread()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine("Thread1111");
                Thread.Sleep(1000);
            }
        }

        public void SecondThread()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine("Thread2222");
                Thread.Sleep(2000);
            }
        }

        public void StartNewProcess()
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Program Files\7-Zip\7zG.exe";
            process.Start();
        }
    }
}
