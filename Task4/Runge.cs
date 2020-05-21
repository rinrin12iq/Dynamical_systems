using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class Runge
    {
        private static double h = 0.01; 

        private static double f1(double x, double y, double b) => (1 + b * x - x * x) * x - x * y;
        private static double f2(double x, double y, double m) => x * y - m * y;

        public static void RungeKutta(ref double x, ref double y, double m, double b)
        {
            double k1, k2, k3, k4, q1, q2, q3, q4;

            k1 = h * f1(x, y, b);
            q1 = h * f2(x, y, m);

            k2 = h * f1(x + k1 / 2, y + q1 / 2, b);
            q2 = h * f2(x + k1 / 2, y + q1 / 2, m);

            k3 = h * f1(x + k2 / 2, y + q2 / 2, b);
            q3 = h * f2(x + k2 / 2, y + q2 / 2, m);

            k4 = h * f1(x + k3, y + q3, b);
            q4 = h * f2(x + k3, y + q3, m);

            x += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            y += (q1 + 2 * q2 + 2 * q3 + q4) / 6;
        }
    }
}
