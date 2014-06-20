using System;

class ex3
{
	static void DoublePrint(int x)
	{
		x*=2;
		Console.WriteLine(x);
	}

	static void Main()
	{
		int x=10;
		int y=20;
		DoublePrint(x);
		DoublePrint(y);
		DoublePrint(30);
		Console.WriteLine("Main x: "+x);
	}
}
