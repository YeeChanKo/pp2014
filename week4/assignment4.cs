using System;

class assignment4
{
	public static void Main(string[] args)
	{
		Console.Write("반복횟수를 입력하세요: ");
		int time=Convert.ToInt32(Console.ReadLine());

		while(time<=0)
		{	
			Console.WriteLine();
			Console.WriteLine("0보다 같거나 작은 숫자는 사용할 수 없습니다!!!");
			Console.Write("다시 입력하세요 : ");
			time=Convert.ToInt32(Console.ReadLine());
		}
		Console.WriteLine();

		for(int i=1;i<=time;i++)
		{
			for(int j=1;j<=i;j++)
				Console.Write("*");
			Console.WriteLine();
		}
	}
}
