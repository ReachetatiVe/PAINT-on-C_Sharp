using System;
using System.Drawing;

namespace MyPaint {

    [Serializable]
    internal class Triangle : Shape {

        public Triangle(PointF startPoint, PointF endPoint, int borderSize, Color borderColor) : base(borderSize, borderColor) {
            points = new PointF [3];
            points [0] = new PointF(startPoint.X, endPoint.Y);
            points [1] = endPoint;
            points [2] = new PointF((endPoint.X - startPoint.X) / 2 + startPoint.X, startPoint.Y); //вершина
        }
    }
}