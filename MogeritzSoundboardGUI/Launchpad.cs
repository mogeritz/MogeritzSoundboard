using Definitions;
using MogeritzDefinitions;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogeritzSoundboardGUI
{
    internal class Launchpad
    {
        int VoicemeeterDeviceNumber = -1;

        WaveStream key1Reader;
        WaveOut key1Player;
        WaveStream key2Reader;
        WaveOut key2Player;
        WaveStream key3Reader;
        WaveOut key3Player;
        WaveStream key4Reader;
        WaveOut key4Player;
        WaveStream key5Reader;
        WaveOut key5Player;
        WaveStream key6Reader;
        WaveOut key6Player;
        WaveStream key7Reader;
        WaveOut key7Player;
        WaveStream key8Reader;
        WaveOut key8Player;
        WaveStream key9Reader;
        WaveOut key9Player;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Launchpad()
        {
            int voicemeeterdev = -1;

            for (int n = -1; n < WaveOut.DeviceCount; n++)
            {
                var caps = WaveOut.GetCapabilities(n);
                if (caps.ProductName.Contains("VoiceMeeter")) VoicemeeterDeviceNumber = n;
            }

            DataContainer.Instance.PropertyChanged += UpdateSoundFiles;

            Program.KeyDown += new KeyEventHandler(hook_KeyPressed);
        }

        void hook_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.NumPad1) PlaySound1();
            if (e.KeyData == Keys.NumPad2) PlaySound2();
            if (e.KeyData == Keys.NumPad3) PlaySound3();
            if (e.KeyData == Keys.NumPad4) PlaySound4();
            if (e.KeyData == Keys.NumPad5) PlaySound5();
            if (e.KeyData == Keys.NumPad6) PlaySound6();
            if (e.KeyData == Keys.NumPad7) PlaySound7();
            if (e.KeyData == Keys.NumPad8) PlaySound8();
            if (e.KeyData == Keys.NumPad9) PlaySound9();
        }

        public void PlaySound1() { key1Player?.PlayOrRepeat(key1Reader); }
        public void PlaySound2() { key2Player?.PlayOrRepeat(key2Reader); }
        public void PlaySound3() { key3Player?.PlayOrRepeat(key3Reader); }
        public void PlaySound4() { key4Player?.PlayOrRepeat(key4Reader); }
        public void PlaySound5() { key5Player?.PlayOrRepeat(key5Reader); }
        public void PlaySound6() { key6Player?.PlayOrRepeat(key6Reader); }
        public void PlaySound7() { key7Player?.PlayOrRepeat(key7Reader); }
        public void PlaySound8() { key8Player?.PlayOrRepeat(key8Reader); }
        public void PlaySound9() { key9Player?.PlayOrRepeat(key9Reader); }

        private void UpdateSoundFiles(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(DataContainer.Instance.SoundFileKey1))
            {
                if (Path.GetExtension(DataContainer.Instance.SoundFileKey1) == ".mp3") key1Reader = new Mp3FileReader(DataContainer.Instance.SoundFileKey1);
                else key1Reader = new WaveFileReader(DataContainer.Instance.SoundFileKey1);
                key1Player = new WaveOut();
                key1Player.DeviceNumber = VoicemeeterDeviceNumber;
                key1Player.PlaybackStopped += new EventHandler<StoppedEventArgs>((o, e) => key1Reader.Seek(0, SeekOrigin.Begin));
                key1Player.Init(key1Reader);
            }
            else
            {
                key1Player = null;
            }
            if (!String.IsNullOrEmpty(DataContainer.Instance.SoundFileKey2))
            {
                if (Path.GetExtension(DataContainer.Instance.SoundFileKey2) == ".mp3") key2Reader = new Mp3FileReader(DataContainer.Instance.SoundFileKey2);
                else key2Reader = new WaveFileReader(DataContainer.Instance.SoundFileKey2);
                key2Player = new WaveOut();
                key2Player.DeviceNumber = VoicemeeterDeviceNumber;
                key2Player.PlaybackStopped += new EventHandler<StoppedEventArgs>((o, e) => key2Reader.Seek(0, SeekOrigin.Begin));
                key2Player.Init(key2Reader);
            }
            else
            {
                key2Player = null;
            }
            if (!String.IsNullOrEmpty(DataContainer.Instance.SoundFileKey3))
            {
                if (Path.GetExtension(DataContainer.Instance.SoundFileKey3) == ".mp3") key3Reader = new Mp3FileReader(DataContainer.Instance.SoundFileKey3);
                else key3Reader = new WaveFileReader(DataContainer.Instance.SoundFileKey3);
                key3Player = new WaveOut();
                key3Player.DeviceNumber = VoicemeeterDeviceNumber;
                key3Player.PlaybackStopped += new EventHandler<StoppedEventArgs>((o, e) => key3Reader.Seek(0, SeekOrigin.Begin));
                key3Player.Init(key3Reader);
            }
            else
            {
                key3Player = null;
            }
            if (!String.IsNullOrEmpty(DataContainer.Instance.SoundFileKey4))
            {
                if (Path.GetExtension(DataContainer.Instance.SoundFileKey4) == ".mp3") key4Reader = new Mp3FileReader(DataContainer.Instance.SoundFileKey4);
                else key4Reader = new WaveFileReader(DataContainer.Instance.SoundFileKey4);
                key4Player = new WaveOut();
                key4Player.DeviceNumber = VoicemeeterDeviceNumber;
                key4Player.PlaybackStopped += new EventHandler<StoppedEventArgs>((o, e) => key4Reader.Seek(0, SeekOrigin.Begin));
                key4Player.Init(key4Reader);
            }
            else
            {
                key4Player = null;
            }
            if (!String.IsNullOrEmpty(DataContainer.Instance.SoundFileKey5))
            {
                if (Path.GetExtension(DataContainer.Instance.SoundFileKey5) == ".mp3") key5Reader = new Mp3FileReader(DataContainer.Instance.SoundFileKey5);
                else key5Reader = new WaveFileReader(DataContainer.Instance.SoundFileKey5);
                key5Player = new WaveOut();
                key5Player.DeviceNumber = VoicemeeterDeviceNumber;
                key5Player.PlaybackStopped += new EventHandler<StoppedEventArgs>((o, e) => key5Reader.Seek(0, SeekOrigin.Begin));
                key5Player.Init(key5Reader);
            }
            else
            {
                key5Player = null;
            }
            if (!String.IsNullOrEmpty(DataContainer.Instance.SoundFileKey6))
            {
                if (Path.GetExtension(DataContainer.Instance.SoundFileKey6) == ".mp3") key6Reader = new Mp3FileReader(DataContainer.Instance.SoundFileKey6);
                else key6Reader = new WaveFileReader(DataContainer.Instance.SoundFileKey6);
                key6Player = new WaveOut();
                key6Player.DeviceNumber = VoicemeeterDeviceNumber;
                key6Player.PlaybackStopped += new EventHandler<StoppedEventArgs>((o, e) => key6Reader.Seek(0, SeekOrigin.Begin));
                key6Player.Init(key6Reader);
            }
            else
            {
                key6Player = null;
            }
            if (!String.IsNullOrEmpty(DataContainer.Instance.SoundFileKey7))
            {
                if (Path.GetExtension(DataContainer.Instance.SoundFileKey7) == ".mp3") key7Reader = new Mp3FileReader(DataContainer.Instance.SoundFileKey7);
                else key7Reader = new WaveFileReader(DataContainer.Instance.SoundFileKey7);
                key7Player = new WaveOut();
                key7Player.DeviceNumber = VoicemeeterDeviceNumber;
                key7Player.PlaybackStopped += new EventHandler<StoppedEventArgs>((o, e) => key7Reader.Seek(0, SeekOrigin.Begin));
                key7Player.Init(key7Reader);
            }
            else
            {
                key7Player = null;
            }
            if (!String.IsNullOrEmpty(DataContainer.Instance.SoundFileKey8))
            {
                if (Path.GetExtension(DataContainer.Instance.SoundFileKey8) == ".mp3") key8Reader = new Mp3FileReader(DataContainer.Instance.SoundFileKey8);
                else key8Reader = new WaveFileReader(DataContainer.Instance.SoundFileKey8);
                key8Player = new WaveOut();
                key8Player.DeviceNumber = VoicemeeterDeviceNumber;
                key8Player.PlaybackStopped += new EventHandler<StoppedEventArgs>((o, e) => key8Reader.Seek(0, SeekOrigin.Begin));
                key8Player.Init(key8Reader);
            }
            else
            {
                key8Player = null;
            }
            if (!String.IsNullOrEmpty(DataContainer.Instance.SoundFileKey9))
            {
                if (Path.GetExtension(DataContainer.Instance.SoundFileKey9) == ".mp3") key9Reader = new Mp3FileReader(DataContainer.Instance.SoundFileKey9);
                else key9Reader = new WaveFileReader(DataContainer.Instance.SoundFileKey9);
                key9Player = new WaveOut();
                key9Player.DeviceNumber = VoicemeeterDeviceNumber;
                key9Player.PlaybackStopped += new EventHandler<StoppedEventArgs>((o, e) => key9Reader.Seek(0, SeekOrigin.Begin));
                key9Player.Init(key9Reader);
            }
            else
            {
                key9Player = null;
            }
        }

        ~Launchpad()
        {

        }
    }
}
