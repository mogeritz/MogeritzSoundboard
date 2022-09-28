using System.ComponentModel;
using Definitions;
using MogeritzSoundboardGUI.Properties;
using NAudio.Wave;

namespace MogeritzSoundboardGUI
{
    internal static partial class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            _hookID = SetHook(_proc);
            Application.Run(new AppContext());
            UnhookWindowsHookEx(_hookID);
        }
    }

    public class AppContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public AppContext()
        {
            // Initialize Tray Icon
            var components = new System.ComponentModel.Container();
            trayIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = SBResources.AppIcon,
                Text = "Mogeritz' Soundboard",
                Visible = true
            };

            trayIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            trayIcon.DoubleClick += ShowSoundBoard;

            new VMInterface();

            new Launchpad();

            Init();
        }

        private void Init()
        {
            DataContainer.Instance.SoundFileKey1 = Settings.Default.PathKey1;
            DataContainer.Instance.SoundFileKey2 = Settings.Default.PathKey2;
            DataContainer.Instance.SoundFileKey3 = Settings.Default.PathKey3;
            DataContainer.Instance.SoundFileKey4 = Settings.Default.PathKey4;
            DataContainer.Instance.SoundFileKey5 = Settings.Default.PathKey5;
            DataContainer.Instance.SoundFileKey6 = Settings.Default.PathKey6;
            DataContainer.Instance.SoundFileKey7 = Settings.Default.PathKey7;
            DataContainer.Instance.SoundFileKey8 = Settings.Default.PathKey8;
            DataContainer.Instance.SoundFileKey9 = Settings.Default.PathKey9;

            DataContainer.Instance.InputDevice = Settings.Default.InputDevice;
            DataContainer.Instance.OutputDevice = Settings.Default.OutputDevice;
        }

        private void ContextMenuStrip_Opening(object sender, EventArgs e)
        {
            trayIcon.ContextMenuStrip.Items.Clear();
            trayIcon.ContextMenuStrip.Items.Add("Open Soundboard", null, ShowSoundBoard);
            trayIcon.ContextMenuStrip.Items.Add("Exit", null, Exit);
        }

        private void ShowSoundBoard(object sender, EventArgs e)
        {
            var sbc = new SoundBoardConfig();

            sbc.ssb1.Path = DataContainer.Instance.SoundFileKey1;
            sbc.ssb2.Path = DataContainer.Instance.SoundFileKey2;
            sbc.ssb3.Path = DataContainer.Instance.SoundFileKey3;
            sbc.ssb4.Path = DataContainer.Instance.SoundFileKey4;
            sbc.ssb5.Path = DataContainer.Instance.SoundFileKey5;
            sbc.ssb6.Path = DataContainer.Instance.SoundFileKey6;
            sbc.ssb7.Path = DataContainer.Instance.SoundFileKey7;
            sbc.ssb8.Path = DataContainer.Instance.SoundFileKey8;
            sbc.ssb9.Path = DataContainer.Instance.SoundFileKey9;

            sbc.ssb1.PathIsSet += new EventHandler((o, e) => ssb1PathSet((string)o, sbc.ssb1));
            sbc.ssb2.PathIsSet += new EventHandler((o, e) => ssb2PathSet((string)o, sbc.ssb2));
            sbc.ssb3.PathIsSet += new EventHandler((o, e) => ssb3PathSet((string)o, sbc.ssb3));
            sbc.ssb4.PathIsSet += new EventHandler((o, e) => ssb4PathSet((string)o, sbc.ssb4));
            sbc.ssb5.PathIsSet += new EventHandler((o, e) => ssb5PathSet((string)o, sbc.ssb5));
            sbc.ssb6.PathIsSet += new EventHandler((o, e) => ssb6PathSet((string)o, sbc.ssb6));
            sbc.ssb7.PathIsSet += new EventHandler((o, e) => ssb7PathSet((string)o, sbc.ssb7));
            sbc.ssb8.PathIsSet += new EventHandler((o, e) => ssb8PathSet((string)o, sbc.ssb8));
            sbc.ssb9.PathIsSet += new EventHandler((o, e) => ssb9PathSet((string)o, sbc.ssb9));

            sbc.ssb1.VolumeChanged += new EventHandler((o, e) =>
            {
                int volchange = (int)o;
                if (volchange > 0 && sbc.ssb1.Volume < 91) sbc.ssb1.Volume++;
                if (volchange < 0 && sbc.ssb1.Volume > 0) sbc.ssb1.Volume--;
            });

            sbc.Closing += new CancelEventHandler((o, e) => SaveSettings());

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                sbc.OutputDeviceComboBox.Items.Add(WaveOut.GetCapabilities(i).ProductName);
            }
            sbc.OutputDeviceComboBox.SelectedIndexChanged += new EventHandler((o, e) => DataContainer.Instance.OutputDevice = sbc.OutputDeviceComboBox.Items[sbc.OutputDeviceComboBox.SelectedIndex].ToString());
            if (!String.IsNullOrEmpty(DataContainer.Instance.OutputDevice)) sbc.OutputDeviceComboBox.SelectedItem = DataContainer.Instance.OutputDevice;

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                sbc.InputDeviceComboBox.Items.Add(WaveIn.GetCapabilities(i).ProductName);
            }
            sbc.InputDeviceComboBox.SelectedIndexChanged += new EventHandler((o, e) => DataContainer.Instance.InputDevice = sbc.InputDeviceComboBox.Items[sbc.InputDeviceComboBox.SelectedIndex].ToString());
            if (!String.IsNullOrEmpty(DataContainer.Instance.InputDevice)) sbc.InputDeviceComboBox.SelectedItem = DataContainer.Instance.InputDevice;

            sbc.Show();
        }

        private void SaveSettings()
        {
            Settings.Default.PathKey1 = DataContainer.Instance.SoundFileKey1;
            Settings.Default.PathKey2 = DataContainer.Instance.SoundFileKey2;
            Settings.Default.PathKey3 = DataContainer.Instance.SoundFileKey3;
            Settings.Default.PathKey4 = DataContainer.Instance.SoundFileKey4;
            Settings.Default.PathKey5 = DataContainer.Instance.SoundFileKey5;
            Settings.Default.PathKey6 = DataContainer.Instance.SoundFileKey6;
            Settings.Default.PathKey7 = DataContainer.Instance.SoundFileKey7;
            Settings.Default.PathKey8 = DataContainer.Instance.SoundFileKey8;
            Settings.Default.PathKey9 = DataContainer.Instance.SoundFileKey9;

            Settings.Default.InputDevice = DataContainer.Instance.InputDevice;
            Settings.Default.OutputDevice = DataContainer.Instance.OutputDevice;

            Settings.Default.Save();
        }

        private void ssb1PathSet(string path, SoundSetterButton button)
        {
            var valid = File.Exists(path);
            DataContainer.Instance.SoundFileKey1 = valid ? path : String.Empty;
            button.Path = DataContainer.Instance.SoundFileKey1;
        }

        private void ssb2PathSet(string path, SoundSetterButton button)
        {
            var valid = File.Exists(path);
            DataContainer.Instance.SoundFileKey2 = valid ? path : String.Empty;
            button.Path = DataContainer.Instance.SoundFileKey2;
        }

        private void ssb3PathSet(string path, SoundSetterButton button)
        {
            var valid = File.Exists(path);
            DataContainer.Instance.SoundFileKey3 = valid ? path : String.Empty;
            button.Path = DataContainer.Instance.SoundFileKey3;
        }

        private void ssb4PathSet(string path, SoundSetterButton button)
        {
            var valid = File.Exists(path);
            DataContainer.Instance.SoundFileKey4 = valid ? path : String.Empty;
            button.Path = DataContainer.Instance.SoundFileKey4;
        }

        private void ssb5PathSet(string path, SoundSetterButton button)
        {
            var valid = File.Exists(path);
            DataContainer.Instance.SoundFileKey5 = valid ? path : String.Empty;
            button.Path = DataContainer.Instance.SoundFileKey5;
        }

        private void ssb6PathSet(string path, SoundSetterButton button)
        {
            var valid = File.Exists(path);
            DataContainer.Instance.SoundFileKey6 = valid ? path : String.Empty;
            button.Path = DataContainer.Instance.SoundFileKey6;
        }

        private void ssb7PathSet(string path, SoundSetterButton button)
        {
            var valid = File.Exists(path);
            DataContainer.Instance.SoundFileKey7 = valid ? path : String.Empty;
            button.Path = DataContainer.Instance.SoundFileKey7;
        }

        private void ssb8PathSet(string path, SoundSetterButton button)
        {
            var valid = File.Exists(path);
            DataContainer.Instance.SoundFileKey8 = valid ? path : String.Empty;
            button.Path = DataContainer.Instance.SoundFileKey8;
        }

        private void ssb9PathSet(string path, SoundSetterButton button)
        {
            var valid = File.Exists(path);
            DataContainer.Instance.SoundFileKey9 = valid ? path : String.Empty;
            button.Path = DataContainer.Instance.SoundFileKey9;
        }

        private void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }
    }
}