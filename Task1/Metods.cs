using System.Windows.Forms.DataVisualization.Charting;

namespace Task1
{
    public class Metods
    {
        public double A, k, h;
        public double x, y, z;

        private Metods() { }

        public Metods(double A, double k, double h)
        {
            this.A = A;
            this.k = k;
            this.h = h;
        }

        #region  Avtogen
        private double f1(double y) => y;
        private double f2(double x, double y) => (A + k * x * x - x * x * x * x) * y - x;

        public void RungeKutta(double x, double y)
        {
            double k1, k2, k3, k4, q1, q2, q3, q4;

            k1 = h * f1(y);
            q1 = h * f2(x, y);

            k2 = h * f1(x + k1 / 2);
            q2 = h * f2(x + k1 / 2, y + q1 / 2);

            k3 = h * f1(x + k2 / 2);
            q3 = h * f2(x + k2 / 2, y + q2 / 2);

            k4 = h * f1(x + k3);
            q4 = h * f2(x + k3, y + q3);

            this.x += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            this.y += (q1 + 2 * q2 + 2 * q3 + q4) / 6;
        }
        #endregion Avtogen

        private double h1(double x)
        {
            if (x <= -1)
                x = (2 * x + 3) / 7;
            else if (x >= 1)
                x = (2 * x - 3) / 7;
            else
                x = -x / 7;

            return x;
        }

        private double g1(double y, double x) => A *(y - h1(x));
        private double g2(double x, double y, double z) => x - y + z;
        private double g3(double y) => -k * y;

        public void RungeKutta(double x, double y, double z)
        {
            double k1, k2, k3, k4, q1, q2, q3, q4, j1, j2, j3, j4;

            k1 = h * g1(x, y);
            q1 = h * g2(x, y, z);
            j1 = h * g3(y);

            k2 = h * g1(x + k1 / 2, y + q1 / 2);
            q2 = h * g2(x + k1 / 2, y + q1 / 2, z + j1 / 2);
            j2 = h * g3(y + q1 / 2);

            k3 = h * g1(x + k2 / 2, y + q2 / 2);
            q3 = h * g2(x + k2 / 2, y + q2 / 2, z + j2 / 2);
            j3 = h * g3(y + q2 / 2);

            k4 = h * g1(x + k3, y + q3);
            q4 = h * g2(x + k3, y + q3, z + j3);
            j4 = h * g3(y + q3);

            this.x += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            this.y += (q1 + 2 * q2 + 2 * q3 + q4) / 6;
            this.z += (j1 + 2 * j2 + 2 * j3 + j4) / 6;
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
