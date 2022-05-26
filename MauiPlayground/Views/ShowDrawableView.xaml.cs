#if __IOS__
using CoreGraphics;
using UIKit;
#endif
using MauiLib.CustomControls.DrawableView;
using MauiLib.CustomControls.Platform;

namespace MauiPlayground.Views;

public partial class ShowDrawableView : ContentView
{
    public ShowDrawableView()
    {
        InitializeComponent();
        var drawableView = new DrawableView() { WidthRequest = 250, HeightRequest = 250 };
        stackLayout.Add(drawableView);
        drawableView.PaintSurface += DrawableView_PaintSurface;
    }
    private void DrawableView_PaintSurface(object sender, PlatformDrawEventArgs e)
    {
#if __ANDROID__
        var control = sender as Android.Views.View;
        var canvas = (Android.Graphics.Canvas)e.PlatformDrawArgs;
        canvas.DrawColor(Android.Graphics.Color.Red);
#elif __IOS__
            var control = sender as UIKit.UIView;
            var rect = (CoreGraphics.CGRect)e.PlatformDrawArgs;
            using (CGContext g = UIGraphics.GetCurrentContext())
            {

                //set up drawing attributes
                g.SetLineWidth(10);
                UIColor.Blue.SetFill();
                UIColor.Red.SetStroke();

                //create geometry
                var path = new CGPath();

                path.AddLines(new CGPoint[]{
                new CGPoint (100, 200),
                new CGPoint (160, 100),
                new CGPoint (220, 200)});

                path.CloseSubpath();

                //add geometry to graphics context and draw it
                g.AddPath(path);
                g.DrawPath(CGPathDrawingMode.FillStroke);
            }

#elif WINDOWS
        var control = sender as Microsoft.Graphics.Canvas.UI.Xaml.CanvasControl;
        var w = control.ActualWidth;
        var h = control.ActualHeight;
        var args = e.PlatformDrawArgs as Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs;
        args.DrawingSession.DrawRectangle(0, 0, (float)w, (float)h, Windows.UI.Color.FromArgb(200, 100, 145, 50));
        args.DrawingSession.DrawText("Hello, World!", new System.Numerics.Vector2((float)(w / 2), (float)(h / 2)), Windows.UI.Color.FromArgb(255, 255, 255, 255));
#endif
    }
}