using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ssd2
{
    internal class GreenContext : ADrawingContext
    {
        public GreenContext()
        {
            bmp = new Bitmap(Convert.ToInt32(512), Convert.ToInt32(512));
            g = Graphics.FromImage(bmp);
            g.Clear(System.Drawing.Color.White);
            pen = new Pen(System.Drawing.Color.Green, 5);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            fileName = "\\firstschemeimage.png";
        }
    }
}
