using SharpConstraintLayout.Maui.Widget;
using static SharpConstraintLayout.Maui.Widget.FluentConstraintSet;
using Visibility = SharpConstraintLayout.Maui.Widget.FluentConstraintSet.Visibility;

namespace MauiPlayground.Pages
{
public partial class ShowZIndexView : ContentPage
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
        layout.AbortAnimation("cardOut");
        //layout.AbortAnimation("cardIn");
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
                set.Clone(defaultSet);
                set.Select(child).Clear().Width(200).Height(200).CenterYTo().RightToLeft(secondView).Rotation(-60)
                   ;
                layout.LayoutTo(set, "cardOut", 16, 500, Easing.SpringIn, (v, b) =>
                {
                    //????Z????
                    foreach (var view1 in layout.Children)
                        if(view1.ZIndex>1)
                            (view1 as View).ZIndex = view1.ZIndex + 1;
                    child.ZIndex = 2;

                    set.ApplyToForAnim(layout);
                    
                    layout.LayoutTo(defaultSet, "cardIn", 16, 1000, Easing.SpringOut,
                    (v, b) => { 
                        defaultSet.ApplyTo(layout); });
                });
            }
        }
    }

    private void LeftSwipeGesture_Swiped(object sender, SwipedEventArgs e)
    {
        RightSwipeGesture_Swiped(sender, e);
    }
}
}