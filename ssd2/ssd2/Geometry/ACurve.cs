using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
    abstract class ACurve : ICurve
    {
        protected VisualCurve curve;

        protected IPoint a, b;

        protected ACurve(IPoint a, IPoint b)
        {
            this.a = a;
            this.b = b;
        }

        public abstract void GetPoint(double t, out IPoint p);
    }
}
