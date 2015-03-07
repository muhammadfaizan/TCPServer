using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace PCFileTransferTCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 8080);
            Console.WriteLine("Listening...");
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("[Client Connected]");
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            int data = stream.Read(buffer, 0, buffer.Length);

            string str = Encoding.Unicode.GetString(buffer, 0, data);
            Console.WriteLine("Message Received:"+  str);
            client.Close();
            Console.ReadLine();
        }
    }
}
