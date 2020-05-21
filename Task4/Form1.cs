using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double m, mmax, m1, m2, b, bmax;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();



            m = double.Parse(textBox1.Text);
            mmax = double.Parse(textBox2.Text);
            //b = double.Parse(textBox3.Text);
            //bmax = double.Parse(textBox4.Text);

            m1 = m2 = m;

            while (m1 < mmax)
            {
                b = -m1 * 2 / 3;
                if ((m1 * (1 + b * m1 - m1 * m1)) > 0)
                {
                    chart1.Series[0].Points.AddXY(m1, b);
                }

                m1 += 0.1;
            }

            while (m2 < mmax)
            {
                b = m2 - 1 / m2;
                if (Math.Abs(-3 * b * m - 2 * m * m) > 1e-5 && Math.Abs(b) < 20)
                {
                    if (m2 < 0)
                        chart1.Series[1].Points.AddXY(m2, b);
                    else
                        chart1.Series[2].Points.AddXY(m2, b);
                }

                m2 += 0.1;
            }
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            chart2.Series[0].Points.Clear();

            double m, b;


            //var res = chart1.HitTest(e.X, e.Y);
            //if (res.Series != null)
            //{
            double x = 0.01, y = 0.01;
            double t = 0, tmax = 100;


            var res = GetAxisValuesFromMouse(e.X, e.Y);
            m = res.Item1;
            b = res.Item2; 

            //m = res.Series.Points[res.PointIndex].XValue;
            //b = res.Series.Points[res.PointIndex].YValues.First();

            while (t < tmax)
            {
                if (Math.Abs(x) < 1e10 || Math.Abs(y) < 1e10)
                {
                    chart2.Series[0].Points.AddXY(x, y);
                    Runge.RungeKutta(ref x, ref y, m, b);
                }
                t += 0.01;
            }
            // }

           
        }
        private Tuple<double, double> GetAxisValuesFromMouse(int x, int y)
        {
            var chartArea = chart1.ChartAreas[0];
            var xValue = chartArea.AxisX.PixelPositionToValue(x);
            var yValue = chartArea.AxisY.PixelPositionToValue(y);
            return new Tuple<double, double>(xValue, yValue);
        }
    }
}
