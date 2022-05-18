#if __IOS__
using CoreGraphics;
using UIKit;
#endif
using MauiPlayground.CustomControls.DrawableView;

namespace MauiPlayground
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            var drawableView = new DrawableView() { WidthRequest = 250, HeightRequest = 250 };
            stackLayout.Add(drawableView);
            drawableView.PaintSurface += DrawableView_PaintSurface;
        }

        private void DrawableView_PaintSurface(object sender, CustomControls.Platform.PlatformDrawEventArgs e)
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
            var w = control.Width;
            var h = control.Height;
            var args = e.PlatformDrawArgs as Microsoft.Graphics.Canvas.UI.Xaml.CanvasDrawEventArgs;
            args.DrawingSession.DrawText("Hello, World!", new System.Numerics.Vector2((float)(w / 2), (float)(h / 2)), Windows.UI.Color.FromArgb(255, 255, 255, 255));
#endif
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}