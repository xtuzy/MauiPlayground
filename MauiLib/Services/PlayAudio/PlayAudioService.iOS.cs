#if __IOS__
using AVFoundation;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stream = System.IO.Stream;

namespace MauiLib.Services.PlayAudio
{
    public partial class PlayAudioService
    {
        protected AVAudioPlayer player;
        public void SetPlayer(Stream stream)
        {
            if (player == null)
            {
                player = AVAudioPlayer.FromData(NSData.FromStream(stream));
                player.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
                {
                    player = null;
                };
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
            player.Stop();
        }
    }
}
#endif