using System;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

namespace httpdemo
{
    public class Worker
    {
        private Socket socket;

        public Worker(Socket socket)
        {
            this.socket = socket;
        }

        public void run()
        {
           
            // Setup streams to read & write
            NetworkStream networkStream = new NetworkStream(socket);
            StreamReader streamReader = new StreamReader(networkStream);
            StreamWriter streamWriter = new StreamWriter(networkStream);
            string line = streamReader.ReadLine();
            // first line always contains the request.
            string response;
            Console.WriteLine(line);
            /* string lline = streamReader.ReadLine();
            Console.WriteLine(lline);
            lline = streamReader.ReadLine();
            Console.WriteLine(lline);
            lline = streamReader.ReadLine();
            Console.WriteLine(lline);
            lline = streamReader.ReadLine();
            Console.WriteLine(lline);
            lline = streamReader.ReadLine();     
            Console.WriteLine(lline);
            lline = streamReader.ReadLine();
            Console.WriteLine(lline);            //empty line        */

            string[] parts = line.Split(' ');
            if (parts[0].ToUpper() == "GET")
            {
                response = "GET handled";
            }
            else if (parts[0].ToUpper() == "POST")
            {
                response = "POST handled";
            }
            else
            {
                streamWriter.WriteLine("HTTP/1.1 405 Method Not Allowed\r\n");
                goto skipResponse;
            }

            string uri = parts[2];
            Console.WriteLine(uri);
            // ignore http version
            streamWriter.Write("HTTP/1.1 200 OK\r\n");
            streamWriter.Write("Server: C# server\r\n");
            streamWriter.Write("Content-Type: text/plain\r\n");
            streamWriter.Write("Connection: Closed\r\n");
            streamWriter.Write("Content-Length: " + response.Length + "\r\n");
            streamWriter.Write("\r\n");
            streamWriter.Write(response);

            skipResponse:  //flag for goto on line 44
            streamWriter.Flush();
            // Client disconnected
            Console.WriteLine("Disconnect");
            socket.Close();
        }
    }
}
