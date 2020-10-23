using System.Drawing;

namespace MyPaint {

    internal abstract class ShapeFactory {
        public abstract Shape CreateShape(Point startPoint, Point endPoint, int borderSize, Color borderColor);
    }
}