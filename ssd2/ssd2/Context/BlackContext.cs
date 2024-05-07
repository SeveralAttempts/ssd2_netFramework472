using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
    internal class BlackContext : ADrawingContext
    {
        public BlackContext()
        {
            bmp = new Bitmap(Convert.ToInt32(512), Convert.ToInt32(512));
            g = Graphics.FromImage(bmp);
            g.Clear(System.Drawing.Color.White);
            pen = new Pen(System.Drawing.Color.Black, 5);
            pen.DashStyle = DashStyle.Dash;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Square;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Square;
            fileName = "\\secondschemeimage.png";
        }
    }
}
