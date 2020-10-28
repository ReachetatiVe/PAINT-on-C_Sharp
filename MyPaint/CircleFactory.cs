using System.Drawing;

namespace MyPaint {

    internal class CircleFactory : ShapeFactory {

        public override Shape CreateShape(PointF startPoint, PointF endPoint, int borderSize, Color borderColor) {
            return new Circle(startPoint, endPoint, borderSize, borderColor);
        }
    }
}