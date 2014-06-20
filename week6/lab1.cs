using System;

class lab1
{
	static void Main()
	{
		int k=0;
		int[] monthday = new int[12] {31,28,31,30,31,30,31,31,30,31,30,31};
		string[,] date = new string[12,31];
		for(int i=0;i<12;i++)
			for(int j=0;j<monthday[i];j++)
			{
				if(k==0)
					date[i,j]="MON";
				else if(k==1)
					date[i,j]="TUE";
				else if(k==2)
					date[i,j]="WED";
				else if(k==3)
					date[i,j]="THU";
				else if(k==4)
					date[i,j]="FRI";
				else if(k==5)
					date[i,j]="SAT";
				else if(k==6)
				{	
					date[i,j]="SUN";
					k=-1;
				}
				k++;
			}
		Console.WriteLine("2007년 1월 1일은 월요일이다. O월 O일은?");
		Console.WriteLine("단 2월은 28일까지 있다.");
		Console.Write("입력: ");
		string input = Console.ReadLine();
		string[] split = input.Split(' ');
		int a = Convert.ToInt32(split[0]);
		int b = Convert.ToInt32(split[1]);
		Console.Write("출력: ");
		Console.WriteLine(date[a-1,b-1]);
	}
}
