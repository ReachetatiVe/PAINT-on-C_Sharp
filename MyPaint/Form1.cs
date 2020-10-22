using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace MyPaint
{
    internal enum module
    {
        rect,
        circle,
        triangle,
        vedro
    }

    public partial class FormMyPaint : Form
    {
        private Bitmap picture;
        private Graphics graphics;
        private Color color;
        private module module;
        private Point startPoint;
        private Collection collection;

        public FormMyPaint()
        {
            InitializeComponent();
            picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(picture);
            pictureBox1.Image = picture;
        }

        private void buttonDrawRectangle_Click(object sender, EventArgs e)
        {
            module = module.rect;
            //foreach (Button btn in groupBoxBtnsStockShapes.Controls)
            //{
            //    btn.Enabled = true;
            //}
            //buttonDrawRectangle.Enabled = false;
            ResetButtons(buttonDrawRectangle);
        }

        void ResetButtons(Button btn)
        {
            foreach (Button button in panel1.Controls.OfType<Button>())
            {
                if (button.Equals(btn))
                    button.Enabled = false;
                else
                    button.Enabled = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (module)
                {
                    case module.rect:
                        collection.RemoveLastElement();
                        Point p = e.Location;
                        int x = Math.Min(startPoint.X, p.X);
                        int y = Math.Min(startPoint.Y, p.Y);
                        int width = Math.Abs(p.X - startPoint.X);
                        int height = Math.Abs(p.Y - startPoint.Y);

                        Rect rect = new Rect(x, y, width, height, graphics, trackBarDepth.Value, color);
                        rect.Draw();
                        collection.Add(rect);
                        //graphics.DrawImage(picture, 0, 0);
                        //pictureBox1.Image = picture;
                        //pictureBox1.Invalidate();
                        break;

                    case module.circle:
                        collection.RemoveLastElement();
                        p = e.Location;
                        x = Math.Min(startPoint.X, p.X);
                        y = Math.Min(startPoint.Y, p.Y);
                        width = Math.Abs(p.X - startPoint.X);
                        height = Math.Abs(p.Y - startPoint.Y);

                        Circle circle = new Circle(x, y, width, height, graphics, trackBarDepth.Value, color);
                        circle.Draw();
                        collection.Add(circle);
                        break;
                }
                collection.ReDraw(graphics);
                pictureBox1.Image = picture;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;

                switch (module)
                {
                    case module.rect:
                        Rect rect = new Rect(startPoint.X, startPoint.Y, 0, 0, graphics, trackBarDepth.Value, color);
                        collection.Add(rect);
                        break;

                    case module.circle:
                        Circle circle = new Circle(startPoint.X, startPoint.Y, 0, 0, graphics, trackBarDepth.Value, color);
                        collection.Add(circle);
                        break;

                    case module.vedro:
                        foreach (Shape shape in collection.shapes)
                        {
                            if (shape.Touch(startPoint))
                            {
                                shape.DoFill(color);
                            }
                        }
                        pictureBox1.Image = picture;
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            collection = new Collection();
            collection.bitmap = picture;
            color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            //color = Color.FromArgb(new Random().Next(0, 256), new Random().Next(0, 256), new Random().Next(0, 256));
            panelColor.BackColor = color;
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            module = module.vedro;
            buttonFill.Enabled = false;
        }

        private void buttonDrawCircle_Click(object sender, EventArgs e)
        {
            module = module.circle;

            foreach (Button btn in groupBoxBtnsStockShapes.Controls)
            {
                btn.Enabled = true;
            }

            buttonDrawCircle.Enabled = false;
        }

        private void panelColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color = colorDialog1.Color;
            panelColor.BackColor = color;
        }
    }
}