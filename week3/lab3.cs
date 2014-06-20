using System;

namespace week3
{
	public class Student {
		public String name;
		public double kor;
		public double math;
		public double avg;
	}

	public class lab3
	{
		static void Main(String[] args)
		{
			Student s1 = new Student ();
			s1.name = "Lim";
			s1.kor = 80;
			s1.math = 90;
			s1.avg = (s1.kor+s1.math)/2;
			Console.WriteLine ("{0} 국어:{1} 수학:{2} 평균:{3}", s1.name, s1.kor, s1.math, s1.avg);
		
			Student s2 = new Student ();
			s2.name = "Bae";
			s2.kor = 88;
			s2.math = 60;
			s2.avg = (s2.kor+s2.math)/2;
			Console.WriteLine ("{0} 국어:{1} 수학:{2} 평균:{3}", s2.name, s2.kor, s2.math, s2.avg);

			double totalavg = (s1.avg + s2.avg) / 2;
			Console.WriteLine ("전체평균:{0}", totalavg);
		}
	}
}

