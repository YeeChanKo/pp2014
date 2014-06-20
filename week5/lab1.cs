using System;

class lab1
{
	public static void Main(string[] args)
	{
		int a=0;
		int count=0;
		a=Convert.ToInt32(Console.ReadLine());
		for(count=1;count<=a;count++)
		{
			for(int b=1;b<=(a-count);b++)
				Console.Write(" ");
			for(int c=1;c<=(2*count-1);c++)
				Console.Write("*");
			Console.WriteLine();
		}
	}
}
