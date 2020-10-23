using System;
using System.Drawing;

namespace MyPaint {

    [Serializable]
    internal abstract class Shape {
        public int BorderSize { get; set; }
        public Color FillColor { get; set; }
        public Color BorderColor { get; set; }

        protected Point [] points;

        public Shape(int borderSize, Color borderColor) {
            BorderSize = borderSize;
            BorderColor = borderColor;
        }

        public virtual Graphics Draw(Graphics graphics) {
            Pen p = new Pen(BorderColor, BorderSize);
            graphics.DrawPolygon(p, points);
            return graphics;
        }

        public virtual double Square() {
            return 0;
        }

        public virtual bool Touch(Point pointForCheck) {
            bool c = false;

            //#Алгоритм(сложный(быстрый))

            for (int i = 0, j = points.Length - 1; i < points.Length; j = i++) {
                if (
                    (
                        ((points [i].Y <= pointForCheck.Y) && (pointForCheck.Y < points [j].Y)) || ((points [j].Y <= pointForCheck.Y) && (pointForCheck.Y < points [i].Y))
                    ) &&
                  (
                        ((points [j].Y - points [i].Y) != 0) && (pointForCheck.X > ((points [j].X - points [i].X) * (pointForCheck.Y - points [i].Y) / (points [j].Y - points [i].Y) + points [i].X)))
                  )
                    c = !c;
            }
            return c;
        }

        public virtual void DoFill(Graphics graphics) {
            graphics.FillPolygon(new SolidBrush(FillColor), points);
            Pen p = new Pen(BorderColor, BorderSize);
            graphics.DrawPolygon(p, points);
        }
    }
}