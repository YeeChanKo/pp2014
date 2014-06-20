using System;

class lab2
{
	public static void Main(string[] args)
	{
		int a = Convert.ToInt32(Console.ReadLine());		int b = Convert.ToInt32(Console.ReadLine());

		for(int hang=1;hang<=a;hang++)
		{
			for(int year=1;year<=b;year++)
					Console.Write("{0}"+"{1} ",hang-1,year-1);
			Console.WriteLine();
		}
	}
}
