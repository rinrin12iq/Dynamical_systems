﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            //chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true; //?
            chart1.ChartAreas[0].CursorX.Interval = 0.01;
            chart1.ChartAreas[0].CursorY.Interval = 0.01;
            chart1.ChartAreas[0].AxisX.ScrollBar.Axis.ScaleView.SmallScrollSize = 0.01;
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
            double x = 1, y = 1;
            A = double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            k = double.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture);
            tmax = double.Parse(textBox3.Text, System.Globalization.CultureInfo.InvariantCulture);
            
            Metods metod = new Metods(A, k, h);


            for (int i = 0; i <= 4; i++)
            {
                x = 1 + (double)i / 100; y = 1 + (double)i / 100; t = 0;

                while (t < tmax)
                {
                    if (!(x < 90000000000 && y < 90000000000 && x > -90000000000 && y > -90000000000))
                    {
                        textBox4.BackColor = Color.Red;
                        break;
                    }

                    chart1.Series[i].Points.AddXY(x, y);
                    metod.RungeKutta(ref x, ref y);
                    t += h;
                }
            }
        }
    }
}
