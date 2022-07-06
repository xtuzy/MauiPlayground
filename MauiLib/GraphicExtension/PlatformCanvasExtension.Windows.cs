#if WINDOWS
using Microsoft.Graphics.Canvas;
using Microsoft.Maui.Graphics.Win2D;
/// 参考https://cloud.tencent.com/developer/article/1342784
namespace MauiLib.GraphicExtension
{
    public class OffScreenContext : IDisposable
    {
        public int Width;
        public int Height;

        public CanvasRenderTarget OffScreen;

        CanvasDrawingSession session;
        internal CanvasDrawingSession Session
        {
            get
            {
                if (session == null)
                    session = OffScreen.CreateDrawingSession();
                return session;
            }
        }

        public OffScreenContext(int w, int h)
        {
            Width = w;
            Height = h;

            CanvasDevice device = CanvasDevice.GetSharedDevice();
            OffScreen = new CanvasRenderTarget(device, w, h, dpi: 96);
        }

        public void Dispose()
        {
            session?.Dispose();//session from Target, first release
            session = null;
            OffScreen?.Dispose();
            OffScreen = null;
        }
    }

    public static partial class PlatformCanvasExtension
    {
        public static ICanvas FromOffScreenContext(OffScreenContext context)
        {
            return new W2DCanvas() { Session = context.Session };
        }

        public static void Draw(this ICanvas canvas, OffScreenContext context)
        {
            if (canvas != null && context.OffScreen != null)
                (canvas as W2DCanvas)?.Session?.DrawImage(context.OffScreen);
        }

        public static void SaveToOffScreenContext(ICanvas canvas, OffScreenContext context)
        {
            context?.Session?.Flush();
        }
    }

    //public static partial class PlatformCanvasExtension
    //{
    //    public static ICanvas FromImage(IImage image)
    //    {
    //        return new W2DCanvas() { Session = 
    //            ((image as Microsoft.Maui.Graphics.Win2D.PlatformImage).CanvasBitmap as CanvasRenderTarget).CreateDrawingSession() };
    //    }

    //    public static IImage CreateImage(int w, int h)
    //    {
    //        var creator = new CanvasResourceCreator();
    //        var bitmap = new CanvasRenderTarget(creator.Device, w, h, dpi: 96);
    //        return new Microsoft.Maui.Graphics.Win2D..PlatformImage(creator, bitmap);
    //    }
    //}

    //public class CanvasResourceCreator : ICanvasResourceCreator,IDisposable
    //{
    //    CanvasDevice device;
    //    public CanvasResourceCreator()
    //    {
    //        device = CanvasDevice.GetSharedDevice();
    //    }

    //    public CanvasDevice Device => device;

    //    public void Dispose()
    //    {
    //        device = null;
    //    }
    //}
}
#endif