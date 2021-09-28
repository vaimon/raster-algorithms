using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterAlgorithms
{
    class HSVTools
    {
        public class HSV
        {
            // 0-360
            public double hue;
            // 0-100
            public double saturation;
            // 0-100
            public double value;

            public HSV(double hue, double saturation, double value)
            {
                this.hue = Math.Round(hue, 1);
                this.saturation = Math.Round(saturation * 100, 1);
                this.value = Math.Round(value * 100, 1);
            }

            public void add(double hue, double sat, double val)
            {
                if (this.hue + hue < 0)
                {
                    this.hue += 360 + hue;
                }
                else
                {
                    this.hue = (this.hue + hue) % 360;
                }

                if (saturation + sat < 0)
                {
                    saturation = 0;
                }
                else if (saturation + sat > 100)
                {
                    saturation = 100;
                }
                else
                {
                    saturation += sat;
                }

                if (value + val < 0)
                {
                    value = 0;
                }
                else if (value + val > 100)
                {
                    value = 100;
                }
                else
                {
                    value += val;
                }
                this.hue = Math.Round(this.hue, 1);
                this.saturation = Math.Round(this.saturation, 1);
                this.value = Math.Round(this.value, 1);
            }
        }

        public class RGB
        {
            public byte r, g, b;

            public RGB(byte r, byte g, byte b)
            {
                this.r = r;
                this.g = g;
                this.b = b;
            }
        }

        public static HSV RGBtoHSV(byte red, byte green, byte blue)
        {
            double h = 0, s;
            byte max = Math.Max(Math.Max(red, green), blue);
            byte min = Math.Min(Math.Min(red, green), blue);
            s = 1.0 - (min * 1.0 / max);
            if (max == 0)
            {
                h = 0;
                s = 0;
            }
            else if (max == min)
            {
                h = 0;
            }
            else if ((max == red) && (green >= blue))
            {
                h = 60 * ((green - blue) / (max * 1.0 - min));
            }
            else if ((max == red) && (green < blue))
            {
                h = 60 * ((green - blue) / (1.0 * max - min)) + 360;
            }
            else if (max == green)
            {
                h = 60 * ((blue - red) / (1.0 * max - min)) + 120;
            }
            else if (max == blue)
            {
                h = 60 * ((red - green) / (1.0 * max - min)) + 240;
            }

            return new HSV(h, s, max / 255.0);
        }
        public static byte bytify(double color)
        {
            return (byte)Math.Round((255 / 100.0) * color);
        }
        public static Color HSVtoRGB(double hue, double saturation, double value)
        {
            int sw = (int)Math.Floor(hue / 60) % 6;
            double vmin = ((100 - saturation) * value) / 100.0;
            double a = (value - vmin) * ((hue % 60) / 60);
            double vinc = vmin + a;
            double vdec = value - a;
            switch (sw)
            {
                case 0: return Color.FromArgb(bytify(value), bytify(vinc), bytify(vmin));
                case 1: return Color.FromArgb(bytify(vdec), bytify(value), bytify(vmin));
                case 2: return Color.FromArgb(bytify(vmin), bytify(value), bytify(vinc));
                case 3: return Color.FromArgb(bytify(vmin), bytify(vdec), bytify(value));
                case 4: return Color.FromArgb(bytify(vinc), bytify(vmin), bytify(value));
                case 5: return Color.FromArgb(bytify(value), bytify(vmin), bytify(vdec));
            }
            return Color.FromArgb(0, 0, 0);
        }

        public static Color[] interpolate(Color start, Color end, int seed)
        {
            List<Color> res = new List<Color>();
            var hstart = RGBtoHSV(start.R, start.G, start.B);
            var hend = RGBtoHSV(end.R, end.G, end.B);
            if ((hstart.hue == 0) && (hend.hue > (360 - hend.hue)))
            {
                hstart.hue = 360;
            }
            if ((hend.hue == 0) && (hstart.hue > (360 - hstart.hue)))
            {
                hend.hue = 360;
            }
            double hstep = (hend.hue - hstart.hue) / (seed - 1), sstep = (hend.saturation - hstart.saturation) / (seed - 1), vstep = (hend.value - hstart.value) / (seed - 1);
            for (int i = 0; i < seed; i++)
            {
                res.Add(HSVtoRGB(hstart.hue + hstep * i, hstart.saturation + sstep * i, hstart.value + vstep * i));
            }
            return res.ToArray();
        }
    }
}
