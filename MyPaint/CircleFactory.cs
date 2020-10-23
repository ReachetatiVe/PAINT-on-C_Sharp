using System.Drawing;

namespace MyPaint {

    internal class CircleFactory : ShapeFactory {

        public override Shape CreateShape(Point startPoint, Point endPoint, int borderSize, Color borderColor) {
            return new Circle(startPoint, endPoint, borderSize, borderColor);
        }
    }
}