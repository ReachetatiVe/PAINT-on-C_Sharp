using System.Drawing;

namespace MyPaint
{
    internal class Shape
    {
        public int x0 { get; set; }
        public int y0 { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public int borderSize { get; set; }
        public Color Fill { get; set; }
        public Color Line { get; set; }
        public Graphics graphics { get; set; }

        public Shape(int x0, int y0, int width, int height, Graphics graphics, int borderSize, Color Line)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.width = width;
            this.height = height;
            this.graphics = graphics;
            this.borderSize = borderSize;
            this.Line = Line;
        }

        virtual public Graphics Draw()
        {
            return graphics;
        }

        virtual public double Square()
        {
            return 0;
        }

        public bool Touch(Point p)
        {
            if (p.X > x0 && p.Y > y0 && p.X < x0 + width && p.Y < height + y0)
                return true;
            else
                return false;
        }

        public virtual void DoFill(Color c)
        {
        }
    }
}