using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Metods.numberToColor(pictureBox2);
            Metods.chartSettings(chart1);
        }
        double x0, a0, amax, b0, bmax;

        private void button1_Click(object sender, EventArgs e)
        {
            double x, t, temp, xscale, yscale;
            Bitmap map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics mapGraphics = Graphics.FromImage(map);
            

            x0 = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            a0 = double.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture);
            amax = double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture);
            b0 = double.Parse(textBox5.Text, System.Globalization.CultureInfo.InvariantCulture);
            bmax = double.Parse(textBox6.Text, System.Globalization.CultureInfo.InvariantCulture);

            xscale = (amax - a0) / pictureBox1.Width;
            yscale = (bmax - b0) / pictureBox1.Height;


            double x1 = 0, y1;
            for (double a = a0; a <= amax; a += xscale)
            {
                y1 = 0;
                for (double b = bmax; b >= b0; b -= yscale)
                {
                    x = x0; t = 0;
                    while (t <= 500)
                    {
                        if (x <= 100)
                            x = Function(x, a, b);

                        t++;
                    }

                    temp = x;

                    for (int i = 0; i < 16; i++)
                    {
                        if (x <= 100)
                        {
                            x = Function(x, a, b);
                            if (Math.Abs(temp - x) < 1e-5)
                            {
                                Metods.MapDrawing(mapGraphics, i, x1, y1, xscale, yscale);
                                break;
                            }
                        }
                        else
                            mapGraphics.FillRectangle(Brushes.White, (float)(x1 / (xscale)), (float)(y1 / (yscale)), 1, 1);
                    }
                    y1 += yscale;
                }
                x1 += xscale;
            }
            pictureBox1.Image = map;
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            double a, b, x, xn;
            a = e.X *(amax - a0)/pictureBox1.Width + a0;
            b = e.Y * (bmax - b0) / pictureBox1.Height + b0;

            {
                chart1.Series[1].Points.AddXY(-2, -2);
                chart1.Series[1].Points.AddXY(2, 2);

                double k = -1.5;
                while (k < 1.5)
                {
                    chart1.Series[2].Points.AddXY(k, Function(k, a, b));
                    k += 0.01;
                }
            }

            x = x0;
            for (int i = 0; i < 25; i++)
            {
                if (Math.Abs(x) <= 10e5 && Math.Abs(x) < 150)
                {
                    xn = Function(x, a, b);
                    chart1.Series[0].Points.AddXY(x, xn);
                    x = xn;
                    chart1.Series[0].Points.AddXY(x, xn);

                    //xn = Function(x, a, b);
                    //chart1.Series[0].Points.AddXY(x, x);
                    //chart1.Series[0].Points.AddXY(xn, x);
                    //x = xn;
                    //xn = Function(x, a, b);
                    //chart1.Series[0].Points.AddXY(x, xn);
                    //x = xn;
                }
            }
        }

        static double Function(double x, double a, double b) => a + b * x - x * x * x;
    }
}
