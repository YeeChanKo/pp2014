using System;

class lab3
{
    static void Main()
    {
        Console.Write("배열 크기를 입력해주세요: ");
        int size = Convert.ToInt32(Console.ReadLine());
        string[,] array = new string[size, size];
        writearray(array, size);
        printarray(array, size);

        while(true)
        {
            Console.WriteLine();
            Console.Write("지울 위치를 입력해주세요: ");
            string line = Console.ReadLine();
            string[] coordinate = line.Split(' ');
            int x = Convert.ToInt32(coordinate[0]);
            int y = Convert.ToInt32(coordinate[1]);
            if (x >= 0 && y >= 0)
            {
                erasearray(array, x, y);
                printarray(array, size);
            }
            else
                break;
        }
        Console.WriteLine();
        Console.WriteLine("END...");
        Console.ReadLine();
    }

    static void printarray(string[,] anyarr, int anysize)
    {
        for (int i = 0; i < anysize; i++)
        {
            for (int j = 0; j < anysize; j++)
                Console.Write(anyarr[i, j]);
            Console.WriteLine();
        }
    }

    static void writearray(string[,] anyarr, int anysize)
    {
        for (int i = 0; i < anysize; i++)
        {
            for (int j = 0; j < anysize; j++)
                anyarr[i, j]= "*";
        }
    }

    static void erasearray(string[,] anyarr, int i, int j)
    {
        if (anyarr[i, j] == " " && anyarr[j, i] == " ")
            Console.WriteLine(System.Environment.NewLine+"이미 지운 곳입니다!");
        else
        {
            anyarr[i, j] = " ";
            anyarr[j, i] = " ";
        }
    }
}