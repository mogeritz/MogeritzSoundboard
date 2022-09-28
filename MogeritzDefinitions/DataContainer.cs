using System.ComponentModel;

namespace Definitions
{
    public class DataContainer : INotifyPropertyChanged
    {
        private static DataContainer instance = null;
        private static readonly object padlock = new object();

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler DevicesChanged;

        public string SoundFileKey1
        {
            get => _soundFilekey1; 
            set 
            { 
                _soundFilekey1 = value;
                OnPropertyChanged();
            }
        }
        private string _soundFilekey1 = string.Empty;

        public string SoundFileKey2
        {
            get => _soundFilekey2;
            set
            {
                _soundFilekey2 = value;
                OnPropertyChanged();
            }
        }
        private string _soundFilekey2 = string.Empty;

        public string SoundFileKey3
        {
            get => _soundFilekey3;
            set
            {
                _soundFilekey3 = value;
                OnPropertyChanged();
            }
        }
        private string _soundFilekey3 = string.Empty;

        public string SoundFileKey4
        {
            get => _soundFilekey4;
            set
            {
                _soundFilekey4 = value;
                OnPropertyChanged();
            }
        }
        private string _soundFilekey4 = string.Empty;

        public string SoundFileKey5
        {
            get => _soundFilekey5;
            set
            {
                _soundFilekey5 = value;
                OnPropertyChanged();
            }
        }
        private string _soundFilekey5 = string.Empty;

        public string SoundFileKey6
        {
            get => _soundFilekey6;
            set
            {
                _soundFilekey6 = value;
                OnPropertyChanged();
            }
        }
        private string _soundFilekey6 = string.Empty;

        public string SoundFileKey7
        {
            get => _soundFilekey7;
            set
            {
                _soundFilekey7 = value;
                OnPropertyChanged();
            }
        }
        private string _soundFilekey7 = string.Empty;

        public string SoundFileKey8
        {
            get => _soundFilekey8;
            set
            {
                _soundFilekey8 = value;
                OnPropertyChanged();
            }
        }
        private string _soundFilekey8 = string.Empty;

        public string SoundFileKey9
        {
            get => _soundFilekey9;
            set
            {
                _soundFilekey9 = value;
                OnPropertyChanged();
            }
        }
        private string _soundFilekey9 = string.Empty;

        public string InputDevice
        {
            get => _inputDevice;
            set
            {
                _inputDevice = value;
                OnDevicesChanged();
            }
        }
        private string _inputDevice = string.Empty;

        public string OutputDevice
        {
            get => _outputDevice;
            set
            {
                _outputDevice = value;
                OnDevicesChanged();
            }
        }
        private string _outputDevice = string.Empty;

        DataContainer()
        {
        }

        void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(null, null);
        }

        void OnDevicesChanged()
        {
            DevicesChanged?.Invoke(null, null);
        }

        public static DataContainer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DataContainer();
                    }
                    return instance;
                }
            }
        }
    }
}
