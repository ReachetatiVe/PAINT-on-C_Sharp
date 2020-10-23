using System;
using System.Drawing;

namespace MyPaint {

    [Serializable]
    internal class Circle : Shape {

        public Circle(Point startPoint, Point endPoint, int borderSize, Color borderColor) : base(borderSize, borderColor) {
            points = new Point [2];

            points [0] = startPoint; //левая верхняя
            points [1] = endPoint; // правая нижняя
        }

        public override Graphics Draw(Graphics graphics) {
            Pen p = new Pen(BorderColor, BorderSize);
            graphics.DrawEllipse(p, new Rectangle(points [0].X, points [0].Y, points [1].X - points [0].X, points [1].Y - points [0].Y));
            return graphics;
        }

        public override bool Touch(Point pointForCheck) {
            int x = pointForCheck.X - points [0].X - (points [1].X - points [0].X) / 2;
            int y = pointForCheck.Y - points [0].Y - (points [1].Y - points [0].Y) / 2;
            double a = (points [1].X - points [0].X) / 2; //большая полуось
            double b = (points [1].Y - points [0].Y) / 2; //малая медведица
            double tmp = Math.Pow(x / a, 2) + Math.Pow(y / b, 2);
            if (tmp <= 1)
                return true;
            else
                return false;
        }

        public override void DoFill(Graphics graphics) {
            graphics.FillEllipse(new SolidBrush(FillColor), new Rectangle(points [0].X, points [0].Y, points [1].X - points [0].X, points [1].Y - points [0].Y));
            Pen p = new Pen(BorderColor, BorderSize);
            graphics.DrawEllipse(p, new Rectangle(points [0].X, points [0].Y, points [1].X - points [0].X, points [1].Y - points [0].Y));
        }
    }
}