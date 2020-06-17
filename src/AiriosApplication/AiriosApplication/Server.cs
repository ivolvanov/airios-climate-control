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

        /// <summary>
        /// With this command we run the server.
        /// We create a "handler" for the streams and all the data parsing on a new thread,
        /// every time there is a new request incoming.
        /// </summary>
        public void Run()
        {
            Thread.CurrentThread.IsBackground = true;
            const int PORT = 42069;                     //The desired port for the server, this is the port that you would portforward if needed.
            const string ADDRESS = "192.168.1.180";   //the IP of the computer this server is going to run on (must be used the IP that the router assigned to the PC

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
            



