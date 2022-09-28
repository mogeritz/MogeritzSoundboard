using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogeritzDefinitions
{
    public static class Extensions
    {
        public static void PlayOrRepeat(this IWavePlayer player, WaveStream provider)
        {
            if (player.PlaybackState == PlaybackState.Playing)
            {
                provider.Seek(0, SeekOrigin.Begin);
            }
            else
            {
                player?.Play();
            }
        }
    }
}
