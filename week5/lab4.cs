using System;

public class NEXT
{
    public static int[] readint(string msg)
	{
		string[] arr1 = msg.Split(' ');
		int[] arr2 = new int[arr1.Length];
		for(int i=0;i<arr1.Length;i++)
		{
			arr2[i]=Convert.ToInt32(arr1[i]);
		}

		return arr2;
	}
}

class lab4
{
	static void Main()
	{
		Console.WriteLine("input test numbers: ");
		string a = Console.ReadLine();
		int[] arr = NEXT.readint(a);
		foreach(int i in arr)
			Console.WriteLine(i);
	}
}
	
