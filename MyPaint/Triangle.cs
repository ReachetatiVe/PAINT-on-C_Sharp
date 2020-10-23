using System;
using System.Drawing;

namespace MyPaint {

    [Serializable]
    internal class Triangle : Shape {

        public Triangle(Point startPoint, Point endPoint, int borderSize, Color borderColor) : base(borderSize, borderColor) {
            points = new Point [3];
            points [0] = new Point(startPoint.X, endPoint.Y);
            points [1] = endPoint;
            points [2] = new Point((endPoint.X - startPoint.X) / 2 + startPoint.X, startPoint.Y); //вершина
        }
    }
}