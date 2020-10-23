using System;
using System.Drawing;

namespace MyPaint {

    [Serializable]
    internal class RevTriangle : Shape {

        public RevTriangle(Point startPoint, Point endPoint, int borderSize, Color borderColor) : base(borderSize, borderColor) {
            points = new Point [3];
            points [0] = startPoint;
            points [1] = new Point(endPoint.X, startPoint.Y);
            points [2] = new Point((endPoint.X - startPoint.X) / 2 + startPoint.X, endPoint.Y); //вершина
        }
    }
}