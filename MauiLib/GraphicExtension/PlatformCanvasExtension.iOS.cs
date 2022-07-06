#if __IOS__
using CoreGraphics;
using Microsoft.Maui.Graphics.Platform;
using UIKit;
using IImage = Microsoft.Maui.Graphics.IImage;
//参考https://stackoverflow.com/questions/39950125/how-do-i-draw-on-an-image-in-swift
//参考https://blog.csdn.net/pjk1129/article/details/6619693
namespace MauiLib.GraphicExtension
{
    public class OffScreenContext : IDisposable
    {
        public CGContext OffScreen;

        internal UIImage Image;

        public OffScreenContext(int w, int h)
        {
            var render = new UIGraphicsImageRenderer();
            OffScreen = UIGraphics.GetCurrentContext();
            //CGColorSpace colorSpace = CGColorSpace.CreateDeviceRGB();
            //new CoreGraphics.CGBitmapContext(null,w,h, 8, 0, colorSpace, kCGImageAlphaPremultipliedLast)
            //OffScreen = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
        }

        public void Dispose()
        {
            Image?.Dispose();//Image form Context, first release
            Image = null;
            OffScreen?.Dispose();
            OffScreen = null;
        }
    }

    public static partial class PlatformCanvasExtension
    {
        public static ICanvas FromOffScreenContext(OffScreenContext context)
        {
            return new PlatformCanvas(() => CGColorSpace.CreateDeviceRGB()) { Context = context.OffScreen };
        }

        public static void Draw(this ICanvas canvas, OffScreenContext context)
        {
            if (canvas != null && context.OffScreen != null)
            {
                var image = context.Image;
                (canvas as PlatformCanvas)?.Context?.DrawImage(new CGRect(0, 0, image.Size.Width, image.Size.Height), image.CGImage);
            }
        }

        public static void SaveToOffScreenContext(ICanvas canvas, OffScreenContext context)
        {
            context.Image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();//TODO:不知道这个是存储到Image还是之后就不能绘图了
        }
    }
}
#endif