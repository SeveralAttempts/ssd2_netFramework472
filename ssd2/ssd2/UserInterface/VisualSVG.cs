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
    internal class VisualSVG : VisualCurve
    {
        public VisualSVG(ICurve curve) : base(curve)
        {

        }

        public override void Draw(IConcreteContext concreteContext)
        {
            points = new IPoint[n];
            for (int i = 0; i <= n - 1; i++)
            {
                points[i] = new Point();
                curve.GetPoint((Convert.ToDouble(i) / Convert.ToDouble(n - 1)), out points[i]);
            }
            string documentContent = concreteContext.GetColors() == Colors.Black ? $"<svg width=\"{512}\" height=\"{512}\" style=\"stroke-dasharray: 10 10\" xmlns=\"http://www.w3.org/2000/svg\">" +
            $"<rect x=\"{(int)points[0].X}\" y=\"{(int)points[0].Y}\" width=\"2\" height=\"2\" stroke=\"black\" fill=\"black\" stroke-width=\"5\"/>" +
            $"<path d=\"M {(int)points[0].X} {(int)points[0].Y} C {(int)points[1].X} {(int)points[1].Y}, {(int)points[2].X} {(int)points[2].Y}, {(int)points[3].X} {(int)points[3].Y}\" stroke=\"black\" fill=\"transparent\"/>" +
            $"<rect x=\"{(int)points[3].X}\" y=\"{(int)points[3].Y}\" width=\"2\" height=\"2\" stroke=\"black\" fill=\"black\" stroke-width=\"5\"/></svg>"
            : $"<svg width=\"{512}\" height=\"{512}\" xmlns=\"http://www.w3.org/2000/svg\">" +
            $"<defs>\r\n<marker id=\"arrow\" markerWidth=\"10\" markerHeight=\"10\" refX=\"0\" refY=\"3\" orient=\"auto\" markerUnits=\"strokeWidth\">\r\n<path d=\"M0,0 L0,6 L9,3 z\" fill=\"green\" />\r\n</marker>\r\n</defs>" +
            $"<circle cx=\"{(int)points[0].X}\" cy=\"{(int)points[0].Y}\" r=\"2\" fill=\"green\"/>" +
            $"<path d=\"M {(int)points[0].X} {(int)points[0].Y} C {(int)points[1].X} {(int)points[1].Y}, {(int)points[2].X} {(int)points[2].Y}, {(int)points[3].X} {(int)points[3].Y}\" stroke=\"green\" fill=\"transparent\" marker-end=\"url(#arrow)\" /></svg>";
            File.WriteAllText(HomePath.HP + "\\image.svg", documentContent);
        }
    }
}
