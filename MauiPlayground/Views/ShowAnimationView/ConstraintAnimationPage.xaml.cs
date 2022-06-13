using SharpConstraintLayout.Maui.Widget;
using System.Collections.Generic;
using System.Linq;
using static SharpConstraintLayout.Maui.Widget.FluentConstraintSet;

namespace MauiPlayground.Views.ShowAnimationView
{
    public partial class ConstraintAnimationPage : ContentView
    {
        bool isExpanded = true;
        Rect expandedRect; // bounds for expanded image view
        Rect detailsRect;  // bounds for details image view

        public ConstraintAnimationPage()
        {
            InitializeComponent();
            using (var set = new FluentConstraintSet())
            {
                set.Clone(layout);
                set.Select(MainImage).TopToTop().EdgesXTo().BottomToTop(ExpandBar).Width(SizeBehavier.MatchConstraint).Height(SizeBehavier.MatchConstraint)
                    .Select(ExpandBar).BottomToBottom(null, 50).EdgesXTo().Width(SizeBehavier.MatchConstraint).Height(SizeBehavier.WrapContent)
                    .Select(BottomFrame).TopToBottom().EdgesXTo().Width(SizeBehavier.MatchConstraint)
                    .Select(Title).TopToTop(null, 40).RightToLeft();
                set.ApplyTo(layout);
            }
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (isExpanded)
                AnimateIn();
            else
                AnimateOut();

            isExpanded = !isExpanded;
        }

        private void AnimateIn()
        {
            //MainImage.LayoutTo(detailsRect, 1200, Easing.SpringOut);
            //BottomFrame.TranslateTo(0, 0, 1200, Easing.SpringOut);
            //Title.TranslateTo(0, 0, 1200, Easing.SpringOut);
            //ExpandBar.FadeTo(.01, 250, Easing.SinInOut);
            var animation = new Animation((v) =>
            {
                using (var set = new FluentConstraintSet())
                {
                    set.Clone(layout);
                    set.Select(MainImage, ExpandBar, BottomFrame, Title).Clear()
                    .Select(MainImage).TopToTop().EdgesXTo().BottomToTop(BottomFrame).Width(SizeBehavier.MatchConstraint).Height(SizeBehavier.MatchConstraint)
                        .Select(ExpandBar).BottomToBottom(null, 50).EdgesXTo().Width(SizeBehavier.MatchConstraint).Height(SizeBehavier.WrapContent).Alpha((float)-v)
                        .Select(BottomFrame).BottomToBottom(null, (int)(BottomFrame.Bounds.Height * v)).EdgesXTo().Width(SizeBehavier.MatchConstraint)
                        .Select(Title).TopToTop(null, 40).LeftToLeft(null, (int)(Title.Bounds.Width * v));
                    set.ApplyTo(layout);
                }
            }, -1, 0, Easing.SpringOut);
            animation.Commit(this, "in", 16, 1600);
        }

        private void AnimateOut()
        {
            //MainImage.LayoutTo(expandedRect, 1200, Easing.SpringOut);
            //BottomFrame.TranslateTo(0, BottomFrame.Height, 1200, Easing.SpringOut);
            //Title.TranslateTo(-Title.Width, 0, 1200, Easing.SpringOut);
            //ExpandBar.FadeTo(1, 250, Easing.SinInOut);

            var animation = new Animation((v) =>
            {
                using (var set = new FluentConstraintSet())
                {
                    set.Clone(layout);
                    set.Select(MainImage, ExpandBar, BottomFrame, Title).Clear()
                    .Select(MainImage).TopToTop().EdgesXTo().BottomToTop(ExpandBar).Width(SizeBehavier.MatchConstraint).Height(SizeBehavier.MatchConstraint)
                        .Select(ExpandBar).BottomToBottom(null, 50).EdgesXTo().Width(SizeBehavier.MatchConstraint).Height(SizeBehavier.WrapContent).Alpha((float)-v)
                        .Select(BottomFrame).BottomToBottom(null, (int)(BottomFrame.Bounds.Height * v)).EdgesXTo().Width(SizeBehavier.MatchConstraint)
                        .Select(Title).TopToTop(null, 40).LeftToLeft(null, (int)(Title.Bounds.Width * v));
                    set.ApplyTo(layout);
                }
            }, 0, -1, Easing.SpringOut);
            animation.Commit(this, "out", 16, 1200);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (BottomFrame == null)
                return;
            detailsRect = new Rect(0, 0, width, BottomFrame.Bounds.Top + 20);
            expandedRect = new Rect(0, 0, width, height);

            if (isExpanded)
            {
                //MainImage.Layout(expandedRect);
                //BottomFrame.TranslationY = BottomFrame.Height;
                //Title.TranslationX = -Title.Width;
            }
            else
            {
                //MainImage.Layout(detailsRect);
                //.TranslationY = 0;
                //Title.TranslationX = 0;
            }
        }

        public override SizeRequest Measure(double widthConstraint, double heightConstraint, MeasureFlags flags = MeasureFlags.None)
        {
            return base.Measure(widthConstraint, heightConstraint, flags);
        }

        protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            return base.MeasureOverride(widthConstraint, heightConstraint);
        }
    }
}