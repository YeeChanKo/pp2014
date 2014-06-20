using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace miro
{
    public class Command
    {
        public const int magic = 0xFD;
        public int direction;
        public string name;
    }
    class server
    {
        public List<Command> cmd = new List<Command>();
        byte[] buf = new byte[16];
        public void start(int port)
        {
            Socket server = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPEndPoint addr = new IPEndPoint(IPAddress.Any, port);

            server.Bind(addr);
            server.Listen(10);
            while(true)
            {
                Socket client = server.Accept();
                NetworkStream ns = new NetworkStream(client);
                ns.Read(buf,0,16);
                Command c= new Command();
                if (Command.magic != buf[0])
                {
                    continue;
                }
                c.direction = (int) buf[1];
                c.name = Encoding.UTF8.GetString(buf,2,14);
                cmd.Add(c);
                ns.Close();
                client.Close();
            }
        }
    }
}
