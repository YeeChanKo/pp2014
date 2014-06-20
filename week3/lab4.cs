using System;

namespace week3
{
	public class Circle {
		public double x;
		public double y;
		public double r;
	}

	public class lab4
	{
		static void Main(String[] args)
		{
			Circle c1 = new Circle ();
			Circle c2 = new Circle ();
		

			Console.WriteLine ("----------원충돌 테스트----------");

			Console.WriteLine ("첫번째 원의 X좌표, Y좌표, 반지름?");
			c1.x = Convert.ToDouble (Console.ReadLine ());
			c1.y = Convert.ToDouble (Console.ReadLine ());
			c1.r = Convert.ToDouble (Console.ReadLine ());

			Console.WriteLine ("두번째 원의 X좌표, Y좌표, 반지름?");
			c2.x = Convert.ToDouble (Console.ReadLine ());
			c2.y = Convert.ToDouble (Console.ReadLine ());
			c2.r = Convert.ToDouble (Console.ReadLine ());
		
			if (Math.Sqrt(Math.Pow((c1.x - c2.x),2)+ Math.Pow((c1.y - c2.y),2)) <= (c1.r + c2.r))
				Console.WriteLine ("두 원은 충돌합니다.");
			else
				Console.WriteLine ("두 원은 충돌하지 않습니다.");
		}
	}
}

