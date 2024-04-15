using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ssd2
{
    internal class SchemeOne : VisualCurve
    {
        IPoint[] points = null;
        public SchemeOne(ICurve curve) : base(curve)
        {

        }

        public override void Draw(int n)
        {
            points = new IPoint[n];
            System.Drawing.PointF[] p = new System.Drawing.PointF[n];
            Bitmap bitmap = new Bitmap(Convert.ToInt32(512), Convert.ToInt32(512));
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(System.Drawing.Color.White);
            Pen pen = new Pen(System.Drawing.Color.Green, 5);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;

            for (int i = 0; i <= n - 1; i++)
            {
                points[i] = new Point();
                curve.GetPoint((Convert.ToDouble(i) / Convert.ToDouble(n - 1)), out points[i]);
                p[i] = new System.Drawing.PointF((float)points[i].X, (float)points[i].Y);
            }
            g.DrawBezier(pen, p[0], p[1], p[2], p[3]);         
            bitmap.Save(HomePath.HP + "\\firstschemeimage.png",
                System.Drawing.Imaging.ImageFormat.Png);
        }

        public override void SaveSVG()
        {
            string documentContent = $"<svg width=\"{512}\" height=\"{512}\" xmlns=\"http://www.w3.org/2000/svg\">" +
                $"<defs>\r\n<marker id=\"arrow\" markerWidth=\"10\" markerHeight=\"10\" refX=\"0\" refY=\"3\" orient=\"auto\" markerUnits=\"strokeWidth\">\r\n<path d=\"M0,0 L0,6 L9,3 z\" fill=\"green\" />\r\n</marker>\r\n</defs>" +
                $"<circle cx=\"{(int)points[0].X}\" cy=\"{(int)points[0].Y}\" r=\"2\" fill=\"green\"/>" +
                $"<path d=\"M {(int)points[0].X} {(int)points[0].Y} C {(int)points[1].X} {(int)points[1].Y}, {(int)points[2].X} {(int)points[2].Y}, {(int)points[3].X} {(int)points[3].Y}\" stroke=\"green\" fill=\"transparent\" marker-end=\"url(#arrow)\" /></svg>";
            File.WriteAllText(HomePath.HP + "\\schemeonesvg.svg", documentContent);
        }
    }
}
