
using MauiLib.CustomControls.DrawableView;
using MauiLib.CustomControls.LikeView;
using MauiLib.CustomControls.Platform;
using MauiPlayground.Views;
using MauiPlayground.Views.ShowAnimationView;
using MauiPlayground.Views.ShowCustomView;
using SharpConstraintLayout.Maui.Widget;
using SkiaSharp;
using SkiaSharp.Views.Maui.Controls;

namespace MauiPlayground
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            stackLayout.RemoveAt(0);
            var canvasView = new SKCanvasView();
            canvasView.PaintSurface += (sender, e) =>
            {

                using (var mPaint = new SKPaint())
                {
                    mPaint.Color = SKColors.Green;
                    mPaint.IsAntialias = true;
                    mPaint.IsDither = true;
                    mPaint.Style = SKPaintStyle.Fill;
                    var mHeartShapePathController = new HeartShapePathController(
                        HeartShapePathController.LR_GROUP_C_RATIO,
                        HeartShapePathController.LR_GROUP_B_RATIO,
                        HeartShapePathController.B_GROUP_AC_RATIO,
                        HeartShapePathController.T_GROUP_B_RATIO);
                    e.Surface.Canvas.Translate(100, 100);
                    e.Surface.Canvas.DrawPath(mHeartShapePathController.getPath(100), mPaint);
                }

            };

            stackLayout.Add(canvasView);

            using (var set = new FluentConstraintSet())
            {
                set.Clone(constraintLayout);
                set.Select(scrollView).EdgesXTo().Width(FluentConstraintSet.SizeBehavier.MatchConstraint)
                    .TopToTop().Height(FluentConstraintSet.SizeBehavier.WrapContent)
                    .Select(stackLayout).EdgesXTo().Width(FluentConstraintSet.SizeBehavier.MatchConstraint)
                    .TopToBottom(scrollView).BottomToBottom().Height(FluentConstraintSet.SizeBehavier.MatchConstraint)
                    ;
                set.ApplyTo(constraintLayout);
            }
        }

        private void CustomView_Clicked(object sender, EventArgs e)
        {
            stackLayout.RemoveAt(0);
            stackLayout.Add(new ShowCustomView() { });
        }

        private void AnimationView_Clicked(object sender, EventArgs e)
        {
            stackLayout.RemoveAt(0);
            stackLayout.Add(new ShowAnimationView() { });
        }
        private void ListView_Clicked(object sender, EventArgs e)
        {
            stackLayout.RemoveAt(0);
            stackLayout.Add(new ShowListView() { });
        }

        private void DrawableView_Clicked(object sender, EventArgs e)
        {
            stackLayout.RemoveAt(0);
            stackLayout.Add(new ShowDrawableView());
        }

        private void PlayAudio_Clicked(object sender, EventArgs e)
        {
            stackLayout.RemoveAt(0);
            stackLayout.Add(new PlayAudioView());
        }
    }
}