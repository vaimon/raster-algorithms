using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterAlgorithms
{
    using FastBitmap;
    public partial class Form1 : System.Windows.Forms.Form
    {
        String currentFileName;
        Color currentColorFill;
        Color currentColorTr1;
        Color currentColorTr2;
        Color currentColorTr3;
        bool isVu = false;
        bool isDrawingMode = false;
        Bitmap bcanvas;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Меняем видимость разных доп элементов
        /// </summary>
        /// <param name="combobox">Выбор алгоритма для отрезка</param>
        /// <param name="colors">Цвета для треугольника</param>
        private void changeVisibility(bool combobox, bool colors)
        {
            comboBoxLine.Visible = combobox;
            color1.Visible = colors;
            color2.Visible = colors;
            color3.Visible = colors;
        }

        /// <summary>
        /// Заливаем цветом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFillColor_Click(object sender, EventArgs e)
        {
            changeVisibility(false, false);
            isDrawingMode = false;
            isTriangleMode = false;
            /// Выбираем цвет
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColorFill = colorDialog.Color;
            }
            /// Устанавливаем картинку для заливки
            canvas.Image = Properties.Resources.back;
        }

        /// <summary>
        /// Заливаем картинкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFillImage_Click(object sender, EventArgs e)
        {
            changeVisibility(false, false);
            isTriangleMode = false;
            canvas.Image = new Bitmap(1300, 900);
            /// Выбираем файл для заливки
            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFileName = chooseFileDialog.FileName;
            }
            isDrawingMode = true;
            /// Используем обычный битмап для рисования
        }

        /// <summary>
        /// Всё ниже надо для рисования
        /// </summary>
        Point prev;
        bool isDrawing = false;
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isDrawingMode)
            {
                return;
            }
            isDrawing = true;
            prev = e.Location;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawingMode)
            {
                return;
            }
            isDrawing = false;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawingMode)
            {
                return;
            }
            if (isDrawing)
            {
                using (Graphics g = Graphics.FromImage(canvas.Image))
                {
                    g.DrawLine(new Pen(Color.Black,2.0f), prev, e.Location);
                }
                canvas.Invalidate();
                prev = e.Location;
            }
        }

        /// <summary>
        /// Выделяем границы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHighlight_Click(object sender, EventArgs e)
        {
            changeVisibility(false, false);
            isDrawingMode = false;
            isTriangleMode = false;
            canvas.Image = new Bitmap(1300, 900);

            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFileName = chooseFileDialog.FileName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLine_Click(object sender, EventArgs e)
        {
            changeVisibility(true, false);
            isDrawingMode = false;
            isTriangleMode = false;

            canvas.Image = new Bitmap(1300, 900);
            /// Алгоритм по умолчанию
            comboBoxLine.SelectedIndex = 0;
        }
        /// <summary>
        /// Выбираем алгоритм
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            canvas.BackColor = SystemColors.Control;
            isVu = comboBoxLine.SelectedIndex == 1;
        }

        bool isTriangleMode = false;
        List<Tuple<Point, Color>> vertices;

        /// <summary>
        /// Рисуем треугольник
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            changeVisibility(false, true);
            isDrawingMode = false;
            canvas.Image = new Bitmap(1300, 900);
            color1.BackColor = currentColorTr1 = Color.Red;
            color2.BackColor = currentColorTr2 = Color.Green;
            color3.BackColor = currentColorTr3 = Color.Blue;
            vertices = new List<Tuple<Point, Color>>();
            isTriangleMode = true;
        }

        private void color1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color1.BackColor = currentColorTr1 = colorDialog.Color;
            }
        }

        private void color2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color2.BackColor = currentColorTr2 = colorDialog.Color;
            }
        }

        private void color3_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color3.BackColor = currentColorTr3 = colorDialog.Color;
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isTriangleMode)
            {
                return;
            }
            if(vertices.Count == 0)
            {
                vertices.Add(Tuple.Create(e.Location,currentColorTr1));
                
            } else if (vertices.Count == 1)
            {
                vertices.Add(Tuple.Create(e.Location, currentColorTr2));

            } else if (vertices.Count == 2)
            {
                vertices.Add(Tuple.Create(e.Location, currentColorTr3));
                drawTriangle();
                isTriangleMode = false;
            }
        }

        private Point[] getLineHigh(int x0, int y0, int x1, int y1)
        {
            List<Point> res = new List<Point>();
            int dx = x1 - x0;
            int dy = y1 - y0;
            int xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }
            int D = (2 * dx) - dy;
            int x = x0;

            for (int y = y0; y < y1; y++)
            {
                res.Add(new Point(x, y));
                if(D > 0)
                {
                    x += xi;
                    D += 2 * (dx - dy);
                }
                else
                {
                    D += 2 * dx;
                }
            }
            return res.OrderBy(p => p.Y).ToArray();
        }

        private Point[] getLineLow(int x0, int y0, int x1, int y1)
        {
            List<Point> res = new List<Point>();
            int dx = x1 - x0;
            int dy = y1 - y0;
            int yi = 1;
            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }
            int D = (2 * dy) - dx;
            int y = y0;

            for (int x = x0; x < x1; x++)
            {
                res.Add(new Point(x, y));
                if (D > 0)
                {
                    y += yi;
                    D += 2 * (dy - dx);
                }
                else
                {
                    D += 2 * dy;
                }
            }
            return res.OrderBy(p => p.Y).ToArray();
        }
        /// <summary>
        /// This code has been stolen (and adapted!) from https://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        Point[] getEdgeCoords(Point p0, Point p1)
        {
            if(Math.Abs(p1.Y - p0.Y) < Math.Abs(p1.X - p0.X))
            {
                if(p0.X > p1.X)
                {
                    return getLineLow(p1.X, p1.Y, p0.X, p0.Y);
                } else
                {
                    return getLineLow(p0.X, p0.Y, p1.X, p1.Y);
                }
            }
            else
            {
                if(p0.Y > p1.Y)
                {
                    return getLineHigh(p1.X, p1.Y, p0.X, p0.Y);
                }
                else
                {
                    return getLineHigh(p0.X, p0.Y, p1.X, p1.Y);
                }
            }
        }

        void drawTriangle()
        {
            vertices.OrderBy(x => x.Item1.Y).ToList();
            var bitmap = new Bitmap(canvas.Image);
            using (FastBitmap fbitmap = new FastBitmap(bitmap))
            {
                var e1 = getEdgeCoords(vertices[1].Item1, vertices[0].Item1);
                var e2 = getEdgeCoords(vertices[2].Item1, vertices[0].Item1);
                var e3 = getEdgeCoords(vertices[2].Item1, vertices[1].Item1);
                foreach(var p in e1)
                {
                    fbitmap.SetPixel(p, Color.Black);
                }
                foreach (var p in e2)
                {
                    fbitmap.SetPixel(p, Color.Black);
                }
                foreach (var p in e3)
                {
                    fbitmap.SetPixel(p, Color.Black);
                }
            }
            canvas.Image = bitmap;
        }
    }
}
