using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ssd2
{
    abstract class ADrawingContext : IDrawingContext
    {
        protected Colors color;
        protected LineType lineType;

        public Colors GetColor()
        {
            return color;
        }

        public LineType GetLineType()
        {
            return lineType;
        }
    }
}
