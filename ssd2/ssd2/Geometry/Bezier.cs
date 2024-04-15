using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
    internal class Bezier : ACurve
    {
        IPoint c, d;

        public Bezier(IPoint a, IPoint b, IPoint c, IPoint d) : base(a, b)
        {
            this.c = c;
            this.d = d;
        }

        public override void GetPoint(double t, out IPoint p)
        {
            double x, y;
            x = (1 - 3 * t + 3 * Math.Pow(t, 2) - Math.Pow(t, 3)) * a.X
                + 3 * t * (1 - 2 * t + Math.Pow(t, 2)) * c.X
                + 3 * Math.Pow(t, 2) * (1 - t) * d.X
                + Math.Pow(t, 3) * b.X;
            y = (1 - 3 * t + 3 * Math.Pow(t, 2) - Math.Pow(t, 3)) * a.Y
                + 3 * t * (1 - 2 * t + Math.Pow(t, 2)) * c.Y
                + 3 * Math.Pow(t, 2) * (1 - t) * d.Y
                + Math.Pow(t, 3) * b.Y;
            p = new Point(x, y);
        }
    }
}
