#if __IOS__
using CoreGraphics;
using UIKit;
#endif
using MauiLib.CustomControls.DrawableView;
using MauiLib.CustomControls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPlayground.Views.ShowCustomView
{
    internal class CustomView : DrawableView
    {
        public override SizeRequest Measure(double widthConstraint, double heightConstraint, MeasureFlags flags = MeasureFlags.None)
        {
            var size = base.Measure(widthConstraint, heightConstraint, flags);
#if WINDOWS
            var device = Microsoft.Graphics.Canvas.CanvasDevice.GetSharedDevice();
            var offscreen = new Microsoft.Graphics.Canvas.CanvasRenderTarget(device, (float)widthConstraint, (float)heightConstraint, 96);
            using (var ds = offscreen.CreateDrawingSession())
            {
                var format = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat { FontSize = 30.0f, WordWrapping = Microsoft.Graphics.Canvas.Text.CanvasWordWrapping.NoWrap };
                var textLayout = new Microsoft.Graphics.Canvas.Text.CanvasTextLayout(ds, Text, format, 0.0f, 0.0f);
                return new SizeRequest(new Size(textLayout.DrawBounds.Width, textLayout.DrawBounds.Height));
            }
#endif
            return size;
        }
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            var size = base.OnMeasure(widthConstraint, heightConstraint);
            return size;
        }
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            var size = base.MeasureOverride(widthConstraint, heightConstraint);
            return size;
        }
        public string Text = "Hello World!";
        public override void OnDraw(object sender, PlatformDrawEventArgs e)
        {
            base.OnDraw(sender, e);
#if __ANDROID__
            var control = sender as Android.Views.View;
            var canvas = (Android.Graphics.Canvas)e.PlatformDrawArgs;
            canvas.DrawColor(Android.Graphics.Color.Red);
#elif __IOS__
            var control = sender as UIView;
            var rect = (CGRect)e.PlatformDrawArgs;
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
            //https://stackoverflow.com/questions/30696838/how-to-calculate-the-size-of-a-piece-of-text-in-win2d
            var format = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat { FontSize = 30.0f, WordWrapping = Microsoft.Graphics.Canvas.Text.CanvasWordWrapping.NoWrap };
            var textLayout = new Microsoft.Graphics.Canvas.Text.CanvasTextLayout(args.DrawingSession, Text, format, 0.0f, 0.0f);
            var theRectYouAreLookingFor = new Windows.Foundation.Rect(w / 2 - textLayout.DrawBounds.Width / 2, h / 2 - textLayout.DrawBounds.Height / 2, textLayout.DrawBounds.Width, textLayout.DrawBounds.Height);
            args.DrawingSession.DrawRectangle(theRectYouAreLookingFor, Microsoft.UI.Colors.Black, 1.0f);
            args.DrawingSession.DrawTextLayout(textLayout, (float)(w / 2 - textLayout.DrawBounds.Width / 2), (float)(h / 2 - textLayout.DrawBounds.Height), Microsoft.UI.Colors.White);
#endif
        }

        public override void WhenMeasure(object sender, EventArgs e)
        {
            base.WhenMeasure(sender, e);
        }
    }
}
