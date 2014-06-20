using System;

class lab3
{
	public static void Main(string[] args)
	{
		Console.Write("행렬 크기: ");
		int n = Convert.ToInt32(Console.ReadLine());
		int[,] array1 = new int[n,n];
		int[,] array2 = new int[n,n];
		int[,] array3 = new int[n,n];
		
		Console.WriteLine("첫번째 행렬({0}*{0})  입력",n);
		for(int i=1;i<=n;i++)
			for(int j=1;j<=n;j++)
			{
				Console.Write("({0},"+"{1})? ",i,j);
				array1[i-1,j-1]=Convert.ToInt32(Console.ReadLine());
			}

		Console.WriteLine();
		
		Console.WriteLine("두번째 행렬({0}*{0})  입력",n);
		for(int i=1;i<=n;i++)
			for(int j=1;j<=n;j++)
			{
				Console.Write("({0},"+"{1})? ",i,j);
				array2[i-1,j-1]=Convert.ToInt32(Console.ReadLine());
			}

		for(int i=1;i<=n;i++)
			for(int j=1;j<=n;j++)
				array3[i-1,j-1]=array1[i-1,j-1]+array2[i-1,j-1];

		Console.WriteLine();

		for(int i=1;i<=n;i++)
		{
			Console.Write("| ");
			for(int j=1;j<=n;j++)
				Console.Write("{0} ",array1[i-1,j-1]);
		Console.WriteLine("|");
		}
		Console.WriteLine();
		
		for(int i=1;i<=n;i++)
		{
			Console.Write("| ");
			for(int j=1;j<=n;j++)
				Console.Write("{0} ",array2[i-1,j-1]);
		Console.WriteLine("|");
		}
		Console.WriteLine();
		
		for(int i=1;i<=n;i++)
		{
			Console.Write("| ");
			for(int j=1;j<=n;j++)
				Console.Write("{0} ",array3[i-1,j-1]);
		Console.WriteLine("|");
		}
		Console.WriteLine();
		
	}
}
