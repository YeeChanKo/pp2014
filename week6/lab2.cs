using System;

class lab2
{
	static void Main()
	{
		Console.Write("입력: ");
		string input = Console.ReadLine();
		string[] split = input.Split(' ');
		int a = Convert.ToInt32(split[0]);
		int b = Convert.ToInt32(split[1]);
		printnum(a,b);
	}

	static void printnum(int m, int n)
	{	
		int[,] arr = new int[m,n];
		for(int i=0;i<m;i++)
			for(int j=0;j<n;j++)
				arr[i,j]=(i+1)+m*j;

		for(int i=0;i<m;i++)
		{	
			for(int j=0;j<n;j++)
				Console.Write(arr[i,j]+" ");
			Console.WriteLine();
		}
	}
}
