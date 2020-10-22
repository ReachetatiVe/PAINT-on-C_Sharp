using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    internal class Collection
    {
        public Bitmap bitmap;
        public List<Shape> shapes;

        public Collection()
        {
            shapes = new List<Shape>();
        }

        public void Add(Shape shape)
        {
            shapes.Add(shape);
        }

        public void RemoveLastElement()
        {
            shapes.RemoveAt(shapes.Count - 1);
        }

        public void ReDraw(Graphics gr)
        {
            gr.Clear(Color.White);

            foreach (Shape shape in shapes)
            {
                shape.Draw();
                shape.DoFill(shape.Fill);
            }
        }

        public void Safe()
        {
            SaveFileDialog sfd1 = new SaveFileDialog();
            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                string filename = sfd1.FileName;
            }
        }
    }
}