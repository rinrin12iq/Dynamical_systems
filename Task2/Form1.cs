using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chartSettings(chart1);
            chartSettings(chart2);
        }
        
        double x0, A, Amax, t, tmax;
        
        private void button1_Click(object sender, EventArgs e)
        {
            double x;
            chart1.Series[0].Points.Clear();  
            A = double.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture);
            Amax = double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture);
            x0 = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);


            while (A < Amax)
            {
                t = 0;
                x = x0;
                while (t < 500)
                {
                    if (!F(A, x))
                        break;

                    if (t > 400)
                        chart1.Series[0].Points.AddXY(A, x);
                    
                    x = Function(x, A);

                    t++;
                }
                A += 0.01;
            }
        }


        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.AddXY(-2, -2);
            chart2.Series[1].Points.AddXY(2, 2);
            double xn, x = x0;
            var res = chart1.HitTest(e.X, e.Y);
            if (res.Series != null) {
                A = res.Series.Points[res.PointIndex].XValue;
                t = 0;
                tmax = double.Parse(textBox4.Text, System.Globalization.CultureInfo.InvariantCulture);

                while (t < tmax)
                {
                    xn = Function(x, A);
                    chart2.Series[0].Points.AddXY(x, xn);
                    x = xn;
                    chart2.Series[0].Points.AddXY(x, xn);
                    t++;
                } 
            }
        }

        static double Function(double x, double A) => A * (x - x * x * x);
        static bool F(double x, double y) //Придумать название
        {
            bool ifX = x > -100000000000 && x < 100000000000;
            bool ifY = y > -100000000000 && y < 100000000000;
            return ifX && ifY;
        }

        public void chartSettings(Chart chart1)
        {
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorX.Interval = 0.01;
            chart1.ChartAreas[0].CursorY.Interval = 0.01;
            chart1.ChartAreas[0].AxisX.ScrollBar.Axis.ScaleView.SmallScrollSize = 0.01;
            chart1.ChartAreas[0].AxisY.ScrollBar.Axis.ScaleView.SmallScrollSize = 0.01;
        }
    }
}
