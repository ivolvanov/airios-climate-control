using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.IO.Ports;
using System.Management;
using System.Runtime.Remoting.Channels;

namespace AiriosApplication
{
   public static class SerialPortService
   {
      //private static SerialPort serialPort;
      //private static string[] serialPorts;
      //private static ManagementEventWatcher arrival;
      //private static ManagementEventWatcher removal;

      //static SerialPortService()
      //{
      //   serialPorts = SerialPort.GetPortNames();
      //}

      //public static void CleanUp()
      //{
      //   arrival.Stop();
      //   removal.Stop();
      //}


      //public static event EventHandler<PortsChangedArgs> PortsChanged;

      //private static void MonitorDeviceChanges()
      //{
      //   try
      //   {
      //      var deviceArrivalQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
      //      var deviceRemovalQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");

      //      arrival = new ManagementEventWatcher(deviceArrivalQuery);
      //      removal = new ManagementEventWatcher(deviceRemovalQuery);

      //      arrival.EventArrived += (o, args) => RaisePortsChanged(EventType.Insertion);
      //      removal.EventArrived += (sender, eventArgs) => RaisePortsChanged(EventType.Removal);

      //      arrival.Start();
      //      removal.Start();
      //   }
      //   catch { }
      //}

      //private enum EventType
      //{
      //   Insertion,
      //   Removal,
      //}

      //private static void RaisePortsChanged(EventType eventType)
      //{
      //   lock (serialPorts)
      //   {
      //      var availableSerialPorts = SerialPort.GetPortNames();
      //      if (!serialPorts.SequenceEqual(availableSerialPorts))
      //      {
      //         serialPorts = availableSerialPorts;
      //         //PortsChanged.Raise(null, new PortsChangedArgs(eventType, serialPorts));
      //      }
      //   }
      //}
   }
}
