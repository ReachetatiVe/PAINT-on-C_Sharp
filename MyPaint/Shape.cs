using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyPaint {

    [Serializable]
    internal abstract class Shape {
        private const int errorSize = 5;
        public int BorderSize { get; set; }
        public Color FillColor { get; set; }
        public Color BorderColor { get; set; }

        protected Rectangle selectRectangle;
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

        protected bool CheckCoordinates(int target, int b) {
            return target <= b + errorSize && target >= b - errorSize;
        }


        public virtual TypeOfTouch CheckTouchSelectionBorder(Point pointForCheck) {
            if (CheckCoordinates(pointForCheck.X, selectRectangle.Left)) {
                if (CheckCoordinates(pointForCheck.Y, selectRectangle.Top))
                    return TypeOfTouch.LeftTop;
                else if (CheckCoordinates(pointForCheck.Y, selectRectangle.Bottom))
                    return TypeOfTouch.LeftBottom;
                return TypeOfTouch.Left;
            }

            else if (CheckCoordinates(pointForCheck.X, selectRectangle.Right)) {
                if (CheckCoordinates(pointForCheck.Y, selectRectangle.Top))
                    return TypeOfTouch.RightTop;
                else if (CheckCoordinates(pointForCheck.Y, selectRectangle.Bottom))
                    return TypeOfTouch.RightBottom;
                return TypeOfTouch.Right;
            }

            else if (CheckCoordinates(pointForCheck.Y, selectRectangle.Bottom))
                return TypeOfTouch.Bottom;

            else if (CheckCoordinates(pointForCheck.Y, selectRectangle.Top))
                return TypeOfTouch.Top;

            else
                return TypeOfTouch.NePopal;
        }

        public virtual void DrawRectAroundShape(Graphics graphics) {
            CreateSelectedRect();

            Pen pen = new Pen(Color.White);
            pen.DashStyle = DashStyle.Solid;
            pen.Width = 1.5f;
            graphics.DrawRectangle(pen, selectRectangle);
            pen.Color = Color.Blue;
            pen.DashPattern = new float [] { 4, 4 };
            graphics.DrawRectangle(pen, selectRectangle);

        }

        private void CreateSelectedRect() {
            if (selectRectangle.Width == 0 && selectRectangle.Height == 0) {
                int xRight = points [0].X;
                int xLeft = points [0].X;
                int yTop = points [0].Y;
                int yBottom = points [0].Y;

                foreach (Point point in points) {
                    xLeft = Math.Min(point.X, xLeft);
                    xRight = Math.Max(point.X, xRight);
                    yTop = Math.Min(point.Y, yTop);
                    yBottom = Math.Max(point.Y, yBottom);
                }

                selectRectangle = new Rectangle(xLeft, yTop, xRight - xLeft, yBottom - yTop);
            }
        }
        public virtual void DoFill(Graphics graphics) {
            graphics.FillPolygon(new SolidBrush(FillColor), points);
            Pen p = new Pen(BorderColor, BorderSize);
            graphics.DrawPolygon(p, points);
        }

        public virtual void ReSize(TypeOfTouch typeOfTouch, Point deltaPoint) {
            int unchangeableX = -1;
            int unchangeableY = -1;
            switch (typeOfTouch) {
                case TypeOfTouch.Bottom:
                    unchangeableX = -1;
                    unchangeableY = selectRectangle.Top;
                    break;
                case TypeOfTouch.Left:
                    unchangeableX = selectRectangle.Right;
                    unchangeableY = -1;
                    break;
                case TypeOfTouch.LeftBottom:
                    unchangeableX = selectRectangle.Right;
                    unchangeableY = selectRectangle.Top;
                    break;
                case TypeOfTouch.LeftTop:
                    unchangeableX = selectRectangle.Right;
                    unchangeableY = selectRectangle.Bottom;
                    break;
                case TypeOfTouch.Right:
                    unchangeableX = selectRectangle.Left;
                    unchangeableY = -1;
                    break;
                case TypeOfTouch.RightBottom:
                    unchangeableX = selectRectangle.Left;
                    unchangeableY = selectRectangle.Top;
                    break;
                case TypeOfTouch.RightTop:
                    unchangeableX = selectRectangle.Left;
                    unchangeableY = selectRectangle.Bottom;
                    break;
                case TypeOfTouch.Top:
                    unchangeableX = -1;
                    unchangeableY = selectRectangle.Bottom;
                    break;
            }
            if (typeOfTouch != TypeOfTouch.NePopal) {
                CreateSelectedRect();
                for (int i = 0; i < points.Length; i++) {
                    int tmpX = points [i].X;
                    int tmpY = points [i].Y;
                    //проверить на 0 (не забыдь)
                    if (unchangeableX != -1)
                        tmpX -= deltaPoint.X * (Math.Abs(unchangeableX - tmpX) / selectRectangle.Width);
                    if (unchangeableY != -1)
                        tmpY -= deltaPoint.Y * (Math.Abs(unchangeableY - tmpY) / selectRectangle.Height);
                    points [i] = new Point(tmpX, tmpY);
                }
                selectRectangle.Width = 0;
                selectRectangle.Height = 0;
            }
        }

        public enum TypeOfTouch {
            Left, Right, Top, Bottom, LeftTop, LeftBottom, RightTop, RightBottom, NePopal
        }
    }
}