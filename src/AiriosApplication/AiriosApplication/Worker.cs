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

        /// <summary>
        /// With this method we accept the data sent and redirect it to the Readings class for parsing. 
        /// </summary>
        public void Run()
        {
            try
            {
                NetworkStream networkStream = new NetworkStream(socket);        //we open the streams we need for reading/writing
                StreamReader streamReader = new StreamReader(networkStream);
                StreamWriter streamWriter = new StreamWriter(networkStream);

                string line = streamReader.ReadLine();

                // first line always contains the request.
                string response;

                string[] parts = line.Split(' ');       //we get the type of request so that we know how to proceed 
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
                        if (lline.ToUpper().StartsWith("CONTENT-LENGTH:"))      //we extract the content length in bytes
                            length = Int16.Parse(lline.Substring(16));
                    }
                    while (lline != "")
                    {
                        lline = streamReader.ReadLine();                    //we read until the end of the header
                    }

                    buffer = new char[length];
                    streamReader.Read(buffer, 0, length);               //and we read the body with the content length we earlier took
                    //Console.WriteLine(buffer);   //debugging                    
                    Readings.GetValuesFromBuffer(buffer);
                    response = "POST handled";
                }
                else
                {
                    streamWriter.WriteLine("HTTP/1.1 405 Method Not Allowed\r\n");      //if the request is different than POST or GET
                    goto skipResponse;
                }

                streamWriter.Write("HTTP/1.1 200 OK\r\n");          //sending response
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

