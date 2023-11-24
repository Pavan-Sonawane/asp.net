using System;



public class ProcessBusinessLogic
{
    public event EventHandler Addition;

    public void StartProcess()
    {
        int a = 2;
        int b = 2;
        int c = a + b;
        if (c % 2 != 0)
        {
            Console.WriteLine("Start process ");
            Console.WriteLine("Addition is " + c);
            OnProcessCompleted(EventArgs.Empty);
        }
        else
        {
            Console.WriteLine("even number");
        }
    }

    protected virtual void OnProcessCompleted(EventArgs e)
    {
        Addition?.Invoke(this, e);
    }
    class Program
    {
        public static void Main()
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.Addition += bl_ProcessCompleted;
            bl.StartProcess();
        }

        public static void bl_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("End Process");
        }
    }
}