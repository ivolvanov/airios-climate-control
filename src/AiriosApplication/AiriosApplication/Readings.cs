using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiriosApplication
{
    public static class Readings
    {
        private static DataTable data = new DataTable();
        public readonly static object readingsLock = new object();

        public static DataTable Data { get { return data; } set { data = value; } }
        /// <summary>
        /// Puts the values from a protocol-compliant message in a char[] buffer in the DataTable of the current static class
        /// </summary>
        /// <param name="buffer"></param>
        public static void GetValuesFromBuffer(char[] buffer)
        {
            string bufferString = new string(buffer);
            string[] splitBuffer = bufferString.Split(';');

            splitBuffer[0] = splitBuffer[0].Replace("#%", "");
            splitBuffer[0] = splitBuffer[0].Replace("#", "");
            splitBuffer[1] = splitBuffer[1].Replace("%", "");
            splitBuffer[3] = splitBuffer[3].Replace("%", "");
            splitBuffer[0] = splitBuffer[0].Replace(".", ","); //doubles need to be with a comma instead of a .
            splitBuffer[2] = splitBuffer[2].Replace(".", ",");
            splitBuffer[4] = splitBuffer[4].Replace("$", "");
            lock (readingsLock)
            {
                Data.Rows.Add(DateTime.Now, Convert.ToDouble(splitBuffer[0]), Convert.ToDouble(splitBuffer[2]),
                Convert.ToInt32(splitBuffer[1]), Convert.ToInt32(splitBuffer[3]), splitBuffer[4]);
            }

            // catch (Exception)
            // { }
            // This monstrosity is necessary because of unsafe threading
            // but hey, we have threads so it's a win in my book ¯\_(ツ)_/¯
            // Update: this monstrosity is no longer necessary because the unsafe threading has been fixed (graphing still causes some problems tho)
            // I'm leaving it as a comment to remind us of our progress ♿
        }

        /// <summary>
        /// Used for breaking the infinite loop in the background thread when closing the app
        /// </summary>
        public static bool ShouldStop = false;
    }
}
