using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadpoolBasisØvelse3
{
    class Program
    {
        static void ThreadpoolTask(object callback)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("5 + ");
            }
        }

        static void ThreadTask()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Power thread doing something " + (i+1) + "time(s) in a row! ");
            }
        }

        static void DisplayThreadInfo()
        {
            Console.WriteLine("\nCurrent Thread ID: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread name: " + Thread.CurrentThread.Name);
            Console.WriteLine("Is Alive: " + Thread.CurrentThread.IsAlive);
            Console.WriteLine("Is background: " + Thread.CurrentThread.IsBackground);
            Console.WriteLine("Thread Prio: " + Thread.CurrentThread.Priority + "\n");

                
        }

        static void SleepCurrentThread()
        {
            //Får den nuværende tråd til at "Sleepe" altså at gå i dvale i de givne millisekunder
            Thread.Sleep(10000);
        }

        static void Main(string[] args)
        {

            Thread thr = new Thread(DisplayThreadInfo);
            thr.Name = "Least awesome thread";
            thr.Priority = ThreadPriority.Lowest;
            //Starter tråden, som betyder at tråden bliver sat til "kørende"
            thr.Start();


            Thread thr2 = new Thread(DisplayThreadInfo);
            thr2.Name = "Middel thread";
            thr2.Priority = ThreadPriority.BelowNormal;
            thr2.IsBackground = true;
            thr2.Start();


            Thread thr3 = new Thread(DisplayThreadInfo);
            thr3.Name = "Most awesome thread";
            thr3.Priority = ThreadPriority.Highest;
            thr3.IsBackground = false;
            thr3.Start();



            thr3 = new Thread(new ThreadStart(SleepCurrentThread));
            thr3 = new Thread(DisplayThreadInfo);

            if (thr.IsBackground)
            {
                //Midlertidig sætter tråden i bero, indtil den bliver resumed igen.
                // Både Suspend og Resume bliver dog ikke rigtig brugt mere, og man henviser til at bruge Monitor.
                thr.Suspend();
            }
            if (thr.Priority == ThreadPriority.AboveNormal)
            {
                //Sætter en tråd i gang som er suspenderet.
                // Både Suspend og Resume bliver dog ikke rigtig brugt mere, og man henviser til at bruge Monitor
                thr.Resume();
            }
            else
            {
                //Abort sætter en aktion i gang for at terminere tråden og smider en ThreadAbortException. 
                thr.Abort();
            }

            //Sætter thr tråden i vente-mode indtil en anden tråd færdiggører sin eksekvering. 
            thr.Join();

            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadpoolTask));
            Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;

            Console.Read();
        }
    }
}
