using System;
using System.Threading;

class Timer
{
    static void PrintStopWatch()
    {

        int hour = 0;
        int min = 0;
        int sec = 0;

        while (true)
        {

            Console.WriteLine("{0:00}:{1:00}.{2}", hour, min, sec);
            sec++;
            Thread.Sleep(50);
            if (sec == 10)
            {
                min++;
                sec = 0;
            }
            if (min == 60)
            {
                hour++;
                min = 0;
            }
        }
    }

    static void Main()
    {
        PrintStopWatch();
        Console.WriteLine("Bye");
    }
}