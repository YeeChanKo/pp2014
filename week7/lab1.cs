using System;
using System.Collections.Generic;
using System.Linq;

class lab1
{
    static void Main()
    {
        List<int> IntList = new List<int>();
        string line = Console.ReadLine();
        string[] words = line.Split(' ');
        for (int i = 0; i < words.Length; i++)
            IntList.Add(Convert.ToInt32(words[i]));

        int temp = 0;
        int a = Convert.ToInt32(Math.Ceiling(IntList.Count / (double)2) - 1);

        for (int i = 0; i <= a; i++)
        {
            temp = IntList.ElementAt(i);
            IntList.RemoveAt(i);
            IntList.Insert(i, IntList.ElementAt(IntList.Count - 1 - i));
            IntList.RemoveAt(IntList.Count - 1 - i);
            IntList.Insert(IntList.Count - i, temp);
        }

        foreach (int i in IntList)
        {
            Console.Write(i);
            Console.Write(" ");
        }
    }
}