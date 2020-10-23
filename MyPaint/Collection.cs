using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MyPaint {

    [Serializable]
    internal class Collection {
        public Bitmap bitmap;
        public List<Shape> shapes;

        public Shape this [int index] {
            get {
                return shapes [index];
            }
            set {
                shapes [index] = value;
            }
        }

        public Collection() {
            shapes = new List<Shape>();
        }

        public void Add(Shape shape) {
            shapes.Add(shape);
        }

        public void RemoveLastElement() {
            shapes.RemoveAt(shapes.Count - 1);
        }

        public void ReDraw(Graphics gr) {
            gr.Clear(Color.White);

            foreach (Shape shape in shapes) {
                shape.Draw(gr);
                shape.DoFill(gr);
            }
        }

        public void Save() {
            SaveFileDialog sfd1 = new SaveFileDialog
            {
                Title = "Сериализовать изображение как...",
                OverwritePrompt = true, //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                CheckPathExists = true //отображать ли предупреждение, если пользователь указывает несуществующий путь
            };

            if (sfd1.ShowDialog() == DialogResult.OK) {
                try {
                    using (FileStream fs = new FileStream(sfd1.FileName, FileMode.OpenOrCreate))
                        new BinaryFormatter().Serialize(fs, shapes);
                }
                catch {
                    throw new Exception("Ошибка при сериализации");
                }
            }
        }

        public void Open() {
            OpenFileDialog opd = new OpenFileDialog
            {
                Title = "Выберите файл для его десериализации...",
                CheckPathExists = true,
                CheckFileExists = true
            };
            if (opd.ShowDialog() == DialogResult.OK) {
                try {
                    shapes.Clear();

                    using (FileStream fs = new FileStream(opd.FileName, FileMode.OpenOrCreate))
                        shapes = (List<Shape>)new BinaryFormatter().Deserialize(fs);
                }
                catch {
                    throw new Exception("Ошибка при десериализации");
                }
            }
        }
    }
}