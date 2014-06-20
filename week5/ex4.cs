using System;

class ex4
{
	static void sumprint(int x, int y)
	{
		x += y;
		Console.WriteLine(x);
	}

	static void Main()
	{
		int x=10;
		int y=20;
		sumprint(x,y);
	}
}
