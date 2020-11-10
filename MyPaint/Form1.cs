using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MyPaint {
    internal enum Module {
        Rect,
        Circle,
        Triangle,
        RevTriangle,
        Vedro,
        Pointer
    }

    public partial class FormMyPaint : Form {
        private Bitmap picture;
        private Graphics graphics;
        private Color color;
        private Module module;
        private PointF startMousePoint;
        private Collection collection;
        private PointF currentPoint;

        private Thread threadForShowInfo;
        private Thread threadForShape;
        private Thread threadForPointer;
        private Shape.TypeOfTouch typeOfTouch;
        private int resizingIndex = -1;

        private bool shapeThreadIsRunning = false;
        private byte borderSize;
        private const byte sleepTime = 16;

        private uint countOfGroupShapes;

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
            pictureBox1.Image = picture;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            currentPoint = e.Location;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                startMousePoint = e.Location;
                //currentPoint = e.Location;

                switch (module) {
                    case Module.Vedro:
                        for (int i = collection.shapes.Count - 1; i >= 0; i--) {
                            if (collection[i].Touch(currentPoint)) {
                                collection[i].FillColor = color;
                                break;
                            }
                        }

                        collection.ReDraw(graphics);
                        pictureBox1.Image = picture;
                        break;

                    case Module.Pointer:
                        for (int i = collection.shapes.Count - 1; i >= 0; i--) {
                            bool isSelected = false;
                            foreach (int index in collection.indexesOfSelectedShapes) {
                                //узнаем, помечена ли конкретная фигура
                                if (index == i) {
                                    isSelected = true;
                                    break;
                                }
                            }

                            bool touched = collection[i].Touch(currentPoint);
                            if (!isSelected) {
                                if (touched) {
                                    collection.indexesOfSelectedShapes.Add(i);
                                    collection.ReDraw(graphics);
                                    pictureBox1.Image = picture;
                                }
                            }
                            else {
                                typeOfTouch = collection[i].CheckTouchSelectionBorder(startMousePoint);
                                if (typeOfTouch != Shape.TypeOfTouch.NePopal) {
                                    resizingIndex = i;
                                    threadForPointer = new Thread(() =>
                                        {
                                            while (resizingIndex != -1) {
                                                collection[resizingIndex].ReSize(typeOfTouch,
                                                    new PointF(startMousePoint.X - currentPoint.X,
                                                        startMousePoint.Y - currentPoint.Y));

                                                startMousePoint = currentPoint;

                                                collection.ReDraw(graphics);
                                                pictureBox1.Image = picture;

                                                Thread.Sleep(sleepTime);
                                            }
                                        });
                                    threadForPointer.Start();
                                    break;
                                }

                                if (touched) {
                                    resizingIndex = i;
                                    threadForPointer = new Thread(() =>
                                        {
                                            while (resizingIndex != -1) {
                                                collection[resizingIndex].Move(
                                                    new PointF(startMousePoint.X - currentPoint.X,
                                                        startMousePoint.Y - currentPoint.Y));

                                                startMousePoint = currentPoint;

                                                collection.ReDraw(graphics);
                                                pictureBox1.Image = picture;

                                                Thread.Sleep(sleepTime);
                                            }
                                        });
                                    threadForPointer.Start();
                                    break;
                                }
                            }
                        }

                        break;

                    default:
                        shapeThreadIsRunning = true;

                        collection.Add(new Rect(currentPoint, currentPoint, 0, Color.Black)); //заглушка

                        threadForShape = new Thread(() =>
                            {
                                while (shapeThreadIsRunning) {
                                    PointF startPoint = new PointF();
                                    PointF endPoint = new PointF();

                                    collection.RemoveLastElement();

                                    startPoint.X = Math.Min(startMousePoint.X, currentPoint.X);
                                    startPoint.Y = Math.Min(startMousePoint.Y, currentPoint.Y);
                                    endPoint.X = startPoint.X + Math.Abs(currentPoint.X - startMousePoint.X);
                                    endPoint.Y = startPoint.Y + Math.Abs(currentPoint.Y - startMousePoint.Y);

                                    ShapeFactory shapeFactory = null;
                                    switch (module) {
                                        case Module.Rect:
                                            shapeFactory = new RectFactory();
                                            break;

                                        case Module.Circle:
                                            shapeFactory = new CircleFactory();
                                            break;

                                        case Module.Triangle:
                                            shapeFactory = new TriangleFactory();
                                            break;

                                        case Module.RevTriangle:
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

            if (e.Button == MouseButtons.Right) {
                ResetSelect();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                shapeThreadIsRunning = false;
                typeOfTouch = Shape.TypeOfTouch.NePopal;
                resizingIndex = -1;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            Random rnd = new Random();
            collection = new Collection();

            new ToolTip().SetToolTip(buttonForUI, "Свернуть панель инструментов");
            new ToolTip().SetToolTip(buttonFill, "Заливка фигур");
            new ToolTip().SetToolTip(buttonPointer, "Выделение фигур");
            new ToolTip().SetToolTip(buttonDrawCircle, "Рисует эллипс");
            new ToolTip().SetToolTip(buttonDrawRectangle, "Рисует прямоугольник");
            new ToolTip().SetToolTip(buttonDrawTriangle, "Рисует треугольник");
            new ToolTip().SetToolTip(buttonDrawRevTriangle, "Рисует перевернутый треугольник");
            new ToolTip().SetToolTip(panelColor, "Выберите цвет");
            new ToolTip().SetToolTip(trackBarDepth, "Задать толщину границы");

            borderSize = (byte) trackBarDepth.Value;

            collection.bitmap = picture;
            color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            panelColor.BackColor = color;

            buttonForUI.Location = new Point(pictureBox1.Width / 2, pictureBox1.Location.Y);


            threadForShowInfo = new Thread(() => ShowInfoAboutForm());
            threadForShowInfo.Start();
        }

        private void ShowInfoAboutForm() {
            while (true) {
                toolStripStatusLabelShowCountOfShapes.Text = collection.shapes.Count.ToString();
                toolStripStatusLabelShowX.Text = "X: " + currentPoint.X;
                toolStripStatusLabelShowY.Text = "Y: " + currentPoint.Y;
                Thread.Sleep(sleepTime);
            }
        }

        private void buttonFill_Click(object sender, EventArgs e) {
            module = Module.Vedro;
            ResetButtons();
            ResetSelect();
            buttonFill.Enabled = false;
        }

        private void buttonDrawRectangle_Click(object sender, EventArgs e) {
            module = Module.Rect;
            ResetButtons();
            ResetSelect();
            buttonDrawRectangle.Enabled = false;
        }

        private void buttonDrawCircle_Click(object sender, EventArgs e) {
            module = Module.Circle;
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
            MessageBox.Show("Программа Paint для сдачи проекта \"Paint\" в университете. Больше ни для чего.",
                "About program");
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
            module = Module.Triangle;
            ResetButtons();
            ResetSelect();
            buttonDrawTriangle.Enabled = false;
        }

        private void buttonDrawRevTriangle_Click(object sender, EventArgs e) {
            module = Module.RevTriangle;
            ResetButtons();
            ResetSelect();
            buttonDrawRevTriangle.Enabled = false;
        }

        private void trackBarDepth_ValueChanged(object sender, EventArgs e) {
            borderSize = (byte) trackBarDepth.Value;
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
                buttonForUI.Location = new Point(pictureBox1.Width / 2, pictureBox1.Location.Y);
            }
        }

        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e) {
            if (pictureBox1.Image != null) {
                SaveFileDialog savedialog = new SaveFileDialog {
                    Title = "Сохранить изображение как...",
                    OverwritePrompt =
                        true, //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                    CheckPathExists =
                        true, //отображать ли предупреждение, если пользователь указывает несуществующий путь
                    Filter =
                        "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*" //список форматов файла, отображаемый в поле "Тип файла"
                };

                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try {
                        picture.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void buttonPointer_Click(object sender, EventArgs e) {
            module = Module.Pointer;
            ResetButtons();
            buttonPointer.Enabled = false;
        }

        private void buttonForUI_Click(object sender, EventArgs e) {
            if (panel1.Visible) {
                panel1.Visible = false;
                buttonForUI.BackgroundImage = Image.FromFile(@"..\..\Images\expand-arrow.png");
            }
            else {
                panel1.Visible = true;
                buttonForUI.BackgroundImage = Image.FromFile(@"..\..\Images\collapse-arrow.png");
            }

            buttonForUI.Location = new Point(pictureBox1.Width / 2, pictureBox1.Location.Y);
        }

        private void buttonAddGroupShape_Click(object sender, EventArgs e) {
            countOfGroupShapes++;
            comboBoxForGroupShape.Items.Add(new Label().Text="Г.Фигура "+countOfGroupShapes);
        }
    }
}