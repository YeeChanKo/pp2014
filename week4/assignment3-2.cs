using System;

class assignment3_2
{
	public static void Main(string[] args)
	{
		int i=1;
		int j=1;

		do
		{
			do
			{
				Console.Write("*");
				j++;
			}while(j<=6-i);

		Console.WriteLine();
		i++;
		j=1;
		}while(i<6);//그렇다..do{}while()문 뒤에 꼭 세미콜론을 붙여줬어야 했다...ㅜㅜ
	}
}
