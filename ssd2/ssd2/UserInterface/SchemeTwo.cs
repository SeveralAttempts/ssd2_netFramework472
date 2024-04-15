using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace ssd2
{
    internal class SchemeTwo : VisualCurve
    {
        IPoint[] points = null;

        public SchemeTwo(ICurve curve) : base(curve)
        {

        }

        public override void Draw(int n)
        {
            points = new IPoint[n];
            System.Drawing.PointF[] p = new System.Drawing.PointF[n];
            Bitmap bitmap = new Bitmap(Convert.ToInt32(512), Convert.ToInt32(512));
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(System.Drawing.Color.White);
            Pen pen = new Pen(System.Drawing.Color.Black, 5);
            pen.DashStyle = DashStyle.Dash;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;

            for (int i = 0; i <= n - 1; i++)
            {
                points[i] = new Point();
                curve.GetPoint((Convert.ToDouble(i) / Convert.ToDouble(n - 1)), out points[i]);
                p[i] = new System.Drawing.PointF((float)points[i].X, (float)points[i].Y);
            }
            g.DrawBezier(pen, p[0], p[1], p[2], p[3]);
            if (System.IO.File.Exists(HomePath.HP + "\\secondschemeimage.png"))
                System.IO.File.Delete(HomePath.HP + "\\secondschemeimage.png");
            bitmap.Save(HomePath.HP + "\\secondschemeimage.png",
                System.Drawing.Imaging.ImageFormat.Png);
        }

        public override void SaveSVG()
        {
            string documentContent = $"<svg width=\"{512}\" height=\"{512}\" style=\"stroke-dasharray: 10 10\" xmlns=\"http://www.w3.org/2000/svg\">" +
                $"<rect x=\"{(int)points[0].X}\" y=\"{(int)points[0].Y}\" width=\"2\" height=\"2\" stroke=\"black\" fill=\"black\" stroke-width=\"5\"/>" +
                $"<path d=\"M {(int)points[0].X} {(int)points[0].Y} C {(int)points[1].X} {(int)points[1].Y}, {(int)points[2].X} {(int)points[2].Y}, {(int)points[3].X} {(int)points[3].Y}\" stroke=\"black\" fill=\"transparent\"/>" +
                $"<rect x=\"{(int)points[3].X}\" y=\"{(int)points[3].Y}\" width=\"2\" height=\"2\" stroke=\"black\" fill=\"black\" stroke-width=\"5\"/></svg>";
            File.WriteAllText(HomePath.HP + "\\schemetwosvg.svg", documentContent);
        }
    }
}
