using System.Drawing;

namespace MyPaint {

    internal class TriangleFactory : ShapeFactory {

        public override Shape CreateShape(PointF startPoint, PointF endPoint, int borderSize, Color borderColor) {
            return new Triangle(startPoint, endPoint, borderSize, borderColor);
        }
    }
}