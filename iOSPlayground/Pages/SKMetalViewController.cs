using SkiaSharp;
using SkiaSharp.Views.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace iOSPlayground.Pages
{
    public class SkMetalViewPage : UIView
    {
        UILabel countLabel;
        private SKMetalView meatalView;

        public SkMetalViewPage(CGRect frame) : base(frame)
        {
            countLabel = new UILabel(new CGRect(0, 0, frame.Width / 2, frame.Height / 2))
            {
                BackgroundColor = UIColor.SystemBackground,
                TextAlignment = UITextAlignment.Center,
                Text = "Hello, iOS!",
                AutoresizingMask = UIViewAutoresizing.All,
            };
            this.AddSubview(countLabel);
            meatalView = new SKMetalView(new CGRect(frame.Width / 2, frame.Height / 2, frame.Width / 2, frame.Height / 2))
            {
            };
            this.AddSubview(meatalView);
            meatalView.PaintSurface += MeatalView_PaintSurface;
        }

        private void MeatalView_PaintSurface(object? sender, SKPaintMetalSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var w = e.BackendRenderTarget.Width;
            var h = e.BackendRenderTarget.Height;
            Draw(canvas, w, h);
        }

        void Draw(SKCanvas canvas, int w, int h)
        {
            canvas.Clear(UIColor.SystemBackground.ToSKColor());
            var fontSize = 30 * 3;
            var paint = new SKPaint() { Color = SKColors.Black, TextSize = fontSize };
            var textWidth = paint.MeasureText(countLabel.Text?.ToString());
            canvas.DrawText(countLabel.Text?.ToString(), w / 2 - textWidth / 2, h / 2 + fontSize / 2, paint);
        }
    }

    internal class SKMetalViewController : UIViewController
    {
        public SKMetalViewController(CGRect frame)
        {
            this.View = new SkMetalViewPage(frame);
        }
    }
}
