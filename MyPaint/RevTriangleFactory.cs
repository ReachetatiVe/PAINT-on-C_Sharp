using System.Drawing;

namespace MyPaint {

    internal class RevTriangleFactory : ShapeFactory {

        public override Shape CreateShape(Point startPoint, Point endPoint, int borderSize, Color borderColor) {
            return new RevTriangle(startPoint, endPoint, borderSize, borderColor);
        }
    }
}