using System;
using System.Drawing;

namespace MyPaint
{
    internal class Circle : Shape
    {
        public Circle(int x0, int y0, int width, int height, Graphics graphics, int borderSize, Color Line) : base(x0, y0, width, height, graphics, borderSize, Line)
        {
        }

        public override Graphics Draw()
        {
            //grPath.FillMode();
            Pen p = new Pen(Line, borderSize);
            graphics.DrawEllipse(p, new Rectangle(x0, y0, width, height));
            return graphics;
        }

        public override double Square()
        {
            return Math.PI * (width / 2) * (height / 2);
        }

        public override void DoFill(Color c)
        {
            graphics.FillEllipse(new SolidBrush(c), new Rectangle(x0 + borderSize - 1, y0 + borderSize, width - borderSize - 1, height - borderSize - 1));
        }
    }
}