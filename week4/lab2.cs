using System;

class lab2
{
	public static void Main(String[] args)
	{
		int guess=0;
		Random r=new Random();
		int number=r.Next(1,11);
		int count=0;

		for(;guess!=number;count++)
		{
			Console.WriteLine("숫자를 맞춰봐:");
			guess=Convert.ToInt32(Console.ReadLine());
			if(guess>number)
				Console.WriteLine("너무 커~~");
			else if(guess<number)
				Console.WriteLine("좀 더 써보지?ㅎㅎ");
			Console.WriteLine();
		}

		Console.WriteLine("{0}번에야 맞췄네~ㅋㅋㅋ",count);
	}
}

