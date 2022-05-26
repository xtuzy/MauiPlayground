
using MauiLib.CustomControls.DrawableView;
using MauiLib.CustomControls.Platform;
using MauiPlayground.Views;

namespace MauiPlayground
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

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