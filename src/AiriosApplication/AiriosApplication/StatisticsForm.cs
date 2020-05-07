using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiriosApplication
{
   public partial class StatisticsForm : Form
   {
      public StatisticsForm()
      {
         InitializeComponent();
      }

      private void StatisticsForm_Load(object sender, EventArgs e)
      {
         ToolTip toolTip = new ToolTip // Create ToolTip and associate with the Form container
         {
            InitialDelay = 1000, // Milliseconds transpired before appearing
            ShowAlways = true // Force ToolTip text to display
         };
         // Set all necessary ToolTips
         toolTip.SetToolTip(gbGraph, "Data from sensor visualized");
         toolTip.SetToolTip(chartStats, "Data from sensor visualized");
         toolTip.SetToolTip(gbData, "Collected data from sensors");
      }
   }
}
