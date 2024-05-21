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
            color = Colors.Black;
            lineType = LineType.Dashed;
        }
    }
}
