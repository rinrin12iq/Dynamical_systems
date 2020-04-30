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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            textBox4.BackColor = default;

            double A, k, h = 0.01;
            double t = 0, tmax;
            double x = 1, y = 1, x1 = 1.1, y1 = 1.1;
            A = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            k = double.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture);
            tmax = double.Parse(textBox3.Text);
            
            Metods metod = new Metods(A, k, h);

            while (t < tmax)
            {
                if (!(x < 90000000 && y < 90000000 && x > -90000000 && y > -90000000)&& !(x1 < 90000000 && y1 < 90000000 && x1 > -90000000 && y1 > -90000000))
                {
                    textBox4.BackColor = Color.Red;
                    break;
                }
                    
                chart1.Series[0].Points.AddXY(x, y);
                metod.RungeKutta(ref x, ref y);
                chart1.Series[1].Points.AddXY(x1, y1);
                metod.RungeKutta(ref x1, ref y1);
                t += h;
            }
        }
    }
}
