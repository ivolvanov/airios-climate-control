using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace AiriosApplication
{
    public class Server
    {
        public void Run()
        {
            Thread.CurrentThread.IsBackground = true;
            const int PORT = 42069;
            const string ADDRESS = "192.168.1.180"; //localhost IP, must be portforwarded with public IP later 

            IPAddress ipAddr = IPAddress.Parse(ADDRESS);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, PORT);

            Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Unspecified);
            try
            {                
                listener.Bind(localEndPoint);                
                listener.Listen(10);

                while (true)
                {     
                    // Get the next connection from the queue or wait
                    Socket clientSocket = listener.Accept();

                    Worker worker = new Worker(clientSocket);
                    Thread t = new Thread(worker.Run);
                    t.Start();

                    if (Readings.ShouldStop)
                        break;
                }
            }
            catch (Exception)
            { }
        }
    }
}
            



