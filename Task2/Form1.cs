using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorX.Interval = 0.01;
            chart1.ChartAreas[0].CursorY.Interval = 0.01;
            chart1.ChartAreas[0].AxisX.ScrollBar.Axis.ScaleView.SmallScrollSize = 0.01;
            chart1.ChartAreas[0].AxisY.ScrollBar.Axis.ScaleView.SmallScrollSize = 0.01;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            
            double x, A, t = 0, tmax;
            x = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            A = double.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture);
            tmax = double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture);

            while (t < tmax)
            {
                if (!F(t, x))
                    break;

                chart1.Series[0].Points.AddXY(t, x);
                x = Function(x, A);
                t += 0.01;
            }
        }

        static double Function(double x, double A) => A * (x - x * x * x);
        static bool F(double x, double y) //Придумать название
        {
            bool ifX = x > -100000000000 && x < 100000000000;
            bool ifY = y > -100000000000 && y < 100000000000;
            return ifX && ifY;
        }
    }
}
