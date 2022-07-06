using Boids.Model;
using MauiLib.GraphicExtension;

namespace Boids.Viewer
{
    public static class SDRender
    {
        public static OffScreenContext RenderField(Field field)
        {
            OffScreenContext bmp = new OffScreenContext((int)field.Width, (int)field.Height);
            //Bitmap bmp = new Bitmap((int)field.Width, (int)field.Height);
            /*using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gfx.Clear(ColorTranslator.FromHtml("#003366"));
                for (int i = 0; i < field.Boids.Count(); i++)
                {
                    if (i < 3)
                        RenderBoid(gfx, field.Boids[i], Color.White);
                    else
                        RenderBoid(gfx, field.Boids[i], Color.LightGreen);
                }
            }*/

            var canvas = PlatformCanvasExtension.FromOffScreenContext(bmp);
            canvas.Antialias = true;
            canvas.FillColor = Color.FromRgb(0, 51, 102);
            canvas.FillRectangle(0, 0, (int)field.Width, (int)field.Height);
            for (int i = 0; i < field.Boids.Count(); i++)
            {
                if (i < 3)
                    RenderBoid(canvas, field.Boids[i], Colors.White);
                else
                    RenderBoid(canvas, field.Boids[i], Colors.LightGreen);
            }
            PlatformCanvasExtension.SaveToOffScreenContext(canvas, bmp);
            return bmp;
        }

        private static void RenderBoid(ICanvas gfx, Boid boid, Color color)
        {
            var boidOutline = new Point[]
            {
                new Point(0, 0),
                new Point(-4, -1),
                new Point(0, 8),
                new Point(4, -1),
                new Point(0, 0),
            };

            /*using (var brush = new SolidBrush(color))
            {
                gfx.TranslateTransform((float)boid.X, (float)boid.Y);
                gfx.RotateTransform((float)boid.GetAngle());
                gfx.FillClosedCurve(brush, boidOutline);
                gfx.ResetTransform();
            }*/

            gfx.SaveState();
            gfx.Translate((float)boid.X, (float)boid.Y);
            gfx.Rotate((float)boid.GetAngle());
            PathF path = new PathF();
            path.MoveTo(boidOutline[0]);
            path.LineTo(boidOutline[1]);
            path.LineTo(boidOutline[2]);
            path.LineTo(boidOutline[3]);
            path.LineTo(boidOutline[4]);
            path.Close();
            gfx.FillColor = color;
            gfx.FillPath(path);
            gfx.RestoreState();
        }
    }
}
