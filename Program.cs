using System;
using System.Threading;

class Program
{
    static object lock1 = new object();
    static object lock2 = new object();

    static void Main(string[] args)
    {
        Thread thread1 = new Thread(Method1);
        Thread thread2 = new Thread(Method2);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("Program completed successfully.");
    }

    static void Method1()
    {
        lock (lock1)
        {
            Console.WriteLine("Thread 1 acquired lock1.");
            Thread.Sleep(1000);

            lock (lock2)
            {
                Console.WriteLine("Thread 1 acquired lock2.");
            }
        }
    }

    static void Method2()
    {
        lock (lock2)
        {
            Console.WriteLine("Thread 2 acquired lock2.");
            Thread.Sleep(1000);

            lock (lock1)
            {
                Console.WriteLine("Thread 2 acquired lock1.");
            }
        }
    }
}
