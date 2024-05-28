using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
    abstract class VisualCurve : ICurve, IDrawable
    {
        protected ICurve curve; // нужен для моста
        protected IPoint[] points = null;
        protected int n;
        public int N { get => n; set => n = value; }

        public VisualCurve(ICurve curve)
        {
            this.curve = curve;
        }

        public abstract void Draw(IConcreteContext concreteContext);

        public virtual void GetPoint(double t, out IPoint p)
        {
            curve.GetPoint(t, out p); //берется из Line или Bezier
        }
    }
}
