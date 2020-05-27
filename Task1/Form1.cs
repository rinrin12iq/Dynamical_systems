using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task1
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
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            textBox4.BackColor = default;

            double A, k, h = 0.01;
            double t = 0, tmax;
            double x = 0.1, y = 0.1, z = 0.1;
            double N = 100000000000;
            A = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            k = double.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture);
            tmax = double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture);
            
            Metods metod = new Metods(A, k, h);


            while (t < tmax)
            {
                if (!(x < N && y < N && x > -N && y > -N))
                {
                    textBox4.BackColor = Color.Red;
                    break;
                }


                chart1.Series[0].Points.AddXY(x, y);
                metod.RungeKutta(x, y);
                x = metod.x;
                y = metod.y;
                t += h;
            }
        }
    }
}
