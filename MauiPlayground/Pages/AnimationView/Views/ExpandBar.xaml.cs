using SharpConstraintLayout.Maui.Widget;
using System;
using System.Collections.Generic;

namespace MauiPlayground.Pages.AnimationView.Views
{
    public partial class ExpandBar : ContentView
    {
        public ExpandBar()
        {
            InitializeComponent();
            layout.ConstrainHeight = ConstraintSet.WrapContent;
            using (var set = new FluentConstraintSet())
            {
                set.Clone(layout);
                set//.Select(image).TopToTop().BottomToTop(ExpandLabel).Height(FluentConstraintSet.SizeBehavier.WrapContent).Width(FluentConstraintSet.SizeBehavier.MatchParent)
                    .Select(ExpandLabel).CenterXTo().BottomToBottom().TopToTop()
                    //.Select(box).EdgesTo(ExpandLabel).Height(FluentConstraintSet.SizeBehavier.MatchConstraint).Width(FluentConstraintSet.SizeBehavier.MatchConstraint)
                    ;
                set.ApplyTo(layout);
            }
        }

        public bool IsLabelVisible
        {
            get { return ExpandLabel.IsVisible; }
            set { ExpandLabel.IsVisible = value; }

        }

        protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            //var i = image;
            var label = ExpandLabel;
            var size =  base.MeasureOverride(widthConstraint, heightConstraint);
            return size;
        }
    }
}
