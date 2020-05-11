using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace AiriosApplication
{
   public partial class VentilationForm : Form
   {
      private bool unit = false;
      private bool connected = false;
      private SerialPort port;
      private Thread thread;
      private string received = "0";

      public VentilationForm()
      {
         InitializeComponent();
         ToolTip toolTip = new ToolTip // Create ToolTip and associate with the Form container
         {
            InitialDelay = 500, // Milliseconds transpired before appearing
            ShowAlways = true // Force ToolTip text to display
         };
         // Set all necessary ToolTips
         toolTip.SetToolTip(btnIncrease, "Increase fan speed");
         toolTip.SetToolTip(btnDecrease, "Decrease fan speed");
         toolTip.SetToolTip(gbFanSpeed, "Current fan speed\nClick on the value to display another unit");
         toolTip.SetToolTip(lbFanSpeed, "Current fan speed\nClick here to display another unit");
         toolTip.SetToolTip(cmbConnected, "Select an available fan");
         toolTip.SetToolTip(btnConnect, "Click to connect or disconnect the fan");
      }

      private void lbFanSpeed_MouseClick(object sender, MouseEventArgs e) // Select unit to display
      {
         if (unit) // Set to percentage of total
         {
            gbFanSpeed.Text = "%";
            lbFanSpeed.Text = ((Convert.ToInt32(received) * 100) / 180).ToString();
         }
         else // Set to degrees
         {
            gbFanSpeed.Text = "°";
            lbFanSpeed.Text = received;
         }
         unit = !unit;
      }

      private void btnIncrease_Click(object sender, EventArgs e)
      {
         // Increase degree if connected
         if (connected)
         {
            try
            {
               port.Write("#INCR\n");
            }
            catch
            {
               SerialDisconnect(); // Shut down application if fan disconnected
            }
         }
      }

      private void btnDecrease_Click(object sender, EventArgs e)
      {
         // Increase degree if connected
         if (connected)
         {
            try
            {
               port.Write("#DECR\n");
            }
            catch
            {
               SerialDisconnect(); // Shut down application if fan disconnected
            }
         }
      }

      private void btnConnect_Click(object sender, EventArgs e)
      {
         if (!connected) { SerialConnect(); } // Connect if unconnected
         else { SerialDisconnect(); } // Disconnect if connected
      }

      private void SerialDisconnect()
      {
         if (connected) 
         {
            try // Try disconnecting normally
            {
               connected = false;
               cmbConnected.Enabled = true;
               cmbConnected.Text = string.Empty;
               port.Write("#STOP\n");
               port.Close();
               thread.Abort();
               btnConnect.Text = "Connect";
               lbFanSpeed.Text = "0";
            }
            catch // Otherwise shut down application
            {
               MessageBox.Show("Device disconnected abruptly. Aborting application.", "Device Disconnected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               Application.Exit();
            }
         }
      }

      private void SerialConnect()
      {
         string[] serialPorts = SerialPort.GetPortNames();
         if (serialPorts.Contains(cmbConnected.Text)) // Add selected COM port
         {
            port = new SerialPort(cmbConnected.Text, 9600, Parity.None, 8, StopBits.One);
            connected = true;
            cmbConnected.Enabled = false;
            port.Open();
            port.Write("#STAR\n");
            thread = new Thread(SerialReceive);
            thread.Start();
            btnConnect.Text = "Disconnect";
         }
         else
         {
            cmbConnected.Text = string.Empty;
            btnConnect.Enabled = false;
         }
      }

      private void VentilationForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         SerialDisconnect(); // Send stop message to fan
      }

      private void SerialReceive()
      {
         // Set string to received data
         while (connected) 
         {
            try
            {
               received = port.ReadLine();
               lbFanSpeed.Invoke(new MethodInvoker(delegate {
                  if (unit)
                  {
                     lbFanSpeed.Text = received;
                  }
                  else
                  {
                     lbFanSpeed.Text = ((Convert.ToInt32(received) * 100) / 180).ToString();
                  }
               }));
            }
            catch { }
         }
      }

      private void cmbConnected_DropDown(object sender, EventArgs e)
      {
         // Set dropdown items
         cmbConnected.Items.Clear();
         string[] ports = SerialPort.GetPortNames();
         foreach (string port in ports)
         {
            cmbConnected.Items.Add(port);
         }
      }

      private void cmbConnected_TextChanged(object sender, EventArgs e)
      {
         // Verify user input by matching available COM port
         string[] serialPorts = SerialPort.GetPortNames();
         if (serialPorts.Contains(cmbConnected.Text))
         {
            btnConnect.Enabled = true;
         }
         else
         {
            btnConnect.Enabled = false;
         }
      }
   }
}
