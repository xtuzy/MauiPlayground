namespace MauiPlayground.Views;

using SharpConstraintLayout.Maui.Widget;
using static SharpConstraintLayout.Maui.Widget.FluentConstraintSet;

public partial class ShowZIndexView : ContentView
{
    private FluentConstraintSet defaultSet;

    public ShowZIndexView()
    {
        InitializeComponent();
        defaultSet = new FluentConstraintSet();
        defaultSet.Clone(layout);
        defaultSet.Select(guideline).GuidelineOrientation(Orientation.X).GuidelinePercent(0.8f)
            .Select(box).CenterYTo().Visibility(Visibility.Invisible)
            .Select(box1, rect1, rect2).Width(200).Height(200).CenterXTo().BottomToTop(guideline)
            .Select(rect2).YBias(0.7f)
           ;
        defaultSet.ApplyTo(layout);

        SwipeGestureRecognizer leftSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
        leftSwipeGesture.Swiped += LeftSwipeGesture_Swiped;
        SwipeGestureRecognizer rightSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };
        rightSwipeGesture.Swiped += RightSwipeGesture_Swiped;

        layout.GestureRecognizers.Add(leftSwipeGesture);
        layout.GestureRecognizers.Add(rightSwipeGesture);
    }

    private void RightSwipeGesture_Swiped(object sender, SwipedEventArgs e)
    {
        View secondView = null;
        foreach (var view in layout.Children)
        {
            if (view.ZIndex == 3)
            {
                secondView = view as View;
            }
        }
        foreach (var view in layout.Children)
        {
            var child = view as View;
            if (child.ZIndex == 4)
            {
                child.RotateTo(-60);
                var set = new FluentConstraintSet();

                set.Clone(layout);
                set.Select(child).Clear().Width(200).Height(200).CenterYTo().RightToLeft(secondView).Rotation(-60)
                   ;
                layout.LayoutToWithAnim(set, "swipecard", 16, 1000, Easing.Linear, (v, b) =>
                {
                    child.ZIndex = 2;
                    set.ApplyTo(layout);
                    layout.LayoutToWithAnim(defaultSet, "default", 16, 1000, Easing.SpringOut,
                    (v, b) => { defaultSet.ApplyTo(layout); });
                });
            }
            else
                child.ZIndex = child.ZIndex + 1;
        }
    }

    private void LeftSwipeGesture_Swiped(object sender, SwipedEventArgs e)
    {
        RightSwipeGesture_Swiped(sender, e);
    }
}