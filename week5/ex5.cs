using System;

class ex5
{
	static int readint(string msg)
	{
		Console.Write("{0}? ",msg);
		int x=Convert.ToInt32(Console.ReadLine());
		return x;
	}

	static double divide(int x, int y)
	{
		double r = (double)x/y;
		return r;
	}

	static void Main()
	{
		int a = readint("a");
		int b = readint("b");
		double x = divide(a,b);
		Console.WriteLine(x);
	}
}

