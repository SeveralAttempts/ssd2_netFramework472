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
            color = Colors.Green;
            lineType = LineType.Straight;
        }
    }
}
