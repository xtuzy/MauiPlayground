namespace MauiLib.SkiaGraphic.Platforms
{
    public static class SkiaViewExtensions
    {
        public static void UpdateDrawable(this PlatformSkiaView PlatformGraphicsView, ISkiaGraphicsView graphicsView)
        {
            PlatformGraphicsView.Drawable = graphicsView.Drawable;
        }
    }
}