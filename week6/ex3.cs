using System;

public class Data
{
	public int id;
	public string name;
	public void print()
	{
		Console.WriteLine("{0}::{1}", id, name);
	}
}

class Test
{
	static void Main()
	{
		Data a = new Data();
		a.id = 10;
		a.name = "data 1";
		a.print();
		increaseId(a);
		a.print();
	}

	static void increaseId(Data d)
	{
		d.id++;
	}
}

