using System.Drawing;

namespace MyPaint {

    internal class RectFactory : ShapeFactory {

        public override Shape CreateShape(PointF startPoint, PointF endPoint, int borderSize, Color borderColor) {
            return new Rect(startPoint, endPoint, borderSize, borderColor);
        }
    }
}