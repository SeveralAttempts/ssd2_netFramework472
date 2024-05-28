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
        public Colors color;
        public LineType dashStyle;

        public GrapgicsConcreteContext(IDrawingContext context, string imageName = "image")
        {
            Color color = default(Color);
            DashStyle dashStyle = default(DashStyle);
            switch (context.GetColor())
            {
                case Colors.Black: color = Color.Black; this.color = Colors.Black; break;
                case Colors.Green: color = Color.Green; this.color = Colors.Green; break;
            }

            switch (context.GetLineType())
            {
                case LineType.Dashed: dashStyle = DashStyle.Dash; this.dashStyle = LineType.Dashed;
                    break;
                case LineType.Straight: dashStyle = DashStyle.Solid; this.dashStyle = LineType.Straight;
                    break;
                default:
                    break;
            }

            bmp = new Bitmap(Convert.ToInt32(512), Convert.ToInt32(512));
            g = Graphics.FromImage(bmp);
            g.Clear(System.Drawing.Color.White);
            pen = new Pen(color, 5);
            pen.DashStyle = dashStyle;
            pen.EndCap = this.color == Colors.Black ? System.Drawing.Drawing2D.LineCap.Square : System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen.StartCap = this.color == Colors.Black ? System.Drawing.Drawing2D.LineCap.Square : System.Drawing.Drawing2D.LineCap.Round;
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

        public Colors GetColors()
        {
            return color;
        }
    }
}
