using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

/*
 * Usage:
 * IP = 192.168.0.105 in my case, localhost IP
 * curl -d "some Random data" IP:42069 = POST request, response expected = "POST Handled" & POST data printed in server console (max 17 chars)
 * curl IP:42069 = GET request, response expected = "GET Handled"
 * 
 * NOTICE: cuts 2 characters from a curl request from the POST body. Works properly with an ESP-made requests.
 */


namespace httpdemo
{
    class Program
    {   private const int PORT = 42069;
        private const string ADDRESS = "192.168.0.105"; //localhost IP, must be portforwarded with public IP later

        static void Main(string[] args)
        {
            IPAddress ipAddr = IPAddress.Parse(ADDRESS);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, PORT);

            Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Unspecified);

            try {
                // Bind to the endpoint
                listener.Bind(localEndPoint);

                // Start listening
                listener.Listen(10);

                while (true) // forever
                {
                    Console.WriteLine($"HTTP Server listening on port {PORT}");

                    // Get the next connection from the queue or wait
                    Socket clientSocket = listener.Accept();

                    Worker worker = new Worker(clientSocket);
                    
                    Thread t = new Thread(worker.run);
                    t.Start();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("HTTP Server quitting");
        }
    }
}
