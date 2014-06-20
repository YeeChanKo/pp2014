using System;
using System.Collections.Generic;
using System.Linq;

class assignment2
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
            int rn = r.Next(0, A.Count-1);
            Swap(ref A, i, rn);
        }
    }

    static void Print(List<int> A)
    {
        for (int i = 0; i < 6;i++ )
        {
            Console.Write("{0} ", A.ElementAt(i));
        }
    }

    static void Main()
    {
        List<int> rist = new List<int>();
        for (int i = 1; i <= 45; i++)
            rist.Add(i);
        Shuffle(ref rist);
        Print(rist);
    }
}