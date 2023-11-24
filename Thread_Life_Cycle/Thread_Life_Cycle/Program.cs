using System;
using System.Threading;

class ThreadLifecycleExample
{
    static void Main(string[] args)
    {
        Thread life = new Thread(new ThreadStart(PrintInfo));

        Console.WriteLine("Thread State: " + life.ThreadState);
        life.Start();

       
        Console.WriteLine("Thread State: " + life.ThreadState);
        life.Suspend();

        Thread.Sleep(1000);

        Console.WriteLine("Thread State: " + life.ThreadState);
        life.Resume();

        
        Console.WriteLine("Thread State: " + life.ThreadState);
        life.Abort();

        Console.WriteLine("Thread State: " + life.ThreadState);

        
    }

    static void PrintInfo()
    {
        try
        {
            Console.WriteLine("This is Thread Life Cycle");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Running......" + i);
                Thread.Sleep(500);
            }
        }
        catch (ThreadAbortException)
        {
            Console.WriteLine("Thread was aborted.");
            Thread.ResetAbort();
        }
    }
}
