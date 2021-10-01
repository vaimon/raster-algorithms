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
        bool isVu = false;
        bool isDrawingMode = false;
        bool isFillingMode = false;
        Bitmap bcanvas;
         Pen p;

       // private Graphics g;
        public Form1()
        {
            var x = HSVTools.interpolate(Color.Red, Color.Blue, 10);
        
           // canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            p = new Pen(Color.Black, 1);
            InitializeComponent();
            // g = Graphics.FromImage(canvas.Image);

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
            isLineMode = false;
            isFillingMode = true;
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
            isLineMode = false;
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
            isLineMode = false;
            canvas.Image = new Bitmap(1300, 900);

            if (chooseFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFileName = chooseFileDialog.FileName;
            }
        }

        private bool isLineMode = false;
        private Point? prevPoint = null;
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
            isLineMode = true;
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
            isLineMode = false;
            canvas.Image = new Bitmap(1300, 900);
            color1.BackColor = Color.Red;
            color2.BackColor = Color.FromArgb(0,255,0);
            color3.BackColor = Color.Blue;
            vertices = new List<Tuple<Point, Color>>();
            isTriangleMode = true;
        }

        private void color1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color1.BackColor = colorDialog.Color;
            }
        }

        private void color2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color2.BackColor = colorDialog.Color;
            }
        }

        private void color3_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color3.BackColor = colorDialog.Color;
            }
        } 
        Color oldcolor;
       
        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (isTriangleMode)
            {
                if (vertices.Count == 0)
                {
                    vertices.Add(Tuple.Create(e.Location, color1.BackColor));

                }
                else if (vertices.Count == 1)
                {
                    vertices.Add(Tuple.Create(e.Location, color2.BackColor));

                }
                else if (vertices.Count == 2)
                {
                    vertices.Add(Tuple.Create(e.Location, color3.BackColor));
                    drawTriangle();
                    vertices.Clear();
                }
            }
            else if (isLineMode)
            {
                if (prevPoint == null)
                {
                    prevPoint = e.Location;
                }
                else
                {
                    if (isVu)
                    {
                        drawVuLine(prevPoint.Value, e.Location);
                    }
                    else
                    {
                        drawBresenhamLine(prevPoint, e.Location);
                    }
                    prevPoint = null;
                }

            }
            else if (isFillingMode)
            {
                //FillFigure(e.Location, currentColorFill);
                oldcolor = ((Bitmap)canvas.Image).GetPixel(e.X, e.Y);
                p.Color = currentColorFill;
                   if (oldcolor!=currentColorFill)//вызываем заливку
                    fillfigure(e.X,e.Y);
            }
             else if (isDrawingMode)
            {
                FillImage(e.Location, currentFileName);//вызываем заливку картинкой
            }
        }
        /* private void getMousecoord(Point p,Color c)
{
var bitmap = new Bitmap(canvas.Image);
//Point p = new Point(e.X, e.Y);
// currentColorFill = colorDialog.Color;
FillFigure( p, c);
canvas.Image = bitmap;
}*/

        private bool CheckPixel(Color cur, Color c2)
        {
            if (cur != c2)
                return true;
            else return false;
        }
        void fillfigure(int x, int y)
        {
            Bitmap bitmap = canvas.Image as Bitmap;
            Color currentColor = bitmap.GetPixel(x, y);
            if (CheckPixel(currentColor,oldcolor )|| currentColor == p.Color)//&& currentColor==Color.Black
                return;
            
            int leftgr =x;//левая граница
            int rightgr =x;//правая граница
            
            while (( bitmap.GetPixel(leftgr, y) == oldcolor) &&(leftgr >= 0))//==oldcolor
            {
                leftgr--;
            }

           
            while (( bitmap.GetPixel(rightgr, y) == oldcolor)&&(rightgr <= canvas.Width))//bitmap
            {
                rightgr++;
            }
            // using (Graphics g = Graphics.FromImage(canvas.Image))
            // {
            //g.DrawLine(p, leftgr + 1, y, rightgr - 1, y);//c drawline почему-то иногда происходит stackOverflow при получении
            //координаты точки, где кликнули мышкой
            //}
            
            if (leftgr + 1 == rightgr - 1)
            {
                bitmap.SetPixel(leftgr + 1, y, currentColorFill);
             
            }
            else {
                for (int i = leftgr + 1; i < rightgr; i++)
                {

                    // fbitmap.SetPixel(new Point(i, y), currentColorFill);
                    bitmap.SetPixel(i, y, currentColorFill);//а вот с setpixel норм
                }
            }
            canvas.Invalidate();

            if (y + 1 <= bitmap.Height)
                for (int i = leftgr + 1; i < rightgr; ++i)
                    fillfigure(i, y + 1);

            if (y - 1 >= 0)
                for (int i = leftgr + 1; i < rightgr; ++i)
                    fillfigure(i, y - 1);

           //
            //canvas.Image = bitmap;
         
        }
        /*private void FillFigure(Point p, Color c)
        { 
            var bitmap = new Bitmap(canvas.Image);
            int x = p.X;
            int leftgr = p.X;//левая граница
            int rightgr = p.X;//правая граница
            int y = p.Y;
            Color fillcolor = c;
            Bitmap bitmap1 = canvas.Image as Bitmap;
          //  using (FastBitmap fbitmap = new FastBitmap(bitmap))
            {
                //Color currentcolor = fbitmap.GetPixel(p);
                Color currentcolor = bitmap1.GetPixel(x,y);
                if ((currentcolor.A != c.A) && (currentcolor.R != c.R) && (currentcolor.G != c.G) && (currentcolor.B != c.B))
                    return;
                if (x > bitmap1.Size.Width)
                    return;
                if (y > bitmap1.Size.Height)
                    return;
              //  {
                    while (!(currentcolor.A == 0) && !(currentcolor.R == 0) && !(currentcolor.G == 0) && !(currentcolor.B == 0)&& (rightgr <= bitmap1.Size.Width))
                    {

                        // currentcolor = fbitmap.GetPixel(new Point(rightgr, y));
                       // if (rightgr <= bitmap1.Width)
                       // {
                            rightgr++;
                            currentcolor = bitmap1.GetPixel(rightgr, y);
                       // }
                       // else break;
                    }
                    //currentcolor = fbitmap.GetPixel(p);
                    currentcolor = bitmap1.GetPixel(x, y);
                    while (!(currentcolor.A == 0)&&!(currentcolor.R == 0) && !(currentcolor.G == 0) && !(currentcolor.B == 0)&& (leftgr >= 0))
                    {
                       // if (leftgr >= 0)
                       // {
                            leftgr--;
                            //currentcolor = fbitmap.GetPixel(new Point(leftgr, y));
                            currentcolor = bitmap1.GetPixel(leftgr, y);
                       // }
                        //else break;
                    }

                    for (int i = leftgr + 1; i < rightgr; i++)
                    {

                        //fbitmap.SetPixel(new Point(i, y), currentColorFill);
                        bitmap1.SetPixel(i, y, currentColorFill);
                    }


                    if ((y + 1 < bitmap1.Size.Height) )
                        for (int i = leftgr + 1; i < rightgr; i++)
                        {
                        //fbitmap.SetPixel(new Point(i, y+1), fillcolor);
                        Color col = bitmap1.GetPixel(i, y + 1);
                        if (col!=currentColorFill)
                            FillFigure(new Point(i, y + 1), fillcolor);
                        }
                    
                    if (y-1>0)
                    for (int i = leftgr; i < rightgr; i++)
                    {
                    //fbitmap.SetPixel(new Point(i, y-1), fillcolor);
                    FillFigure(new Point(i, y - 1), fillcolor);
                    }
               // }


            }
            //canvas.Image = bitmap;
            canvas.Image = bitmap1;

        }*/
        private void FillImage(Point p, string filename)
        {
            Image newImage = Image.FromFile(filename);
          
            Bitmap bitmap = canvas.Image as Bitmap;
            Bitmap imbitmap = newImage as Bitmap;
            int rightgr = p.X;
            int downgr = p.Y;
            Color currentColor = bitmap.GetPixel(p.X,p.Y);
            while ((rightgr <= bitmap.Size.Width))//!(currentColor==Color.Black)
            {

                // currentcolor = fbitmap.GetPixel(new Point(rightgr, y));
                // if (rightgr <= bitmap1.Width)
                // {
                rightgr++;
                currentColor = bitmap.GetPixel(rightgr, p.Y);
                // }
                // else break;
            }
            //currentcolor = fbitmap.GetPixel(p);
            while (  (downgr <= bitmap.Size.Height))//!(currentColor == Color.Black)
            {

                // currentcolor = fbitmap.GetPixel(new Point(rightgr, y));
                // if (rightgr <= bitmap1.Width)
                // {
                downgr++;
                currentColor = bitmap.GetPixel(p.X, downgr);
                // }
                // else break;
            }

            using (FastBitmap fbitmap = new FastBitmap(bitmap))
            {
                int i1 = 0;
                int j1 = 0;
                for (int i = p.X; i < rightgr; i++)
                    for (int j = p.Y; j < downgr; j++)
                    {
                        Color c = imbitmap.GetPixel(i1, j1);
                        fbitmap.SetPixel(new Point(i, j), c);
                        i1++;
                        j1++;
                    }
            }
            canvas.Image = bitmap;
        }
            private float frac(double f)
        {
            return (float)(f - Math.Truncate(f));
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Xiaolin_Wu%27s_line_algorithm
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        private void drawVuLine(Point p0, Point p1)
        {
            var bitmap = new Bitmap(canvas.Image);
            using (FastBitmap fbitmap = new FastBitmap(bitmap))
            {
                float x0 = p0.X, x1 = p1.X, y0 = p0.Y, y1 = p1.Y;
                bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
                if (steep)
                {
                    (x0, y0) = (y0, x0);
                    (x1, y1) = (y1, x1);
                }
                if (x0 > x1)
                {
                    (x0, x1) = (x1, x0);
                    (y0, y1) = (y1, y0);
                }
                fbitmap.SetPixel(p1, Color.Black);
                

                float dx = x1 - x0, dy = y1 - y0;
                float gradient = dy / dx;
                if(dx == 0)
                {
                    gradient = 1;
                }

                float xend = (float)Math.Round(x0);
                float yend = y0 + gradient * (xend - x0);
                float xgap = (float)(1 - frac(x0 + 0.5));
                float xpxl1 = xend;
                float ypxl1 = (float)Math.Floor(yend);
                if(steep)
                {
                    fbitmap.SetPixel(new Point((int)ypxl1, (int)xpxl1), Color.FromArgb(HSVTools.bytify((1 - frac(yend)) * xgap),0,0,0));
                    fbitmap.SetPixel(new Point((int)ypxl1 + 1, (int)xpxl1), Color.FromArgb(HSVTools.bytify(frac(yend) * xgap), 0, 0, 0));
                }
                else
                {
                    fbitmap.SetPixel(new Point((int)xpxl1, (int)ypxl1), Color.FromArgb(HSVTools.bytify((1 - frac(yend)) * xgap), 0, 0, 0));
                    fbitmap.SetPixel(new Point((int)xpxl1, (int)ypxl1 + 1), Color.FromArgb(HSVTools.bytify((1 - frac(yend)) * xgap), 0, 0, 0));
                }
                float intery = yend + gradient;

                xend = (float)Math.Round(x1);
                yend = y1 + gradient * (xend - x1);
                xgap = (float)frac(x1 + 0.5);
                float xpxl2 = xend;
                float ypxl2 = (float)Math.Floor(yend);
                List<byte> rrr = new List<byte>();
                if (steep)
                {
                    rrr.Add(HSVTools.bytify(1 - frac(intery)));
                    rrr.Add(HSVTools.bytify(frac(intery)));
                    fbitmap.SetPixel(new Point((int)ypxl2, (int)xpxl2), Color.FromArgb(HSVTools.bytify((1 - frac(yend)) * xgap), 0, 0, 0));
                    fbitmap.SetPixel(new Point((int)ypxl2 + 1, (int)xpxl2), Color.FromArgb(HSVTools.bytify(frac(yend) * xgap), 0, 0, 0));
                }
                else
                {
                    rrr.Add(HSVTools.bytify(1 - frac(intery)));
                    rrr.Add(HSVTools.bytify(frac(intery)));
                    fbitmap.SetPixel(new Point((int)xpxl2, (int)ypxl2), Color.FromArgb(HSVTools.bytify((1 - frac(yend)) * xgap), 0, 0, 0));
                    fbitmap.SetPixel(new Point((int)xpxl2, (int)ypxl2 + 1), Color.FromArgb(HSVTools.bytify(frac(yend) * xgap), 0, 0, 0));
                }

                if (steep)
                {
                    for(var x = xpxl1 + 1; x < xpxl2; x++)
                    {
                        rrr.Add(HSVTools.bytify(1 - frac(intery)));
                        rrr.Add(HSVTools.bytify(frac(intery)));
                        fbitmap.SetPixel(new Point((int)Math.Floor(intery), (int)x), Color.FromArgb(HSVTools.bytify(1 - frac(intery)), 0, 0, 0));
                        fbitmap.SetPixel(new Point((int)Math.Floor(intery) + 1, (int)x), Color.FromArgb(HSVTools.bytify(frac(intery)), 0, 0, 0));
                        intery += gradient;
                    }
                }
                else
                {
                    for (var x = xpxl1 + 1; x < xpxl2; x++)
                    {
                        rrr.Add(HSVTools.bytify(1 - frac(intery)));
                        rrr.Add(HSVTools.bytify(frac(intery)));
                        fbitmap.SetPixel(new Point((int)x, (int)Math.Floor(intery)), Color.FromArgb(HSVTools.bytify(1 - frac(intery)), 0, 0, 0));
                        fbitmap.SetPixel(new Point((int)x, (int)Math.Floor(intery) + 1), Color.FromArgb(HSVTools.bytify(frac(intery)), 0, 0, 0));
                        intery += gradient;
                    }
                }
            }
            canvas.Image = bitmap;
        }

        private void drawBresenhamLine(Point? point, Point eLocation)
        {
            var bitmap = new Bitmap(canvas.Image);
            using (FastBitmap fbitmap = new FastBitmap(bitmap))
            {
                var line = getLineCoordsByBresenham(point.Value, eLocation);
                foreach(var p in line)
                {
                    fbitmap.SetPixel(p, Color.Black);
                }
            }
            canvas.Image = bitmap;
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

            for (int y = y0; y <= y1; y++)
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

            for (int x = x0; x <= x1; x++)
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
        /// <param name="p0"></param>
        /// <returns></returns>
        Point[] getLineCoordsByBresenham(Point p0, Point p1)
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

        public static Color[] interpolateRGB(Color start, Color end, int seed)
        {
            List<Color> res = new List<Color>();
            double rstep = (end.R - start.R) / (1.0 * seed - 1), gstep = (end.G - start.G) / (1.0 * seed - 1), bstep = (1.0 * end.B - start.B) / (seed - 1);

            for (int i = 0; i < seed; i++)
            {
                res.Add(Color.FromArgb((byte)Math.Round(start.R + rstep * i), (byte)Math.Round(start.G + gstep * i), (byte)Math.Round(start.B + bstep * i)));
            }
            return res.ToArray();
        }

        void drawTriangle()
        {
            vertices = vertices.OrderBy(x => x.Item1.Y).ToList();
            var bitmap = new Bitmap(canvas.Image);
           
            using (FastBitmap fbitmap = new FastBitmap(bitmap))
            {
                var e1 = getLineCoordsByBresenham(vertices[0].Item1, vertices[1].Item1).GroupBy(p => p.Y).Select(g => (vertices[0].Item1.X > vertices[1].Item1.X ? g.First() : g.Last())).ToArray();
                var e2 = getLineCoordsByBresenham(vertices[0].Item1, vertices[2].Item1).GroupBy(p => p.Y).Select(g => (vertices[0].Item1.X > vertices[2].Item1.X ? g.First() : g.Last())).ToArray();
                var e3 = getLineCoordsByBresenham(vertices[1].Item1, vertices[2].Item1).GroupBy(p => p.Y).Select(g => (vertices[1].Item1.X > vertices[2].Item1.X ? g.First() : g.Last())).ToArray();

                // var c1 = HSVTools.interpolate(vertices[0].Item2, vertices[1].Item2, e1.Length);
                // var c2 = HSVTools.interpolate(vertices[0].Item2, vertices[2].Item2, e2.Length);
                // var c3 = HSVTools.interpolate(vertices[1].Item2, vertices[2].Item2, e3.Length);

                var c1 = interpolateRGB(vertices[0].Item2, vertices[1].Item2, e1.Length);
                var c2 = interpolateRGB(vertices[0].Item2, vertices[2].Item2, e2.Length);
                var c3 = interpolateRGB(vertices[1].Item2, vertices[2].Item2, e3.Length);

                /*
                for (int i = 0; i < c1.Length; i++)
                {
                    for(int j = 0; j < 7; j++)
                    {
                        fbitmap.SetPixel(new Point(100 + j, 200 + i), c1[i]);
                    }
                }
                for (int i = 0; i < c2.Length; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        fbitmap.SetPixel(new Point(110 + j, 200 + i), c2[i]);
                    }
                }

                for (int i = 0; i < c3.Length; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        fbitmap.SetPixel(new Point(120 + j, 200 + i), c3[i]);
                    }
                }
                */

                for (int i = 0; i < e1.Length; i++)
                {
                    Color[] colors;
                    Point left, right;
                    if(vertices[1].Item1.X < vertices[2].Item1.X)
                    {
                        //colors = HSVTools.interpolate(c1[i], c2[i], Math.Abs(e2[i].X - e1[i].X) + 1);
                        colors = interpolateRGB(c1[i], c2[i], Math.Abs(e2[i].X - e1[i].X) + 1);
                        left = e1[i];
                        right = e2[i];
                    }
                    else
                    {
                        // colors = HSVTools.interpolate(c2[i], c1[i], Math.Abs(e2[i].X - e1[i].X) + 1);
                        colors = interpolateRGB(c2[i], c1[i], Math.Abs(e2[i].X - e1[i].X) + 1);
                        left = e2[i];
                        right = e1[i];
                    }
                    
                    int cind = 0;
                    for(int x = left.X; x <= right.X; x++)
                    {
                        fbitmap.SetPixel(new Point(x,e2[i].Y), colors[cind]);
                        cind++;
                    }
                }

                for (int i = 0; i < e3.Length; i++)
                {
                    int ie2 = i + e1.Length - 1;
                    Color[] colors;
                    Point left, right;
                    if (vertices[1].Item1.X < vertices[2].Item1.X)
                    {
                        // colors = HSVTools.interpolate(c3[i], c2[ie2], Math.Abs(e3[i].X - e2[ie2].X) + 1);
                        colors = interpolateRGB(c3[i], c2[ie2], Math.Abs(e3[i].X - e2[ie2].X) + 1);
                        left = e3[i];
                        right = e2[ie2];
                    }
                    else
                    {
                        // colors = HSVTools.interpolate(c2[ie2], c3[i], Math.Abs(e3[i].X - e2[ie2].X) + 1);
                        colors = interpolateRGB(c2[ie2], c3[i], Math.Abs(e3[i].X - e2[ie2].X) + 1);
                        left = e2[ie2];
                        right = e3[i];
                    }

                    int cind = 0;
                    for (int x = left.X; x <= right.X; x++)
                    {
                        fbitmap.SetPixel(new Point(x, e2[ie2].Y), colors[cind]);
                        cind++;
                    }
                }
            }
            canvas.Image = bitmap;
        }
    }
}
