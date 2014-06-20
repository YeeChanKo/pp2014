using System;

class extra
{
	public static void Main(string[] args)
	{
		string line = Console.ReadLine();
		string[] element = line.Split(' ');
		
		int sum = Convert.ToInt32(element[0]);
		
		for(int b = 2;b<=element.Length;b+=2)
		{
		if(element[b]=="*")
			sum *= Convert.ToInt32(element[b-1]); 
		else if(element[b]=="+")
			sum += Convert.ToInt32(element[b-1]);
		else if(element[b]=="/")
			sum /= Convert.ToInt32(element[b-1]);
		else if(element[b]=="-")
			sum -= Convert.ToInt32(element[b-1]);
		else
			Console.WriteLine("사칙연산만 됩니다.");
		}
		Console.WriteLine("{0}",sum);
	}
}
