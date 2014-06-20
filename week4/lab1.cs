using System;

namespace lab1
{
	class lab1
	{
		public static void Main(String[] args)
		{
			int sum=0;
			int a=1;
			int count=0;

			for(;a!=0;count++)
			{
			Console.WriteLine("더할 숫자?(0 입력시 끝남)");
			a=Convert.ToInt32(Console.ReadLine());
			sum=sum+a;
			}
			count--;	
			Console.WriteLine("총합:{0}",sum);
			double average=(double)sum/count;
			Console.WriteLine("평균:{0}",average);
		}
	}
}
