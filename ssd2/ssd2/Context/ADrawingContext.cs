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
        protected Graphics g;
        protected Pen pen;
        protected Bitmap bmp;
        protected string fileName;

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
