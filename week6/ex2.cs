using System;

class Test
{
	static void Main()
	{
		int[] x = {1,2,3};
		PrintIntArray(x);
		DoubleArray(x);
		PrintIntArray(x);
	}

	static void PrintIntArray(int[] arr)
	{
		foreach(int i in arr)
			Console.Write("{0} ",i);
		Console.WriteLine();
	}

	static void DoubleArray(int[] arr)
	{
		for(int i = 0; i < arr.Length; i++)
			arr[i] *= 2;
	}
}
