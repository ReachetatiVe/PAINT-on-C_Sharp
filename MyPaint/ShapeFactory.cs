using System.Drawing;

namespace MyPaint {

    internal abstract class ShapeFactory {
        public abstract Shape CreateShape(PointF startPoint, PointF endPoint, int borderSize, Color borderColor);
    }
}