using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ssd2
{
    internal interface IDrawingContext
    {
        Graphics GetGraphics();
        Pen GetPen();
        Bitmap GetBitmap();
        string GetFileName();
    }
}
