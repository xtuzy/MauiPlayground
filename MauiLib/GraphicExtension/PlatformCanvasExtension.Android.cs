#if __ANDROID__
using Android.Content;
using Android.Graphics;
using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;
using Paint = Android.Graphics.Paint;

namespace MauiLib.GraphicExtension
{
    public class OffScreenContext : IDisposable
    {
        public Bitmap OffScreen;

        internal Canvas Canvas;
        public OffScreenContext(int w, int h)
        {
            OffScreen = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
            Canvas = new Canvas(OffScreen);
        }

        public void Dispose()
        {
            Canvas?.Dispose();//Canvas from Bitmap, first release canvas;
            Canvas = null;
            OffScreen?.Dispose();
            OffScreen = null;
        }
    }

    public static partial class PlatformCanvasExtension
    {
        public static ICanvas FromOffScreenContext(OffScreenContext context)
        {
            return new PlatformCanvas() { Canvas = context.Canvas };
        }

        public static void Draw(this ICanvas canvas, OffScreenContext context)
        {
            if (canvas != null && context.OffScreen != null)
                ((canvas as ScalingCanvas)?.ParentCanvas as PlatformCanvas)?.Canvas?.DrawBitmap(context.OffScreen, 0, 0, new Paint());
        }

        public static void SaveToOffScreenContext(ICanvas canvas, OffScreenContext context)
        {
            context?.Canvas?.Save();
        }
    }

    //public static partial class PlatformCanvasExtension
    //{
    //    public static ICanvas CreateOffScreenCanvasFromOffScreenImage(IImage image)
    //    {
    //        return new PlatformCanvas() { Canvas = new Canvas(image.AsBitmap()) };
    //    }

    //    public static IImage CreateOffScreenImage(int width, int height)
    //    {
    //        return new PlatformImage(Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888));
    //    }

    //    public static void SaveToOffScreenImage(ICanvas canvas)
    //    {
    //        (canvas as Microsoft.Maui.Graphics.Platform.PlatformCanvas).Canvas.Save();
    //    }
    //}
}
#endif