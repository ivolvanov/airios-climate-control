using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiriosApplication
{
    public static class Readings
    {
        private static List<double> temperature = new List<double>();
        private static List<double> humidity = new List<double>();
        private static List<int> co2 = new List<int>();
        private static List<int> voc = new List<int>();

        public static List<double> Temperature { get { return temperature; } }
        public static List<double> Humidity { get { return humidity; } }
        public static List<int> Co2 { get { return co2; } }
        public static List<int> Voc { get { return voc; } }


        /// <summary>
        /// Puts the values from a protocol-compliant message in a char[] buffer in the according lists of the current static class
        /// </summary>
        /// <param name="buffer"></param>
        public static void GetValuesFromBuffer(char[] buffer)
        {
            String bufferString = new String(buffer);
            String[] splitBuffer = bufferString.Split(';');
            try
            {
                splitBuffer[0] = splitBuffer[0].Replace("#%", "");
                temperature.Add(Convert.ToDouble(splitBuffer[0]));

                co2.Add(Convert.ToInt32(splitBuffer[1]));

                humidity.Add(Convert.ToDouble(splitBuffer[2]));
                
                splitBuffer[3] = splitBuffer[3].Replace("$", "");
                voc.Add(Convert.ToInt32(splitBuffer[3]));

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
