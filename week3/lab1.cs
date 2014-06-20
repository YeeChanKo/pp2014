using System;

namespace week3
{
	public class lab1
	{
		public static void Main (string[] args)
		{
			int kor1=80, kor2=88;
			int math1=90, math2=60;
			double avg1=(math1+kor1)/2, avg2=(kor2+math2)/2;
			double avg3 = (avg1 + avg2) / 2;
			String name1="임정민", name2="배철오";

			Console.WriteLine ("=====SCORE=====");
			Console.WriteLine ("AVG of {0}: {1}", name1, avg1);
			Console.WriteLine ("AVG of {0}: {1}", name2, avg2);
			Console.WriteLine ("AVG TOTAL: {0}", avg3);
		}
	}
}
