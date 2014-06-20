using System;

class lab1
{
    static void Main()
    {
        string line = Console.ReadLine();
        string[] read = line.Split(' ');
        int m = Convert.ToInt32(read[0]);
        int n = Convert.ToInt32(read[1]);

        for (int i=1;i<=m;i++)
        {
            for (int j=1;j<=n;j++)
            {
                Console.Write(i*j + " ");
            }
            Console.WriteLine();
        }
    }
}
