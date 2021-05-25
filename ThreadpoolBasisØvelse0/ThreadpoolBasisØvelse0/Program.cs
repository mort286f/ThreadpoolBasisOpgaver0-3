/*
* C# Program to Create Thread Pools
*/
using System;
using System.Threading;
class ThreadPoolDemo
{
    //Method that the first treadpool executes
    public void task1(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 1 is being executed");
        }
    }

    //Method that the second threadpool executes
    public void task2(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 2 is being executed");
        }
    }

    static void Main()
    {
        //Creates a new instance for the TreadhPoolDemo class so that methods can be accessed for the thread pools to execute
        ThreadPoolDemo tpd = new ThreadPoolDemo();

        //For-loop that creates 2 threadpools and executes their methods for each interation of the loop
        for (int i = 0; i < 2; i++)
        {
            //Queues the method in the QueueUserWorkItem method when a thread comes available in the thread pool
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task1));
            //This goes for the other thread pool aswell
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task2));
        }

        Console.Read();
    }
}