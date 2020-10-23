using System.Drawing;

namespace MyPaint {

    internal class RectFactory : ShapeFactory {

        public override Shape CreateShape(Point startPoint, Point endPoint, int borderSize, Color borderColor) {
            return new Rect(startPoint, endPoint, borderSize, borderColor);
        }
    }
}