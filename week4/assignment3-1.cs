using System;

class assignment3_1
{
	public static void Main(string[] args)
	{
		int i=1,j=1;
		while(i<6)
		{
			while(j<=i)
			{
				Console.Write("*");
				j++;
			}
		Console.WriteLine();
		i++;
		j=1;
		}
	}
}
