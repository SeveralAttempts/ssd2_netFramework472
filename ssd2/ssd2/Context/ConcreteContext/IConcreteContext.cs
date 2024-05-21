using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
    internal interface IConcreteContext
    {
        Bitmap GetBitmap();

        string GetFileName();

        Graphics GetGraphics();

        Pen GetPen();
    }
}
