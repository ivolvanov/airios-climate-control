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

namespace AiriosApplication
{
   public partial class VentilationForm : Form
   {
      private bool unit = false;
      private bool connected = false;
      private SerialPort port;
      private Thread thread;

      public VentilationForm()
      {
         InitializeComponent();
         ToolTip toolTip = new ToolTip
         {
            InitialDelay = 1000,
            ShowAlways = true
         };
         toolTip.SetToolTip(btnIncrease, "Increase fan speed");
         toolTip.SetToolTip(btnDecrease, "Decrease fan speed");
         toolTip.SetToolTip(gbFanSpeed, "Current fan speed\nClick on the value to display another unit");
         toolTip.SetToolTip(lbFanSpeed, "Current fan speed\nClick here to display another unit");
      }

      private void lbFanSpeed_MouseClick(object sender, MouseEventArgs e)
      {
         // TODO: change later
         if (unit) { gbFanSpeed.Text = "%"; }
         else { gbFanSpeed.Text = "PWM"; }
         unit = !unit;
      }

      private void VentilationForm_Load(object sender, EventArgs e)
      {
         string[] ports = SerialPort.GetPortNames();
         foreach (string serialPort in ports)
         {
            cmbConnected.Items.Add(serialPort);
            if (ports[0] != null)
            {
               cmbConnected.Enabled = true;
               cmbConnected.SelectedItem = ports[0];
               btnConnect.Enabled = true;
            }
         }
      }

      private void btnIncrease_Click(object sender, EventArgs e)
      {
         if (connected) { port.Write("#INCR\n"); }
      }

      private void btnDecrease_Click(object sender, EventArgs e)
      {
         if (connected) { port.Write("#DECR\n"); }
      }

      private void btnConnect_Click(object sender, EventArgs e)
      {
         if (!connected) { SerialConnect(); }
         else { SerialDisconnect(); }
      }

      private void SerialDisconnect()
      {
         if (connected)
         {
            connected = false;
            cmbConnected.Enabled = true;
            string ports = SerialPort.GetPortNames()[0];
            port.Write("#STOP\n");
            port.Close();
            thread.Abort();
            btnConnect.Text = "Connect";
            lbFanSpeed.Text = "0";
         }
      }

      private void SerialConnect()
      {
         connected = true;
         cmbConnected.Enabled = false;
         string selectedPort = cmbConnected.GetItemText(cmbConnected.SelectedItem);
         port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
         port.Open();
         port.Write("#STAR\n");
         thread = new Thread(SerialReceive);
         thread.Start();
         btnConnect.Text = "Disconnect";
      }

      private void VentilationForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         SerialDisconnect();
      }

      private void SerialReceive()
      {
         while (connected)
         {
            try
            {
               string received = port.ReadLine();
               lbFanSpeed.Invoke(new MethodInvoker(delegate { lbFanSpeed.Text = received; }));
            }
            catch { }
         }
      }

      private void cmbConnected_DropDown(object sender, EventArgs e)
      {
         cmbConnected.Items.Clear();
         string[] ports = SerialPort.GetPortNames();
         foreach (string port in ports)
         {
            cmbConnected.Items.Add(port);
         }
      }
   }
}
