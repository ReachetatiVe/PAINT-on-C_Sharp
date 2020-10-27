using System;
using System.Drawing;

namespace MyPaint {

    [Serializable]
    internal class RevTriangle : Shape {

        public RevTriangle(PointF startPoint, PointF endPoint, int borderSize, Color borderColor) : base(borderSize, borderColor) {
            points = new PointF [3];
            points [0] = startPoint;
            points [1] = new PointF(endPoint.X, startPoint.Y);
            points [2] = new PointF((endPoint.X - startPoint.X) / 2 + startPoint.X, endPoint.Y); //вершина
        }
    }
}