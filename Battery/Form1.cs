using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Battery
{
    public partial class Form1 : Form
    {
        private PowerStatus p = SystemInformation.PowerStatus;
        private BatteryChargeStatus b; 
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            b = p.BatteryChargeStatus;
            TimeSpan time = TimeSpan.FromSeconds(p.BatteryLifeRemaining);
            if (b == BatteryChargeStatus.Low && (b | BatteryChargeStatus.Charging) != BatteryChargeStatus.Charging)
            {
                progressBar1.ForeColor = Color.Yellow;
                progressBar1.Value = (int)(p.BatteryLifePercent * 100);
            }
            else
            {
                progressBar1.ForeColor = Color.Green;

            }
            if ((b & BatteryChargeStatus.Charging) == BatteryChargeStatus.Charging)
            {
                label3.Text = "Enerji toplanır";
                progressBar1.ForeColor = Color.Green;
            }
            /*else
            {
                label3.Visible = false;
            }
            label4.Text = (p.BatteryLifePercent*100 ).ToString() + "%";
            */
            else if (p.BatteryLifeRemaining < 0)
            {
                label3.Text = "Gözləyin...";
            }
            else
            {
                //label3.Text = string.Format("{ 0:D2}:{ 1:D2}:{ 2:D2}", time.Hours, time.Minutes, time.Seconds);
            }
            label4.Text = (p.BatteryLifePercent * 100).ToString() + "%";
        }
    }
}
