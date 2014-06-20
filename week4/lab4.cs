using System;

class lab4
{
	public static void Main(String[] args)
	{
		Console.WriteLine("input:");
		string determine=Console.ReadLine();
		string[] numbers=determine.Split(' ');
		int initial = Convert.ToInt32(numbers[0]);
		int final = Convert.ToInt32(numbers[1]);
		int step = Convert.ToInt32(numbers[2]);
		int sum=0;
		Console.WriteLine("output:");

		for(int a=initial;a<=final;a+=step)
		{
			sum+=a;
			Console.WriteLine("{0}",sum);
		}
	}
}
