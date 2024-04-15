using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
    internal class Line : ACurve
    {
        public Line(IPoint a, IPoint b) : base(a, b) { }

        public override void GetPoint(double t, out IPoint p)
        {
            double x, y;
            x = (1 - t) * a.X + t * b.X;
            y = (1 - t) * a.Y + t * b.Y;
            p = new Point(x, y);
        }
    }
}
