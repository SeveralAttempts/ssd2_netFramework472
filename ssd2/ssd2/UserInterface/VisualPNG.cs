using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ssd2
{
    internal class VisualPNG : VisualCurve
    { 
        public VisualPNG(ICurve curve) : base(curve)
        {

        }

        public override void Draw(IConcreteContext concreteContext)
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
    }
}
