using System;
using System.Collections.Generic;
using System.Linq;

class lab2
{
    static void Swap(ref List<int> A, int i, int j)
    {
        int elementi = A.ElementAt(i);
        int elementj = A.ElementAt(j);

        A.RemoveAt(i);
        A.Insert(i, elementj);
        A.RemoveAt(j);
        A.Insert(j, elementi);
    }

    static void Shuffle(ref List<int> A)
    {
        Random r = new Random();
        for (int i = 0; i < A.Count; i++)
        {
            int rn = r.Next(0, 9);
            Swap(ref A, i, rn);
        }
    }

    static void Print(List<int> A)
    {
        foreach (int i in A)
        {
            Console.Write(i);
            Console.Write(" ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        List<int> rist = new List<int>();
        for (int i = 1; i <= 10; i++)
            rist.Add(i);
        Shuffle(ref rist);
        Print(rist);
    }
}