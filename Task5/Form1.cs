using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Metods.numberToColor(pictureBox2);
        }

        double x0, y0, a0, amax, b0, bmax;

        private void button1_Click(object sender, EventArgs e)
        {
            double x, y, t, tempX, tempY, xscale, yscale;
            Bitmap map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics mapGraphics = Graphics.FromImage(map);


            x0 = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            y0 = double.Parse(textBox4.Text, System.Globalization.CultureInfo.InvariantCulture);
            a0 = double.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture);
            amax = double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture);
            b0 = double.Parse(textBox5.Text, System.Globalization.CultureInfo.InvariantCulture);
            bmax = double.Parse(textBox6.Text, System.Globalization.CultureInfo.InvariantCulture);

            yscale = (amax - a0) / pictureBox1.Width;
            xscale = (bmax - b0) / pictureBox1.Height;


            double x1 = 0, y1;
            for (double b = b0; b <= bmax; b += xscale)
            {
                y1 = 0;
                for (double a = amax; a >= a0; a -= yscale)
                {
                    x = x0; t = 0; y = y0;
                    while (t <= 500)
                    {
                        if (x <= 150 || y <= 150)
                        {
                            x = Xn(x, y, a, b);
                            y = Yn(x);
                        }

                        t++;
                    }

                    tempX = x;
                    tempY = y;

                    for (int i = 0; i < 16; i++)
                    {
                        if (x <= 150 || y <= 150)
                        {
                            x = Xn(x, y, a, b);
                            y = Yn(x);

                            if (Math.Abs(tempX - x) < 1e-5 && Math.Abs(tempY - y) < 1e-5)
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

        static double Xn(double x, double y, double a, double b) => 1 - a * x * x + b * y;
        static double Yn(double x) => x;

    }
}
