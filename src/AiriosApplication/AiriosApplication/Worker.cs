using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AiriosApplication
{
    public class Worker
    {
        private Socket socket;

        public Worker(Socket socket)
        {
            this.socket = socket;
        }
       
        public void Run()
        {
            try
            {
                NetworkStream networkStream = new NetworkStream(socket);
                StreamReader streamReader = new StreamReader(networkStream);
                StreamWriter streamWriter = new StreamWriter(networkStream);
           
                string line = streamReader.ReadLine();

                // first line always contains the request.
                string response;

                string[] parts = line.Split(' ');
                if (parts[0].ToUpper() == "GET")
                    response = "GET handled";

                else if (parts[0].ToUpper() == "POST")
                {
                    string lline = "";
                    int length = 0;
                    char[] buffer;

                    while (!lline.ToUpper().StartsWith("CONTENT-LENGTH:"))
                    {
                        lline = streamReader.ReadLine();
                        lline = lline.ToUpper();
                        if (lline.ToUpper().StartsWith("CONTENT-LENGTH:"))
                            length = Int16.Parse(lline.Substring(16));
                    }
                    while (lline != "")
                    {
                        lline = streamReader.ReadLine();
                    }

                    buffer = new char[length];
                    streamReader.Read(buffer, 0, length);
                    //Console.WriteLine(buffer);   //debugging
                    Readings.GetValuesFromBuffer(buffer);
                    response = "POST handled";
                }
                else
                {
                    streamWriter.WriteLine("HTTP/1.1 405 Method Not Allowed\r\n");
                    goto skipResponse;
                }
            
                streamWriter.Write("HTTP/1.1 200 OK\r\n");
                streamWriter.Write("Server: C# server\r\n");
                streamWriter.Write("Content-Type: text/plain\r\n");
                streamWriter.Write("Connection: Closed\r\n");
                streamWriter.Write("Content-Length: " + response.Length + "\r\n");
                streamWriter.Write("\r\n");
                streamWriter.Write(response);

                skipResponse:  //flag for goto on line 60
                streamWriter.Flush();            
                socket.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}

