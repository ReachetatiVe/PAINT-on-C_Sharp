using System.Drawing;

namespace MyPaint {

    internal class TriangleFactory : ShapeFactory {

        public override Shape CreateShape(Point startPoint, Point endPoint, int borderSize, Color borderColor) {
            return new Triangle(startPoint, endPoint, borderSize, borderColor);
        }
    }
}