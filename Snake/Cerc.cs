using System.Drawing;

namespace Snake
{
    public class Cerc
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Culoare { get; set; }

        public Cerc(int x, int y, Color culoare)
        {
            this.X = x;
            this.Y = y;
            this.Culoare = culoare;
        }

        public void DrawAsApple(Graphics g)
        {
            SolidBrush dark = new SolidBrush(Culoare);
            int pX = X * 20;
            int pY = Y * 20;

            g.FillRectangle(dark, pX + 8, pY + 2, 4, 4);
            g.FillRectangle(dark, pX + 4, pY + 6, 12, 8);
            g.FillRectangle(dark, pX + 8, pY + 14, 4, 4);

            dark.Dispose();
        }

        public void DrawAsBody(Graphics g, Color bg)
        {
            SolidBrush dark = new SolidBrush(Culoare);
            SolidBrush light = new SolidBrush(bg);
            int pX = X * 20;
            int pY = Y * 20;

            g.FillRectangle(dark, pX, pY, 20, 20);

            g.FillRectangle(light, pX + 4, pY + 4, 12, 12);

            g.FillRectangle(dark, pX + 8, pY + 8, 4, 4);

            dark.Dispose();
            light.Dispose();
        }

        public void DrawAsHead(Graphics g, Color bg)
        {
            SolidBrush dark = new SolidBrush(Culoare);
            SolidBrush light = new SolidBrush(bg);
            int pX = X * 20;
            int pY = Y * 20;

            g.FillRectangle(dark, pX, pY, 20, 20);

            g.FillRectangle(light, pX + 4, pY + 8, 4, 4);
            g.FillRectangle(light, pX + 12, pY + 8, 4, 4);

            dark.Dispose();
            light.Dispose();
        }
    }
}