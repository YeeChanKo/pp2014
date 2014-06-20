using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace netex1
{
    class Program
    {
        static byte[] buf = new byte[1024]; // 32bit는 4byte.

        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.Write("port: ");
            int port = Convert.ToInt32(Console.ReadLine()); // Int.Parse()로 해도됨.
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, port);
            s.Bind(ip);

            s.Listen(15); // 대기 15명.
            Console.WriteLine("서버 시작, 주소: {0}", ip.ToString()); // 모든 클래스는 tostring을 갖고 있어서 사용가능.

            while (true)
            {
                Socket t = s.Accept();
                Console.WriteLine("클라이언트 접속: {0}", t.RemoteEndPoint.ToString());
                NetworkStream ns = new NetworkStream(t);
                int len;
                while ((len = ns.Read(buf, 0, buf.Length)) != 0)
                {
                    string msg = Encoding.UTF8.GetString(buf,0,len);
                    Console.WriteLine(msg);
                    byte[] send = Encoding.UTF8.GetBytes(msg + "\r\n뭐라고?");
                    ns.Write(send, 0, send.Length);
                }
                Console.WriteLine("다 읽었음");
                ns.Close();
            }
        }
    }
}
