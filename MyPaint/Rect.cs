using System;
using System.Drawing;

namespace MyPaint {

    [Serializable]
    internal class Rect : Shape {

        public Rect(Point startPoint, Point endPoint, int borderSize, Color borderColor) : base(borderSize, borderColor) {
            points = new Point [4];

            //pointsBorder[0] = startPoint; //левая верхняя
            //pointsBorder[1] = new Point(startPoint.X, endPoint.Y); //левая нижняя
            //pointsBorder[2] = new Point(endPoint.X, startPoint.Y); //правая верхняя
            //pointsBorder[3] = endPoint; //правая нижняя

            points [0] = startPoint; //левая верхняя
            points [1] = new Point(endPoint.X, startPoint.Y); //правая верхняя
            points [2] = endPoint; // правая нижняя
            points [3] = new Point(startPoint.X, endPoint.Y); //левая нижняя
        }

        public override double Square() {
            return 0;
        }
    }
}