using System;
using System.Drawing;

namespace MyPaint {

    [Serializable]
    internal class Rect : Shape {

        public Rect(PointF startPoint, PointF endPoint, int borderSize, Color borderColor) : base(borderSize, borderColor) {
            points = new PointF [4];

            //pointsBorder[0] = startPoint; //левая верхняя
            //pointsBorder[1] = new PointF(startPoint.X, endPoint.Y); //левая нижняя
            //pointsBorder[2] = new PointF(endPoint.X, startPoint.Y); //правая верхняя
            //pointsBorder[3] = endPoint; //правая нижняя

            points [0] = startPoint; //левая верхняя
            points [1] = new PointF(endPoint.X, startPoint.Y); //правая верхняя
            points [2] = endPoint; // правая нижняя
            points [3] = new PointF(startPoint.X, endPoint.Y); //левая нижняя
        }

        public override double Square() {
            return 0;
        }
    }
}