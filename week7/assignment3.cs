using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public static int Total=0;
    public string Name;
}

class assignment3
{
    static void Main()
    {
        string nameinput;
        Console.WriteLine("학생 이름을 입력하세요.(q: 종료)");
        List<Student> rist = new List<Student>();
        do
        {
            nameinput = Console.ReadLine();
            Student stu = new Student { Name = nameinput }; // 이 부분 원리???
            rist.Add(stu);
            Student.Total++;
        }while(nameinput != "q");
        
        Student.Total--;
        rist.RemoveAt(rist.Count-1);
                
        Console.Write("몇명 선택하시겠습니까? (1-{0}) ", rist.Count);
        int numofpp = Convert.ToInt32(Console.ReadLine());

        Random r = new Random();
        int randomindex;
        List<string> namelist = new List<string>();

        for (int i = 0; i < numofpp; i++)
        {
            do
            {
                randomindex = r.Next(0, rist.Count);
            } while (namelist.IndexOf(rist.ElementAt(randomindex).Name) != -1);
            namelist.Add(rist.ElementAt(randomindex).Name);
        }

        foreach (string i in namelist)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("님이 밥을 사세요.");
    }
}
