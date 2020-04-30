using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Metods
    {
        public double A, k, h;

        private Metods() { }

        public Metods(double A, double k, double h)
        {
            this.A = A;
            this.k = k;
            this.h = h;
        }

        private double f1(double y) => y;
        private double f2(double x, double y) => (A + k * x * x - x * x * x * x) * y - x;

        public void RungeKutta(ref double x, ref double y)
        {
            double k1, k2, k3, k4, q1, q2, q3, q4, j1, j2, j3, j4;

            k1 = h * f1(y);
            q1 = h * f2(x, y);

            k2 = h * f1(x + k1 / 2);
            q2 = h * f2(x + k1 / 2, y + q1 / 2);

            k3 = h * f1(x + k2 / 2);
            q3 = h * f2(x + k2 / 2, y + q2 / 2);

            k4 = h * f1(x + k3);
            q4 = h * f2(x + k3, y + q3);

            x += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            y += (q1 + 2 * q2 + 2 * q3 + q4) / 6;
        }

    }
}
