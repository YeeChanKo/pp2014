using System;

public class NumPuzzle
{
	public string name;
	private int[,] mData;
	private int mSize;
	
	public void Init(int size)
	{
		mSize = size;
		mData = new int[mSize,mSize];
		for(int i=0;i<mSize;i++)
			for(int j=0;j<mSize;j++)
				mData[i,j]=(j+1)+mSize*i;
		mData[mSize-1,mSize-1]=0;
	}
	
	public string FindMove()
	{
		int x = 0;
		int y = 0;
		for(int i=0;i<mSize;i++)
			for(int j=0;j<mSize;j++)
			{	if(isMove(i, j))
				{	x = i;
					y = j;
				}
			}
		FindAvail(x-1,y);
		FindAvail(x+1,y);
		FindAvail(x,y-1);
		FindAvail(x,y+1);
		
		return "1 1";
	}

	public void FindAvail(int a, int b)
	{
		if((a>=0)&&(a<mSize)&&(b>=0)&&(b<mSize))
			Console.WriteLine(a+" "+b);
	}

	private bool isMove(int row, int col)
	{
		if(mData[row,col]==0)
			return true;
		else
			return false;
	}
}

class Test
{
	static void Fail(string msg)
	{
		Console.WriteLine(msg);
		Environment.Exit(1);
	}

	static void Main()
	{
		NumPuzzle np1 = new NumPuzzle();

		np1.Init(3); // 1 2 3 4 5 6 7 8 0
		
		string avail = np1.FindMove();
		if(avail != "6 8")
			Fail("FindMove Test Fail");
		Console.WriteLine("test1 success!!");
	}
}
