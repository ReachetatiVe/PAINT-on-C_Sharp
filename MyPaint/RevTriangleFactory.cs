using System.Drawing;

namespace MyPaint {

    internal class RevTriangleFactory : ShapeFactory {

        public override Shape CreateShape(PointF startPoint, PointF endPoint, int borderSize, Color borderColor) {
            return new RevTriangle(startPoint, endPoint, borderSize, borderColor);
        }
    }
}