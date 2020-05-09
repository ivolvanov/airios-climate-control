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

namespace AiriosApplication
{
   public partial class VentilationForm : Form
   {
      private bool unit = false;

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
         // TODO: get fan speed
      }

      private void btnIncrease_Click(object sender, EventArgs e)
      {
         // TODO: increase fan speed - get fan speed as result
      }

      private void btnDecrease_Click(object sender, EventArgs e)
      {
         // TODO: decrease fan speed - get fan speed as result
      }
   }
}
