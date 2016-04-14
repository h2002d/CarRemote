using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace CarRemoteSocketConsoleApplication
{
   public class Program
    {
        private static byte[] _buffer = new byte[1024];
        private static List<Socket> _clientSockets = new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            Console.Title = "Server";
            SetupServer();
            Console.ReadLine();
        }
        private static void SetupServer()
        {
            Console.WriteLine("Setting up server...");
            //Console.WriteLine(String.Format("Server started on {0}:{1}", IPAddress.Any, 100));
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            //Console.WriteLine(_serverSocket.RemoteEndPoint);
            _serverSocket.Listen(5);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

        }
        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = _serverSocket.EndAccept(AR);
            _clientSockets.Add(socket);
            Console.WriteLine("Client Connected...");
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void RecieveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            try
            {

                int received = socket.EndReceive(AR);
                byte[] dataBuf = new byte[received];
                Array.Copy(_buffer, dataBuf, received);
                string s = Encoding.ASCII.GetString(dataBuf);
                Console.WriteLine("Text Received: " + s);
                Console.WriteLine("Checking for answer...");
                string response = string.Empty;

                switch (s.ToLower())
                {
                    case "horn":
                        response = "Horn Started";
                        break;
                    case "lock":
                        response = "Car Locked";
                        break;
                    case "engine":
                        response = "Engine Started";
                        break;
                    case "lights":
                        response = "Lights Switched";
                        break;
                    default:
                        response = String.Format("Command '{0}' is not available", s);
                        break;
                }
                //response = String.Format("Request {0} accepted", s);
                byte[] data = Encoding.ASCII.GetBytes(response);
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallback), socket);

                //Socket secondSocket = null;
                //foreach (var item in _clientSockets)
                //{
                //    if (item != socket)
                //    {
                //        secondSocket = item;
                //    }
                //}
                //if (secondSocket != null)
                //    secondSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), secondSocket);

                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                _clientSockets.Remove(socket);
            }
        }
        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        public string SendDataToMobile(string response)
        {
            byte[] data = Encoding.ASCII.GetBytes(response);
            Socket socket = (Socket)_clientSockets[0];
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            return "";
        }
    }
}
