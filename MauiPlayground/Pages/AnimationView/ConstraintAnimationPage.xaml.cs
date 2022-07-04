using SharpConstraintLayout.Maui.Widget;
using static SharpConstraintLayout.Maui.Widget.FluentConstraintSet;

namespace MauiPlayground.Pages.AnimationView
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

            /*var animation = new Animation((v) =>
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
            animation.Commit(this, "in", 16, 1600);*/

            layout.AbortAnimation("out");
            var inSet = new FluentConstraintSet();
            inSet.Clone(layout);
            inSet.Select(MainImage, ExpandBar, BottomFrame, Title).Clear()
            .Select(MainImage).TopToTop().EdgesXTo().BottomToTop(BottomFrame).Width(SizeBehavier.MatchConstraint).Height(SizeBehavier.MatchConstraint)
                .Select(ExpandBar).BottomToBottom(null, 50).EdgesXTo().Width(SizeBehavier.MatchConstraint).Height(SizeBehavier.WrapContent).Alpha(1)
                .Select(BottomFrame).BottomToBottom().EdgesXTo().Width(SizeBehavier.MatchConstraint)
                .Select(Title).TopToTop(null, 40).LeftToLeft();
            LayoutToWithAnim(layout, inSet, "in", 16, 1600, Easing.SpringOut);
        }

        private void AnimateOut()
        {
            //MainImage.LayoutTo(expandedRect, 1200, Easing.SpringOut);
            //BottomFrame.TranslateTo(0, BottomFrame.Height, 1200, Easing.SpringOut);
            //Title.TranslateTo(-Title.Width, 0, 1200, Easing.SpringOut);
            //ExpandBar.FadeTo(1, 250, Easing.SinInOut);

            /*var animation = new Animation((v) =>
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
            animation.Commit(this, "out", 16, 1200);*/

            layout.AbortAnimation("in");
            var outSet = new FluentConstraintSet();
            outSet.Clone(layout);
            outSet.Select(MainImage, ExpandBar, BottomFrame, Title).Clear()
            .Select(MainImage).TopToTop().EdgesXTo().BottomToTop(BottomFrame).Width(SizeBehavier.MatchConstraint).Height(SizeBehavier.MatchConstraint)
                .Select(ExpandBar).BottomToBottom(null, 50).EdgesXTo().Width(SizeBehavier.MatchConstraint).Height(SizeBehavier.WrapContent).Alpha(0)
                .Select(BottomFrame).TopToBottom(null).EdgesXTo().Width(SizeBehavier.MatchConstraint)
                .Select(Title).TopToTop(null, 40).RightToLeft();
            LayoutToWithAnim(layout, outSet, "out", 16, 1200, Easing.SpringOut);
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

        public void LayoutToWithAnim(ConstraintLayout layout, ConstraintSet finishSet, string animName, uint rate = 16, uint length = 250, Easing easing = null, Action<double, bool> finished = null, Func<bool> repeat = null)
        {
            var animation = CreateAnimation(layout, finishSet, easing);
            if (finished == null)
                animation.Commit(layout, animName, rate, length, Easing.Linear, (v, b) => { finishSet.ApplyTo(layout); }, repeat);
            else
                animation.Commit(layout, animName, rate, length, Easing.Linear, finished, repeat);
        }

        public Animation CreateAnimation(ConstraintLayout layout, ConstraintSet finish, Easing easing)
        {
            Dictionary<int, ViewInfo> startLayoutTreeInfo = layout.CaptureLayoutTreeInfo();
            finish.ApplyToForAnim(layout);
            Dictionary<int, ViewInfo> finfishLayoutTreeInfo = layout.CaptureLayoutTreeInfo(isNeedMeasure: true);
            return GenerateAnimation(layout, startLayoutTreeInfo, finfishLayoutTreeInfo, easing);
        }

        public Animation CreateAnimation(ConstraintLayout layout, ConstraintSet start, ConstraintSet finish)
        {
            start.ApplyToForAnim(layout);
            Dictionary<int, ViewInfo> startLayoutTreeInfo = layout.CaptureLayoutTreeInfo(isNeedMeasure: true);
            finish.ApplyToForAnim(layout);
            Dictionary<int, ViewInfo> finfishLayoutTreeInfo = layout.CaptureLayoutTreeInfo(isNeedMeasure: true);
            return GenerateAnimation(layout, startLayoutTreeInfo, finfishLayoutTreeInfo);
        }

        private Animation GenerateAnimation(ConstraintLayout layout, Dictionary<int, ViewInfo> startLayoutTreeInfo, Dictionary<int, ViewInfo> finfishLayoutTreeInfo, Easing easing = null)
        {
            ConstraintLayout layout2 = layout;
            Animation animation = new Animation();
            foreach (KeyValuePair<int, ViewInfo> item in startLayoutTreeInfo)
            {
                View view = layout2.FindElementById(item.Key);
                ViewInfo startInfo = item.Value;
                ViewInfo finishInfo = finfishLayoutTreeInfo[item.Key];
                animation.Add(0.0, 1.0, new Animation(delegate (double v)
                {
                    Rect rect = new Rect(startInfo.X + (finishInfo.X - startInfo.X) * v, startInfo.Y + (finishInfo.Y - startInfo.Y) * v, startInfo.Width + (finishInfo.Width - startInfo.Width) * v, startInfo.Height + (finishInfo.Height - startInfo.Height) * v);
                    layout2.LayoutChild(view, (int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
                    view.TranslationX = (finishInfo.TranlateX - startInfo.TranlateX) * v;
                    view.TranslationY = (finishInfo.TranlateY - startInfo.TranlateY) * v;
                    view.RotationX = startInfo.RotationX + (finishInfo.RotationX - startInfo.RotationX) * v;
                    view.RotationY = startInfo.RotationY + (finishInfo.RotationY - startInfo.RotationY) * v;
                    view.ScaleX = startInfo.ScaleX + (finishInfo.ScaleX - startInfo.ScaleX) * v;
                    view.ScaleY = startInfo.ScaleY + (finishInfo.ScaleY - startInfo.ScaleY) * v;
                    view.Opacity = startInfo.Alpha + (finishInfo.Alpha - startInfo.Alpha) * v;
                }, 0, 1, easing));
            }

            return animation;
        }
    }
}