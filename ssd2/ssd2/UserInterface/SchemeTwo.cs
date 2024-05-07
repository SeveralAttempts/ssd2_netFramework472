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
        public SchemeTwo(ICurve curve) : base(curve)
        {

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
