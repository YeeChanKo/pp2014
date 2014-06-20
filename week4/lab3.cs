using System;

class lab4
{
	public static void Main(String[] args)
	{
		int input=0;
		int count=0;
	 	Console.WriteLine("숫자를 하나 입력하세요");
		input=Convert.ToInt32(Console.ReadLine());

		for(;(input>20)||(input<=0);)
		{
			Console.WriteLine("1~20 사이의 수를 입력하세요");
			Console.Write("다시 입력:");
			input=Convert.ToInt32(Console.ReadLine());
		}

		for(count=1;count<10;count++)
		{
			Console.WriteLine("{0} * {1} = {2}",input,count,input*count);
		}
	}
}

