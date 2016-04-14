using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
namespace Client
{
    class Program
    {
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Socket Handler;
        private static Socket listener;
        static void Main(string[] args)
        {
            Console.Title = "Client";
            LoopConnect();
            ThreadStart childref = new ThreadStart(StartListening);
            Thread childThread = new Thread(childref);
            childThread.Start();
            
            SendLoop();
            Console.ReadLine();

        }

        private static void StartListening()
        {
            while (true)
            {

                byte[] receivedBuf = new byte[1024];
                int rec = _clientSocket.Receive(receivedBuf);
                byte[] data = new byte[rec];
                Array.Copy(receivedBuf, data, rec);
                if (rec > 0)
                {
                    Console.WriteLine("Call from another client");
                }

              

            }
        }

        private static void SendLoop()
        {
         
            while(true)
            {
                Console.Write("Enter Request");
                string req = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(req);

                _clientSocket.Send(buffer);

                byte[] receivedBuf = new byte[1024];

                int rec = _clientSocket.Receive(receivedBuf);
                byte[] data = new byte[rec];
                Array.Copy(receivedBuf, data, rec);
                Console.WriteLine("Received : " + Encoding.ASCII.GetString(data));

                //TcpClient lclient = listener.AcceptTcpClient();

                //NetworkStream stream = _clientSocket.GetStream();
                //byte[] ldata = new byte[_clientSocket.ReceiveBufferSize];
                //int bytesRead = stream.Read(ldata, 0, Convert.ToInt32(lclient.ReceiveBufferSize));
                //string request = Encoding.ASCII.GetString(ldata, 0, bytesRead);
                //Console.WriteLine("From another Client:" + request);

            }
        }


       

        private static void LoopConnect()
        {
            int count = 0;
           
            
            while (!_clientSocket.Connected)
            {
                try
                {
                    count++;
                    _clientSocket.Connect(IPAddress.Loopback, 100);
                }
                catch (SocketException)
                {
                    Console.Clear();
                    Console.WriteLine("Connection attepmts are: " + count.ToString());
                }
            }
            Console.Clear();
            Console.WriteLine("Connected");

        }
    }
}
