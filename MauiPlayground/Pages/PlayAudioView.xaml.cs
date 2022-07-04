using MauiLib.Services.PlayAudio;
using System.Diagnostics;

namespace MauiPlayground.Pages;

public partial class PlayAudioView : ContentPage
{
    public PlayAudioView()
    {
        InitializeComponent();
        InitPlayAudioServiceAsync();
    }

    private async void InitPlayAudioServiceAsync()
    {
        if (playAudioService == null)
        {
            try
            {
                var stream = await FileSystem.OpenAppPackageFileAsync("01 - Lovely Days.mp3");

                playAudioService = new PlayAudioService();
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                playAudioService.SetPlayer(memoryStream);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }

    private async void PlayAudio_Clicked(object sender, EventArgs e)
    {
        playAudioService.Start();
    }
    private async void PauseAudio_Clicked(object sender, EventArgs e)
    {
        playAudioService.Pause();
    }
    private async void StopAudio_Clicked(object sender, EventArgs e)
    {
        playAudioService.Stop();
    }

    PlayAudioService playAudioService;
}