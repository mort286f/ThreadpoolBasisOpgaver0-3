using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadpoolBasisØvelse1
{
    class Program
    {
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Process));
            }
        }

        static void Process(object callback)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {

                }
            }
            //for (int i = 0; i < 100000; i++)
            //{

            //}
        }

        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();

            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());

            mywatch.Reset();

            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
            Console.ReadLine();


            //ØVELSE 2:
            //Da jeg kørte programmet efter at have lagt det første for loop i Process metoden
            //gik det hurtigt for ThreadPool metoden, men meget langsommere for Thread metoden.
            //Der var en kæmpe forskel

            //Da jeg indsatte de dobbelte for-loop var ThreadPool metoden stadig virkelig hurtigt imens Thread metoden var utrolig lang tid om det.

        }
    }
}

