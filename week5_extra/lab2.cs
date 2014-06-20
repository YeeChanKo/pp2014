using System;

class lab2
{
    static void Main()
    {
        int times = Convert.ToInt32(Console.ReadLine());

        for(int i=0;i<=times;i++)
        {
            for (int j = 1; j <= i; j++)
                Console.Write("#");
            for (int k = times; k >= (i+1) ; k--)
                Console.Write("*");
            Console.WriteLine();
        }
    }
}