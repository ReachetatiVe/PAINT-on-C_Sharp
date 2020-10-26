using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MyPaint {

    internal enum Module {
        rect,
        circle,
        triangle,
        revTriangle,
        vedro,
        pointer
    }

    public partial class FormMyPaint : Form {
        private Bitmap picture;
        private Graphics graphics;
        private Color color;
        private Module module;
        private Point startMousePoint;
        private Collection collection;
        private Point currentPoint;
        private Thread threadForShowInfo;
        private Thread threadForShape;
        private Thread threadForPointer;
        private Shape.TypeOfTouch typeOfTouch;
        private bool shapeThreadIsRunning = false;
        private byte borderSize;
        private const byte sleepTime = 16;

        public FormMyPaint() {
            InitializeComponent();
            picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(picture);
            pictureBox1.Image = picture;
        }

        private void ResetButtons() {
            foreach (Button button in panel1.Controls.OfType<Button>())
                button.Enabled = true;
        }

        private void ResetSelect() {
            collection.indexesOfSelectedShapes.Clear();
            collection.ReDraw(graphics);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            currentPoint = e.Location;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                startMousePoint = e.Location;
                currentPoint = e.Location;

                switch (module) {
                    case Module.vedro:
                        for (int i = collection.shapes.Count - 1; i >= 0; i--) {
                            if (collection [i].Touch(currentPoint)) {
                                collection [i].FillColor = color;
                                break;
                            }
                        }
                        collection.ReDraw(graphics);
                        pictureBox1.Image = picture;
                        break;

                    case Module.pointer:
                        for (int i = collection.shapes.Count - 1; i >= 0; i--) {
                            bool isSelected = false;
                            foreach (int index in collection.indexesOfSelectedShapes) {
                                if (index == i) {
                                    isSelected = true;
                                    break;
                                }
                            }

                            if (!isSelected) {
                                if (collection [i].Touch(currentPoint)) {
                                    collection.indexesOfSelectedShapes.Add(i);
                                    collection.ReDraw(graphics);
                                    pictureBox1.Image = picture;
                                }
                            }
                            else {
                                typeOfTouch = collection [i].CheckTouchSelectionBorder(startMousePoint);
                                threadForPointer = new Thread(() =>
                                {
                                    while (typeOfTouch != Shape.TypeOfTouch.NePopal) {
                                        collection [i].ReSize(typeOfTouch, new Point(startMousePoint.X - currentPoint.X, startMousePoint.Y - currentPoint.Y));

                                        startMousePoint = currentPoint;

                                        collection.ReDraw(graphics);
                                        pictureBox1.Image = picture;

                                        Thread.Sleep(sleepTime);
                                    }
                                });
                                threadForPointer.Start();
                            }

                            break;
                        }
                        break;

                    default:
                        shapeThreadIsRunning = true;

                        collection.Add(new Rect(currentPoint, currentPoint, 0, Color.Black)); //заглушка

                        threadForShape = new Thread(() =>
                        {
                            while (shapeThreadIsRunning) {
                                Point startPoint = new Point();
                                Point endPoint = new Point();

                                collection.RemoveLastElement();

                                startPoint.X = Math.Min(startMousePoint.X, currentPoint.X);
                                startPoint.Y = Math.Min(startMousePoint.Y, currentPoint.Y);
                                endPoint.X = startPoint.X + Math.Abs(currentPoint.X - startMousePoint.X);
                                endPoint.Y = startPoint.Y + Math.Abs(currentPoint.Y - startMousePoint.Y);

                                ShapeFactory shapeFactory = null;
                                switch (module) {
                                    case Module.rect:
                                        shapeFactory = new RectFactory();
                                        break;

                                    case Module.circle:
                                        shapeFactory = new CircleFactory();
                                        break;

                                    case Module.triangle:
                                        shapeFactory = new TriangleFactory();
                                        break;

                                    case Module.revTriangle:
                                        shapeFactory = new RevTriangleFactory();
                                        break;
                                }

                                collection.Add(shapeFactory.CreateShape(startPoint, endPoint, borderSize, color));

                                collection.ReDraw(graphics);
                                pictureBox1.Image = picture;

                                Thread.Sleep(sleepTime);
                            }
                        });

                        threadForShape.Start();
                        break;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                shapeThreadIsRunning = false;
                typeOfTouch = Shape.TypeOfTouch.NePopal;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            Random rnd = new Random();
            collection = new Collection();

            borderSize = (byte)trackBarDepth.Value;

            collection.bitmap = picture;
            color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            panelColor.BackColor = color;

            threadForShowInfo = new Thread(() => ShowInfoAboutForm());
            threadForShowInfo.Start();
        }

        private void ShowInfoAboutForm() {
            while (!false) {
                toolStripStatusLabelShowCountOfShapes.Text = collection.shapes.Count.ToString();
                toolStripStatusLabelShowX.Text = "X: " + currentPoint.X;
                toolStripStatusLabelShowY.Text = "Y: " + currentPoint.Y;
                Thread.Sleep(17);
            }
        }

        private void buttonFill_Click(object sender, EventArgs e) {
            module = Module.vedro;
            ResetButtons();
            ResetSelect();
            buttonFill.Enabled = false;
        }

        private void buttonDrawRectangle_Click(object sender, EventArgs e) {
            module = Module.rect;
            ResetButtons();
            ResetSelect();
            buttonDrawRectangle.Enabled = false;
        }

        private void buttonDrawCircle_Click(object sender, EventArgs e) {
            module = Module.circle;
            ResetButtons();
            ResetSelect();
            buttonDrawCircle.Enabled = false;
        }

        private void panelColor_Click(object sender, EventArgs e) {
            colorDialog1.ShowDialog();
            color = colorDialog1.Color;
            panelColor.BackColor = color;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Программа Paint для сдачи проекта \"Paint\" в университете. Больше ни для чего.", "About program");
        }

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e) {
            collection.Save();
        }

        private void deserializeToolStripMenuItem_Click(object sender, EventArgs e) {
            picture.Dispose();
            picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(picture);

            collection.Open();

            collection.ReDraw(graphics);
            pictureBox1.Image = picture;
        }

        private void buttonDrawTriangle_Click_1(object sender, EventArgs e) {
            module = Module.triangle;
            ResetButtons();
            ResetSelect();
            buttonDrawTriangle.Enabled = false;
        }

        private void buttonDrawRevTriangle_Click(object sender, EventArgs e) {
            module = Module.revTriangle;
            ResetButtons();
            ResetSelect();
            buttonDrawRevTriangle.Enabled = false;
        }

        private void trackBarDepth_ValueChanged(object sender, EventArgs e) {
            borderSize = (byte)trackBarDepth.Value;
        }

        private void FormMyPaint_FormClosed(object sender, FormClosedEventArgs e) {
            if (threadForShape != null && threadForShape.IsAlive)
                threadForShape.Abort();
            threadForShowInfo.Abort();
        }

        private void FormMyPaint_SizeChanged(object sender, EventArgs e) {
            if (graphics != null) {
                picture = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = picture;
                graphics = Graphics.FromImage(picture);
                collection.ReDraw(graphics);
            }
        }

        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e) {
            if (pictureBox1.Image != null) {
                SaveFileDialog savedialog = new SaveFileDialog
                {
                    Title = "Сохранить изображение как...",
                    OverwritePrompt = true, //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                    CheckPathExists = true, //отображать ли предупреждение, если пользователь указывает несуществующий путь
                    Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*" //список форматов файла, отображаемый в поле "Тип файла"
                };

                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try {
                        picture.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void buttonPointer_Click(object sender, EventArgs e) {
            module = Module.pointer;
            ResetButtons();
            buttonPointer.Enabled = false;
        }
    }
}