using MauiLib.CustomControls.LikeView;
using SharpConstraintLayout.Maui.Widget;

namespace MauiPlayground.Views.ShowAnimationView;

public partial class ShowAnimationView : ContentView
{
    private Button button1;
    private ConstraintLayout layoutContainer;

    public ShowAnimationView()
    {
        InitializeComponent();
        using (var set = new FluentConstraintSet())
        {
            set.Clone(RootLayout);
            set.Select(buttonlist).EdgesXTo().TopToTop().Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.WrapContent);
            set.ApplyTo(RootLayout);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        //button.ScaleTo(1.5, 1000, Easing.CubicIn);
        //var animation = new Animation(v => button1.Scale = v, 1, 2);
        //animation.Commit(this, "SimpleAnimation", 16, 2000, Easing.Linear, (v, c) => button1.Scale = 1, () => false);
        var animation2 = new Animation(v =>
        {
            using (var set = new FluentConstraintSet())
            {
                set.Clone(layoutContainer);
                set.Select(button1).CenterTo().XBias((float)v).Alpha((float)v).Rotation((float)v * 360).Scale((float)v * 2);
                set.ApplyTo(layoutContainer);
            }
        }, 0, 1);
        animation2.Commit(this, "SimpleAnimation", 16, 1000, Easing.CubicInOut, (v, c) =>
        {
            using (var startset = new FluentConstraintSet())
            {
                startset.Clone(layoutContainer);
                startset.Select(button1).Clear().LeftToLeft().CenterYTo();
                startset.ApplyTo(layoutContainer);
            }
        }, () => false);

    }

    private void BasisAnimation_Clicked(object sender, EventArgs e)
    {
        RootLayout.Remove(layoutContainer);
        layoutContainer = null;
        layoutContainer = new ConstraintLayout() { BackgroundColor = Colors.AliceBlue };
        RootLayout.Add(layoutContainer);
        using (var set = new FluentConstraintSet())
        {
            set.Clone(RootLayout);
            set//.Select(buttonlist).EdgesXTo().TopToTop().Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.WrapContent)
                .Select(layoutContainer).TopToBottom(buttonlist).EdgesXTo().BottomToBottom().Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.MatchConstraint);
            set.ApplyTo(RootLayout);
        }
        button1 = new Button() { Text = "Button1" };
        layoutContainer.Add(button1);
        button1.Clicked += Button_Clicked;

        using (var startset = new FluentConstraintSet())
        {
            startset.Clone(layoutContainer);
            startset.Select(button1).CenterTo();
            startset.ApplyTo(layoutContainer);
        }
    }

    private void ComplexAnimation_Clicked(object sender, EventArgs e)
    {
        RootLayout.Remove(layoutContainer);
        layoutContainer = null;
        layoutContainer = new ConstraintLayout() { BackgroundColor = Colors.AliceBlue };
        RootLayout.Add(layoutContainer);
        using (var set = new FluentConstraintSet())
        {
            set.Clone(RootLayout);
            set//.Select(buttonlist).EdgesXTo().TopToTop().Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.WrapContent)
                .Select(layoutContainer).TopToBottom(buttonlist).EdgesXTo().BottomToBottom().Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.MatchConstraint);
            set.ApplyTo(RootLayout);
        }

        var complex = new AnimationPage() { };
        layoutContainer.Add(complex);

        using (var startset = new FluentConstraintSet())
        {
            startset.Clone(layoutContainer);
            startset.Select(complex).EdgesTo().Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.MatchConstraint);
            startset.ApplyTo(layoutContainer);
        }
    }

    private void LikeView_Clicked(object sender, EventArgs e)
    {
        RootLayout.Remove(layoutContainer);
        layoutContainer = null;
        layoutContainer = new ConstraintLayout() { BackgroundColor = Colors.AliceBlue };
        RootLayout.Add(layoutContainer);
        using (var set = new FluentConstraintSet())
        {
            set.Clone(RootLayout);
            set//.Select(buttonlist).EdgesXTo().TopToTop().Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.WrapContent)
                .Select(layoutContainer).TopToBottom(buttonlist).EdgesXTo().BottomToBottom().Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.MatchConstraint);
            set.ApplyTo(RootLayout);
        }

        var likeView = new LikeViewBuilder()
            .setRadius(25)
            .setDefaultColor(Colors.Green.ToInt())
            .setCheckedColor(Colors.Red.ToInt())
            .setCycleTime(1600)
            .setUnSelectCycleTime(200)
            .setTGroupBRatio(0.37f)
            .setBGroupACRatio(0.54f)
            //.setDotColors(new int[] { Colors.Red.ToInt(), Colors.Green.ToInt(), Colors.Blue.ToInt() })
            .setLrGroupBRatio(1)
            .setInnerShapeScale(3)
            .setDotSizeScale(10)
            .setAllowRandomDotColor(false)
            .create();
        layoutContainer.Add(likeView);
        using (var startset = new FluentConstraintSet())
        {
            startset.Clone(layoutContainer);
            startset.Select(likeView).CenterTo().Width(50).Height(50);
            startset.ApplyTo(layoutContainer);
        }
    }

    private void ConstraintAnimation_Clicked(object sender, EventArgs e)
    {
        RootLayout.Remove(layoutContainer);
        layoutContainer = null;
        layoutContainer = new ConstraintLayout() { BackgroundColor = Colors.AliceBlue };
        RootLayout.Add(layoutContainer);
        using (var set = new FluentConstraintSet())
        {
            set.Clone(RootLayout);
            set//.Select(buttonlist).EdgesXTo().TopToTop().Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.WrapContent)
                .Select(layoutContainer).TopToBottom(buttonlist).EdgesXTo().BottomToBottom()
                .Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.MatchConstraint);
            set.ApplyTo(RootLayout);
        }
        var c = new ConstraintAnimationPage();
        layoutContainer.AddElement(c);

        using (var startset = new FluentConstraintSet())
        {
            startset.Clone(layoutContainer);
            startset.Select(c).EdgesTo().Width(FluentConstraintSet.SizeBehavier.MatchConstraint).Height(FluentConstraintSet.SizeBehavier.MatchConstraint);
            startset.ApplyTo(layoutContainer);
        }
    }

    protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
    {
        var l = buttonlist;
        var c = layoutContainer;
        var size = base.MeasureOverride(widthConstraint, heightConstraint);
        return size;
    }
}