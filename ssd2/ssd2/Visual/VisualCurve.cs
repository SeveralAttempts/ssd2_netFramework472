using ssd2.Visual;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
    abstract class VisualCurve : ICurve, IDrawable, ISvgSaver
    {
        protected ICurve curve; // нужен для моста
        protected IPoint[] points = null;
        int n;
        public int N { get => n; set => n = value; }

        public VisualCurve(ICurve curve)
        {
            this.curve = curve;
        }

        public void Draw(IConcreteContext concreteContext)
        {
            points = new IPoint[n];
            System.Drawing.PointF[] p = new System.Drawing.PointF[n];

            for (int i = 0; i <= n - 1; i++)
            {
                points[i] = new Point();
                curve.GetPoint((Convert.ToDouble(i) / Convert.ToDouble(n - 1)), out points[i]);
                p[i] = new System.Drawing.PointF((float)points[i].X, (float)points[i].Y);
            }
            concreteContext.GetGraphics().DrawBezier(concreteContext.GetPen(), p[0], p[1], p[2], p[3]);
            concreteContext.GetBitmap().Save(HomePath.HP + concreteContext.GetFileName(),
                System.Drawing.Imaging.ImageFormat.Png);
        }

        public virtual void GetPoint(double t, out IPoint p)
        {
            curve.GetPoint(t, out p); //берется из Line или Bezier
        }

        public abstract void SaveSVG();
    }
}
