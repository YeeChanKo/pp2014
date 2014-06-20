using System;

namespace week3
{
	public class lab2
	{
		static void Main(String[] args)
		{
			String name;
			double baseline;
			double height;

			Console.Write("이름? ");
			name=Console.ReadLine();
			Console.Write("밑변? ");
			baseline=Convert.ToDouble(Console.ReadLine());
			Console.Write("높이? ");
			height=Convert.ToDouble(Console.ReadLine());
			Console.Write("{0}의 넓이 = {1}",name,baseline*height/2);
		}
	}
}

