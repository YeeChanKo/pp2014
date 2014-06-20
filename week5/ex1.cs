using System;

class ex1
{
	static void Line()
	{
		int number = Convert.ToInt32(Console.ReadLine());
		for (int i=1;i<=number;i++)
			Console.WriteLine("--------------------------");
	}

	static void Main()
	{
		Console.Write("Number? ");
		Line();
		Console.Write("Another Number? ");
		Line();
		Console.WriteLine("End");
	}
}
