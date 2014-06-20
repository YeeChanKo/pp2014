using System;

class Test
{
	static void Main()
	{
		int x = 10;
		Call1(x);
		Console.WriteLine("Main: {0}", x);
		Call2(ref x);
		Console.WriteLine("Main: {0}", x);
	}

	static void Call2(ref int n)
	{
		n *= 2;
		Console.WriteLine("Call2: {0}", n);
	}

	static void Call1(int n)
	{
		n *= 2;
		Console.WriteLine("Call1: {0}", n);
	}
}
