using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MogeritzSoundboardGUI
{
    public partial class SoundSetterButton : Button
    {
        public EventHandler PathIsSet;
        public EventHandler VolumeChanged;

        public string Path
        {
            get => _path;
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.BackColor =  Color.LightGreen;
                    volumeBar.Visible = true;
                }
                else
                {
                    this.BackColor = Color.LightGray;
                    volumeBar.Visible = false;
                }
                _path = value;
            }
        }
        private string _path = "";

        public int Volume 
        { 
            get => _volume;
            set
            {
                _volume = value;
                this.volumeBar.Height = _volume;
                this.Invalidate();
            }
        }
        private int _volume = 92;

        System.Windows.Forms.ToolTip ToolTip1;

        public SoundSetterButton()
        {
            InitializeComponent();
            ToolTip1 = new System.Windows.Forms.ToolTip();
            this.SetStyle(ControlStyles.Selectable, false);
            this.MouseHover += new EventHandler((o,e) => ShowToolTip());
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                openFileDialog.Filter = "Audio Files (*.wav, *.mp3)|*.wav;*.mp3|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    OnPathIsSet(filePath);
                }
            }
        }

        private void OnRightClick(object sender, EventArgs e)
        {
            var me = (MouseEventArgs) e;
            if(me.Button == MouseButtons.Right)
            {
                OnPathIsSet(string.Empty);
            }
        }

        private void OnMouseScroll(object sender, MouseEventArgs e)
        {
            OnVolumeChanged(e.Delta);
        }

        void ShowToolTip()
        {
            if (!String.IsNullOrEmpty(Path))
            {
                ToolTip1.SetToolTip(this, Path);
            }
            else
            {
                ToolTip1.SetToolTip(this, "");
            }
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }

        private void OnPathIsSet(string path)
        {
            PathIsSet?.Invoke(path, new EventArgs());
        }

        private void OnVolumeChanged(int vol)
        {
            VolumeChanged?.Invoke(vol, new EventArgs());
        }
    }
}
