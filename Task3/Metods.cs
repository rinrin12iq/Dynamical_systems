using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Task3
{
    public static class Metods
    {
        private static Color[] color = new Color[] { Color.Navy, Color.Red, Color.Blue, Color.Purple
                , Color.SkyBlue, Color.Olive, Color.Black, Color.Aqua, Color.Coral, Color.Yellow
            , Color.DarkGreen, Color.Fuchsia, Color.Lime, Color.Brown, Color.Gray, Color.Orange};
        public static void chartSettings(Chart chart1)
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

        public static void MapDrawing(Graphics map, int p, double a, double b, double xscale, double yscale)
        {
            map.FillRectangle(new SolidBrush(color[p]), (float)(a / (xscale)), (float)(b / (yscale)), 1, 1);
        }

        public static void numberToColor(PictureBox box)
        {
            Bitmap bitmap = new Bitmap(box.Width, box.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            for (int i = 0; i < 16; i++)
            {
                graphics.FillRectangle(new SolidBrush(color[i]), 0, 25 * i + 5, 15, 15);
                graphics.DrawString($"{i + 1}", new Font("Arial", 14), Brushes.Black, 15, 25 * i + 5);
            }
            box.Image = bitmap;
        }
    }
}
