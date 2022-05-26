#if __ANDROID__
using Android.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                player.SetAudioAttributes(new AudioAttributes.Builder().SetFlags(AudioFlags.AudibilityEnforced)
                    .SetLegacyStreamType(Android.Media.Stream.Music).SetUsage(AudioUsageKind.Game).SetContentType(AudioContentType.Music).Build());
                player.Reset();
                player.SetDataSource(new MyMediaDataSource(stream));
                player.Prepare();
            }
        }

        public void Start()
        {
            player.Start();
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

    class MyMediaDataSource : MediaDataSource
    {
        Stream AudioStream;
        public MyMediaDataSource(Stream stream)
        {
            AudioStream = stream;
        }

        public override long Size => AudioStream != null ? AudioStream.Length : 0;

        public override void Close()
        {
            AudioStream?.Close();
        }

        public override int ReadAt(long position, byte[] buffer, int offset, int size)
        {
            if (position >= AudioStream.Length) return -1; // -1 indicates EOF 

            AudioStream.Position = position;
            return AudioStream.Read(buffer, offset, size);
        }
    }
}
#endif