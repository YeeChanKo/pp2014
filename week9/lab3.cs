using System;
using System.Threading;

class Timer
{
    static void PrintStopWatch()
    {

        while (true)
        {
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;
            Console.WriteLine("{0:00}:{1:00}:{2:00}", hour, min, sec);
            Thread.Sleep(1000);
        }
    }

    static void Main()
    {
        PrintStopWatch();
        Console.WriteLine("Bye");
    }
}