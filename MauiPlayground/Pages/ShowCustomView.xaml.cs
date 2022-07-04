namespace MauiPlayground.Pages
{
    public partial class ShowCustomView : ContentPage
    {
        public ShowCustomView()
        {
            InitializeComponent();
            this.Content = new CustomView() { BackgroundColor = Colors.AliceBlue };
        }
    }
}