using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab1
{
    public class filetest
    {
        public static void ReadFile(string name)
        {
            string dir = Directory.GetCurrentDirectory();
            string fullname = dir + "\\" + name;
            Console.WriteLine(fullname);
            StreamReader r = new StreamReader(fullname, Encoding.GetEncoding("euc-kr"));
            
            int i = 1;

            while(r.Peek() != -1) // !r.EndOfStream
            {
                string str = r.ReadLine();
                Console.WriteLine("{0}째내용: " + str,i);
                i++;
            }
            
            r.Close();
        }

        public static void WriteFile(string fullpath, bool append, string end)
        {
            StreamWriter sw = new StreamWriter(fullpath, append, Encoding.GetEncoding("euc-kr"));
            string input="";
            while (true)
            {
                Console.Write("Prompt$ ");
                input = Console.ReadLine();
                if (input == "bye")
                    break;
                sw.WriteLine(input);
            }
            sw.Close();
        }
    }
}
