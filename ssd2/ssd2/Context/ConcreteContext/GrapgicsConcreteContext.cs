using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
    internal class GrapgicsConcreteContext : IConcreteContext
    {

        public Graphics g;
        public Pen pen;
        public Bitmap bmp;
        public string fileName;

        public GrapgicsConcreteContext(IDrawingContext context, string imageName)
        {
            Color color = default(Color);
            DashStyle dashStyle = default(DashStyle);
            switch (context.GetColor())
            {
                case Colors.Black: color = Color.Black; break;
                case Colors.Green: color = Color.Green; break;
            }

            switch (context.GetLineType())
            {
                case LineType.Dashed: dashStyle = DashStyle.Dash;
                    break;
                case LineType.Straight: dashStyle = DashStyle.Solid;
                    break;
                default:
                    break;
            }

            bmp = new Bitmap(Convert.ToInt32(512), Convert.ToInt32(512));
            g = Graphics.FromImage(bmp);
            g.Clear(System.Drawing.Color.White);
            pen = new Pen(color, 5);
            pen.DashStyle = dashStyle;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            fileName = "\\" + imageName + ".png";
        }

        public Bitmap GetBitmap()
        {
            return bmp;
        }

        public string GetFileName()
        {
            return fileName;
        }

        public Graphics GetGraphics()
        {
            return g;
        }

        public Pen GetPen()
        {
            return pen;
        }
    }
}
