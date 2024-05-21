using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ssd2
{
    enum Colors
    {
        Green,
        Black
    }

    enum LineType
    {
        Dashed,
        Straight
    }

    internal interface IDrawingContext
    {
        LineType GetLineType();
        Colors GetColor();
    }
}
