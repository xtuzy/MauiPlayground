#if WINDOWS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage.Streams;
using Stream = System.IO.Stream;

namespace MauiLib.Services.PlayAudio
{
    public partial  class PlayAudioService
    {
        protected MediaPlayer player;
        public void SetPlayer(Stream stream)
        {
            if (player == null)
            {
                player = new MediaPlayer();
                IRandomAccessStream randomAccessStream = stream.AsRandomAccessStream();
                player.Source = MediaSource.CreateFromStream(randomAccessStream, null);
            }
        }

        public void Start()
        {
            player.Play();
        }

        public void Pause()
        {
            player.Pause();
        }

        public void Stop()
        {
            player.Pause();
        }
    }
}
#endif