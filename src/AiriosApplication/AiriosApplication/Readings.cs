﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiriosApplication
{
    public static class Readings
    {
        private static DataTable data = new DataTable();

        public static DataTable Data { get { return data; } }
        /// <summary>
        /// Puts the values from a protocol-compliant message in a char[] buffer in the DataTable of the current static class
        /// </summary>
        /// <param name="buffer"></param>
        public static void GetValuesFromBuffer(char[] buffer)
        {
            string bufferString = new string(buffer);
            string[] splitBuffer = bufferString.Split(';');
            try
            {
                splitBuffer[0] = splitBuffer[0].Replace("#%", "");
                splitBuffer[3] = splitBuffer[3].Replace("$", "");
                Data.Rows.Add(DateTime.Now, Convert.ToDouble(splitBuffer[0]), Convert.ToDouble(splitBuffer[2]),
                    Convert.ToInt32(splitBuffer[1]), Convert.ToInt32(splitBuffer[3]));
            }
            catch (Exception)
            {
                MessageBox.Show("Protocol failure!");
            }
        }

        /// <summary>
        /// Used for breaking the infinite loop in the background thread when closing the app
        /// </summary>
        public static bool ShouldStop = false;
    }
}