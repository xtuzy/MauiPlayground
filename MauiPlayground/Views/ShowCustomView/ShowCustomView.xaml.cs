namespace MauiPlayground.Views.ShowCustomView;

public partial class ShowCustomView : ContentView
{
    public ShowCustomView()
    {
        InitializeComponent();
        this.Content = new CustomView() { BackgroundColor = Colors.AliceBlue };
    }
}